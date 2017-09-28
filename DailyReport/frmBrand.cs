using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyReport
{
    public partial class frmBrand : XtraForm
    {
        private DataTable _data;
        public frmBrand()
        {
            InitializeComponent();
            _data = new DataTable();
            _data.Columns.Add("Brand");
            _data.Columns.Add("BrandMain");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataRow dr = _data.NewRow();
            bool check = false;

            foreach (DataRow dr2 in _data.Rows)
            {
                if (dr2["Brand"].ToString() == txtBrand.Text.ToUpper().Trim())
                {
                    check = true;
                    
                }
            }
            if (!check)
            {
                dr["Brand"] = txtBrand.Text.ToUpper().Trim();
                dr["BrandMain"] = txtBrandMain.Text.ToUpper().Trim();
                _data.Rows.Add(dr);
                txtBrand.Text ="";
                BrandModel.SaveBrandToFile(_data);
                dtgBrand.DataSource = BrandModel.OpenBrandFromFile();
            }
            else
            {
                XtraMessageBox.Show("Brand đã có!");
            }     
        }

        private void frmBrand_Load(object sender, EventArgs e)
        {
            _data = BrandModel.OpenBrandFromFile();
            dtgBrand.DataSource = _data;
        }

        private void dtgBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                _data.Rows.RemoveAt(e.RowIndex);
                BrandModel.SaveBrandToFile(_data);
                dtgBrand.DataSource = _data;
            }
        }
    }
}
