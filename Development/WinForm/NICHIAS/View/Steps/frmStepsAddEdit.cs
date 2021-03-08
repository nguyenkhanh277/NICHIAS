using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NICHIAS.Persistence;
using NICHIAS.Persistence.Repositories;
using NICHIAS.Core.Domain;
using NICHIAS.Core;
using NICHIAS.Core.Helper;

namespace NICHIAS.View.Steps
{
    public partial class frmStepsAddEdit : XtraForm
    {
        ProjectDataContext _projectDataContext;
        StepRepository _stepRepository;

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

        public frmStepsAddEdit()
        {
            InitializeComponent();
        }

        public frmStepsAddEdit(string id)
        {
            InitializeComponent();
            _id = id;
        }

        private void frmStepsAddEdit_Load(object sender, EventArgs e)
        {
            _projectDataContext = new ProjectDataContext();
            _stepRepository = new StepRepository(_projectDataContext);
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
            txtStepNo.Value = 0;
            txtStepName.Text = "";
            txtNote.Text = "";
            chkUsing.Checked = true;
            txtStepNo.Focus();
        }

        private void GetData()
        {
            //Get Data Table Step
            Step step = _stepRepository.Get(_id);
            txtStepNo.Value = step.StepNo;
            txtStepName.Text = step.StepName;
            chkRequestScanInYes.Checked = (step.RequestScanIn == GlobalConstants.RequestScanValue.Yes);
            chkRequestScanOutYes.Checked = (step.RequestScanOut == GlobalConstants.RequestScanValue.Yes);
            txtNote.Text = step.Note;
            chkUsing.Checked = (step.Status == GlobalConstants.StatusValue.Using);
        }

        private bool CheckData()
        {
            if (txtStepNo.Value == 0)
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Chưa điền dữ liệu"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStepNo.Focus();
                return false;
            }
            else if (txtStepName.Text.Trim() == "")
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Chưa điền dữ liệu"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStepName.Focus();
                return false;
            }
            Step step = _stepRepository.FirstOrDefault(_ => _.StepNo.Equals(txtStepNo.Value));
            if(step != null &&
                (
                    String.IsNullOrEmpty(_id) ||
                    (!String.IsNullOrEmpty(_id) && txtStepNo.Value != step.StepNo)
                ))
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Dữ liệu đã tồn tại"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStepNo.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckData()) return;
                //Table Step
                Step step = new Step();
                step.Id = _id;
                step.StepNo = (int)txtStepNo.Value;
                step.StepName = txtStepName.Text.Trim();
                step.RequestScanIn = (chkRequestScanInYes.Checked ? GlobalConstants.RequestScanValue.Yes : GlobalConstants.RequestScanValue.No);
                step.RequestScanOut = (chkRequestScanOutYes.Checked ? GlobalConstants.RequestScanValue.Yes : GlobalConstants.RequestScanValue.No);
                step.Note = txtNote.Text.Trim();
                step.Status = (chkUsing.Checked ? GlobalConstants.StatusValue.Using : GlobalConstants.StatusValue.NoUse);
                _stepRepository.Save(step);
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

        private void chkRequestScanInYes_CheckedChanged(object sender, EventArgs e)
        {
            chkRequestScanInNo.Checked = !chkRequestScanInYes.Checked;
        }

        private void chkRequestScanOutYes_CheckedChanged(object sender, EventArgs e)
        {
            chkRequestScanOutNo.Checked = !chkRequestScanOutYes.Checked;
        }

        private void chkUsing_CheckedChanged(object sender, EventArgs e)
        {
            chkNoUse.Checked = !chkUsing.Checked;
        }
    }
}