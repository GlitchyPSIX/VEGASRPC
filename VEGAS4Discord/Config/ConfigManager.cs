using System;
using System.IO;
using System.Xml.Serialization;

namespace VegasDiscordRPC {
    public class ConfigManager {
        public Config CurrentConfig { get; private set; } = new();

        public void SaveConfig() {
            string configFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Vegas4Discord");
            if (!Directory.Exists(configFolder)) {
                Directory.CreateDirectory(configFolder);
            }

            FileStream _fileSw;

            if (!File.Exists(Path.Combine(configFolder, "config.xml"))) {
                _fileSw = File.Create(Path.Combine(configFolder, "config.xml"));
            }
            else {
                File.Delete(Path.Combine(configFolder, "config.xml"));
                _fileSw = File.Create(Path.Combine(configFolder, "config.xml"));
            }

            XmlSerializer serializer = new(typeof(Config));
            serializer.Serialize(_fileSw, CurrentConfig);
            _fileSw.Close();
        }

        public void LoadConfig()
        {
            string configFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Vegas4Discord");
            if (!Directory.Exists(configFolder))
            {
                Directory.CreateDirectory(configFolder);
            }

            FileStream _fileSw;

            if (!File.Exists(Path.Combine(configFolder, "config.xml"))) {
                CurrentConfig = new();
                SaveConfig();
                return;
            }
            
            FileStream _fileSr = File.OpenRead(Path.Combine(configFolder, "config.xml"));

            XmlSerializer serializer = new(typeof(Config));
            CurrentConfig = (Config)serializer.Deserialize(_fileSr);
            _fileSr.Close();
            if (CurrentConfig.IdleTimeout < 10) {
                CurrentConfig.IdleTimeout = 10;
            }
        }
    }
}