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
        private DataTable dataTemp1;
        private DataTable dataTemp2;
        private DataTable dataTemp3;
        private DataTable dataFileTotal;
        private string title1 = "1.Samsonite";
        private string title2 = "2.Global";
        private string title3 = "3.Fashion";

        public UC_ImportFileExecute()
        {
            InitializeComponent();
            dataFile1 = new DataTable();
            dataFile2 = new DataTable();
            dataFile3 = new DataTable();
           
        }
        private void createTable()
        {
            dataFileTotal = new DataTable();
            dataFileTotal.Columns.Add("STT");
            dataFileTotal.Columns.Add("ReportFor");
            dataFileTotal.Columns.Add("Inventory");
            dataFileTotal.Columns.Add("Store");
            dataFileTotal.Columns.Add("Brand");
            dataFileTotal.Columns.Add("Category");
            dataFileTotal.Columns.Add("Model");
            dataFileTotal.Columns.Add("Code");
            dataFileTotal.Columns.Add("Qty");
            dataFileTotal.Columns.Add("Price");
            dataFileTotal.Columns.Add("Amount");

            dataTemp1 = dataFileTotal.Copy();
            dataTemp2 = dataFileTotal.Copy();
            dataTemp3 = dataFileTotal.Copy();

            lsLog1.Items.Clear();
            lsLog2.Items.Clear();
            lsLog3.Items.Clear();
        }
        private void btnChooseFile1_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, object> data = OpenFileExcel.getInfoFile();
                if (data != null)
                {
                    txtPathFile1.Text = data["fileName"].ToString();
                    string selectSheet = data["selectSheet"].ToString();
                    //checkExistsFile();
                    dataFile1 = OpenFileExcel.getDataExcelFromFileToDataTable(data["fileName"].ToString(), selectSheet);
                }
            }
            catch (Exception ex) { XtraMessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnChooseFile2_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, object> data = OpenFileExcel.getInfoFile();
                if (data != null)
                {
                    txtPathFile2.Text = data["fileName"].ToString();
                    string selectSheet = data["selectSheet"].ToString();
                    checkExistsFile();
                    dataFile2 = OpenFileExcel.getDataExcelFromFileToDataTable(data["fileName"].ToString(), selectSheet);
                }
            }
            catch (Exception ex) { XtraMessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnChooseFile3_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, object> data = OpenFileExcel.getInfoFile();
                if (data != null)
                {
                    txtPathFile3.Text = data["fileName"].ToString();
                    string selectSheet = data["selectSheet"].ToString();
                    checkExistsFile();
                    dataFile3 = OpenFileExcel.getDataExcelFromFileToDataTable(data["fileName"].ToString(), selectSheet);
                }
            }
            catch (Exception ex) { XtraMessageBox.Show("Lỗi: " + ex.Message); }
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
            createTable();
            int maxProBar1 = dataFile1.Rows.Count - 2;
            int maxProBar2 = dataFile2.Rows.Count - 2;
            int maxProBar3 = dataFile3.Rows.Count - 1;

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
            DataRow dr = dataTemp1.NewRow();
            string strInventory = "";
            string strBrand = "";
            string strCategory = "";
            string strModel = "";
            string strCode = "";
            int count = 0;
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
                        if (curBranch.ToString().Split(' ')[0] != "Total"
                            && curBranch.ToString() != "TOTAL"
                            && curBranch.ToString() != "CHO MUON MAU"
                            && curBranch.ToString() != "OFFICE")
                            curColName = dataFile1.Columns[j].ColumnName.ToString();
                        if (curColName != "")
                        {

                            dr["ReportFor"] = "SAM";
                            dr["Inventory"] = strInventory;
                            dr["Store"] = curColName;
                            dr["Brand"] = strBrand;
                            dr["Category"] = strCategory;
                            dr["Model"] = strModel;
                            dr["Code"] = strCode;
                            double qty = double.Parse(curColQty);
                            if (qty > 0 && curCode != "")
                            {
                                double amount = double.Parse(dataFile1.Rows[i][j + 2].ToString());
                                dr["Price"] = (int)(amount / qty);
                                dr["Qty"] = (int)qty;
                                dr["Amount"] = (int)(amount);
                                DataRow drTemp = dr;
                                dataTemp1.Rows.Add(drTemp);
                                dr = dataTemp1.NewRow();
                                count++;
                                lsLog1.Invoke((MethodInvoker)delegate { lsLog1.Items.Insert(0, "[SAM]:Current Position: [" + i + "][" + j + "]: " + curColName + "" + curBranch + "-[" + strBrand + ":" + strCode + "]"); });
                            }//end if                
                        }//end if
                    }
                    else
                        break;
                }//end for
                proBar1.Invoke((MethodInvoker)delegate { proBar1.Position++; });
                lblPer1.Invoke((MethodInvoker)delegate { lblPer1.ResetText(); lblPer1.Text = ((proBar1.Position / proBar1.Properties.Maximum) * 100).ToString() + "%"; });
            }
            lblTitle1.Invoke((MethodInvoker)delegate { lblTitle1.Text = title1 + " - [" + count + "]"; });
            dataTemp1.AcceptChanges();
        }
        private void executeDataTable2()
        {
            DataRow dr = dataTemp2.NewRow();
            string strInventory = "";
            string strBrand = "";
            string strCategory = "";
            string strModel = "";
            string strCode = "";
            int count = 0;
            for (int i = 2; i < dataFile2.Rows.Count; i++)
            {
                for (int j = 6; j < dataFile2.Columns.Count; j += 8)
                {
                    string curInventory = dataFile2.Rows[i][1].ToString().Trim();
                    string curBrand = dataFile2.Rows[i][2].ToString().Trim();
                    string curCategory = dataFile2.Rows[i][3].ToString().Trim();
                    string curModel = dataFile2.Rows[i][4].ToString().Trim();
                    string curCode = dataFile2.Rows[i][5].ToString().Trim();
                    string curColQty = dataFile2.Rows[i][j].ToString().Trim();

                    var curColName = "";
                    var curBranch = dataFile2.Rows[0][j].ToString();

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
                            curCode = dataFile2.Rows[i][4].ToString();
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
                        if (curBranch.ToString().Split(' ')[0] != "Total"
                            && curBranch.ToString() != "TOTAL"
                            && curBranch.ToString() != "CHO MUON MAU"
                            && curBranch.ToString() != "OFFICE")
                            curColName = dataFile2.Columns[j].ColumnName.ToString();
                        if (curColName != "")
                        {
                            dr["ReportFor"] = "GLO";
                            dr["Inventory"] = strInventory;
                            dr["Store"] = curColName;
                            dr["Brand"] = strBrand;
                            dr["Category"] = strCategory;
                            dr["Model"] = strModel;
                            dr["Code"] = strCode;
                            double qty = double.Parse(curColQty);
                            if (qty > 0 && curCode != "")
                            {
                                double amount = double.Parse(dataFile2.Rows[i][j + 2].ToString());
                                dr["Price"] = (int)(amount / qty);
                                dr["Qty"] = (int)qty;
                                dr["Amount"] = (int)(amount);
                                DataRow drTemp = dr;
                                dataTemp2.Rows.Add(drTemp);
                                dr = dataTemp2.NewRow();
                                lsLog2.Invoke((MethodInvoker)delegate { lsLog2.Items.Insert(0, "[GLO]:Current Position: [" + i + "][" + j + "]: " + curColName + "" + curBranch + "-[" + strBrand + ":" + strCode + "]"); });
                                count++;
                            }//end if                
                        }//end if
                    }
                    else
                        break;
                }//end for
                proBar2.Invoke((MethodInvoker)delegate { proBar2.Position++; });
                lblPer2.Invoke((MethodInvoker)delegate { lblPer2.ResetText(); lblPer2.Text = ((proBar2.Position / proBar2.Properties.Maximum) * 100).ToString() + "%"; });
            }
            lblTitle2.Invoke((MethodInvoker)delegate { lblTitle2.Text = title2 + " - [" + count + "]"; });
            dataTemp2.AcceptChanges();
        }
        private void executeDataTable3()
        {
            DataRow dr3 = dataTemp3.NewRow();
            string strInventory = "";
            string strBrand = "";
            string strCategory = "";
            string strModel = "";
            string strCode = "";
            int count = 0;
            for (int i = 1; i < dataFile3.Rows.Count; i++)
            {
                for (int j = 6; j < dataFile3.Columns.Count; j += 8)
                {
                    string curInventory = dataFile3.Rows[i][1].ToString().Trim();
                    string curBrand = dataFile3.Rows[i][2].ToString().Trim();
                    string curCategory = dataFile3.Rows[i][3].ToString().Trim();
                    string curModel = dataFile3.Rows[i][4].ToString().Trim();
                    string curCode = dataFile3.Rows[i][5].ToString().Trim();
                    string curColQty = dataFile3.Rows[i][j].ToString().Trim();

                    var curColName = dataFile3.Columns[j].ColumnName.ToString();

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
                            curCode = dataFile3.Rows[i][4].ToString();
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
                        //if (curColName.ToString().Split(' ')[0] != "Total"
                        //    && curColName.ToString() != "TOTAL"
                        //    && curColName.ToString() != "CHO MUON MAU"
                        //    && curColName.ToString() != "OFFICE")
                        //    curColName = dataFile3.Columns[j].ColumnName.ToString();
                        if (curColName != "" && curColName != "TOTAL")
                        {

                            dr3["ReportFor"] = "FAS";
                            dr3["Inventory"] = strInventory;
                            dr3["Store"] = curColName;
                            dr3["Brand"] = strBrand;
                            dr3["Category"] = strCategory;
                            dr3["Model"] = strModel;
                            dr3["Code"] = strCode;
                            double qty = double.Parse(curColQty);
                            if (qty > 0 && curCode != "")
                            {
                                double amount = double.Parse(dataFile3.Rows[i][j + 2].ToString());
                                dr3["Price"] = (int)(amount / qty);
                                dr3["Qty"] = (int)qty;
                                dr3["Amount"] = (int)(amount);
                                DataRow drTemp = dr3;
                                dataTemp3.Rows.Add(drTemp);
                                dr3 = dataTemp3.NewRow();
                                count += 1;
                                lsLog3.Invoke((MethodInvoker)delegate { lsLog3.Items.Insert(0, "[FAS]:Current Position: [" + i + "][" + j + "]: " + curColName + "-[" + strBrand + ":" + strCode + "]"); });
                            }//end if                
                        }//end if
                    }
                    else
                        break;
                }//end for
                proBar3.Invoke((MethodInvoker)delegate { proBar3.Position++; });
                lblPer3.Invoke((MethodInvoker)delegate { lblPer3.ResetText(); lblPer3.Text = ((proBar3.Position / proBar3.Properties.Maximum) * 100).ToString() + "%"; });
            }
            lblTitle3.Invoke((MethodInvoker)delegate { lblTitle3.Text = title3 + " - [" + count + "]"; });
            dataTemp3.AcceptChanges();
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {     
            dataFileTotal.Merge(dataTemp1, true);
            dataFileTotal.Merge(dataTemp2, true);
            dataFileTotal.Merge(dataTemp3, true);
            UC_ImportFileExecuteDetail uc = new UC_ImportFileExecuteDetail(dataFileTotal);
            frmShowWindow frm = new frmShowWindow(uc);
            frm.Text = "Result Import Data From File Excel";
            frm.Show();
        }
    }
}
