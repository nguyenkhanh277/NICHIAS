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

namespace NICHIAS.View.Products
{
    public partial class frmProductsAddEdit : XtraForm
    {
        ProjectDataContext _projectDataContext;
        ProductRepository _productRepository;
        AuthorityGroupRepository _authorityGroupRepository;
        ProductAuthorityRepository _productAuthorityRepository;

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

        public frmProductsAddEdit()
        {
            InitializeComponent();
        }

        public frmProductsAddEdit(string id)
        {
            InitializeComponent();
            _id = id;
        }

        private void frmProductsAddEdit_Load(object sender, EventArgs e)
        {
            _projectDataContext = new ProjectDataContext();
            _productRepository = new ProductRepository(_projectDataContext);
            _authorityGroupRepository = new AuthorityGroupRepository(_projectDataContext);
            _productAuthorityRepository = new ProductAuthorityRepository(_projectDataContext);
            LanguageTranslate.ChangeLanguageForm(this);
            LanguageTranslate.ChangeLanguageDataGridView(dgvDuLieu);
            if (String.IsNullOrEmpty(_id))
            {
                Clear();
            }
            else
            {
                GetData();
            }
            LoadAuthority();
        }

        private void Clear()
        {
            txtProductname.Text = "";
            txtPassword.Text = "";
            txtPassword.Enabled = true;
            txtFullName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            chkMale.Checked = true;
            txtNote.Text = "";
            chkUsing.Checked = true;
            txtProductname.Focus();
        }

        private void GetData()
        {
            //Get Data Table Product
            Product product = _productRepository.Get(_id);
            txtProductname.Text = product.Productname;
            txtPassword.Text = "";
            txtPassword.Enabled = false;
            txtFullName.Text = product.FullName;
            txtPhone.Text = product.Phone;
            txtAddress.Text = product.Address;
            chkMale.Checked = (product.Gender == GlobalConstants.GenderValue.Male);
            txtNote.Text = product.Note;
            chkUsing.Checked = (product.Status == GlobalConstants.StatusValue.Using);
        }

        private void LoadAuthority()
        {
            var authorityGroups = _authorityGroupRepository.Find(_ => _.Status == GlobalConstants.StatusValue.Using).OrderBy(_ => _.Sort);
            var productAuthoritys = _productAuthorityRepository.Find(_ => _.ProductId.Equals(_id));

            dgvDuLieu.Rows.Clear();
            int check = 0;
            foreach (var authorityGroup in authorityGroups)
            {
                check = 0;
                foreach (var programFunctionAuthority in productAuthoritys)
                {
                    if (programFunctionAuthority.AuthorityGroupId == authorityGroup.Id)
                    {
                        check = 1;
                        break;
                    }
                }
                object[] rowAdd = { check, authorityGroup.Id, authorityGroup.AuthorityGroupName };
                dgvDuLieu.Rows.Add(rowAdd);
            }
        }

        private bool CheckData()
        {
            if (txtProductname.Text.Trim() == "")
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Chưa điền dữ liệu"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductname.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(_id) && txtPassword.Text.Trim() == "")
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Chưa điền dữ liệu"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }
            else if (txtFullName.Text.Trim() == "")
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Chưa điền dữ liệu"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }
            Product product = _productRepository.FirstOrDefault(_ => _.Productname.Equals(txtProductname.Text.Trim()));
            if(product != null &&
                (
                    String.IsNullOrEmpty(_id) ||
                    (!String.IsNullOrEmpty(_id) && txtProductname.Text.Trim() != product.Productname)
                ))
            {
                XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Dữ liệu đã tồn tại"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckData()) return;
                //Table Product
                Product product = new Product();
                product.Id = _id;
                product.Productname = txtProductname.Text.Trim();
                product.Password = txtPassword.Text.Trim();
                product.FullName = txtFullName.Text.Trim();
                product.Phone = txtPhone.Text.Trim();
                product.Address = txtAddress.Text.Trim();
                product.Gender = (chkMale.Checked ? GlobalConstants.GenderValue.Male : GlobalConstants.GenderValue.Female);
                product.Note = txtNote.Text.Trim();
                product.Status = (chkUsing.Checked ? GlobalConstants.StatusValue.Using : GlobalConstants.StatusValue.NoUse);
                _productRepository.Save(product);
                if (!String.IsNullOrEmpty(_productRepository.id))
                {
                    _productAuthorityRepository.DeleteByProductId(_productRepository.id);
                    for (int i = 0; i < dgvDuLieu.RowCount; i++)
                    {
                        if (dgvDuLieu.Rows[i].Cells["Assign"].Value.ToString() == "1")
                        {
                            ProductAuthority productAuthority = new ProductAuthority();
                            GlobalConstants.AuthorityGroupValue authorityGroupId;
                            Enum.TryParse<GlobalConstants.AuthorityGroupValue>(dgvDuLieu.Rows[i].Cells["Id"].Value.ToString(), out authorityGroupId);
                            productAuthority.AuthorityGroupId = authorityGroupId;
                            productAuthority.ProductId = _productRepository.id;
                            _productAuthorityRepository.Save(productAuthority);
                        }
                    }
                }
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

        private void chkMale_CheckedChanged(object sender, EventArgs e)
        {
            chkFemale.Checked = !chkMale.Checked;
        }

        private void chkUsing_CheckedChanged(object sender, EventArgs e)
        {
            chkNoUse.Checked = !chkUsing.Checked;
        }
    }
}