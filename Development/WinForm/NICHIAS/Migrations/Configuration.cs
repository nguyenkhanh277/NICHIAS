using NICHIAS.Core.Domain;
using NICHIAS.Persistence;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NICHIAS.Migrations
{
    using NICHIAS.Core;
    using NICHIAS.Core.Helper;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<NICHIAS.Persistence.ProjectDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectDataContext projectDataContext)
        {
            FirstUpdate(projectDataContext);
            AddOrUpdateLanguageLibrary(projectDataContext);
            
        }

        private void AddOrUpdateLanguageLibrary(ProjectDataContext projectDataContext)
        {
            #region LanguageLibrary
            var languageLibrarys = new List<LanguageLibrary>
            {
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Bạn không có quyền sử dụng chức năng này",
                    English = "You do not have permission to use this function",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Ứng dụng cần kết nối mạng để kích hoạt",
                    English = "The application requires a network connection to activate",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Ứng dụng cần quyền Quản trị để kích hoạt",
                    English = "Application needs Admin rights to activate",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Đăng ký sử dụng phần mềm",
                    English = "Register to use the software",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Dùng thử",
                    English = "Trial",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Dùng thử cho 1 máy tính",
                    English = "Try it on 1 computer",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Bản quyền",
                    English = "License",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Mã sản phẩm",
                    English = "Product code",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Ngày kích hoạt",
                    English = "Activation date",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Ngày hết hạn",
                    English = "Expiration date",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Còn lại",
                    English = "Left day",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Sau thời gian chỉ định chương trình sẽ bị vô hiệu",
                    English = "After the specified time the program will be disabled",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Để tiếp tục sử dụng, bạn nên mua giấy phép",
                    English = "To continue using, you should purchase a license",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Tên công ty",
                    English = "Company name",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Cấu hình",
                    English = "Setting",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Ngày",
                    English = "DateTime",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Từ ngày",
                    English = "FromDate",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Đến ngày",
                    English = "ToDate",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "In thất bại",
                    English = "Print failed",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Thông báo",
                    English = "Notification",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Xác nhận",
                    English = "Confirmation",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Đăng nhập",
                    English = "Sign In",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Tài khoản",
                    English = "Username",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Mật khẩu",
                    English = "Password",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Lưu thông tin đăng nhập",
                    English = "Keep me signed in",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Quên mật khẩu",
                    English = "I forgot my password",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Mật khẩu không đúng",
                    English = "Incorrect password",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Tài khoản không tồn tại",
                    English = "Username does not exist",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Chương trình chính",
                    English = "Main Menu",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Hệ thống",
                    English = "System",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Danh mục",
                    English = "Category",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Chức năng",
                    English = "Function",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Báo cáo",
                    English = "Report",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Quản lý người dùng",
                    English = "User management",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Người dùng",
                    English = "User",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Đổi mật khẩu",
                    English = "Change password",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Ngôn ngữ",
                    English = "Language",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Mật khẩu cũ",
                    English = "Old password",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Mật khẩu mới",
                    English = "New password",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Xác nhận mật khẩu",
                    English = "Confirm password",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Thư viện ngôn ngữ",
                    English = "Language Library",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Thêm (F1)",
                    English = "Add (F1)",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Sửa (F2)",
                    English = "Edit (F2)",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Xóa (F3)",
                    English = "Del (F3)",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Excel (F4)",
                    English = "Excel (F4)",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Lọc (F5)",
                    English = "Refresh (F5)",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Lưu (F1)",
                    English = "Save (F1)",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Đóng (ESC)",
                    English = "Close (ESC)",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Trạng thái",
                    English = "Status",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Tất cả",
                    English = "All",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Sử dụng",
                    English = "Using",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Bị hủy",
                    English = "No Use",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Giới tính",
                    English = "Gender",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Nam",
                    English = "Male",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Nữ",
                    English = "Female",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Tên đầy đủ",
                    English = "FullName",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Điện thoại",
                    English = "Phone",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Địa chỉ",
                    English = "Address",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Ghi chú",
                    English = "Note",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Chọn",
                    English = "Select",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Mã",
                    English = "ID",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Nhóm quyền",
                    English = "Authority Group",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Tiếng Việt",
                    English = "Vietnamese",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Tiếng Anh",
                    English = "English",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Chức năng chương trình",
                    English = "Program Function Master",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Chương trình",
                    English = "Program",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Diễn giải",
                    English = "Explanation",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Chưa điền dữ liệu",
                    English = "No data entered",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Chưa chọn dữ liệu",
                    English = "No data selected",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Dữ liệu đã tồn tại",
                    English = "Data already exists",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Dữ liệu không đúng",
                    English = "The data is incorrect",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Lưu thành công",
                    English = "Save successfully",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Lưu thất bại",
                    English = "Save failed",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Bạn có muốn hủy thông tin này?",
                    English = "Do you want to cancel this information?",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Bạn có muốn xóa thông tin này?",
                    English = "Do you want to delete this information?",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Hủy thất bại",
                    English = "Cancel failed",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                },
                new LanguageLibrary
                {
                    Id = Guid.NewGuid().ToString(),
                    Vietnamese = "Xóa thất bại",
                    English = "Delete failed",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                }
            };

            foreach (var languageLibrary in languageLibrarys)
                projectDataContext.LanguageLibrarys.AddOrUpdate(a => a.Id, languageLibrary);
            #endregion
        }
        private void FirstUpdate(ProjectDataContext projectDataContext)
        {
            //return;
            string defaultPassword = "1";
            string salt = SecurityHelper.CreateSalt(GlobalConstants.defaultSaltLength);
            string encryptedPassword = SecurityHelper.GenerateMD5(defaultPassword, salt);


            #region Add SettingMaster
            var settingMasters = new List<SettingMaster>
            {
                new SettingMaster
                {
                    Id = "1",
                    Company = "CÔNG TY NICHIAS",
                    Address = "",
                    TaxCode = "",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                }
            };

            foreach (var settingMaster in settingMasters)
                projectDataContext.SettingMasters.Add(settingMaster);
            #endregion


            #region Add Users
            string userAdmin = Guid.NewGuid().ToString();
            var users = new List<User>
            {
                new User
                {
                    Id = userAdmin,
                    Username = "admin",
                    Salt = salt,
                    Password = encryptedPassword,
                    FullName = "Administrator",
                    Gender = GlobalConstants.GenderValue.Male,
                    Status = GlobalConstants.StatusValue.Using,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                }
            };

            foreach (var user in users)
                projectDataContext.Users.AddOrUpdate(a => a.Id, user);
            #endregion


            #region Add AuthorityGroup
            var authorityGroups = new List<AuthorityGroup>
            {
                new AuthorityGroup
                {
                    Id = GlobalConstants.AuthorityGroupValue.Admin,
                    AuthorityGroupName = "Quyền admin",
                    Sort = 0,
                    Status = GlobalConstants.StatusValue.Using,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                }
            };

            foreach (var authorityGroup in authorityGroups)
                projectDataContext.AuthorityGroups.Add(authorityGroup);
            #endregion


            #region Add UserAuthority
            var userAuthoritys = new List<UserAuthority>
            {
                new UserAuthority
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = userAdmin,
                    AuthorityGroupId = GlobalConstants.AuthorityGroupValue.Admin,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Administrator"
                }
            };

            foreach (var userAuthority in userAuthoritys)
                projectDataContext.UserAuthoritys.AddOrUpdate(a => a.Id, userAuthority);
            #endregion
        }
    }
}