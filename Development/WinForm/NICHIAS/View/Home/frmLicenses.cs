using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NICHIAS.Core;
using NICHIAS.Core.Helper;
using Registration.Core.License;
using System.Diagnostics;

namespace NICHIAS.View.Home
{
    public partial class frmLicenses : XtraForm
    {
        public frmLicenses()
        {
            InitializeComponent();
            lblMaKichHoat.Text = ": " + GlobalConstants.license.Read().ProductId;
            lblTrangThai.Text = ": " + LanguageTranslate.ChangeLanguageText("Dùng thử");
            lblBanQuyen.Text = ": " + LanguageTranslate.ChangeLanguageText("Dùng thử cho 1 máy tính");
            lblNgayKichHoat.Text = ": " + GlobalConstants.license.Read().TrialKeyBegin.ToString("dd/MM/yyyy HH:mm");
            lblNgayHetHan.Text = ": " + GlobalConstants.license.Read().TrialKeyEnd.ToString("dd/MM/yyyy HH:mm");
            lblConLai.Text = ": " + GlobalConstants.license.Read().TrialKeyLeft.ToString() + " " + LanguageTranslate.ChangeLanguageText("Ngày");
            btnTrial.Enabled = (GlobalConstants.license.Read().TrialKeyLeft > 0);
        }

        private void frmLicenses_Load(object sender, EventArgs e)
        {
            LanguageTranslate.ChangeLanguageForm(this);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmLicense frm = new frmLicense();
            frm.License = GlobalConstants.license;
            frm.BuyLicenseUrl = "http://datatech.vn/";
            frm.Text = LanguageTranslate.ChangeLanguageText("Đăng ký sử dụng phần mềm") + " " + GlobalConstants.Company;
            frm.Icon = Properties.Resources.icon;
            DialogResult dr = frm.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnTrial_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void openLink(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo sInfo = new ProcessStartInfo("http://datatech.vn/");
                Process.Start(sInfo);
            }
            catch { }
        }
    }
}