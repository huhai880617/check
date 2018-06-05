using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check
{
   public class ConfigSetting
    {
        private string _iniFile="config.ini";
        private string _server = "http://localhost:8080";
        private string _user="hjk";
        private string _warehouse="W200286";
        

        public ConfigSetting(string iniFile)
        {
            _iniFile = iniFile;
            if (!System.IO.File.Exists(iniFile))
                Write();

            Read();
        }

        public string IniFile
        {
            get
            {
                return _iniFile;
            }

            set
            {
                _iniFile = value;
            }
        }

        public string Server
        {
            get
            {
                return _server;
            }

            set
            {
                _server = value;
            }
        }

        public string User
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
            }
        }

        public string Warehouse
        {
            get
            {
                return _warehouse;
            }

            set
            {
                _warehouse = value;
            }
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        public void Read()
        {
            IniFile cfg = new IniFile(_iniFile);
            if (cfg != null)
            {
                Server = cfg.IniReadValue("Configuration", "server");
                User = cfg.IniReadValue("Configuration", "user");
                Warehouse = cfg.IniReadValue("Configuration", "warehouse");
                
            }
        }

        /// <summary>
        /// 将配置写入INI文件
        /// </summary>
        public void Write()
        {
            IniFile cfg = new IniFile(_iniFile);
            if (cfg != null)
            {
                cfg.IniWriteValue("Configuration", "url", Server);
                cfg.IniWriteValue("Configuration", "user", User);
                cfg.IniWriteValue("Configuration", "warehouse", Warehouse);
            }
        }
    }
}
