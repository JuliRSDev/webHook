using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace WbHooksCroydon.Log4Net
{
    public class Logs
    {
        private static Logs instance = null;

        public static Logs Intance
        {
            get
            {
                if (instance == null)
                    return instance = new Logs();
                return instance;
            }
        }

        public ILog log;

        public Logs()
        {
            log = GetLogger();
        }

        public static ILog GetLogger([CallerFilePath] string filename = "")
        {
            string root = HttpContext.Current.Server.MapPath("~/") + "log_proccess";
            bool exists = System.IO.Directory.Exists(root);
            if (!exists)
                System.IO.Directory.CreateDirectory(root);
            root = root + "\\file_log_" + DateTime.Now.ToString("yyyy_MM_dd");
            GlobalContext.Properties["LogFileLocation"] = root; //log file path
            XmlConfigurator.Configure();
            return LogManager.GetLogger(filename);
        }
    }
}