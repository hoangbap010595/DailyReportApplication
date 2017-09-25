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

namespace DailyReport.UControls
{
    public partial class UC_ImportFileExecuteDetail : XtraUserControl
    {
        private DataTable _dataTable;
        public UC_ImportFileExecuteDetail()
        {
            InitializeComponent();
        }
        public UC_ImportFileExecuteDetail(DataTable dt)
        {
            InitializeComponent();
            _dataTable = dt;
        }

        private void UC_ImportFileExecuteDetail_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = _dataTable;
        }
    }
}
