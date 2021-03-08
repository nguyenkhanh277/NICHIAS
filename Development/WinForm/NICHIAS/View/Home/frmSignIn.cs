using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NICHIAS.Persistence;
using NICHIAS.Persistence.Repositories;
using NICHIAS.Core;
using NICHIAS.Core.Helper;

namespace NICHIAS.View.Home
{
    public partial class frmSignIn : XtraForm
    {
        ProjectDataContext _projectDataContext;
        UserRepository _userRepository;

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            _projectDataContext.Dispose();
        }

        public frmSignIn()
        {
            InitializeComponent();
        }

        private void frmSignIn_Load(object sender, EventArgs e)
        {
            _projectDataContext = new ProjectDataContext();
            _userRepository = new UserRepository(_projectDataContext);
            LoadLanguage(GlobalConstants.language);
            LanguageTranslate.ChangeLanguageForm(this);
            lblTieuDe.Text = GlobalConstants.Company;
            chkKeepMeSignedIn.Checked = Properties.Settings.Default.KeepMeSignedIn;
            if (chkKeepMeSignedIn.Checked)
            {
                txtUsername.Text = Properties.Settings.Default.Username;
                txtPassword.Text = Properties.Settings.Default.Password;
            }
        }

        private bool CheckData()
        {
            if (txtUsername.Text.Trim() == "")
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Chưa điền dữ liệu"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }
            else if (txtPassword.Text.Trim() == "")
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Chưa điền dữ liệu"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }
            _userRepository.CheckSecurity(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            if (_userRepository.error)
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText(_userRepository.errorMessage), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            Properties.Settings.Default.KeepMeSignedIn = chkKeepMeSignedIn.Checked;
            if (chkKeepMeSignedIn.Checked)
            {
                Properties.Settings.Default.Username = txtUsername.Text.Trim();
                Properties.Settings.Default.Password = txtPassword.Text.Trim();
            }
            else
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Password = "";
            }
            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                txtPassword.SelectAll();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignIn_Click(null, null);
            }
        }

        private void LoadLanguage(int language)
        {
            GlobalConstants.language = language;
            Properties.Settings.Default.Language = GlobalConstants.language;
            Properties.Settings.Default.Save();
            if (language == (int)GlobalConstants.LanguageValue.English)
            {
                picEnglish.BackColor = Color.Yellow;
                picVietnamese.BackColor = Color.Transparent;
            }
            else
            {
                picVietnamese.BackColor = Color.Yellow;
                picEnglish.BackColor = Color.Transparent;
            }
        }

        private void picVietnamese_Click(object sender, EventArgs e)
        {
            LoadLanguage((int)GlobalConstants.LanguageValue.Vietnamese);
            LanguageTranslate.switchLanguage = true;
            LanguageTranslate.ChangeLanguageForm(this);
            LanguageTranslate.switchLanguage = false;
        }

        private void picEnglish_Click(object sender, EventArgs e)
        {
            LoadLanguage((int)GlobalConstants.LanguageValue.English);
            LanguageTranslate.switchLanguage = true;
            LanguageTranslate.ChangeLanguageForm(this);
            LanguageTranslate.switchLanguage = false;
        }
    }
}