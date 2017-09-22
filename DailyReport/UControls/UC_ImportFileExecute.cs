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
    public partial class UC_ImportFileExecute : XtraUserControl
    {
        private DataTable dataFile1;
        private DataTable dataFile2;
        private DataTable dataFile3;
        private DataTable dataFileTotal;
        public UC_ImportFileExecute()
        {
            InitializeComponent();
            dataFile1 = new DataTable();
            dataFile2 = new DataTable();
            dataFile3 = new DataTable();
        }
        private void creatTable()
        {
            dataFileTotal = new DataTable();

            dataFileTotal.Columns.Add("STT");
            dataFileTotal.Columns.Add("Store");
            dataFileTotal.Columns.Add("Inventory");
            dataFileTotal.Columns.Add("Brand");
            dataFileTotal.Columns.Add("Category");
            dataFileTotal.Columns.Add("Model");
            dataFileTotal.Columns.Add("Code");
            dataFileTotal.Columns.Add("Qty");
            dataFileTotal.Columns.Add("Amount");

            lsLog.Items.Clear();
        }
        private void btnChooseFile1_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> data = OpenFileExcel.getInfoFile();
            if (data != null)
            {
                txtPathFile1.Text = data["fileName"].ToString();
                string selectSheet = data["selectSheet"].ToString();
                //checkExistsFile();
                dataFile1 = OpenFileExcel.getDataExcelFromFileToDataTable(data["fileName"].ToString());
            }
        }

        private void btnChooseFile2_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> data = OpenFileExcel.getInfoFile();
            if (data != null)
            {
                txtPathFile2.Text = data["fileName"].ToString();
                string selectSheet = data["selectSheet"].ToString();
                checkExistsFile();
                dataFile2 = OpenFileExcel.getDataExcelFromFileToDataTable(data["fileName"].ToString());
                List<Dictionary<string, object>> data2 = OpenFileExcel.getDataFromExcelToList(data["fileName"].ToString(), selectSheet);
            }
        }

        private void btnChooseFile3_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> data = OpenFileExcel.getInfoFile();
            if (data != null)
            {
                txtPathFile3.Text = data["fileName"].ToString();
                string selectSheet = data["selectSheet"].ToString();
                checkExistsFile();
                dataFile3 = OpenFileExcel.getDataExcelFromFileToDataTable(data["fileName"].ToString());
            }
        }

        private void checkExistsFile()
        {
            if (txtPathFile1.Text.Trim() != "" && txtPathFile2.Text.Trim() != "" && txtPathFile3.Text.Trim() != "")
                btnExecuteData.Enabled = true;
        }

        private void setText(Control a, string text)
        {
            a.Invoke((MethodInvoker)delegate { a.Text = text; });
        }
        private void setProgessBar(ProgressBarControl p, string text)
        {
            p.Invoke((MethodInvoker)delegate { p.Position++; });
        }
        private void btnExecuteData_Click(object sender, EventArgs e)
        {
            creatTable();
            int maxProBar1 = dataFile1.Rows.Count - 2;
            int maxProBar2 = dataFile2.Rows.Count - 2;
            int maxProBar3 = dataFile3.Rows.Count - 2;

            proBar1.Properties.Maximum = maxProBar1;
            proBar2.Properties.Maximum = maxProBar2;
            proBar3.Properties.Maximum = maxProBar3;

            lblTitle.Text = dataFile1.Columns.Count.ToString();
            Thread t = new Thread(new ThreadStart(() =>
            {
                executeDataTable1();
            }));
            t.Start();
            Thread t2 = new Thread(new ThreadStart(() =>
            {
                executeDataTable2();
            }));
            t2.Start();
            Thread t3 = new Thread(new ThreadStart(() =>
            {
                executeDataTable3();
            }));
            t3.Start();
        }
        private void executeDataTable1()
        {
           
            DataRow dr = dataFileTotal.NewRow();
            string strInventory = "";
            string strBrand = "";
            string strCategory = "";
            string strModel = "";
            string strCode = "";

            for (int i = 2; i < dataFile1.Rows.Count; i++)
            {
                for (int j = 6; j < dataFile1.Columns.Count; j += 8)
                {
                    string curInventory = dataFile1.Rows[i][1].ToString().Trim();
                    string curBrand = dataFile1.Rows[i][2].ToString().Trim();
                    string curCategory = dataFile1.Rows[i][3].ToString().Trim();
                    string curModel = dataFile1.Rows[i][4].ToString().Trim();
                    string curCode = dataFile1.Rows[i][5].ToString().Trim();
                    string curColQty = dataFile1.Rows[i][j].ToString().Trim();

                    var curColName = "";
                    var curBranch = dataFile1.Rows[0][j].ToString();

                    if (curInventory != "" && curInventory.ToString().Split(' ')[0].ToString() != "Total")
                        strInventory = curInventory;
                    else if (curInventory.ToString().Split(' ')[0].ToString() == "Total")
                        break;

                    if (curBrand != "" && curBrand.ToString().Split(' ')[0].ToString() != "Total")
                        strBrand = curBrand;
                    else if (curBrand.ToString().Split(' ')[0].ToString() == "Total")
                        break;

                    if (curCategory != "" && curCategory.ToString().Split(' ')[0].ToString() != "Total")
                        strCategory = curCategory;
                    else if (curCategory.ToString().Split(' ')[0].ToString() == "Total")
                        break;
                    if (curModel != "")
                    {
                        strModel = curModel;
                        if (curModel.ToString().Split(' ')[0].ToString() != "Total" && curCode == "" && curColQty != "")
                        {
                            curCode = dataFile1.Rows[i][4].ToString();
                        }
                    }
                    else if (curModel.ToString().Split(' ')[0].ToString() == "Total")
                        break;

                    if (curCode != "" && curCode.ToString().Split(' ')[0].ToString() != "Total")
                        strCode = curCode;
                    else if (curModel.ToString().Split(' ')[0].ToString() == "Total")
                        break;

                    if (curColQty != "")
                    {
                        if (!curBranch.ToString().Split(' ')[0].Equals("TOTAL")
                        || !curBranch.ToString().Equals("CHO MUON MAU")
                         || !curBranch.ToString().Equals("OFFICE"))
                            curColName = dataFile1.Columns[j].ColumnName.ToString();

                        dr["Store"] = curColName;
                        dr["Inventory"] = strInventory;
                        dr["Brand"] = strBrand;
                        dr["Category"] = strCategory;
                        dr["Model"] = strModel;
                        dr["Code"] = strCode;
                        double qty = double.Parse(curColQty);
                        if (qty > 0 && curCode != "" && curColName != "") 
                        {
                                string amount = dataFile1.Rows[i][j + 2].ToString();
                                dr["Qty"] = (int)qty;
                                dr["Amount"] = double.Parse(amount);
                                DataRow drTemp = dr;
                                dataFileTotal.Rows.Add(drTemp);
                                dr = dataFileTotal.NewRow();
                        }
                        dataGridView1.Invoke((MethodInvoker)delegate { dataGridView1.DataSource = dataFileTotal; });
                        lsLog.Invoke((MethodInvoker)delegate { lsLog.Items.Insert(0, "Current Index: [" + i + "][" + j + "]: " + curColName + "" + curBranch + ""); });
                    }
                    else
                        break;
                }//end for
            }
            dataFileTotal.AcceptChanges();
        }
        private void executeDataTable2()
        {

        }
        private void executeDataTable3()
        {

        }
    }
}
