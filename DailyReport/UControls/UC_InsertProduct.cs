using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

namespace DailyReport.UControls
{
    public partial class UC_InsertProduct : UserControl
    {
        private DataTable _dataTempView;
        public UC_InsertProduct()
        {
            InitializeComponent();
        }

        private void btnChooseFile1_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, object> data = OpenFileExcel.getInfoFiles();
                if (data != null)
                {
                    txtPathFile1.Text = data["fileName"].ToString();
                    data.Remove("fileName");
                    foreach (var item in data)
                    {
                        cbbSheet.Properties.Items.Add(item.Value.ToString().Trim(new char['\'']).Replace("\'",""));
                    }
                    cbbSheet.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { XtraMessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(() =>
            {
                executeInsert();
            }));
            t.Start();
        }

        private void executeInsert()
        {
            for (int i = 0; i < _dataTempView.Rows.Count; i++)
            {
                for (int j = 0; j < _dataTempView.Columns.Count; j++)
                {

                }
            }
        }

        private void cbbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dataTempView = new DataTable();
            string selectSheet = cbbSheet.Text;
            _dataTempView = OpenFileExcel.getDataExcelFromFileToDataTable(txtPathFile1.Text, selectSheet);
            gridControl1.DataSource = _dataTempView;
        }
    }
}
