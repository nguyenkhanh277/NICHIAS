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

namespace NICHIAS.View.Machines
{
    public partial class frmMachinesAddEdit : XtraForm
    {
        ProjectDataContext _projectDataContext;
        MachineRepository _machineRepository;

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

        public frmMachinesAddEdit()
        {
            InitializeComponent();
        }

        public frmMachinesAddEdit(string id)
        {
            InitializeComponent();
            _id = id;
        }

        private void frmMachinesAddEdit_Load(object sender, EventArgs e)
        {
            _projectDataContext = new ProjectDataContext();
            _machineRepository = new MachineRepository(_projectDataContext);
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
            txtMachineNo.Value = 0;
            txtMachineName.Text = "";
            txtNote.Text = "";
            chkUsing.Checked = true;
            txtMachineNo.Focus();
        }

        private void GetData()
        {
            //Get Data Table Machine
            Machine machine = _machineRepository.Get(_id);
            txtMachineNo.Value = machine.MachineNo;
            txtMachineName.Text = machine.MachineName;
            txtNote.Text = machine.Note;
            chkUsing.Checked = (machine.Status == GlobalConstants.StatusValue.Using);
        }

        private bool CheckData()
        {
            if (txtMachineNo.Value == 0)
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Chưa điền dữ liệu"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMachineNo.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(_id) && txtMachineName.Text.Trim() == "")
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Chưa điền dữ liệu"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMachineName.Focus();
                return false;
            }
            Machine machine = _machineRepository.FirstOrDefault(_ => _.MachineNo.Equals(txtMachineNo.Value));
            if(machine != null &&
                (
                    String.IsNullOrEmpty(_id) ||
                    (!String.IsNullOrEmpty(_id) && txtMachineNo.Value != machine.MachineNo)
                ))
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Dữ liệu đã tồn tại"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMachineNo.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckData()) return;
                //Table Machine
                Machine machine = new Machine();
                machine.Id = _id;
                machine.MachineNo = (int)txtMachineNo.Value;
                machine.MachineName = txtMachineName.Text.Trim();
                machine.Note = txtNote.Text.Trim();
                machine.Status = (chkUsing.Checked ? GlobalConstants.StatusValue.Using : GlobalConstants.StatusValue.NoUse);
                _machineRepository.Save(machine);
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

        private void chkUsing_CheckedChanged(object sender, EventArgs e)
        {
            chkNoUse.Checked = !chkUsing.Checked;
        }
    }
}