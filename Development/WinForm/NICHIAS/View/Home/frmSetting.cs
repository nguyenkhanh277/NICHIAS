using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NICHIAS.Core.Helper;
using System.Drawing.Printing;
using NICHIAS.Persistence.Repositories;
using NICHIAS.Persistence;
using NICHIAS.Core.Domain;

namespace NICHIAS.View.Home
{
    public partial class frmSetting : XtraForm
    {
        ProjectDataContext _projectDataContext;
        SettingMasterRepository _settingMasterRepository;
        string _id = "1";
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            _projectDataContext.Dispose();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs e = new KeyEventArgs(keyData);
            if (e.KeyCode == Keys.F1)
            {
                btnSave_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public frmSetting()
        {
            InitializeComponent();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            _projectDataContext = new ProjectDataContext();
            _settingMasterRepository = new SettingMasterRepository(_projectDataContext);
            LanguageTranslate.ChangeLanguageForm(this);
            GetData();
        }

        private void GetData()
        {
            SettingMaster settingMaster = _settingMasterRepository.Get(_id);
            if (settingMaster != null)
            {
                txtCompany.Text = settingMaster.Company;
                txtAddress.Text = settingMaster.Address;
                txtPhone.Text = settingMaster.Phone;
                txtTaxCode.Text = settingMaster.TaxCode;
            }
            else
            {
                _id = "";
                txtCompany.Text = "";
                txtAddress.Text = "";
                txtPhone.Text = "";
                txtTaxCode.Text = "";
            }
        }

        private bool CheckData()
        {
            if (txtCompany.Text.Trim() == "")
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Chưa điền dữ liệu"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCompany.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            try
            {
                if (!CheckData()) return;
                _projectDataContext = new ProjectDataContext();
                _settingMasterRepository = new SettingMasterRepository(_projectDataContext);
                //Table SettingMaster
                SettingMaster settingMaster = new SettingMaster();
                settingMaster.Id = _id;
                settingMaster.Company = txtCompany.Text.Trim();
                settingMaster.Address = txtAddress.Text.Trim();
                settingMaster.Phone = txtPhone.Text.Trim();
                settingMaster.TaxCode = txtTaxCode.Text.Trim();
                _settingMasterRepository.Save(settingMaster);
                UnitOfWork unitOfWork = new UnitOfWork(_projectDataContext);
                int result = unitOfWork.Complete();
                if (result > 0)
                {
                    XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Lưu thành công"), LanguageTranslate.ChangeLanguageText("Thông báo"));
                    Close();
                }
                else
                {
                    XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Lưu thất bại"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Lưu thất bại"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SelectAll(object sender, EventArgs e)
        {
            ((SpinEdit)sender).SelectAll();
        }
    }
}