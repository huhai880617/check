using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check
{
   public class MConfigSetting
    {
        private string _iniFile="mconfig.ini";
        private string _receiptEach = "Recinputeach";
        private string _receiptMore="Recinputmore";
        private string _receiptMix="Receiptmix";
        

        public MConfigSetting(string iniFile)
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

        public string ReceiptEach
        {
            get
            {
                return _receiptEach;
            }

            set
            {
                _receiptEach = value;
            }
        }

        public string ReceiptMore
        {
            get
            {
                return _receiptMore;
            }

            set
            {
                _receiptMore = value;
            }
        }

        public string ReceiptMix
        {
            get
            {
                return _receiptMix;
            }

            set
            {
                _receiptMix = value;
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
                ReceiptEach = cfg.IniReadValue("Configuration", "receiptEach");
                ReceiptMore = cfg.IniReadValue("Configuration", "receiptMore");
                ReceiptMix = cfg.IniReadValue("Configuration", "receiptMix");
                
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
                cfg.IniWriteValue("Configuration", "receiptEach", ReceiptEach);
                cfg.IniWriteValue("Configuration", "user", ReceiptMore);
                cfg.IniWriteValue("Configuration", "warehouse", ReceiptMix);
            }
        }
    }
}
