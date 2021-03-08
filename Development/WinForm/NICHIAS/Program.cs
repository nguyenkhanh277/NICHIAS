using DevExpress.XtraEditors;
using NICHIAS.Core;
using NICHIAS.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NICHIAS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Persistence.ProjectDataContext _projectDataContext = new Persistence.ProjectDataContext();
            Persistence.Repositories.LanguageLibraryRepository _languageLibraryRepository = new Persistence.Repositories.LanguageLibraryRepository(_projectDataContext);
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.Theme);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GlobalConstants.languageLibrary = _languageLibraryRepository.GetAll().ToList();
            GlobalConstants.language = Properties.Settings.Default.Language;
            License();
        }

        static void License()
        {
            if (!GlobalConstants.debugMode)
            {
                DialogResult dr;
                GlobalConstants.license = new Registration.Core.License.kLicense();
                Registration.Core.License.kLicenseType lic_type = Registration.Core.License.kLicenseType.Inactive;
                try
                {
                    Registration.Fusion.Library.kKeycode keycode = new Registration.Fusion.Library.kKeycode()
                    {
                        Prefix = GlobalConstants.keySoft,
                        Salt = GlobalConstants.saltSoft + GlobalConstants.keySoft,
                        ProductType = Registration.Fusion.Library.kProductType.Both,
                        SerialType = Registration.Fusion.Library.kSerialType.Rev2
                    };
                    GlobalConstants.license.Keycode = keycode;
                    GlobalConstants.license.FileName = GlobalConstants.keySoft + ".set";
                    GlobalConstants.license.TrialKeyUsed = @"SOFTWARE\WindowsNT\" + GlobalConstants.keySoft;
                    lic_type = GlobalConstants.license.IsLicensed(false);
                }
                catch
                { }
                switch (lic_type)
                {
                    default:
                    case Registration.Core.License.kLicenseType.Inactive:
                    case Registration.Core.License.kLicenseType.Incorrect:
                        if (!Registration.Fusion.Library.kNetwork.IsInternetConnected())
                        {
                            XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Ứng dụng cần kết nối mạng để kích hoạt"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        if (!Registration.Core.Uc.kForm.IsRunAsAdministrator())
                        {
                            dr = XtraMessageBox.Show(LanguageTranslate.ChangeLanguageText("Ứng dụng cần quyền Quản trị để kích hoạt"), LanguageTranslate.ChangeLanguageText("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (dr != DialogResult.OK)
                            {
                                return;
                            }
                            return;
                        }
                        Registration.Core.License.frmLicense frmLicense = new Registration.Core.License.frmLicense();
                        frmLicense.License = GlobalConstants.license;
                        frmLicense.BuyLicenseUrl = "http://datatech.vn/";
                        frmLicense.Text = LanguageTranslate.ChangeLanguageText("Đăng ký sử dụng phần mềm") + " " + GlobalConstants.Company;
                        frmLicense.TrialDateLimit = Registration.Fusion.Library.kDateLimit.Thirty;
                        frmLicense.IsOnlineActivationCheck = false;
                        frmLicense.Icon = Properties.Resources.icon;
                        dr = frmLicense.ShowDialog();
                        break;
                    case Registration.Core.License.kLicenseType.Trial:
                    case Registration.Core.License.kLicenseType.Expired:
                        View.Home.frmLicenses frm = new View.Home.frmLicenses();
                        dr = frm.ShowDialog();
                        break;
                    case Registration.Core.License.kLicenseType.Serial:
                        dr = DialogResult.OK;
                        break;
                }
                if (dr != DialogResult.OK)
                {
                    Environment.Exit(1);
                    return;
                }
            }
            Login();
        }

        static void Login()
        {
            View.Home.frmSignIn frm = new View.Home.frmSignIn();
            DialogResult dr = frm.ShowDialog();
            if (dr != DialogResult.OK)
            {
                Application.Exit();
                return;
            }
            Application.Run(new View.Home.frmMain());
        }
    }
}
