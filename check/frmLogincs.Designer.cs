namespace check
{
    partial class frmLogincs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSetting = new System.Windows.Forms.Label();
            this.chkLoginDefault = new System.Windows.Forms.CheckBox();
            this.cbxWarehouse = new System.Windows.Forms.ComboBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(83, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(304, 2);
            this.label5.TabIndex = 232;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cornsilk;
            this.panel1.Controls.Add(this.lblSetting);
            this.panel1.Controls.Add(this.chkLoginDefault);
            this.panel1.Controls.Add(this.cbxWarehouse);
            this.panel1.Controls.Add(this.txtPwd);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(57, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 237);
            this.panel1.TabIndex = 239;
            // 
            // lblSetting
            // 
            this.lblSetting.AutoSize = true;
            this.lblSetting.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSetting.ForeColor = System.Drawing.Color.Blue;
            this.lblSetting.Location = new System.Drawing.Point(238, 161);
            this.lblSetting.Name = "lblSetting";
            this.lblSetting.Size = new System.Drawing.Size(45, 12);
            this.lblSetting.TabIndex = 248;
            this.lblSetting.Text = " 设置 ";
            this.lblSetting.Click += new System.EventHandler(this.lblSetting_Click);
            // 
            // chkLoginDefault
            // 
            this.chkLoginDefault.AutoSize = true;
            this.chkLoginDefault.Location = new System.Drawing.Point(92, 161);
            this.chkLoginDefault.Name = "chkLoginDefault";
            this.chkLoginDefault.Size = new System.Drawing.Size(96, 16);
            this.chkLoginDefault.TabIndex = 247;
            this.chkLoginDefault.Text = "默认仓库登录";
            this.chkLoginDefault.UseVisualStyleBackColor = true;
            this.chkLoginDefault.CheckedChanged += new System.EventHandler(this.chkLoginDefault_CheckedChanged);
            // 
            // cbxWarehouse
            // 
            this.cbxWarehouse.FormattingEnabled = true;
            this.cbxWarehouse.Location = new System.Drawing.Point(94, 200);
            this.cbxWarehouse.Name = "cbxWarehouse";
            this.cbxWarehouse.Size = new System.Drawing.Size(185, 20);
            this.cbxWarehouse.TabIndex = 246;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(92, 116);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(187, 21);
            this.txtPwd.TabIndex = 245;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(92, 76);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(187, 21);
            this.txtUser.TabIndex = 244;
            this.txtUser.Leave += new System.EventHandler(this.txtUser_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 239;
            this.label1.Text = "用户：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 240;
            this.label2.Text = "密码：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 242;
            this.label8.Text = "仓库：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(91, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 14);
            this.label6.TabIndex = 241;
            this.label6.Text = "用户登陆(User Login)";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(196, 301);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(78, 24);
            this.btnLogin.TabIndex = 240;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(297, 301);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 24);
            this.btnCancel.TabIndex = 240;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmLogincs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(458, 361);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Name = "frmLogincs";
            this.Text = "系统登录";
            this.Load += new System.EventHandler(this.frmLogincs_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxWarehouse;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkLoginDefault;
        private System.Windows.Forms.Label lblSetting;
    }
}