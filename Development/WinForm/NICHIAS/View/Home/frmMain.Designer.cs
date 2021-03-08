using DevExpress.XtraBars;

namespace NICHIAS.View.Home
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.btnUsers = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.txtUser = new DevExpress.XtraBars.BarStaticItem();
            this.btnLanguageLibrary = new DevExpress.XtraBars.BarButtonItem();
            this.rgbiSkins = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.btnRegistOrder = new DevExpress.XtraBars.BarButtonItem();
            this.btnCar = new DevExpress.XtraBars.BarButtonItem();
            this.btnRoad = new DevExpress.XtraBars.BarButtonItem();
            this.btnDriver = new DevExpress.XtraBars.BarButtonItem();
            this.btnOwner = new DevExpress.XtraBars.BarButtonItem();
            this.btnListOrder = new DevExpress.XtraBars.BarButtonItem();
            this.btnSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnReportOrderCarsOwner = new DevExpress.XtraBars.BarButtonItem();
            this.btnReportOrderGoodsOwner = new DevExpress.XtraBars.BarButtonItem();
            this.btnReportOrderBothOwner = new DevExpress.XtraBars.BarButtonItem();
            this.btnReportOrderCost = new DevExpress.XtraBars.BarButtonItem();
            this.btnReportOrder = new DevExpress.XtraBars.BarButtonItem();
            this.btnCost = new DevExpress.XtraBars.BarButtonItem();
            this.btnCollectionFee = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrice = new DevExpress.XtraBars.BarButtonItem();
            this.btnOrderGBP = new DevExpress.XtraBars.BarButtonItem();
            this.btnOrderCost = new DevExpress.XtraBars.BarButtonItem();
            this.btnReportOrderChotSo = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpdateOilPrice = new DevExpress.XtraBars.BarButtonItem();
            this.rbpHeThong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpDanhMuc = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpChucNang = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpBaoCao = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.alertControl = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.CaptionBarItemLinks.Add(this.barStaticItem1);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem1,
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnUsers,
            this.btnChangePassword,
            this.txtUser,
            this.btnLanguageLibrary,
            this.rgbiSkins,
            this.btnRegistOrder,
            this.btnCar,
            this.btnRoad,
            this.btnDriver,
            this.btnOwner,
            this.btnListOrder,
            this.btnSetting,
            this.btnReportOrderCarsOwner,
            this.btnReportOrderGoodsOwner,
            this.btnReportOrderBothOwner,
            this.btnReportOrderCost,
            this.btnReportOrder,
            this.btnCost,
            this.btnCollectionFee,
            this.btnPrice,
            this.btnOrderGBP,
            this.btnOrderCost,
            this.btnReportOrderChotSo,
            this.btnUpdateOilPrice});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 60;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.txtUser);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpHeThong,
            this.rbpDanhMuc,
            this.rbpChucNang,
            this.rbpBaoCao});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1014, 143);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Phone: 08 8822 2329 - Email: contact@datatech.vn";
            this.barStaticItem1.Id = 42;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // btnUsers
            // 
            this.btnUsers.Caption = "Quản lý người dùng";
            this.btnUsers.Id = 11;
            this.btnUsers.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Users;
            this.btnUsers.LargeWidth = 100;
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUsers_ItemClick);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Caption = "Đổi mật khẩu";
            this.btnChangePassword.Id = 12;
            this.btnChangePassword.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.ChangePassword;
            this.btnChangePassword.LargeWidth = 100;
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangePassword_ItemClick);
            // 
            // txtUser
            // 
            this.txtUser.Caption = "     ";
            this.txtUser.Id = 18;
            this.txtUser.Name = "txtUser";
            // 
            // btnLanguageLibrary
            // 
            this.btnLanguageLibrary.Caption = "Ngôn ngữ";
            this.btnLanguageLibrary.Id = 19;
            this.btnLanguageLibrary.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Translate;
            this.btnLanguageLibrary.LargeWidth = 100;
            this.btnLanguageLibrary.Name = "btnLanguageLibrary";
            this.btnLanguageLibrary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLanguageLibrary_ItemClick);
            // 
            // rgbiSkins
            // 
            this.rgbiSkins.Caption = "Skins";
            // 
            // 
            // 
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseFont = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseTextOptions = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Hovered.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseTextOptions = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Pressed.Options.UseFont = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Pressed.Options.UseTextOptions = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Pressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rgbiSkins.Id = 13;
            this.rgbiSkins.Name = "rgbiSkins";
            this.rgbiSkins.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.rgbiSkins_GalleryItemClick);
            // 
            // btnRegistOrder
            // 
            this.btnRegistOrder.Caption = "Đăng ký kế hoạch";
            this.btnRegistOrder.Id = 26;
            this.btnRegistOrder.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.RegisterOrder;
            this.btnRegistOrder.LargeWidth = 100;
            this.btnRegistOrder.Name = "btnRegistOrder";
            // 
            // btnCar
            // 
            this.btnCar.Caption = "Xe";
            this.btnCar.Id = 31;
            this.btnCar.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Car;
            this.btnCar.LargeWidth = 100;
            this.btnCar.Name = "btnCar";
            // 
            // btnRoad
            // 
            this.btnRoad.Caption = "Tuyến vận chuyển";
            this.btnRoad.Id = 32;
            this.btnRoad.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Road;
            this.btnRoad.LargeWidth = 115;
            this.btnRoad.Name = "btnRoad";
            // 
            // btnDriver
            // 
            this.btnDriver.Caption = "Lái xe";
            this.btnDriver.Id = 33;
            this.btnDriver.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Driver;
            this.btnDriver.LargeWidth = 100;
            this.btnDriver.Name = "btnDriver";
            // 
            // btnOwner
            // 
            this.btnOwner.Caption = "Chủ hàng/Chủ xe";
            this.btnOwner.Id = 34;
            this.btnOwner.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Owner;
            this.btnOwner.LargeWidth = 100;
            this.btnOwner.Name = "btnOwner";
            // 
            // btnListOrder
            // 
            this.btnListOrder.Caption = "D/sách kế hoạch";
            this.btnListOrder.Id = 39;
            this.btnListOrder.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.ListOrder;
            this.btnListOrder.LargeWidth = 100;
            this.btnListOrder.Name = "btnListOrder";
            // 
            // btnSetting
            // 
            this.btnSetting.Caption = "Cấu hình";
            this.btnSetting.Id = 41;
            this.btnSetting.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Setting;
            this.btnSetting.LargeWidth = 100;
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSetting_ItemClick);
            // 
            // btnReportOrderCarsOwner
            // 
            this.btnReportOrderCarsOwner.Caption = "Bảng kê công nợ cho chủ xe";
            this.btnReportOrderCarsOwner.Id = 47;
            this.btnReportOrderCarsOwner.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Report1;
            this.btnReportOrderCarsOwner.LargeWidth = 100;
            this.btnReportOrderCarsOwner.Name = "btnReportOrderCarsOwner";
            // 
            // btnReportOrderGoodsOwner
            // 
            this.btnReportOrderGoodsOwner.Caption = "Bảng kê công nợ cho chủ hàng";
            this.btnReportOrderGoodsOwner.Id = 48;
            this.btnReportOrderGoodsOwner.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Report2;
            this.btnReportOrderGoodsOwner.LargeWidth = 100;
            this.btnReportOrderGoodsOwner.Name = "btnReportOrderGoodsOwner";
            // 
            // btnReportOrderBothOwner
            // 
            this.btnReportOrderBothOwner.Caption = "Bảng kê công nợ cho chủ hàng+xe";
            this.btnReportOrderBothOwner.Id = 49;
            this.btnReportOrderBothOwner.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Report3;
            this.btnReportOrderBothOwner.LargeWidth = 100;
            this.btnReportOrderBothOwner.Name = "btnReportOrderBothOwner";
            // 
            // btnReportOrderCost
            // 
            this.btnReportOrderCost.Caption = "Doanh thu theo xe";
            this.btnReportOrderCost.Id = 50;
            this.btnReportOrderCost.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Report4;
            this.btnReportOrderCost.LargeWidth = 100;
            this.btnReportOrderCost.Name = "btnReportOrderCost";
            // 
            // btnReportOrder
            // 
            this.btnReportOrder.Caption = "Doanh thu theo đại lý";
            this.btnReportOrder.Id = 51;
            this.btnReportOrder.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Report5;
            this.btnReportOrder.LargeWidth = 100;
            this.btnReportOrder.Name = "btnReportOrder";
            // 
            // btnCost
            // 
            this.btnCost.Caption = "Chi phí";
            this.btnCost.Id = 53;
            this.btnCost.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Cost;
            this.btnCost.LargeWidth = 100;
            this.btnCost.Name = "btnCost";
            this.btnCost.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnCollectionFee
            // 
            this.btnCollectionFee.Caption = "Thu hộ";
            this.btnCollectionFee.Id = 54;
            this.btnCollectionFee.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.CollectionFee;
            this.btnCollectionFee.LargeWidth = 100;
            this.btnCollectionFee.Name = "btnCollectionFee";
            this.btnCollectionFee.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnPrice
            // 
            this.btnPrice.Caption = "Cước vận chuyển";
            this.btnPrice.Id = 55;
            this.btnPrice.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Price;
            this.btnPrice.LargeWidth = 100;
            this.btnPrice.Name = "btnPrice";
            // 
            // btnOrderGBP
            // 
            this.btnOrderGBP.Caption = "Chung chuyển";
            this.btnOrderGBP.Id = 56;
            this.btnOrderGBP.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Road;
            this.btnOrderGBP.LargeWidth = 100;
            this.btnOrderGBP.Name = "btnOrderGBP";
            // 
            // btnOrderCost
            // 
            this.btnOrderCost.Caption = "D/sách chi phí";
            this.btnOrderCost.Id = 57;
            this.btnOrderCost.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Cost;
            this.btnOrderCost.LargeWidth = 100;
            this.btnOrderCost.Name = "btnOrderCost";
            // 
            // btnReportOrderChotSo
            // 
            this.btnReportOrderChotSo.Caption = "Chốt sổ";
            this.btnReportOrderChotSo.Id = 58;
            this.btnReportOrderChotSo.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Price;
            this.btnReportOrderChotSo.LargeWidth = 100;
            this.btnReportOrderChotSo.Name = "btnReportOrderChotSo";
            // 
            // btnUpdateOilPrice
            // 
            this.btnUpdateOilPrice.Caption = "Cập nhật giá dầu";
            this.btnUpdateOilPrice.Id = 59;
            this.btnUpdateOilPrice.ImageOptions.LargeImage = global::NICHIAS.Properties.Resources.Setting;
            this.btnUpdateOilPrice.LargeWidth = 100;
            this.btnUpdateOilPrice.Name = "btnUpdateOilPrice";
            // 
            // rbpHeThong
            // 
            this.rbpHeThong.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.rbpHeThong.Name = "rbpHeThong";
            this.rbpHeThong.Text = "Hệ thống";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnUsers);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnChangePassword);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLanguageLibrary);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSetting);
            this.ribbonPageGroup1.ItemLinks.Add(this.rgbiSkins);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // rbpDanhMuc
            // 
            this.rbpDanhMuc.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.rbpDanhMuc.Name = "rbpDanhMuc";
            this.rbpDanhMuc.Text = "Danh mục";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnOwner);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCar);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnDriver);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnRoad);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnPrice);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCost);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCollectionFee);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // rbpChucNang
            // 
            this.rbpChucNang.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.rbpChucNang.Name = "rbpChucNang";
            this.rbpChucNang.Text = "Chức năng";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnRegistOrder);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnOrderGBP);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnListOrder);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnOrderCost);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnReportOrderChotSo);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnUpdateOilPrice);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // rbpBaoCao
            // 
            this.rbpBaoCao.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.rbpBaoCao.Name = "rbpBaoCao";
            this.rbpBaoCao.Text = "Báo cáo";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnReportOrderCost);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnReportOrder);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnReportOrderCarsOwner);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnReportOrderGoodsOwner);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnReportOrderBothOwner);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // alertControl
            // 
            this.alertControl.AllowHotTrack = false;
            this.alertControl.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.alertControl.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.alertControl.AppearanceCaption.Options.UseFont = true;
            this.alertControl.AppearanceCaption.Options.UseForeColor = true;
            this.alertControl.AppearanceText.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.alertControl.AppearanceText.ForeColor = System.Drawing.Color.Red;
            this.alertControl.AppearanceText.Options.UseFont = true;
            this.alertControl.AppearanceText.Options.UseForeColor = true;
            this.alertControl.AppearanceText.Options.UseTextOptions = true;
            this.alertControl.AppearanceText.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.alertControl.AppearanceText.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.alertControl.AutoHeight = true;
            this.alertControl.BeforeFormShow += new DevExpress.XtraBars.Alerter.AlertFormEventHandler(this.alertControl_BeforeFormShow);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 379);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Chương trình chính";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpHeThong;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpChucNang;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpBaoCao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private BarButtonItem btnUsers;
        private BarButtonItem btnChangePassword;
        private BarStaticItem txtUser;
        private BarButtonItem btnLanguageLibrary;
        private RibbonGalleryBarItem rgbiSkins;
        private BarButtonItem btnRegistOrder;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private BarButtonItem btnCar;
        private BarButtonItem btnRoad;
        private BarButtonItem btnDriver;
        private BarButtonItem btnOwner;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpDanhMuc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private BarButtonItem btnListOrder;
        private BarButtonItem btnSetting;
        private BarStaticItem barStaticItem1;
        private BarButtonItem btnReportOrderCarsOwner;
        private BarButtonItem btnReportOrderGoodsOwner;
        private BarButtonItem btnReportOrderBothOwner;
        private BarButtonItem btnReportOrderCost;
        private BarButtonItem btnReportOrder;
        private BarButtonItem btnCost;
        private BarButtonItem btnCollectionFee;
        private BarButtonItem btnPrice;
        private BarButtonItem btnOrderGBP;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl;
        private BarButtonItem btnOrderCost;
        private BarButtonItem btnReportOrderChotSo;
        private BarButtonItem btnUpdateOilPrice;
    }
}

