using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace check
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Data_Init();
            this.Text = string.Format("ANNTO WMS 工作登记台 Ver1.1.3-180608");
        }

        private void Data_Init()
        {
            // step1: 填充登录信息
            lblOperator.Text = loginUser.user;
            lblWarehouse.Text = loginUser.warehouseCode;

            //step2: 设置光标移动顺序



            // 填充cbx
            //string sql = string.Format("select d.identifier as 'code',d.description as 'name'  from config_detail d where warehouseCode='{0}' and recordType='ORDER_SHORTAGE_REASON'", loginUser.warehouseCode);
            //DataTable dt = DBConnect.GetDataSet(sql);
            //cbxOrderReason.DataSource = null;
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    cbxOrderReason.DataSource = dt;
            //    cbxOrderReason.DisplayMember = "name";
            //    cbxOrderReason.ValueMember = "code";
            //}
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            if(Msg.AskQuestion("你确定需要退出系统程序？？？"))
            Application.Exit();
        }

        private void btnCloseContainer_Click(object sender, EventArgs e)
        {

        }

        private void btnCloseOrder_Click(object sender, EventArgs e)
        {
            if (Msg.AskQuestion("你确定需要关闭订单。关闭订单，关闭后数据将上传接口，且不可撤销，是否继续？") == true)
            {
                receiptAPI api = new receiptAPI(loginUser.server);
                if (responseReceiptInfo != null)
                {
                    ResponseEntity rsp = api.closeReceipt("receipt/closeReceipt", responseReceiptInfo.id);
                    if (rsp != null && rsp.code == "0")
                    {
                        Msg.ShowInformation(string.Format("订单{0}关闭成功！！！", responseReceiptInfo.receiptCode));
                        // PlayMusic.playFinish();
                    }
                }
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            txtCarNo.Text = "";
            lbllpnCount.Text = "0";
            lblOrderNum.Text = "0";
            txtCarNo.Enabled = true;
            txtOrder.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            receiptAPI api = new receiptAPI(loginUser.server);
            if (dataGridView2.SelectedRows != null && dataGridView2.SelectedRows.Count == 1)
            {
                int containerId = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                ResponseEntity rsp = api.cancelCheck("receipt/cancelCheck", containerId);
                if (rsp != null && rsp.code == "0")
                {
                    PlayMusic.playDing();
                    Msg.ShowInformation(string.Format("订单号:{0}的容器:{1}取消收货成功", txtOrder.Text.Trim(), dataGridView2.SelectedRows[0].Cells[1].Value.ToString()));
                    int t1 = int.Parse(lblOrderNum.Text) - 1;
                    int t2 = int.Parse(lbllpnCount.Text) - 1;
                    if (t1 > 0)
                    {
                        lblOrderNum.Text = t1.ToString();
                        lbllpnCount.Text = t2.ToString();
                    }
                    else
                    {
                        lblOrderNum.Text = "0";
                        lbllpnCount.Text = "0";
                    }
                    RefreshData();
                }
                else
                {
                    PlayMusic.playError();
                    Msg.ShowError(string.Format("订单号:{0}的容器:{1}取消收货失败", txtOrder.Text.Trim(), dataGridView2.SelectedRows[0].Cells[1].Value.ToString()));
                }
            }
            else
            {
                Msg.Warning("没有选择相应的数据行！！！");
            }
        }

        private void btnlocate_Click(object sender, EventArgs e)
        {
            receiptAPI api = new receiptAPI(loginUser.server);
            if (dataGridView2.SelectedRows != null && dataGridView2.SelectedRows.Count == 1)
            {
                int containerId = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                ResponseEntity rsp = api.cancelCheck("receipt/locate", containerId);
                if (rsp != null && rsp.code == "0")
                {
                    PlayMusic.playDing();
                    Msg.ShowInformation(string.Format("订单号:{0}的容器:{1}定位成功", txtOrder.Text.Trim(), dataGridView2.SelectedRows[0].Cells[1].Value.ToString()));
                    RefreshData();
                }
                else
                {
                    PlayMusic.playError();
                    Msg.ShowError(string.Format("订单号:{0}的容器:{1}定位失败", txtOrder.Text.Trim(), dataGridView2.SelectedRows[0].Cells[1].Value.ToString()));
                }
            }
            else
            {
                Msg.Warning("没有选择相应的数据行！！！");
            }
        }

        private void btnlocateCancel_Click(object sender, EventArgs e)
        {
            receiptAPI api = new receiptAPI(loginUser.server);
            if (dataGridView2.SelectedRows != null && dataGridView2.SelectedRows.Count == 1)
            {
                int containerId = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                ResponseEntity rsp = api.cancelCheck("receipt/unlocate", containerId);
                if (rsp != null && rsp.code == "0")
                {
                    PlayMusic.playDing();
                    Msg.ShowInformation(string.Format("订单号:{0}的容器:{1}取消定位成功", txtOrder.Text.Trim(), dataGridView2.SelectedRows[0].Cells[1].Value.ToString()));
                    RefreshData();
                }
                else
                {
                    PlayMusic.playError();
                    Msg.ShowError(string.Format("订单号:{0}的容器:{1}取消定位失败", txtOrder.Text.Trim(), dataGridView2.SelectedRows[0].Cells[1].Value.ToString()));
                }
            }
            else
            {
                Msg.Warning("没有选择相应的数据行！！！");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
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
                                if (getCarInfo(textbox.Text.Trim()) == true)
                                {
                                    PlayMusic.playDing();
                                    textbox.Enabled = false;
                                    txtOrder.Enabled = true;
                                    txtOrder.Focus();
                                }
                                else
                                {
                                    PlayMusic.playError();
                                }
                                break;
                            }
                        case "txtOrder":
                            {
                                if (getOrderInfo(textbox.Text, prefCode) == true)
                                {
                                    PlayMusic.playOpen();
                                    txtBarcode.Focus();
                                }
                                else
                                {
                                    PlayMusic.playError();
                                }
                                break;
                            }
                        case "txtLpn":
                            {
                                if (rdoEach.Checked) { txtSN.Text = txtLpn.Text; }
                                if (checkContainer(textbox.Text.Trim()) == true)
                                {
                                    if (confirm() == true)
                                    {
                                       
                                        PlayMusic.playFinish();
                                        txtLpn.Text = "";
                                        txtBarcode.Text = "";
                                        txtSN.Text = "";
                                        richTextBox1.Text = "";
                                        txtBarcode.Focus();
                                        if (lblRemainNum.Text == "1")
                                        {
                                            txtOrder.Text = "";
                                            lblSKUCount.Text = "0";
                                            lblCountNum.Text = "0";
                                            txtOrder.Focus();
                                        }
                                        lblRemainNum.Text = (int.Parse(lblRemainNum.Text) - 1).ToString();

                                        RefreshData();
                                    }
                                    else
                                    {
                                        PlayMusic.playError();
                                        txtLpn.Text = "";
                                        txtLpn.Focus();
                                    };
                                }
                                else
                                {
                                    PlayMusic.playError();
                                    txtLpn.Text = "";
                                    txtSN.Text = "";
                                    txtLpn.Focus();
                                }
                                break;
                            }
                        case "txtBarcode":
                            {
                                getItemName(textbox.Text.Trim());
                                txtBarcodeCount.Text = "1";
                                txtLpn.Focus();
                                //if (confirm() == true)
                                //{
                                //    PlayMusic.playFinish();
                                //    txtLpn.Text = "";
                                //    txtBarcode.Text = "";
                                //    txtSN.Text = "";
                                //    txtLpn.Focus();
                                //}
                                //else
                                //{
                                //    PlayMusic.playError();
                                //    txtBarcode.Text = "";
                                //    txtBarcode.Focus();
                                //};
                                //FillContainerDataGridView(txtOrder.Text.Trim());
                                
                                // txtBarcodeCount.Focus();
                                break;
                            }
                        case "txtBarcodeCount":
                            {
                               // txtBarcodeCount.Text = "1";
                                //confirm();
                                //FillContainerDataGridView(txtOrder.Text.Trim());
                                break;
                            }
                        case "txtSN":
                            {

                                break;
                            }
                        default: break;
                    }

                   // Msg.ShowInformation(textbox.Name);
                }
            }
        }

        private string controlReceiptApi = @"/rf/inbound/checkIn";
        private string prefCode = "Recinputeach";
        private string inventorySts = "Y";
        private ResponseReceiptInfo responseReceiptInfo;
       
        /// <summary>
        /// 查询获取订单信息
        /// </summary>
        /// <param name="receiptCode">订单号</param>
        /// <param name="PrefCode">入库首选项</param>
        private bool getOrderInfo(string receiptCode, string PrefCode)
        {
            bool flag = false;
            string name = @"/receipt";
            string url = string.Format("{0}{1}{2}?receiptCode={3}&prefCode={4}", loginUser.server, controlReceiptApi, name, receiptCode, PrefCode);
            string Rstr = TTX_WebAPI_Helper.getReturnJson(url);
            ResponseReceiptEntity rsp = JsonToolEx.ToObject<ResponseReceiptEntity>(Rstr);
            //Root rs = JsonToolEx.ToObject<Root>(Rstr);
            // 获取待收货数量  总数量   SKU数量
            if (rsp.code == "0" && rsp.data != null)
            {
                lblRemainNum.Text = rsp.data.openQty.ToString(); //货品待收货数量
                lblCountNum.Text = rsp.data.totalQty.ToString(); //货品总件数
                lblSKUCount.Text = rsp.data.itemQty.ToString(); //货品总数
               
                responseReceiptInfo = rsp.data;
                FillReciptDataGridView(responseReceiptInfo);
                FillContainerDataGridView(responseReceiptInfo.receiptCode);
                flag = true;
            }
            return flag;
        }

        // 收货
        private bool confirm()
        {
            bool flag = false;
            ReceiptConfirmRequest req = new ReceiptConfirmRequest();
            req.receiptCode = txtOrder.Text.Trim();
            //req.prefCode = "Recinputeach";
            req.containerCodec = txtLpn.Text.Trim();
            req.prefCode = "Recinputeach-"+ txtCarNo.Text.Trim();
            List<ReceiptConfirmRequest.Item> items = new List<ReceiptConfirmRequest.Item>();
            ReceiptConfirmRequest.Item item = new ReceiptConfirmRequest.Item();
            item.itemCode = txtBarcode.Text.Trim();
            item.inventorySts = inventorySts;
            item.qty =int.Parse( txtBarcodeCount.Text.Trim());
            item.unit = "EA";
            item.templateValue = null;
            item.serialNumbers = null;
            items.Add(item);
            req.items = items;
           
            receiptAPI api = new receiptAPI(loginUser.server);
            ResponseEntity r = api.confirmReceipt("confirm", req);
            if (r != null && r.code == "0")
            {
               // Msg.ShowInformation(string.Format("收货成功,商品编码:{0},数量:{1}", item.itemCode, item.qty));
                getOrderInfo(req.receiptCode, req.prefCode);
                FillReciptDataGridView(responseReceiptInfo);
                flag = true;
                lblOrderNum.Text = (int.Parse(lblOrderNum.Text) + 1).ToString();
                lbllpnCount.Text = (int.Parse(lbllpnCount.Text) + 1).ToString();
            }
            else
            {
                richTextBox1.ForeColor = Color.Red;
                richTextBox1.Text = (string.Format("收货失败,商品编码:{0}--:{1}", item.itemCode, r.msg));
            }
            return flag;
        }

        private bool checkContainer(string containerCodec)
        {
            bool flag=false;
            receiptAPI api = new receiptAPI(loginUser.server);
            ResponseEntity r = api.checkReceiptContainer("receipt/container", containerCodec);
            if (r != null && r.code != "0")
            {
                richTextBox1.ForeColor = Color.Red;
                richTextBox1.Text=(string.Format("{0} 验证失败 :{1}", containerCodec,r.msg));

            }
            if (r != null && r.code == "0") flag = true;
            return flag;
        }

        public bool getCarInfo(string carNo)
        {
            bool flag = false;
            receiptAPI api = new receiptAPI(loginUser.server);
            ResponseMessage<ReceivingCar> r = api.receivingCart("receipt/receivingCart", carNo);
            if (r != null && r.code == "0")
            {
                if (r.data != null) {
                    lblOrderNum.Text = r.data.receiptitemqty.ToString();
                    lbllpnCount.Text = r.data.containercount.ToString();
                    flag = true;
                }
            }
            return flag;
        }

        private void getItemName(string itemCode)
        {
            if (responseReceiptInfo != null && responseReceiptInfo.items.Count > 0)
            {
                foreach (Item i in responseReceiptInfo.items)
                {
                    if (i.itemCode == itemCode)
                    {
                        richTextBox1.ForeColor = Color.Black;
                        richTextBox1.Text = i.itemName;
                        inventorySts = i.inventorySts;
                    }

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rspinfo"></param>
        private void FillReciptDataGridView(ResponseReceiptInfo rspinfo)
        {
            dataGridView1.DataSource = null;
            if (rspinfo != null && rspinfo.items.Count > 0)
            {
                DataTable dt = new DataTable();
                string[] columns = new string[] { "单号", "编码", "名称", "总数", "待收" };
                foreach (string s in columns)
                {
                    dt.Columns.Add(s);
                }

                foreach (Item o in responseReceiptInfo.items)
                {
                    DataRow dr = dt.NewRow();
                    dr["单号"] = rspinfo.receiptCode;
                    dr["编码"] = o.itemCode;
                    dr["名称"] = o.itemName;
                    dr["总数"] = o.totalQty;
                    dr["待收"] = o.openQty;
                    dt.Rows.Add(dr);
                }
                dataGridView1.DataSource = dt;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rspinfo"></param>
        private void FillContainerDataGridView(string receiptCode)
        {
            receiptAPI api = new receiptAPI(loginUser.server);
            ResponseMessage<List<ContainerInfo>>  rspinfo=  api.queryRecontainer("receipt/containercode", receiptCode);
            dataGridView2.DataSource = null;
            if (rspinfo != null && rspinfo.data.Count>0)
            {
                DataTable dt = new DataTable();
                string[] columns = new string[] { "标识", "容器", "编码", "名称","数量","库位","状态","车号" };
                foreach (string s in columns)
                {
                    dt.Columns.Add(s);
                }

                foreach (ContainerInfo o in rspinfo.data)
                {
                    DataRow dr = dt.NewRow();
                    dr["标识"] = o.id;
                    dr["容器"] = o.containerCode;
                    dr["编码"] = o.itemCode;
                    dr["名称"] = o.itemName;
                    dr["数量"] = o.quantity;
                    dr["库位"] = o.toLocation;
                    dr["状态"] = o.status;
                    dr["车号"] = o.receivingCartId;
                    dt.Rows.Add(dr);
                }
                dataGridView2.DataSource = dt;
            }
        }

        private void txtCarNo_TextChanged(object sender, EventArgs e)
        {
            //if (txtCarNo.Text.Length > 0)
            //{
            //    txtOrder.Enabled = true;
            //}
            //else
            //{
            //    txtOrder.Enabled = false;
            //}
        }

        private void RefreshData()
        {
            string orderCode = txtOrder.Text.Trim();
            if (orderCode != "")
            {
                if (getOrderInfo(orderCode, prefCode) == false)
                {
                    responseReceiptInfo = null;
                    dataGridView1.DataSource = null;
                    dataGridView2.DataSource = null;
                }
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;
            }
        }
    }
}
