namespace NICHIAS.View.Home
{
    partial class frmSignIn
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
            this.linkIForgetMyPassword = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.chkKeepMeSignedIn = new DevExpress.XtraEditors.CheckEdit();
            this.btnSignIn = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblTieuDe = new DevExpress.XtraEditors.LabelControl();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.picEnglish = new System.Windows.Forms.PictureBox();
            this.picVietnamese = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chkKeepMeSignedIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnglish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVietnamese)).BeginInit();
            this.SuspendLayout();
            // 
            // linkIForgetMyPassword
            // 
            this.linkIForgetMyPassword.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.linkIForgetMyPassword.Appearance.Options.UseFont = true;
            this.linkIForgetMyPassword.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.linkIForgetMyPassword.Location = new System.Drawing.Point(45, 302);
            this.linkIForgetMyPassword.Name = "linkIForgetMyPassword";
            this.linkIForgetMyPassword.Size = new System.Drawing.Size(300, 30);
            this.linkIForgetMyPassword.TabIndex = 4;
            this.linkIForgetMyPassword.Text = "Quên mật khẩu";
            this.linkIForgetMyPassword.Visible = false;
            // 
            // chkKeepMeSignedIn
            // 
            this.chkKeepMeSignedIn.Location = new System.Drawing.Point(45, 210);
            this.chkKeepMeSignedIn.Name = "chkKeepMeSignedIn";
            this.chkKeepMeSignedIn.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkKeepMeSignedIn.Properties.Appearance.Options.UseFont = true;
            this.chkKeepMeSignedIn.Properties.AutoHeight = false;
            this.chkKeepMeSignedIn.Properties.Caption = "Lưu thông tin đăng nhập";
            this.chkKeepMeSignedIn.Size = new System.Drawing.Size(300, 30);
            this.chkKeepMeSignedIn.TabIndex = 2;
            // 
            // btnSignIn
            // 
            this.btnSignIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignIn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
            this.btnSignIn.Appearance.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.btnSignIn.Appearance.Options.UseBackColor = true;
            this.btnSignIn.Appearance.Options.UseFont = true;
            this.btnSignIn.Location = new System.Drawing.Point(45, 246);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(500, 50);
            this.btnSignIn.TabIndex = 3;
            this.btnSignIn.Text = "Đăng nhập";
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(45, 173);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPassword.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtPassword.Properties.AutoHeight = false;
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(500, 30);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(45, 148);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 15);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Mật khẩu";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Appearance.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
            this.lblTieuDe.Appearance.Options.UseFont = true;
            this.lblTieuDe.Appearance.Options.UseForeColor = true;
            this.lblTieuDe.Appearance.Options.UseTextOptions = true;
            this.lblTieuDe.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTieuDe.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(590, 73);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "COMPANY";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.EditValue = "";
            this.txtUsername.Location = new System.Drawing.Point(45, 110);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsername.Properties.Appearance.Options.UseFont = true;
            this.txtUsername.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtUsername.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtUsername.Properties.AutoHeight = false;
            this.txtUsername.Size = new System.Drawing.Size(500, 30);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(45, 85);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 15);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Tài khoản";
            // 
            // picEnglish
            // 
            this.picEnglish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picEnglish.BackgroundImage = global::NICHIAS.Properties.Resources.English;
            this.picEnglish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picEnglish.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEnglish.Location = new System.Drawing.Point(549, 329);
            this.picEnglish.Name = "picEnglish";
            this.picEnglish.Size = new System.Drawing.Size(29, 27);
            this.picEnglish.TabIndex = 14;
            this.picEnglish.TabStop = false;
            this.picEnglish.Click += new System.EventHandler(this.picEnglish_Click);
            // 
            // picVietnamese
            // 
            this.picVietnamese.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picVietnamese.BackgroundImage = global::NICHIAS.Properties.Resources.Vietnamese;
            this.picVietnamese.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picVietnamese.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picVietnamese.Location = new System.Drawing.Point(514, 329);
            this.picVietnamese.Name = "picVietnamese";
            this.picVietnamese.Size = new System.Drawing.Size(29, 27);
            this.picVietnamese.TabIndex = 15;
            this.picVietnamese.TabStop = false;
            this.picVietnamese.Click += new System.EventHandler(this.picVietnamese_Click);
            // 
            // frmSignIn
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(590, 368);
            this.Controls.Add(this.picEnglish);
            this.Controls.Add(this.picVietnamese);
            this.Controls.Add(this.linkIForgetMyPassword);
            this.Controls.Add(this.chkKeepMeSignedIn);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.frmSignIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkKeepMeSignedIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnglish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVietnamese)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.HyperlinkLabelControl linkIForgetMyPassword;
        private DevExpress.XtraEditors.CheckEdit chkKeepMeSignedIn;
        private DevExpress.XtraEditors.SimpleButton btnSignIn;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblTieuDe;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.PictureBox picEnglish;
        private System.Windows.Forms.PictureBox picVietnamese;
    }
}