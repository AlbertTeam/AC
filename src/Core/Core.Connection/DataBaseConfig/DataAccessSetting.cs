using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Connection.DataBaseConfig
{
    internal static class DataAccessSetting
    {
        //private static string s_DatabaseConfigFile;
        //private static string s_DataCommandFileListConfigFile;

        static DataAccessSetting()
        {
            //s_DatabaseConfigFile = ConfigurationHelper.GetConfigurationFile("DatabaseListFile");
            //s_DatabaseConfigFile = ConfigurationHelper.GetDataBaseConfigFile();
            //s_DataCommandFileListConfigFile = ConfigurationHelper.GetConfigurationFile("DataCommandFile");
        }

        /// <summary>
        /// get the configuration file for database settings
        /// </summary>
        public static string DatabaseConfigFile
        {
            get { return ConfigurationHelper.GetDataBaseConfigFile(); }
        }


    }
}
