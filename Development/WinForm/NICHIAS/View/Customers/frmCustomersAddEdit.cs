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

namespace NICHIAS.View.Customers
{
    public partial class frmCustomersAddEdit : XtraForm
    {
        ProjectDataContext _projectDataContext;
        CustomerRepository _customerRepository;

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

        public frmCustomersAddEdit()
        {
            InitializeComponent();
        }

        public frmCustomersAddEdit(string id)
        {
            InitializeComponent();
            _id = id;
        }

        private void frmCustomersAddEdit_Load(object sender, EventArgs e)
        {
            _projectDataContext = new ProjectDataContext();
            _customerRepository = new CustomerRepository(_projectDataContext);
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
            txtCustomerNo.Text = "";
            txtCustomerName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtNote.Text = "";
            chkUsing.Checked = true;
            txtCustomerNo.Focus();
        }

        private void GetData()
        {
            //Get Data Table Customer
            Customer customer = _customerRepository.Get(_id);
            txtCustomerNo.Text = customer.CustomerNo;
            txtCustomerName.Text = customer.CustomerName;
            txtPhone.Text = customer.Phone;
            txtAddress.Text = customer.Address;
            txtNote.Text = customer.Note;
            chkUsing.Checked = (customer.Status == GlobalConstants.StatusValue.Using);
        }

        private bool CheckData()
        {
            if (txtCustomerNo.Text.Trim() == "")
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Chưa điền dữ liệu"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerNo.Focus();
                return false;
            }
            else if (txtCustomerName.Text.Trim() == "")
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Chưa điền dữ liệu"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return false;
            }
            Customer customer = _customerRepository.FirstOrDefault(_ => _.CustomerNo.Equals(txtCustomerNo.Text.Trim()));
            if(customer != null &&
                (
                    String.IsNullOrEmpty(_id) ||
                    (!String.IsNullOrEmpty(_id) && txtCustomerNo.Text.Trim() != customer.CustomerNo)
                ))
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Dữ liệu đã tồn tại"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerNo.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckData()) return;
                //Table Customer
                Customer customer = new Customer();
                customer.Id = _id;
                customer.CustomerNo = txtCustomerNo.Text.Trim();
                customer.CustomerName = txtCustomerName.Text.Trim();
                customer.Phone = txtPhone.Text.Trim();
                customer.Address = txtAddress.Text.Trim();
                customer.Note = txtNote.Text.Trim();
                customer.Status = (chkUsing.Checked ? GlobalConstants.StatusValue.Using : GlobalConstants.StatusValue.NoUse);
                _customerRepository.Save(customer);
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