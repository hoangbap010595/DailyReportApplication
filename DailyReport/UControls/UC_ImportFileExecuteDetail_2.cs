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
            var items = _dataTable.AsEnumerable().GroupBy(
            x => new { Store = x.Field<string>("Store"), BrandMain = x.Field<string>("BrandMain") }
            ).Select
            (
                n => new
                {
                    Store = n.Key.Store,
                    BrandMain = n.Key.BrandMain,
                    TotalQty = Convert.ToInt32(n.Sum(z => Convert.ToInt32(z.Field<string>("Qty")))),
                    TotalAmount = Convert.ToInt32(n.Sum(z => Convert.ToInt32(z.Field<string>("Amount")))),
                    Discount = Convert.ToInt32(n.Sum(z => Convert.ToInt32(z.Field<string>("Discount")))),
                    TotalNetAmount = Convert.ToInt32(n.Sum(z => Convert.ToInt32(z.Field<string>("Amount"))) - n.Sum(z => Convert.ToInt32(z.Field<string>("Discount")))),
                }
            ).OrderBy(x=>x.Store)
            .ToList();

            //DataTable dtResult = new DataTable();

            gridControl1.DataSource = items;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            gridView1.SaveFileFromGridView();
        }
    }
}
