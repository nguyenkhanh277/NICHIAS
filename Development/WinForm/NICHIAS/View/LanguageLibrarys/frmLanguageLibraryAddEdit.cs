using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NICHIAS.Persistence;
using NICHIAS.Persistence.Repositories;
using NICHIAS.Core.Domain;
using NICHIAS.Core.Helper;

namespace NICHIAS.View.LanguageLibrarys
{
    public partial class frmLanguageLibraryAddEdit : XtraForm
    {
        ProjectDataContext _projectDataContext;
        LanguageLibraryRepository _languageLibraryRepository;

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

        string _id = "";

        public frmLanguageLibraryAddEdit()
        {
            InitializeComponent();
        }

        public frmLanguageLibraryAddEdit(string id)
        {
            InitializeComponent();
            _id = id;
        }

        private void frmLanguageLibraryAddEdit_Load(object sender, EventArgs e)
        {
            _projectDataContext = new ProjectDataContext();
            _languageLibraryRepository = new LanguageLibraryRepository(_projectDataContext);
            LanguageTranslate.ChangeLanguageForm(this);
            if (String.IsNullOrEmpty(_id))
            {
                Clear();
            }
            else
            {
                GetData();
            }
        }

        private void Clear()
        {
            txtVietnamese.Text = "";
            txtEnglish.Text = "";
            txtVietnamese.Focus();
        }

        private void GetData()
        {
            //Get Data Table Language
            LanguageLibrary languageLibrary = _languageLibraryRepository.Get(_id);
            txtVietnamese.Text = languageLibrary.Vietnamese;
            txtEnglish.Text = languageLibrary.English;
        }

        private bool CheckData()
        {
            if (txtVietnamese.Text.Trim() == "")
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Chưa điền dữ liệu"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVietnamese.Focus();
                return false;
            }
            else if (txtEnglish.Text.Trim() == "")
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Chưa điền dữ liệu"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnglish.Focus();
                return false;
            }
            LanguageLibrary languageLibrary = _languageLibraryRepository.FirstOrDefault(_ => _.Vietnamese.Equals(txtVietnamese.Text.Trim()));
            if (languageLibrary != null &&
                (
                    String.IsNullOrEmpty(_id) ||
                    (!String.IsNullOrEmpty(_id) && txtVietnamese.Text.Trim() != languageLibrary.Vietnamese)
                ))
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Dữ liệu đã tồn tại"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVietnamese.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckData()) return;
                //Table Language
                LanguageLibrary languageLibrary = new LanguageLibrary();
                languageLibrary.Id = _id;
                languageLibrary.English = txtEnglish.Text.Trim();
                languageLibrary.Vietnamese = txtVietnamese.Text.Trim();
                _languageLibraryRepository.Save(languageLibrary);
                UnitOfWork unitOfWork = new UnitOfWork(_projectDataContext);
                int result = unitOfWork.Complete();
                if (result > 0)
                {
                    if (String.IsNullOrEmpty(_id))
                    {
                        XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Lưu thành công"), LanguageTranslate.ChangeLanguageText("Thông báo"));
                        Clear();
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
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
    }
}