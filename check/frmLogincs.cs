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
    public partial class frmLogincs : Form
    {
        private ResponseWarehouseEntity rsm;
        public static ConfigSetting cfg;
       // public string controllApi = @"/rf/login/warehouse";
        public frmLogincs()
        {
            InitializeComponent();
        }

        private void frmLogincs_Load(object sender, EventArgs e)
        {
            string file = Path.Combine(Application.StartupPath, "config\\config.ini");
            cfg = new ConfigSetting(file);
            txtUser.Text = cfg.User;
            //string url = cfg.Server + controllApi;
            loginAPI login = new loginAPI(cfg.Server);
            ResponseWarehouseEntity rsp = login.logInWarehouse("warehouse");
            if (rsp != null && rsp.data != null)
            {
                rsm = rsp;
                if (rsm.data != null && rsm.data.Count > 0)
                {
                    cbxWarehouse.DataSource = null;
                    cbxWarehouse.DataSource = rsm.data;
                    cbxWarehouse.DisplayMember = "name";
                    cbxWarehouse.ValueMember = "code";
                }
            }
        }

        public void getDefaultWarehouseInfo(string user)
        {
            //try
            //{
            //    string sql = string.Format("select s.defaultWarehouseCode as 'code',s.defaultWarehouseName as 'name'  from user_settings s where s.Code='{0}' ;", user);
            //    cbxWarehouse.DataSource = null;
            //    DataTable dt2 = DBConnect.GetDataSet(sql);
            //    cbxWarehouse.DataSource = dt2;
            //    cbxWarehouse.DisplayMember = "name";
            //    cbxWarehouse.ValueMember = "code";
            //}
            //catch (Exception ex)
            //{
            //    LogExecute.WriteExceptionLog("getDefaultWarehouseInfo", ex);
            //}
        }

       

        private void txtUser_Leave(object sender, EventArgs e)
        {
            //cbxWarehouse_Init();
        }

        private void chkLoginDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLoginDefault.Checked)
            {
                if (rsm != null)
                {
                    foreach (ResponseWarehouse r in rsm.data)
                    {
                        if (r.Flag == true)
                        {
                            cbxWarehouse.Text = r.Name;
                        }
                    }
                }
            }
            cbxWarehouse.Enabled = !chkLoginDefault.Checked;
            //cbxWarehouse_Init();
        }

      

        private bool Valid_Input()
        {
            if (txtUser.Text.Trim() == "")
            {
                Msg.ShowInformation("请输入用户代码");
                txtUser.Focus();
                return false;
            }
            if (txtPwd.Text.Trim() == "")
            {
                Msg.ShowInformation("请输入密码");
                txtPwd.Focus();
                return false;
            }
            if (cbxWarehouse.SelectedValue.ToString() == "")
            {
                Msg.ShowInformation("请选择登录仓库");
                cbxWarehouse.Focus();
                return false;
            }
            return true;
        }

        private bool LoginOn(string user, string pwd, string warehouseCode)
        {
            //string password = CEncoder.Encode(pwd);
            string password = CEncoder.encryptMD5(pwd);
            string sql = string.Format("select count(0) from ttx_user_password where code='{0}' and password ='{1}' ", user, password);
            //if (DBConnect.GetDataSet(sql).Rows[0][0].ToString() != "")
            {
                loginUser.user = user;
                loginUser.warehouseCode = warehouseCode;
                loginUser.warehouseName = cbxWarehouse.Text;
                loginUser.server = cfg.Server;
                TTX_WebAPI_Helper.warehouse = loginUser.warehouseCode;
                TTX_WebAPI_Helper.user = loginUser.user;
                return true;
            }
           // return false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Valid_Input())
            {
                if (LoginOn(txtUser.Text.Trim(), txtPwd.Text.Trim(), cbxWarehouse.SelectedValue.ToString()) == true)
                {
                    this.Hide();
                    frmMain frmForm1 = new frmMain();
                    frmForm1.ShowDialog();
                }
            }
        }

        /// <summary>
        /// 显示登陆窗体.(公共静态方法)
        /// </summary>        
        public static bool Login()
        {
            frmLogincs form = new frmLogincs();
            DialogResult result = form.ShowDialog();
            bool ret = (result == DialogResult.OK);
            return ret;
        }

        private void lblSetting_Click(object sender, EventArgs e)
        {
            frmSetting frmseting = new frmSetting();
            frmseting.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
    }
}
