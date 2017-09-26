using System;
using System.Data;
using System.Linq;
using DevExpress.XtraEditors;
using System.Data.Linq;


namespace DailyReport.UControls
{
    public partial class UC_ImportFileExecuteDetail_2 : XtraUserControl
    {
        private DataTable _dataTable;
        public UC_ImportFileExecuteDetail_2()
        {
            InitializeComponent();
        }
        public UC_ImportFileExecuteDetail_2(DataTable dt)
        {
            InitializeComponent();
            _dataTable = dt;
        }

        private void UC_ImportFileExecuteDetail_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = _dataTable;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            //gridView1.SaveFileFromGridView();
        }
    }
}
