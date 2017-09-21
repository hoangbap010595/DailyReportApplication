using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyReport
{
    public static class OpenFileExcel
    {
        public static DataTable getDataFromExcel(string path, string selectSheet)
        {
            try
            {
                DataTable dt = new DataTable();
                string constr = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source=" + path.Trim() + "; Extended Properties = \"Excel 8.0; HDR=Yes;\";";
                OleDbConnection con = new OleDbConnection(constr);
                OleDbDataAdapter da = new OleDbDataAdapter("Select * from [" + selectSheet + "]", con);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }

        public static Dictionary<string, object> getInfoFile()
        {
            Dictionary<string, object> lsData = new Dictionary<string, object>();
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "Excel .xlsx|*.xlsx|Excel .xls|*.xls";
                if (DialogResult.OK == op.ShowDialog())
                {
                    lsData.Clear();
                    string constr = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source=" + op.FileName.Trim() + "; Extended Properties = \"Excel 8.0; HDR=Yes; IMEX=1;\";";
                    DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
                    DbConnection con = factory.CreateConnection();
                    con.ConnectionString = constr;
                    con.Open();
                    DataTable dt = con.GetSchema("Tables");
                    con.Close();

                    lsData.Add("fileName", op.FileName.Trim());

                    int i = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (i == 1)
                        {
                            string str = (string)row["TABLE_NAME"];
                            lsData.Add("selectSheet", str.Trim());
                        }
                        i++;
                    }
                }
                return lsData;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }
    }
}
