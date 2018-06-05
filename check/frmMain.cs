using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace check
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Data_Init();
        }

        private void Data_Init()
        {
            // step1: 填充登录信息
            lblOperator.Text = loginUser.user;
            lblWarehouse.Text = loginUser.warehouseCode;

            //step2: 设置光标移动顺序



            // 填充cbx
            string sql = string.Format("select d.identifier as 'code',d.description as 'name'  from config_detail d where warehouseCode='{0}' and recordType='ORDER_SHORTAGE_REASON'", loginUser.warehouseCode);
            DataTable dt = DBConnect.GetDataSet(sql);
            cbxOrderReason.DataSource = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                cbxOrderReason.DataSource = dt;
                cbxOrderReason.DisplayMember = "name";
                cbxOrderReason.ValueMember = "code";
            }
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCloseContainer_Click(object sender, EventArgs e)
        {

        }

        private void btnCloseOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnlocate_Click(object sender, EventArgs e)
        {

        }

        private void btnlocateCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

       
        /// <summary>
        /// 键盘回车事件提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCarNo_KeyDown(object sender, KeyEventArgs e)
        {
            // 判断按下的字符是否是回车
            if (e.KeyCode == Keys.Enter)
            {
                TextBox textbox = null;
                if (sender is TextBox)
                {
                    textbox = (TextBox)sender;

                    switch (textbox.Name)
                    {
                        case "txtCarNo":
                            {
                                textbox.Enabled = false;
                                break;
                            }
                        case "txtOrder":
                            {
                                getOrderInfo(textbox.Text, prefCode);
                                break;
                            }
                        case "txtLpn":
                            {
                                if (rdoEach.Checked) { txtSN.Text = txtLpn.Text; }
                                break;
                            }
                        case "txtBarcode":
                            {
                                txtBarcodeCount.Text = "1";
                                break;
                            }
                        case "txtBarcodeCount":
                            {
                                txtBarcodeCount.Text = "1";
                                break;
                            }
                        case "txtSN":
                            {
                                
                                break;
                            }
                        default:break;
                    }

                    Msg.ShowInformation(textbox.Name);
                }
            }
        }

        private string controlReceiptApi = @"/rf/inbound/checkIn";
        private string prefCode = "Recinputeach";
        /// <summary>
        /// 查询获取订单信息
        /// </summary>
        /// <param name="receiptCode">订单号</param>
        /// <param name="PrefCode">入库首选项</param>
        private void getOrderInfo(string receiptCode, string PrefCode)
        {
            string name=@"/receipt";
            string url = string.Format("{0}{1}{2}?receiptCode={3}&prefCode={4}", loginUser.server, controlReceiptApi, name, receiptCode, PrefCode);
            string Rstr = TTX_WebAPI_Helper.getReturnJson(url);
            ResponseReceiptEntity rsp = JsonToolEx.ToObject<ResponseReceiptEntity>(Rstr);
            
        }
    }
}
