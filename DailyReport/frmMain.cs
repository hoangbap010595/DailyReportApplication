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
        private string TitleApp = "Daily Report ";
        private string VersionApp = "2.0.0 ";
        public frmMain()
        {
            InitializeComponent();
            Text = TitleApp + VersionApp;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            panelControlMain.Controls.Clear();
            UC_ImportFileExecute frm = new UC_ImportFileExecute();
            //UC_InsertProduct frm = new UC_InsertProduct();
            frm.Dock = DockStyle.Fill;
            panelControlMain.Controls.Add(frm);
            //this.Size = new Size(1000, Screen.PrimaryScreen.Bounds.Height);
        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrand frm = new frmBrand();
            frm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
