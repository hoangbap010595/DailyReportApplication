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
    public partial class frmShowWindow : XtraForm
    {
        private XtraUserControl _uc;
        public frmShowWindow()
        {
            InitializeComponent();
        }
        public frmShowWindow(XtraUserControl uc)
        {
            InitializeComponent();
            _uc = uc;
            if (_uc != null)
            {
                _uc.Dock = DockStyle.Fill;
                this.Controls.Clear();
                this.Controls.Add(_uc);
            }
        }

        private void frmShowWindow_Load(object sender, EventArgs e)
        {
            
        }
    }
}
