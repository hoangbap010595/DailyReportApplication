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
        }

        private void btnChooseFile1_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> data = OpenFileExcel.getInfoFile();
            txtPathFile1.Text = data["fileName"].ToString();
            string selectSheet = data["selectSheet"].ToString();
            //checkExistsFile();
            dataFile1 = OpenFileExcel.getDataFromExcel(data["fileName"].ToString(), selectSheet);
        }

        private void btnChooseFile2_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> data = OpenFileExcel.getInfoFile();
            txtPathFile2.Text = data["fileName"].ToString();
            string selectSheet = data["selectSheet"].ToString();
            checkExistsFile();
            dataFile2 = OpenFileExcel.getDataFromExcel(data["fileName"].ToString(), selectSheet);
        }

        private void btnChooseFile3_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> data = OpenFileExcel.getInfoFile();
            txtPathFile3.Text = data["fileName"].ToString();
            string selectSheet = data["selectSheet"].ToString();
            checkExistsFile();
            dataFile3 = OpenFileExcel.getDataFromExcel(data["fileName"].ToString(), selectSheet);
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
            int maxProBar1 = dataFile1.Rows.Count - 2;
            int maxProBar2 = dataFile2.Rows.Count - 2;
            int maxProBar3 = dataFile3.Rows.Count - 2;

            proBar1.Properties.Maximum = maxProBar1;
            proBar2.Properties.Maximum = maxProBar2;
            proBar3.Properties.Maximum = maxProBar3;
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
            for (int i = 2; i < dataFile1.Rows.Count; i++)
            {
                for (int j = 6; j < dataFile1.Columns.Count; j += 8)
                {  
                    var curInventory = dataFile1.Rows[i][1].ToString();
                    var curBrand = dataFile1.Rows[i][2].ToString();
                    var curCategory = dataFile1.Rows[i][3].ToString();
                    var curModel = dataFile1.Rows[i][4].ToString();
                    var curCode = dataFile1.Rows[i][5].ToString();
                    var curColQty = dataFile1.Rows[i][j].ToString();
                    var curColName = dataFile1.Columns[j].ColumnName.ToString();
                    if (curColName == "")
                        break;
                    if (curInventory != "")
                        dr["Inventory"] = curInventory;
                    else if (curInventory.ToString().Split(' ')[0].ToString() == "Total")
                        break;
                    if (curBrand != "")
                        dr["Brand"] = curBrand;
                    else if (curBrand.ToString().Split(' ')[0].ToString() == "Total")
                    {
                        dr = dataFileTotal.NewRow();
                        break;
                    }
                    if (curCategory != "")
                        dr["Category"] = curCategory;
                    else if (curCategory.ToString().Split(' ')[0].ToString() == "Total")
                        break;
                    if (curModel != "")
                        dr["Model"] = curModel;
                    else if (curModel.ToString().Split(' ')[0].ToString() == "Total")
                        break;
                    if (curCode != "")
                        dr["Code"] = curCode;
                    else if (curCode.ToString().Split(' ')[0].ToString() == "Total")
                        break;

                    if (curColQty != "")
                    {
                        if (int.Parse(curColQty) > 0 && curCode != "")
                        {
                            dr["Store"] = curColName;
                            string amount = dataFile1.Rows[i][j+2].ToString();
                            dr["Qty"] = int.Parse(curColQty);
                            dr["Amount"] = double.Parse(amount);
                            DataRow drTemp = dr;
                            dataFileTotal.Rows.Add(drTemp);
                            dr = dataFileTotal.NewRow();
                            dataFileTotal.AcceptChanges();
                        }
                        else if(int.Parse(curColQty) > 0 && curCode == "")
                        {
                            string amount = dataFile1.Rows[i][j + 2].ToString();
                            dr["Store"] = curColName;
                            dr["Code"] = dataFile1.Rows[i][4].ToString();
                            dr["Qty"] = int.Parse(curColQty);
                            dr["Amount"] = double.Parse(amount);
                            DataRow drTemp = dr;
                            dataFileTotal.Rows.Add(drTemp);
                            dr = dataFileTotal.NewRow();
                            dataFileTotal.AcceptChanges();
                        }
                        dataGridView1.Invoke((MethodInvoker)delegate { dataGridView1.DataSource = dataFileTotal; });
                        Thread.Sleep(2000);
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
