using System;
using System.IO;
using System.Xml.Serialization;

namespace Logic
{
    public class AppSettings
    {
        private static readonly string sr_FileLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FacebookApiApp";
        private static readonly string sr_File = sr_FileLocation + "\\AppSettings.txt";

        public bool RememberUser
        {
            get;
            set;
        }

        public string LastAccessToken
        {
            get;
            set;
        }

        public AppSettings()
        {
            RememberUser = false;
            LastAccessToken = null;
            CheckFolder();
        }

        public static AppSettings LoadFromFile()
        {
            AppSettings userSetting = new AppSettings();

            if (File.Exists(sr_File))
            {
                using (Stream stream = new FileStream(sr_File, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                    userSetting = serializer.Deserialize(stream) as AppSettings;
                }
            }

            return userSetting;
        }

        public void CheckFolder()
        {
            if (!Directory.Exists(sr_FileLocation))
            {
                Directory.CreateDirectory(sr_FileLocation);
            }
        }

        public void SaveToFile()
        {
            if (!File.Exists(sr_File))
            {
                Stream stream = new FileStream(sr_File, FileMode.Create);
                stream.Dispose();
            }

            using (Stream stream = new FileStream(sr_File, FileMode.Truncate))
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stream, this);
            }
        }
    }
}
