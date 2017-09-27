namespace DailyReport.UControls
{
    partial class UC_ImportFileExecuteDetail
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridColumnPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReportFor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnInventory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnStore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBrandMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBrand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumnPrice
            // 
            this.gridColumnPrice.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumnPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnPrice.Caption = "Price";
            this.gridColumnPrice.DisplayFormat.FormatString = "#,###";
            this.gridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumnPrice.FieldName = "Price";
            this.gridColumnPrice.MaxWidth = 70;
            this.gridColumnPrice.MinWidth = 70;
            this.gridColumnPrice.Name = "gridColumnPrice";
            this.gridColumnPrice.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumnPrice.Visible = true;
            this.gridColumnPrice.VisibleIndex = 8;
            this.gridColumnPrice.Width = 70;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(15, 29);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(855, 269);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnSTT,
            this.gridColumnReportFor,
            this.gridColumnInventory,
            this.gridColumnStore,
            this.gridColumnBrandMain,
            this.gridColumnBrand,
            this.gridColumnCategory,
            this.gridColumnModel,
            this.gridColumnCode,
            this.gridColumnQty,
            this.gridColumnPrice,
            this.gridColumnAmount});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 2;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.AllowExcelFormat = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnReportFor, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnStore, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumnSTT
            // 
            this.gridColumnSTT.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnSTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnSTT.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnSTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnSTT.Caption = "STT";
            this.gridColumnSTT.FieldName = "STT";
            this.gridColumnSTT.MaxWidth = 40;
            this.gridColumnSTT.Name = "gridColumnSTT";
            this.gridColumnSTT.Visible = true;
            this.gridColumnSTT.VisibleIndex = 0;
            this.gridColumnSTT.Width = 82;
            // 
            // gridColumnReportFor
            // 
            this.gridColumnReportFor.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnReportFor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnReportFor.Caption = "ReportFor";
            this.gridColumnReportFor.FieldName = "ReportFor";
            this.gridColumnReportFor.Name = "gridColumnReportFor";
            this.gridColumnReportFor.Visible = true;
            this.gridColumnReportFor.VisibleIndex = 1;
            // 
            // gridColumnInventory
            // 
            this.gridColumnInventory.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnInventory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnInventory.Caption = "Inventory";
            this.gridColumnInventory.FieldName = "Inventory";
            this.gridColumnInventory.Name = "gridColumnInventory";
            this.gridColumnInventory.Visible = true;
            this.gridColumnInventory.VisibleIndex = 1;
            // 
            // gridColumnStore
            // 
            this.gridColumnStore.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnStore.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnStore.Caption = "Store";
            this.gridColumnStore.FieldName = "Store";
            this.gridColumnStore.Name = "gridColumnStore";
            this.gridColumnStore.Visible = true;
            this.gridColumnStore.VisibleIndex = 1;
            // 
            // gridColumnBrandMain
            // 
            this.gridColumnBrandMain.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnBrandMain.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnBrandMain.Caption = "BrandMain";
            this.gridColumnBrandMain.FieldName = "BrandMain";
            this.gridColumnBrandMain.Name = "gridColumnBrandMain";
            this.gridColumnBrandMain.Visible = true;
            this.gridColumnBrandMain.VisibleIndex = 2;
            // 
            // gridColumnBrand
            // 
            this.gridColumnBrand.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnBrand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnBrand.Caption = "Brand";
            this.gridColumnBrand.FieldName = "Brand";
            this.gridColumnBrand.Name = "gridColumnBrand";
            this.gridColumnBrand.Visible = true;
            this.gridColumnBrand.VisibleIndex = 3;
            // 
            // gridColumnCategory
            // 
            this.gridColumnCategory.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnCategory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnCategory.Caption = "Category";
            this.gridColumnCategory.FieldName = "Category";
            this.gridColumnCategory.Name = "gridColumnCategory";
            this.gridColumnCategory.Visible = true;
            this.gridColumnCategory.VisibleIndex = 4;
            // 
            // gridColumnModel
            // 
            this.gridColumnModel.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnModel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnModel.Caption = "Model";
            this.gridColumnModel.FieldName = "Model";
            this.gridColumnModel.Name = "gridColumnModel";
            this.gridColumnModel.Visible = true;
            this.gridColumnModel.VisibleIndex = 5;
            // 
            // gridColumnCode
            // 
            this.gridColumnCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnCode.Caption = "Code";
            this.gridColumnCode.FieldName = "Code";
            this.gridColumnCode.Name = "gridColumnCode";
            this.gridColumnCode.Visible = true;
            this.gridColumnCode.VisibleIndex = 6;
            // 
            // gridColumnQty
            // 
            this.gridColumnQty.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnQty.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnQty.Caption = "Qty";
            this.gridColumnQty.DisplayFormat.FormatString = "#,#";
            this.gridColumnQty.FieldName = "Qty";
            this.gridColumnQty.MaxWidth = 40;
            this.gridColumnQty.MinWidth = 40;
            this.gridColumnQty.Name = "gridColumnQty";
            this.gridColumnQty.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumnQty.Visible = true;
            this.gridColumnQty.VisibleIndex = 7;
            this.gridColumnQty.Width = 40;
            // 
            // gridColumnAmount
            // 
            this.gridColumnAmount.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumnAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnAmount.Caption = "Amount";
            this.gridColumnAmount.DisplayFormat.FormatString = "#.###";
            this.gridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnAmount.FieldName = "Amount";
            this.gridColumnAmount.MaxWidth = 70;
            this.gridColumnAmount.MinWidth = 70;
            this.gridColumnAmount.Name = "gridColumnAmount";
            this.gridColumnAmount.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumnAmount.Visible = true;
            this.gridColumnAmount.VisibleIndex = 9;
            this.gridColumnAmount.Width = 70;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(725, 4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(145, 23);
            this.btnExportExcel.TabIndex = 1;
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // UC_ImportFileExecuteDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.gridControl1);
            this.Name = "UC_ImportFileExecuteDetail";
            this.Size = new System.Drawing.Size(885, 326);
            this.Load += new System.EventHandler(this.UC_ImportFileExecuteDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSTT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReportFor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnInventory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStore;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBrand;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAmount;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBrandMain;
    }
}
