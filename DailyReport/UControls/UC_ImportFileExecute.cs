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
        private DataTable dataTempDiscount1;
        private DataTable dataTempDiscount2;
        private DataTable dataTempDiscount3;
        private DataTable dataFileTotal;
        private DataTable dataFileTotalDiscount;
        private DataTable dataFileTotalALL;
        private string title1 = "1.Samsonite";
        private string title2 = "2.Global";
        private string title3 = "3.Fashion";

        public UC_ImportFileExecute()
        {
            InitializeComponent();
            dataFile1 = new DataTable();
            dataFile2 = new DataTable();
            dataFile3 = new DataTable();
            createTable();
        }
        private void createTable()
        {
            dataFileTotal = new DataTable();
            dataFileTotal.Columns.Add("STT");
            dataFileTotal.Columns.Add("ReportFor");
            dataFileTotal.Columns.Add("Inventory");
            dataFileTotal.Columns.Add("Store");
            dataFileTotal.Columns.Add("BrandID");
            dataFileTotal.Columns.Add("BrandMain");
            dataFileTotal.Columns.Add("Brand");
            dataFileTotal.Columns.Add("Category");
            dataFileTotal.Columns.Add("Model");
            dataFileTotal.Columns.Add("Code");
            dataFileTotal.Columns.Add("Qty");
            dataFileTotal.Columns.Add("Price");
            dataFileTotal.Columns.Add("Amount");
            dataFileTotal.Columns.Add("Discount");
            dataFileTotal.Columns.Add("NetSales");

            dataFileTotalDiscount = new DataTable();
            dataFileTotalDiscount.Columns.Add("STT");
            dataFileTotalDiscount.Columns.Add("ReportFor");
            dataFileTotalDiscount.Columns.Add("Inventory");
            dataFileTotalDiscount.Columns.Add("Store");
            dataFileTotalDiscount.Columns.Add("BrandID");
            dataFileTotalDiscount.Columns.Add("BrandMain");
            dataFileTotalDiscount.Columns.Add("Brand");
            dataFileTotalDiscount.Columns.Add("Discount");

            dataFileTotalALL = new DataTable();
            dataFileTotalALL.Columns.Add("STT");
            dataFileTotalALL.Columns.Add("Store");
            dataFileTotalALL.Columns.Add("Brand");
            dataFileTotalALL.Columns.Add("Qty", typeof(Int32));
            dataFileTotalALL.Columns.Add("Amount", typeof(Int32));
            dataFileTotalALL.Columns.Add("Discount", typeof(Int32));
            dataFileTotalALL.Columns.Add("NetSales", typeof(Int32));

            dataTemp1 = dataFileTotal.Copy();
            dataTemp2 = dataFileTotal.Copy();
            dataTemp3 = dataFileTotal.Copy();

            dataTempDiscount1 = dataFileTotalDiscount.Copy();
            dataTempDiscount2 = dataFileTotalDiscount.Copy();
            dataTempDiscount3 = dataFileTotalDiscount.Copy();

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
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, "Lỗi"); }
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
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, "Lỗi"); }
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
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, "Lỗi"); }
        }

        private bool checkExistsFile()
        {
            if (txtPathFile1.Text.Trim() != "" || txtPathFile2.Text.Trim() != "" || txtPathFile3.Text.Trim() != "")
                return true;
            else
                return false;
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
            if (checkExistsFile())
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
                    excecuteDataDiscount1();
                }));
                t.Start();
                Thread t2 = new Thread(new ThreadStart(() =>
                {
                    executeDataTable2();
                    excecuteDataDiscount2();
                }));
                t2.Start();
                Thread t3 = new Thread(new ThreadStart(() =>
                {
                    executeDataTable3();
                    excecuteDataDiscount3();
                }));
                t3.Start();
            }
            else
                XtraMessageBox.Show("Bạn chưa chọn file để thực thi.");
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
                    {
                        strCategory = curCategory;
                        if (curCategory.ToString().Split(' ')[0].ToString() != "Total" && curModel == "" && curColQty != "")
                        {
                            curModel = dataFile1.Rows[i][3].ToString();
                        }
                    }
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
                            if (qty != 0 && curCode != "")
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
            updateBrandMain(dataTemp1);
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
                    {
                        strCategory = curCategory;
                        if (curCategory.ToString().Split(' ')[0].ToString() != "Total" && curModel == "" && curColQty != "")
                        {
                            curModel = dataFile2.Rows[i][3].ToString();
                        }
                    }
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
                            if (qty != 0 && curCode != "")
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
            updateBrandMain(dataTemp2);
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
                            if (qty != 0 && curCode != "")
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
            updateBrandMain(dataTemp3);
        }

        private void excecuteDataDiscount1()
        {
            DataRow dr = dataTempDiscount1.NewRow();
            string strInventory = "";
            string strBrand = "";
            string strCategory = "";

            for (int i = 2; i < dataFile1.Rows.Count; i++)
            {
                for (int j = 6; j < dataFile1.Columns.Count; j += 8)
                {
                    string curInventory = dataFile1.Rows[i][1].ToString().Trim();
                    string curBrand = dataFile1.Rows[i][2].ToString().Trim();
                    string curCategory = dataFile1.Rows[i][3].ToString().Trim();

                    string curAmount = dataFile1.Rows[i][j + 2].ToString().Trim();
                    string totalALL = dataFile1.Rows[i][0].ToString().Trim();

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

                    if (totalALL == "TOTAL")
                        break;
                    if (strInventory == "Discounts")
                    {
                        if (strBrand == "DISCOUNT" && curAmount != "")
                        {
                            if (curBranch.ToString().Split(' ')[0] != "Total"
                            && curBranch.ToString() != "TOTAL"
                            && curBranch.ToString() != "CHO MUON MAU"
                            && curBranch.ToString() != "OFFICE")
                                curColName = dataFile1.Columns[j].ColumnName.ToString();

                            double amount = Math.Abs(double.Parse(curAmount));
                            if (curColName != "" && amount > 0)
                            {
                                dr["ReportFor"] = "SAM";
                                dr["Inventory"] = strInventory;
                                dr["Store"] = curColName;
                                dr["Brand"] = strCategory;
                                dr["Discount"] = (int)(amount);

                                DataRow drTemp = dr;
                                dataTempDiscount1.Rows.Add(drTemp);
                                dr = dataTempDiscount1.NewRow();
                                lsLog1.Invoke((MethodInvoker)delegate { lsLog1.Items.Insert(0, "[SAM]:Discount Position: [" + i + "][" + j + "]: " + curColName + "" + curBranch + "-[" + strCategory + " - " + amount.ToString() + "]"); });
                            }//end if                
                        }
                    }
                    else
                        break;
                }//end for
            }
            dataTempDiscount1.AcceptChanges();
            updateBrandMain(dataTempDiscount1);
        }
        private void excecuteDataDiscount2()
        {
            DataRow dr = dataTempDiscount2.NewRow();
            string strInventory = "";
            string strBrand = "";
            string strCategory = "";

            for (int i = 2; i < dataFile2.Rows.Count; i++)
            {
                for (int j = 6; j < dataFile2.Columns.Count; j += 8)
                {
                    string curInventory = dataFile2.Rows[i][1].ToString().Trim();
                    string curBrand = dataFile2.Rows[i][2].ToString().Trim();
                    string curCategory = dataFile2.Rows[i][3].ToString().Trim();

                    string curAmount = dataFile2.Rows[i][j + 2].ToString().Trim();
                    string totalALL = dataFile2.Rows[i][0].ToString().Trim();

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

                    if (totalALL == "TOTAL")
                        break;
                    if (strInventory == "Discounts")
                    {
                        if (strBrand == "DISCOUNT")
                        {
                            if (curAmount != "")
                            {
                                if (curBranch.ToString().Split(' ')[0] != "Total"
                                && curBranch.ToString() != "TOTAL"
                                && curBranch.ToString() != "CHO MUON MAU"
                                && curBranch.ToString() != "OFFICE")
                                    curColName = dataFile2.Columns[j].ColumnName.ToString();

                                double amount = Math.Abs(double.Parse(curAmount));
                                if (curColName != "" && amount > 0)
                                {
                                    dr["ReportFor"] = "SAM";
                                    dr["Inventory"] = strInventory;
                                    dr["Store"] = curColName;
                                    dr["Brand"] = strCategory;
                                    dr["Discount"] = (int)(amount);

                                    DataRow drTemp = dr;
                                    dataTempDiscount2.Rows.Add(drTemp);
                                    dr = dataTempDiscount2.NewRow();
                                    lsLog2.Invoke((MethodInvoker)delegate { lsLog2.Items.Insert(0, "[GLO]:Discount Position: [" + i + "][" + j + "]: " + curColName + "" + curBranch + "-[" + strCategory + " - " + amount.ToString() + "]"); });
                                }//end if                
                            }
                            else break;
                        }
                        else break;
                    }
                    else
                        break;
                }//end for
            }
            dataTempDiscount2.AcceptChanges();
            updateBrandMain(dataTempDiscount2);
        }
        private void excecuteDataDiscount3()
        {
            DataRow dr = dataTempDiscount3.NewRow();
            string strInventory = "";
            string strBrand = "";
            string strCategory = "";

            for (int i = 2; i < dataFile3.Rows.Count; i++)
            {
                for (int j = 6; j < dataFile3.Columns.Count; j += 8)
                {
                    string curInventory = dataFile3.Rows[i][1].ToString().Trim();
                    string curBrand = dataFile3.Rows[i][2].ToString().Trim();
                    string curCategory = dataFile3.Rows[i][3].ToString().Trim();

                    string curAmount = dataFile3.Rows[i][j + 2].ToString().Trim();
                    string totalALL = dataFile3.Rows[i][0].ToString().Trim();

                    var curColName = "";

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

                    if (totalALL == "TOTAL")
                        break;
                    if (strInventory == "Discounts")
                    {
                        if (strBrand == "SALES DISCOUNT")
                        {
                            curColName = dataFile3.Columns[j].ColumnName.ToString();
                            if (curAmount != "" && curColName != "TOTAL")
                            {
                                double amount = Math.Abs(double.Parse(curAmount));
                                if (curColName != "" && amount > 0)
                                {
                                    dr["ReportFor"] = "SAM";
                                    dr["Inventory"] = strInventory;
                                    dr["Store"] = curColName;
                                    dr["Brand"] = strCategory;
                                    dr["Discount"] = (int)(amount);

                                    DataRow drTemp = dr;
                                    dataTempDiscount3.Rows.Add(drTemp);
                                    dr = dataTempDiscount3.NewRow();
                                    lsLog3.Invoke((MethodInvoker)delegate { lsLog3.Items.Insert(0, "[FAS]:Discount Position: [" + i + "][" + j + "]: " + curColName + "-[" + strCategory + " - " + amount.ToString() + "]"); });
                                }//end if                
                            }
                            else break;
                        }
                        else break;
                    }
                    else
                        break;
                }//end for
            }
            dataTempDiscount3.AcceptChanges();
            updateBrandMain(dataTempDiscount3);
        }
        private void updateBrandMain(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Brand"].ToString().Split(' ')[0].Contains("SAMSONITE"))
                {
                    dr["BrandMain"] = "SAMSONITE";
                }
                else if (dr["Brand"].ToString().Equals("AT"))
                {
                    dr["BrandMain"] = "AMERICAN TOURISTER";
                }
                else
                    dr["BrandMain"] = dr["Brand"];
            }
            foreach (DataRow dr in dt.Rows)
            {
                switch (dr["BrandMain"].ToString())
                {
                    case "SAMSONITE":
                        dr["BrandID"] = 1;
                        break;
                    case "AMERICAN TOURISTER":
                        dr["BrandMain"] = "AT";
                        dr["BrandID"] = 2;
                        break;
                    case "LIPAULT":
                        dr["BrandID"] = 3;
                        break;
                    case "HIGH SIERRA":
                        dr["BrandID"] = 4;
                        break;

                    case "KAMILIANT":
                        dr["BrandID"] = 5;
                        break;

                }
            }
            dt.AcceptChanges();
        }

        private void updateDataTemp1()
        {
            var itemDataTemp1 = dataTemp1.AsEnumerable().GroupBy(
         x => new { Store = x.Field<string>("Store"), BrandMain = x.Field<string>("BrandMain") }
         ).Select
         (
             n => new
             {
                 Store = n.Key.Store,
                 BrandMain = n.Key.BrandMain,
                 Qty = Convert.ToInt32(n.Sum(z => Convert.ToInt32(z.Field<string>("Qty")))),
                 NetAmount = Convert.ToInt32(n.Sum(z => Convert.ToInt32(z.Field<string>("Amount")))),
             }
         ).OrderBy(x => x.Store)
         .ToList();

            var itemsDiscount = dataTempDiscount1.AsEnumerable().GroupBy(
            x => new { Store = x.Field<string>("Store"), BrandMain = x.Field<string>("BrandMain") }
            ).Select
            (
                n => new
                {
                    Store = n.Key.Store,
                    BrandMain = n.Key.BrandMain,
                    Discount = Convert.ToInt32(n.Sum(z => Convert.ToInt32(z.Field<string>("Discount")))),
                }
            ).OrderBy(x => x.Store)
            .ToList();
            foreach (var dr1 in itemDataTemp1)
            {
                DataRow dr = dataFileTotalALL.NewRow();
                dr["Store"] = dr1.Store;
                dr["Brand"] = dr1.BrandMain;
                dr["Qty"] = dr1.Qty;
                dr["Amount"] = dr1.NetAmount;
                dataFileTotalALL.Rows.Add(dr);
            }
            foreach (DataRow dr1 in dataFileTotalALL.Rows)
            {

                foreach (var dr2 in itemsDiscount)
                {

                    if ((dr1["Store"].ToString() == dr2.Store.ToString()) && (dr1["Brand"].ToString() == dr2.BrandMain.ToString()))
                        dr1["Discount"] = dr2.Discount;
                }

            }
        }
        private void updateDataTemp2()
        {
            var itemDataTemp2 = dataTemp2.AsEnumerable().GroupBy(
          x => new { Store = x.Field<string>("Store"), BrandMain = x.Field<string>("BrandMain") }
          ).Select
          (
              n => new
              {
                  Store = n.Key.Store,
                  BrandMain = n.Key.BrandMain,
                  Qty = Convert.ToInt32(n.Sum(z => Convert.ToInt32(z.Field<string>("Qty")))),
                  NetAmount = Convert.ToInt32(n.Sum(z => Convert.ToInt32(z.Field<string>("Amount")))),
              }
          ).OrderBy(x => x.Store)
          .ToList();

            var itemsDiscount = dataTempDiscount2.AsEnumerable().GroupBy(
            x => new { Store = x.Field<string>("Store"), BrandMain = x.Field<string>("BrandMain") }
            ).Select
            (
                n => new
                {
                    Store = n.Key.Store,
                    BrandMain = n.Key.BrandMain,
                    Discount = Convert.ToInt32(n.Sum(z => Convert.ToInt32(z.Field<string>("Discount")))),
                }
            ).OrderBy(x => x.Store)
            .ToList();
            foreach (var dr1 in itemDataTemp2)
            {
                DataRow dr = dataFileTotalALL.NewRow();
                dr["Store"] = dr1.Store;
                dr["Brand"] = dr1.BrandMain;
                dr["Qty"] = dr1.Qty;
                dr["Amount"] = dr1.NetAmount;
                dataFileTotalALL.Rows.Add(dr);
            }
            foreach (DataRow dr1 in dataFileTotalALL.Rows)
            {
                foreach (var dr2 in itemsDiscount)
                {

                    if ((dr1["Store"].ToString() == dr2.Store.ToString()) && (dr1["Brand"].ToString() == dr2.BrandMain.ToString()))
                        dr1["Discount"] = dr2.Discount;
                }
            }
        }
        private void updateDataTemp3()
        {
            var itemDataTemp3 = dataTemp3.AsEnumerable().GroupBy(
         x => new { Store = x.Field<string>("Store"), BrandMain = x.Field<string>("BrandMain") }
         ).Select
         (
             n => new
             {
                 Store = n.Key.Store,
                 BrandMain = n.Key.BrandMain,
                 Qty = Convert.ToInt32(n.Sum(z => Convert.ToInt32(z.Field<string>("Qty")))),
                 NetAmount = Convert.ToInt32(n.Sum(z => Convert.ToInt32(z.Field<string>("Amount")))),
             }
         ).OrderBy(x => x.Store)
         .ToList();

            var itemsDiscount = dataTempDiscount3.AsEnumerable().GroupBy(
            x => new { Store = x.Field<string>("Store"), BrandMain = x.Field<string>("BrandMain") }
            ).Select
            (
                n => new
                {
                    Store = n.Key.Store,
                    BrandMain = n.Key.BrandMain,
                    Discount = Convert.ToInt32(n.Sum(z => Convert.ToInt32(z.Field<string>("Discount")))),
                }
            ).OrderBy(x => x.Store)
            .ToList();
            foreach (var dr1 in itemDataTemp3)
            {
                DataRow dr = dataFileTotalALL.NewRow();
                dr["Store"] = dr1.Store;
                dr["Brand"] = dr1.BrandMain;
                dr["Qty"] = dr1.Qty;
                dr["Amount"] = dr1.NetAmount;
                dataFileTotalALL.Rows.Add(dr);
            }
            foreach (DataRow dr1 in dataFileTotalALL.Rows)
            {
                foreach (var dr2 in itemsDiscount)
                {

                    if ((dr1["Store"].ToString() == dr2.Store.ToString()) && (dr1["Brand"].ToString() == dr2.BrandMain.ToString()))
                        dr1["Discount"] = dr2.Discount;
                }
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            dataFileTotal.Rows.Clear();
            if (dataTemp1.Rows.Count > 0)
                dataFileTotal.Merge(dataTemp1, true);
            if (dataTemp2.Rows.Count > 0)
                dataFileTotal.Merge(dataTemp2, true);
            if (dataTemp3.Rows.Count > 0)
                dataFileTotal.Merge(dataTemp3, true);
            if (dataFileTotal.Rows.Count > 0)
            {
                foreach (DataRow dr in dataFileTotal.Rows)
                {
                    int am = dr["Amount"].ToString() == "" ? 0 : int.Parse(dr["Amount"].ToString());
                    int ds = dr["Discount"].ToString() == "" ? 0 : int.Parse(dr["Discount"].ToString());
                    dr["NetSales"] = am - ds;
                }
                dataFileTotal.AcceptChanges();
                UC_ImportFileExecuteDetail uc = new UC_ImportFileExecuteDetail(dataFileTotal);
                frmShowWindow frm = new frmShowWindow(uc);
                frm.Text = "Result Import Data From File Excel";
                frm.ShowDialog();
            }
            else
                XtraMessageBox.Show("Không có dữ liệu hiển thị");
           
        }
        private void btnShowData_Click(object sender, EventArgs e)
        {
            dataFileTotalALL.Rows.Clear();
            if (dataTemp1.Rows.Count > 0)
                updateDataTemp1();
            if (dataTemp2.Rows.Count > 0)
                updateDataTemp2();
            if (dataTemp3.Rows.Count > 0)
                updateDataTemp3();
            if (dataFileTotalALL.Rows.Count > 0)
            {    
                foreach (DataRow dr in dataFileTotalALL.Rows)
                {
                    int am = dr["Amount"].ToString() == "" ? 0 : int.Parse(dr["Amount"].ToString());
                    int ds = dr["Discount"].ToString() == "" ? 0 : int.Parse(dr["Discount"].ToString());
                    dr["NetSales"] = am - ds;
                }
                dataFileTotalALL.AcceptChanges();
                UC_ImportFileExecuteDetail_2 uc = new UC_ImportFileExecuteDetail_2(dataFileTotalALL);
                frmShowWindow frm = new frmShowWindow(uc);
                frm.Text = "Result Import Data From File Excel";
                frm.ShowDialog();
            }
            else
                XtraMessageBox.Show("Không có dữ liệu hiển thị");

        }
    }
}
