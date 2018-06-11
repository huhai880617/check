using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace check
{
    public partial class frmSetting : Form
    {
       
        MConfigSetting mcfg;
        public frmSetting()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            // 服务器参数
            string file = Path.Combine(Application.StartupPath, "config\\config.ini");
           frmLogincs.cfg = new ConfigSetting(file);
            txtUrl.Text = frmLogincs.cfg.Server;

            // 入库首选项Map
            file = Path.Combine(Application.StartupPath, "config\\mconfig.ini");
            mcfg = new MConfigSetting(file);
            textBox1.Text = mcfg.ReceiptEach;
            textBox2.Text = mcfg.ReceiptMore;
            textBox3.Text = mcfg.ReceiptMix;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strPre = frmLogincs.cfg.Server;
            string strCur= txtUrl.Text.Trim();
            frmLogincs.cfg.Server = strCur;
            frmLogincs.cfg.Write();
            frmLogincs.cfg.Read();
            if (frmLogincs.cfg.Server == strCur)
            {
                Msg.ShowInformation(String.Format("保存成功!!! 由原来的{0} 修改成{1}", strPre, strCur));
            }
            else
            {
                Msg.Warning("保存失败!!!");
                frmLogincs.cfg.Server = strPre;
            }
        }

        private void btnMapping_Click(object sender, EventArgs e)
        {
            string strEachPre = mcfg.ReceiptEach;
            string strMorePre = mcfg.ReceiptMore;
            string strMixPre = mcfg.ReceiptMix;

            string strEachCur = textBox1.Text.Trim();
            string strMoreCur = textBox2.Text.Trim();
            string strMixCur = textBox3.Text.Trim();

            mcfg.ReceiptEach = strEachCur;
            mcfg.ReceiptMore = strMoreCur;
            mcfg.ReceiptMix = strMixCur;

            mcfg.Write();
            mcfg.Read();

            if (mcfg.ReceiptEach == strEachCur && mcfg.ReceiptMore == strMoreCur && mcfg.ReceiptMix == strMixCur)
            {
                Msg.ShowInformation(String.Format("绑定成功!!! \r\n由原来的{0},{1},{2} \r\n 修改成{3},{4},{5}", 
                    strEachPre, strMorePre,strMixPre, strEachCur, strMoreCur,strMixCur));
            }
            else
            {
                Msg.Warning("保存失败!!!");
            }
        }
    }
}
