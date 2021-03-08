namespace NICHIAS.View.LanguageLibrarys
{
    partial class frmLanguageLibraryAddEdit
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
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtEnglish = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtVietnamese = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnglish.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVietnamese.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(265, 146);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 40);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng (ESC)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(154)))), ((int)(((byte)(242)))));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(179, 146);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu (F1)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtEnglish
            // 
            this.txtEnglish.EditValue = "";
            this.txtEnglish.Location = new System.Drawing.Point(45, 103);
            this.txtEnglish.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEnglish.Name = "txtEnglish";
            this.txtEnglish.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEnglish.Properties.Appearance.Options.UseFont = true;
            this.txtEnglish.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtEnglish.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtEnglish.Properties.AutoHeight = false;
            this.txtEnglish.Size = new System.Drawing.Size(300, 30);
            this.txtEnglish.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(45, 78);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 19);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tiếng Anh";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(45, 15);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 19);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Tiếng Việt";
            // 
            // txtVietnamese
            // 
            this.txtVietnamese.EditValue = "";
            this.txtVietnamese.Location = new System.Drawing.Point(45, 40);
            this.txtVietnamese.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVietnamese.Name = "txtVietnamese";
            this.txtVietnamese.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtVietnamese.Properties.Appearance.Options.UseFont = true;
            this.txtVietnamese.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtVietnamese.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtVietnamese.Properties.AutoHeight = false;
            this.txtVietnamese.Size = new System.Drawing.Size(300, 30);
            this.txtVietnamese.TabIndex = 0;
            // 
            // frmLanguageLibraryAddEdit
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(390, 198);
            this.Controls.Add(this.txtVietnamese);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtEnglish);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLanguageLibraryAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thư viện ngôn ngữ";
            this.Load += new System.EventHandler(this.frmLanguageLibraryAddEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtEnglish.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVietnamese.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtEnglish;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtVietnamese;
    }
}