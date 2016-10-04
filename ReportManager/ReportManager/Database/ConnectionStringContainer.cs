using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ReportManager.Database
{
    public class ConnectionStringContainer
    {
        private static string _settingsPath =
            $@"{Environment.GetEnvironmentVariable("AllUsersProfile")}\ReportManagerSettings\Settings.xml";

        private static ConnectionStringContainer _instance;
        public static ConnectionStringContainer GetInstance()
        {
            return _instance ?? (_instance = new ConnectionStringContainer());
        }
        public static void SetInstance(ConnectionStringContainer instance)
        {
            _instance = instance;
        }

        public string NifudaConnectionString { get; set;}
        public string IsupConnectionString { get; set; }

        public static void SaveSettings()
        {
            // TODO создать папку ReportManagerSettings
            var xs = new XmlSerializer(typeof(ConnectionStringContainer));
            using (Stream writer = new FileStream(_settingsPath, FileMode.Create))
            {
                xs.Serialize(writer, GetInstance());
                writer.Close();
            }
        }

        public static void LoadGlobalSettings()
        {
            try
            {
                var xs = new XmlSerializer(typeof(ConnectionStringContainer));
                using (Stream reader = new FileStream(_settingsPath, FileMode.Open))
                {
                    SetInstance((ConnectionStringContainer)xs.Deserialize(reader));
                    reader.Close();
                }
            }
            catch
            {
                SetInstance(new ConnectionStringContainer());
                throw;
            }
        }

        public static void LoadDefaultSettings()
        {
            SetInstance(new ConnectionStringContainer
            {
                IsupConnectionString = "Data Source=10.26.0.35;Initial Catalog=yru_v2;Persist Security Info=True;User ID=yru_operator;Password=yru_operator",
                NifudaConnectionString = "Data Source=HIS0555\\;Initial Catalog=YruPCIassembling;User ID=YruPCItestUser; Password=YruPCItestUser"
            });
        }
    }
}
