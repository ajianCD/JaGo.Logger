﻿using System;
using System.Collections.Generic;
using System.Text;

namespace chdu.jago.logger.Implements
{
    /// <summary>
    ///  Function:以log4net组件的方式写日志
    ///  Remark:日志记录方法可以使用第三方组件,如log4net
    ///  log4net.config 文件路径：/Config/log4net.config"
    ///  </summary>
    public class Log4Logger : LoggerBase
    {
        /// <summary>
        /// log4net配置文件路径
        /// </summary>
        static string _logConfig = string.Empty;
        /// <summary>
        /// log4net日志执行者
        /// </summary>
        static log4net.Core.LogImpl logImpl;
        /// <summary>
        /// 私有架造方法
        /// </summary>
        static Log4Logger()
        {
            try
            {
                _logConfig = System.Web.HttpContext.Current.Server.MapPath("/Config/log4net.config");
            }
            catch (NullReferenceException)
            {
                try
                {
                    _logConfig = System.Web.HttpRuntime.AppDomainAppPath + "\\Config\\log4net.config"; //例如：c:\\project\\
                }
                catch (ArgumentNullException)
                {

                    _logConfig = Environment.CurrentDirectory + "\\Config\\log4net.config"; //例如：c:\\project\\bin\\debug
                }

            }
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(_logConfig));//初始化指定配置文件
            //log4net.Config.XmlConfigurator.Configure();//初始化web.config里的log4net节点

            logImpl = log4net.LogManager.GetLogger("Core.Logger") as log4net.Core.LogImpl;//Core.Logger为log4net方案名称,为空表示使用root节点
        }

        protected override void InputLogger(string message)
        {
            logImpl.Info(message);
        }
        #region log4net重新写日志方法

        public override void Logger_Error(Exception ex)
        {
            logImpl.Error(ex);
        }

        public override void Logger_Debug(string message)
        {
            logImpl.Debug(message);
        }

        public override void Logger_Fatal(string message)
        {
            logImpl.Fatal(message);
        }

        public override void Logger_Info(string message)
        {
            logImpl.Info(message);
        }

        public override void Logger_Warn(string message)
        {
            logImpl.Warn(message);
        }
        #endregion

    }
}
