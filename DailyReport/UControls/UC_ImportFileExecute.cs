﻿using System;
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

            dataFileTotalDiscount = new DataTable();
            dataFileTotalDiscount.Columns.Add("STT");
            dataFileTotalDiscount.Columns.Add("ReportFor");
            dataFileTotalDiscount.Columns.Add("Inventory");
            dataFileTotalDiscount.Columns.Add("Store");
            dataFileTotalDiscount.Columns.Add("BrandID");
            dataFileTotalDiscount.Columns.Add("BrandMain");
            dataFileTotalDiscount.Columns.Add("Brand");
            dataFileTotalDiscount.Columns.Add("Discount");

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

                    if (strInventory == "Discounts")
                    {
                        if (strBrand == "DISCOUNT")
                        {

                        }
                    }
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
                        if (strBrand == "DISCOUNT")
                        {
                            if (curAmount != "")
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
                                    lsLog1.Invoke((MethodInvoker)delegate { lsLog1.Items.Insert(0, "[SAM]:Current Position: [" + i + "][" + j + "]: " + curColName + "" + curBranch + "-[" + strCategory + " - "+ amount.ToString() + "]"); });
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
            dataTempDiscount1.AcceptChanges();
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
        }
        private void btnShowData_Click(object sender, EventArgs e)
        {
            if (dataTemp1.Rows.Count > 0)
                dataFileTotal.Merge(dataTemp1, true);
            if (dataTemp2.Rows.Count > 0)
                dataFileTotal.Merge(dataTemp2, true);
            if (dataTemp3.Rows.Count > 0)
                dataFileTotal.Merge(dataTemp3, true);
            if (dataFileTotal.Rows.Count > 0)
                updateDataTotal();

            if (dataTempDiscount1.Rows.Count > 0)
                dataFileTotalDiscount.Merge(dataTempDiscount1, true);
            if (dataTempDiscount2.Rows.Count > 0)
                dataFileTotalDiscount.Merge(dataTempDiscount2, true);
            if (dataTempDiscount3.Rows.Count > 0)
                dataFileTotalDiscount.Merge(dataTempDiscount3, true);
            if (dataFileTotalDiscount.Rows.Count > 0)
                updateDataTotalDiscount();

            doMerageData();
            UC_ImportFileExecuteDetail_2 uc = new UC_ImportFileExecuteDetail_2(dataFileTotal);
            frmShowWindow frm = new frmShowWindow(uc);
            frm.Text = "Result Import Data From File Excel";
            frm.Show();
        }
        private void updateDataTotal()
        {
            foreach (DataRow dr in dataFileTotal.Rows)
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
            foreach (DataRow dr in dataFileTotal.Rows)
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
            dataFileTotal.AcceptChanges();
        }
        private void updateDataTotalDiscount()
        {
            foreach (DataRow dr in dataFileTotalDiscount.Rows)
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
            foreach (DataRow dr in dataFileTotalDiscount.Rows)
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
            dataFileTotal.AcceptChanges();
        }

        private void doMerageData()
        {
            foreach (DataRow dr1 in dataFileTotal.Rows)
            {
                foreach (DataRow dr2 in dataFileTotalDiscount.Rows)
                {
                    string st1 = dr1["Store"].ToString().ToUpper();
                    string br1 = dr1["BrandID"].ToString().ToUpper();
                    string st2 = dr2["Store"].ToString().ToUpper();
                    string br2 = dr2["BrandID"].ToString().ToUpper();
                    if (st1.Equals(st2) && br1 == br2)
                    {
                        dr1["Discount"] = dr2["Discount"];
                    }
                }
            }

            dataFileTotal.AcceptChanges();
        }
    }
}
