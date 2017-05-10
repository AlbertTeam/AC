using CommonTool;
using CommonTool.XML;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Connection.DataBaseConfig
{
    internal class DatabaseManager
    {
        private static Dictionary<string, DatabaseInstance> s_DatabaseHashtable;
        private static FileSystemWatcher s_Watcher;
        private static FileSystemChangeEventHandler s_FileChangeHandler;

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        static DatabaseManager()
        {
            s_DatabaseHashtable = new Dictionary<string, DatabaseInstance>();
            s_FileChangeHandler = new FileSystemChangeEventHandler(500);
            s_FileChangeHandler.ActualHandler += new FileSystemEventHandler(OnFileChanged);

            // set up file system watcher
            string databaseFolder = Path.GetDirectoryName(DataAccessSetting.DatabaseConfigFile);
            string databaseFile = Path.GetFileName(DataAccessSetting.DatabaseConfigFile);
            s_Watcher = new FileSystemWatcher(databaseFolder);
            s_Watcher.Filter = databaseFile;
            s_Watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime;
            s_Watcher.Changed += new FileSystemEventHandler(s_FileChangeHandler.ChangeEventHandler);
            s_Watcher.EnableRaisingEvents = true;

            // load database
            s_DatabaseHashtable = LoadDatabaseList();
        }

        private static void OnFileChanged(Object sender, FileSystemEventArgs e)
        {
            //DataAccessLogger.LogDatabaseFileChanged(e);
            s_DatabaseHashtable = LoadDatabaseList();
        }

        private static Dictionary<string, DatabaseInstance> LoadDatabaseList()
        {
            string EncrytIV = "Weiche88";
            DatabaseList list = ObjectXmlSerializer.LoadFromXml<DatabaseList>(DataAccessSetting.DatabaseConfigFile);
            if (list == null || list.DatabaseInstances == null || list.DatabaseInstances.Length == 0)
            {
                throw new DatabaseNotSpecifiedException();
            }
            Dictionary<string, DatabaseInstance> hashtable = new Dictionary<string, DatabaseInstance>(list.DatabaseInstances.Length);
            foreach (DatabaseInstance instance in list.DatabaseInstances)
            {

                DatabaseInstance conn = null;
                if (ConfigurationHelper.IsNeedEncryt)
                {
                    if (ConfigurationManager.AppSettings["EncryptKey"] == String.Empty)
                    {
                        throw new ConnStringEncrytSettingException();
                    }
                    try
                    {
                        instance.ConnectionString = SecurityHelper.Dencrypt(instance.ConnectionString, ConfigurationManager.AppSettings["EncryptKey"], EncrytIV);
                        conn = instance;

                    }
                    catch
                    {
                        throw new ConnStringDeEncrytException(instance.Name);
                    }
                }
                else
                {
                    conn = instance;
                }
                hashtable.Add(instance.Name.ToUpper(), conn);
            }
            return hashtable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">name of the database, case insensitive</param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException">The name is not found in the database list.</exception>
        public static DatabaseInstance GetDatabase(string name)
        {
            return s_DatabaseHashtable[name.ToUpper()];
        }
    }
}
