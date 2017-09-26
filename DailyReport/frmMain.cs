using DailyReport.UControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DailyReport
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Controls.Clear();
            UC_ImportFileExecute frm = new UC_ImportFileExecute();
            //UC_InsertProduct frm = new UC_InsertProduct();
            frm.Dock = DockStyle.Fill;
            this.Controls.Add(frm);
        }
    }
}
