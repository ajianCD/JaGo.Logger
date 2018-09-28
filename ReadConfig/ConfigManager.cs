using chdu.jago.logger.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace chdu.jago.logger.ReadConfig
{
    /// <summary>
    /// 读取ConfigConstants配置文件
    /// logger.xml的配置文件路径：Config/JaGo/ConfigConstants_Logger
    /// </summary>
    public class ConfigManager
    {

        private static ConfigModel _config;
        private static string _fileUrl = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config/JaGo");
        private static string _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config/JaGo/ConfigConstants_Logger.xml");
        private static object _lockObj = new object();
        private static ConfigModel _init;

        static ConfigManager()
        {
            if (!System.IO.Directory.Exists(_fileUrl))
                System.IO.Directory.CreateDirectory(_fileUrl);
            _init = new ConfigModel();
        }

        /// <summary>
        /// 配置字典,单例模式
        /// </summary>
        /// <returns></returns>
        public static ConfigModel Config
        {
            get
            {
                if (_config == null)
                {
                    lock (_lockObj)
                    {
                        XmlElement xml = null;
                        var old = SerializationHelper.DeserializeFromXml<ConfigModel>(_fileName);

                        if (old != null)
                        {
                            var configXml = new XmlDocument();
                            configXml.Load(_fileName);
                            xml = configXml.DocumentElement;
                        }
                        if (old == null || xml.ChildNodes.Count != typeof(ConfigModel).GetProperties().Count())
                        {
                            SerializationHelper.SerializeToXml(_fileName, _init);
                            _config = _init;
                        }
                        else
                        {
                            _config = old;
                        }
                    }
                }
                return _config;
            }
        }
    }
}
