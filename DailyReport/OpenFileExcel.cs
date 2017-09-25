using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Windows.Forms;
using ExcelDataReader;
using System.IO;

namespace DailyReport
{
    public static class OpenFileExcel
    {
        public static DataTable getDataFromExcelToDataTable(string fileName, string selectSheet)
        {
            try
            {
                DataTable dt = new DataTable();
                string constr = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source=" + fileName.Trim() + "; Extended Properties = \"Excel 8.0; HDR=Yes;\";";
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
        public static Dictionary<string, object> getInfoFiles()
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
                        string str = (string)row["TABLE_NAME"];
                        lsData.Add("selectSheet" + i, str.Trim());
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

        public static List<Dictionary<string, object>> getDataFromExcelToList(string fileName, string selectSheet)
        {
            try
            {
                List<Dictionary<string, object>> lsData = new List<Dictionary<string, object>>();
                string constr = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source=" + fileName.Trim() + "; Extended Properties = \"Excel 8.0;HDR=YES;IMEX=1;MAXSCANROWS=15;READONLY=FALSE\";";
                OleDbConnection con = new OleDbConnection(constr);
                con.Open();
                //OleDbDataAdapter da = new OleDbDataAdapter("Select * from [" + selectSheet + "]", con);
                selectSheet = selectSheet.Substring(selectSheet.Length - 1, 1);
                OleDbCommand command = new OleDbCommand("Select * from[Sheet1$A1:LU2200]", con);
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    Dictionary<string, object> row = null;
                    while (reader.Read())
                    {
                        // this assumes just one column, and the value is text
                        string value = reader[i].ToString();
                        row = new Dictionary<string, object>();
                        row.Add("Column" + i, value);
                        i++;
                    }
                    lsData.Add(row);
                }
                return lsData;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
                return null;
            }

        }

        public static DataTable getDataExcelFromFileToDataTable(string filePath, string selectSheet)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    //Get all Table
                    DataTableCollection tables = result.Tables;
                    //Get Table
                    string sheet = selectSheet.Split('$')[0].ToString().Trim();
                    DataTable dt = tables[sheet];
                    return dt;
                }

            }
        }
    }
}

