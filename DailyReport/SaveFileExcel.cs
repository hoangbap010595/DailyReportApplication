using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.IO;
using System.Windows.Forms;

namespace DailyReport
{
    public static class SaveFileExcel
    {
        public static void SaveFileFromGridView(this GridView g)
        {
            try
            {
                if (g.RowCount != 0)
                {
                    string path = "";
                    SaveFileDialog saved = new SaveFileDialog();
                    saved.Filter = "Excel (*.xlsx)|*.xlsx|Excel (*.xls)|*.xls";

                    saved.FileName = "Report_"+DateTime.Now.ToString("ddMMyyyy") + "";
                    if (DialogResult.OK == saved.ShowDialog())
                    {
                        path = saved.FileName.ToString();
                        ExportTarget excel = ExportTarget.Xlsx;
                        g.BestFitColumns(true);
                        g.OptionsPrint.AutoWidth = false;
                        g.OptionsPrint.ExpandAllDetails = true;
                        g.OptionsPrint.PrintVertLines = false;
                        g.OptionsPrint.PrintHorzLines = false;
                        g.Export(excel, path);
                        if (DialogResult.OK == XtraMessageBox.Show("Mở file \"" + Path.GetFileName(path) + "\" ?", "", MessageBoxButtons.OKCancel))
                        {
                            System.Diagnostics.Process.Start(path);
                        }
                    }
                }
                else { XtraMessageBox.Show("Không có dữ liệu!", "Thông báo"); }
            }
            catch (Exception ex) { XtraMessageBox.Show("Lỗi: " + ex.Message, "Thông báo"); }
        }
    }
}
