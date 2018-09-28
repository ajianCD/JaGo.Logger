using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace chdu.jago.logger.Helpers
{
    /// <summary>
    /// 序列化与反序列化到文件
    /// </summary>
    public class SerializationHelper
    {
        private static object lockObj = new object();
        #region XML
        /// <summary>
        /// 泛型版本：XML将对象序列化到磁盘文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="obj"></param>
        public static void SerializeToXml<T>(string fileName, T obj) where T : class
        {
            try
            {
                lock (lockObj)
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Create))
                    {
                        new XmlSerializer(typeof(T)).Serialize(fs, obj);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 泛型版本：XML反序列化从磁盘到内存对象
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T DeserializeFromXml<T>(string fileName) where T : class
        {
            try
            {
                if (!File.Exists(fileName))
                    return null;
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    return new XmlSerializer(typeof(T)).Deserialize(fs) as T;
                }
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
