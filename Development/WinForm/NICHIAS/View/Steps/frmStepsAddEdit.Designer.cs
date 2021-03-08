namespace NICHIAS.View.Steps
{
    partial class frmStepsAddEdit
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
            this.txtStepName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtStepNo = new DevExpress.XtraEditors.SpinEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.chkRequestScanOutYes = new System.Windows.Forms.RadioButton();
            this.chkRequestScanOutNo = new System.Windows.Forms.RadioButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkRequestScanInYes = new System.Windows.Forms.RadioButton();
            this.chkRequestScanInNo = new System.Windows.Forms.RadioButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtNote = new DevExpress.XtraEditors.MemoEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.chkUsing = new System.Windows.Forms.RadioButton();
            this.chkNoUse = new System.Windows.Forms.RadioButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtStepName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStepNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(265, 386);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 40);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Đóng (ESC)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(154)))), ((int)(((byte)(242)))));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(179, 386);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 40);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu (F1)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtStepName
            // 
            this.txtStepName.EditValue = "";
            this.txtStepName.Location = new System.Drawing.Point(45, 101);
            this.txtStepName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStepName.Name = "txtStepName";
            this.txtStepName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStepName.Properties.Appearance.Options.UseFont = true;
            this.txtStepName.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtStepName.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtStepName.Properties.AutoHeight = false;
            this.txtStepName.Size = new System.Drawing.Size(300, 30);
            this.txtStepName.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(45, 76);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(90, 19);
            this.labelControl4.TabIndex = 25;
            this.labelControl4.Text = "Tên công đoạn";
            // 
            // txtStepNo
            // 
            this.txtStepNo.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtStepNo.Location = new System.Drawing.Point(45, 41);
            this.txtStepNo.Name = "txtStepNo";
            this.txtStepNo.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtStepNo.Properties.Appearance.Options.UseFont = true;
            this.txtStepNo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtStepNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtStepNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtStepNo.Properties.IsFloatValue = false;
            this.txtStepNo.Properties.Mask.EditMask = "N0";
            this.txtStepNo.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtStepNo.Size = new System.Drawing.Size(300, 28);
            this.txtStepNo.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.chkRequestScanOutYes);
            this.panelControl3.Controls.Add(this.chkRequestScanOutNo);
            this.panelControl3.Location = new System.Drawing.Point(45, 224);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(300, 30);
            this.panelControl3.TabIndex = 3;
            // 
            // chkRequestScanOutYes
            // 
            this.chkRequestScanOutYes.AutoSize = true;
            this.chkRequestScanOutYes.BackColor = System.Drawing.Color.Transparent;
            this.chkRequestScanOutYes.Checked = true;
            this.chkRequestScanOutYes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkRequestScanOutYes.Location = new System.Drawing.Point(10, 4);
            this.chkRequestScanOutYes.Name = "chkRequestScanOutYes";
            this.chkRequestScanOutYes.Size = new System.Drawing.Size(44, 23);
            this.chkRequestScanOutYes.TabIndex = 0;
            this.chkRequestScanOutYes.TabStop = true;
            this.chkRequestScanOutYes.Text = "Có";
            this.chkRequestScanOutYes.UseVisualStyleBackColor = false;
            this.chkRequestScanOutYes.CheckedChanged += new System.EventHandler(this.chkRequestScanOutYes_CheckedChanged);
            // 
            // chkRequestScanOutNo
            // 
            this.chkRequestScanOutNo.AutoSize = true;
            this.chkRequestScanOutNo.BackColor = System.Drawing.Color.Transparent;
            this.chkRequestScanOutNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkRequestScanOutNo.Location = new System.Drawing.Point(94, 4);
            this.chkRequestScanOutNo.Name = "chkRequestScanOutNo";
            this.chkRequestScanOutNo.Size = new System.Drawing.Size(67, 23);
            this.chkRequestScanOutNo.TabIndex = 1;
            this.chkRequestScanOutNo.Text = "Không";
            this.chkRequestScanOutNo.UseVisualStyleBackColor = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(45, 200);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(188, 19);
            this.labelControl3.TabIndex = 24;
            this.labelControl3.Text = "Quét mã vạch sản phẩm khi ra";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkRequestScanInYes);
            this.panelControl1.Controls.Add(this.chkRequestScanInNo);
            this.panelControl1.Location = new System.Drawing.Point(45, 163);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(300, 30);
            this.panelControl1.TabIndex = 2;
            // 
            // chkRequestScanInYes
            // 
            this.chkRequestScanInYes.AutoSize = true;
            this.chkRequestScanInYes.BackColor = System.Drawing.Color.Transparent;
            this.chkRequestScanInYes.Checked = true;
            this.chkRequestScanInYes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkRequestScanInYes.Location = new System.Drawing.Point(10, 4);
            this.chkRequestScanInYes.Name = "chkRequestScanInYes";
            this.chkRequestScanInYes.Size = new System.Drawing.Size(44, 23);
            this.chkRequestScanInYes.TabIndex = 0;
            this.chkRequestScanInYes.TabStop = true;
            this.chkRequestScanInYes.Text = "Có";
            this.chkRequestScanInYes.UseVisualStyleBackColor = false;
            this.chkRequestScanInYes.CheckedChanged += new System.EventHandler(this.chkRequestScanInYes_CheckedChanged);
            // 
            // chkRequestScanInNo
            // 
            this.chkRequestScanInNo.AutoSize = true;
            this.chkRequestScanInNo.BackColor = System.Drawing.Color.Transparent;
            this.chkRequestScanInNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkRequestScanInNo.Location = new System.Drawing.Point(94, 4);
            this.chkRequestScanInNo.Name = "chkRequestScanInNo";
            this.chkRequestScanInNo.Size = new System.Drawing.Size(67, 23);
            this.chkRequestScanInNo.TabIndex = 1;
            this.chkRequestScanInNo.Text = "Không";
            this.chkRequestScanInNo.UseVisualStyleBackColor = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(45, 139);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(198, 19);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "Quét mã vạch sản phẩm khi vào";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(45, 15);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(89, 19);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "Mã công đoạn";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(45, 285);
            this.txtNote.Name = "txtNote";
            this.txtNote.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNote.Properties.Appearance.Options.UseFont = true;
            this.txtNote.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNote.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtNote.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtNote.Size = new System.Drawing.Size(300, 30);
            this.txtNote.TabIndex = 4;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.chkUsing);
            this.panelControl2.Controls.Add(this.chkNoUse);
            this.panelControl2.Location = new System.Drawing.Point(45, 346);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(300, 30);
            this.panelControl2.TabIndex = 5;
            // 
            // chkUsing
            // 
            this.chkUsing.AutoSize = true;
            this.chkUsing.BackColor = System.Drawing.Color.Transparent;
            this.chkUsing.Checked = true;
            this.chkUsing.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkUsing.Location = new System.Drawing.Point(10, 4);
            this.chkUsing.Name = "chkUsing";
            this.chkUsing.Size = new System.Drawing.Size(78, 23);
            this.chkUsing.TabIndex = 0;
            this.chkUsing.TabStop = true;
            this.chkUsing.Text = "Sử dụng";
            this.chkUsing.UseVisualStyleBackColor = false;
            this.chkUsing.CheckedChanged += new System.EventHandler(this.chkUsing_CheckedChanged);
            // 
            // chkNoUse
            // 
            this.chkNoUse.AutoSize = true;
            this.chkNoUse.BackColor = System.Drawing.Color.Transparent;
            this.chkNoUse.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkNoUse.Location = new System.Drawing.Point(94, 4);
            this.chkNoUse.Name = "chkNoUse";
            this.chkNoUse.Size = new System.Drawing.Size(97, 23);
            this.chkNoUse.TabIndex = 1;
            this.chkNoUse.Text = "Ko sử dụng";
            this.chkNoUse.UseVisualStyleBackColor = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(45, 322);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(61, 19);
            this.labelControl7.TabIndex = 20;
            this.labelControl7.Text = "Trạng thái";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(45, 261);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(43, 17);
            this.labelControl8.TabIndex = 17;
            this.labelControl8.Text = "Ghi chú";
            // 
            // frmStepsAddEdit
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(390, 438);
            this.Controls.Add(this.txtStepName);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtStepNo);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStepsAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Công đoạn";
            this.Load += new System.EventHandler(this.frmStepsAddEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtStepName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStepNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtStepName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SpinEdit txtStepNo;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.RadioButton chkRequestScanOutYes;
        private System.Windows.Forms.RadioButton chkRequestScanOutNo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.RadioButton chkRequestScanInYes;
        private System.Windows.Forms.RadioButton chkRequestScanInNo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit txtNote;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.RadioButton chkUsing;
        private System.Windows.Forms.RadioButton chkNoUse;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}