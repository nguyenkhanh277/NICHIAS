using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NICHIAS.Core.Helper
{
    class LanguageTranslate
    {
        public static bool switchLanguage = false;
        public static void ChangeLanguageForm(XtraForm xtraForm)
        {
            xtraForm.Icon = Properties.Resources.icon;
            //xtraForm.Text = ChangeLanguageText(xtraForm.Text.Trim());
            //foreach (Control control in xtraForm.Controls)
            //{
            //    RecursivePocessing(control);
            //}
        }

        public static string ChangeLanguageText(string content)
        {
            string result = content;
            //if (content != "" && content != GlobalConstants.Company && GlobalConstants.languageLibrary.Count > 0)
            //{
            //    if (!String.IsNullOrEmpty(result))
            //    {
            //        if (switchLanguage && GlobalConstants.language == (int)GlobalConstants.LanguageValue.Vietnamese)
            //        {
            //            result = GlobalConstants.languageLibrary.Where(_ => _.English.Equals(content)).Select(_ => _.Vietnamese).FirstOrDefault();
            //        }
            //        else if (GlobalConstants.language == (int)GlobalConstants.LanguageValue.English)
            //        {
            //            result = GlobalConstants.languageLibrary.Where(_ => _.Vietnamese.Equals(content)).Select(_ => _.English).FirstOrDefault();
            //        }
            //    }
            //    if (String.IsNullOrEmpty(result))
            //    {
            //        result = content;
            //    }
            //}
            return result;
        }

        public static void ChangeLanguageGridView(GridView gridView)
        {
            foreach (GridColumn item in gridView.Columns)
            {
                item.Caption = ChangeLanguageText(item.Caption);
            }
        }

        public static void ChangeLanguageDataGridView(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Columns[i].HeaderText = ChangeLanguageText(dataGridView.Columns[i].HeaderText.Trim());
            }
        }

        public static void ChangeLanguageGroupControl(GroupControl groupControl)
        {
            foreach (Control control in groupControl.Controls)
            {
                RecursivePocessing(control);
            }
        }

        public static void ChangeLanguagePanelControl(PanelControl panelControl)
        {
            foreach (Control control in panelControl.Controls)
            {
                RecursivePocessing(control);
            }
        }

        private static void RecursivePocessing(Control x)
        {
            if (x is GroupControl)
            {
                x.Text = ChangeLanguageText(x.Text.Trim());
                ChangeLanguageGroupControl((GroupControl)x);
                return;
            }
            if (x is PanelControl)
            {
                ChangeLanguagePanelControl((PanelControl)x);
                return;
            }
            if (x is DateTimePicker)
            {
                return;
            }
            if (x is DateEdit)
            {
                return;
            }
            if (x is TimeEdit)
            {
                return;
            }
            try
            {
                x.Text = ChangeLanguageText(x.Text.Trim());
            }
            catch
            { }
        }
    }
}
