using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chdu.jago.logger.ReadConfig
{
    public class ConfigModel
    {
        /// <summary>
        /// 初始化日志XML配置
        /// </summary>
        public ConfigModel()
        {
            this.Type = "File";
            this.Level = "ERROR";
            this.ProjectName = "JaGo";
        }
        #region 日志Logger(File,Log4net)
        /// <summary>
        /// 日志实现方式：File,Log4net
        /// </summary>
        [DisplayName("日志实现方式：File,Log4net")]
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Type { get; set; }
        /// <summary>
        /// 日志级别：DEBUG|INFO|WARN|ERROR|FATAL|OFF
        /// </summary>
        [DisplayName("日志级别：DEBUG|INFO|WARN|ERROR|FATAL|OFF")]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string Level { get; set; }
        /// <summary>
        /// 日志记录的项目名称
        /// </summary>
        [DisplayName("日志记录的项目名称")]
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ProjectName { get; set; }
        #endregion
    }
}
