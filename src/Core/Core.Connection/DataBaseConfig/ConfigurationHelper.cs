using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Connection.DataBaseConfig
{
    public class ConfigurationHelper
    {
        public static bool IsNeedEncryt
        {
            get
            {
                bool _IsNeedEncryt = false;
                if (ConfigurationManager.AppSettings["IsNeedEncryt"] != null)
                {
                    if (!bool.TryParse(ConfigurationManager.AppSettings["IsNeedEncryt"].ToLower(), out _IsNeedEncryt))
                    {
                        throw new ConnStringEncrytSettingException();
                    }
                }

                return _IsNeedEncryt;
            }
        }

        public static string GetConfigurationFile(string appSection)
        {
            string configFile = appSection;
            if (ConfigurationManager.AppSettings[appSection] == null)
            {
                throw new DatabaseFilePathSettingException("AppSetting “" + appSection + "” Key not Set");
            }

            configFile = System.Configuration.ConfigurationManager.AppSettings[appSection];
            configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configFile.Replace('/', '\\').TrimStart('\\'));

            if (!File.Exists(configFile))
            {
                throw new DatabaseFilePathSettingException("配置文件 “" + configFile + "”文件不存在！");
            }

            return configFile;
        }

        public static string GetDataBaseConfigFile()
        {
            if (ConfigurationManager.AppSettings["DatabaseListFile"] == null)
            {
                DatabaseFilePathSettingException ex = new DatabaseFilePathSettingException("AppSetting “DatabaseListFile” Key not Set");
                throw ex;
            }

            string configFile = System.Configuration.ConfigurationManager.AppSettings["DatabaseListFile"];
            configFile = configFile.Replace('/', '\\').TrimStart('\\');
            if (!File.Exists(configFile))
            {
                throw new DatabaseFilePathSettingException("配置文件 “" + configFile + "”文件不存在！");
            }

            return configFile;
        }
    }
}
