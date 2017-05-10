using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Connection.DataBaseConfig
{
    [XmlRoot("databaseList", Namespace = "http://www.chemical.ai/DatabaseList")]
    public class DatabaseList
    {
        private DatabaseInstance[] m_DatabaseInstances;

        [XmlElement("database")]
        public DatabaseInstance[] DatabaseInstances
        {
            get { return m_DatabaseInstances; }
            set { m_DatabaseInstances = value; }
        }
    }

    [XmlRoot("database")]
    public class DatabaseInstance
    {
        private string m_Name;
        private string m_ConnectionString;
        private string m_providerName;

        [XmlAttribute("name")]
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        [XmlElement("connectionString")]
        public string ConnectionString
        {
            get { return m_ConnectionString; }
            set { m_ConnectionString = value; }
        }
        [XmlElement("providerName")]
        public string ProviderName
        {
            get { return m_providerName; }
            set { m_providerName = value; }
        }
    }
}
