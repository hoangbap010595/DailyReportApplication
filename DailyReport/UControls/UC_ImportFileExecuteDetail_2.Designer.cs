namespace DailyReport.UControls
{
    partial class UC_ImportFileExecuteDetail_2
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
            this.gridColumnStore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBrandMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridColumnPrice.Caption = "Gross Sales";
            this.gridColumnPrice.DisplayFormat.FormatString = "#.###";
            this.gridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumnPrice.FieldName = "Amount";
            this.gridColumnPrice.GroupFormat.FormatString = "{0:#.###}";
            this.gridColumnPrice.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnPrice.MaxWidth = 100;
            this.gridColumnPrice.MinWidth = 100;
            this.gridColumnPrice.Name = "gridColumnPrice";
            this.gridColumnPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:#.###}")});
            this.gridColumnPrice.Visible = true;
            this.gridColumnPrice.VisibleIndex = 3;
            this.gridColumnPrice.Width = 100;
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
            this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
            this.gridView1.Appearance.GroupFooter.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupFooter.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnSTT,
            this.gridColumnStore,
            this.gridColumnBrandMain,
            this.gridColumnQty,
            this.gridColumnPrice,
            this.gridColumnDiscount,
            this.gridColumnAmount});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", this.gridColumnQty, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", this.gridColumnPrice, "{0:#.###}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetSales", this.gridColumnAmount, "{0:#.###}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Discount", this.gridColumnDiscount, "{0:#.###}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.AllowExcelFormat = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
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
            this.gridColumnSTT.OptionsEditForm.CaptionLocation = DevExpress.XtraGrid.EditForm.EditFormColumnCaptionLocation.None;
            this.gridColumnSTT.Visible = true;
            this.gridColumnSTT.VisibleIndex = 0;
            this.gridColumnSTT.Width = 41;
            // 
            // gridColumnStore
            // 
            this.gridColumnStore.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnStore.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnStore.Caption = "Store";
            this.gridColumnStore.FieldName = "Store";
            this.gridColumnStore.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value;
            this.gridColumnStore.Name = "gridColumnStore";
            this.gridColumnStore.OptionsEditForm.CaptionLocation = DevExpress.XtraGrid.EditForm.EditFormColumnCaptionLocation.None;
            this.gridColumnStore.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Store", "{0}")});
            this.gridColumnStore.Visible = true;
            this.gridColumnStore.VisibleIndex = 1;
            // 
            // gridColumnBrandMain
            // 
            this.gridColumnBrandMain.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnBrandMain.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnBrandMain.Caption = "Brand";
            this.gridColumnBrandMain.FieldName = "Brand";
            this.gridColumnBrandMain.Name = "gridColumnBrandMain";
            this.gridColumnBrandMain.Visible = true;
            this.gridColumnBrandMain.VisibleIndex = 1;
            // 
            // gridColumnQty
            // 
            this.gridColumnQty.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnQty.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnQty.Caption = "Qty";
            this.gridColumnQty.DisplayFormat.FormatString = "#.#";
            this.gridColumnQty.FieldName = "Qty";
            this.gridColumnQty.GroupFormat.FormatString = "{0:#.###}";
            this.gridColumnQty.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnQty.MaxWidth = 60;
            this.gridColumnQty.MinWidth = 60;
            this.gridColumnQty.Name = "gridColumnQty";
            this.gridColumnQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0:0.##}")});
            this.gridColumnQty.Visible = true;
            this.gridColumnQty.VisibleIndex = 2;
            this.gridColumnQty.Width = 60;
            // 
            // gridColumnDiscount
            // 
            this.gridColumnDiscount.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnDiscount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumnDiscount.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnDiscount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnDiscount.Caption = "Discount";
            this.gridColumnDiscount.FieldName = "Discount";
            this.gridColumnDiscount.GroupFormat.FormatString = "{0:#.###}";
            this.gridColumnDiscount.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnDiscount.MaxWidth = 100;
            this.gridColumnDiscount.MinWidth = 100;
            this.gridColumnDiscount.Name = "gridColumnDiscount";
            this.gridColumnDiscount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Discount", "{0:0.##}")});
            this.gridColumnDiscount.Visible = true;
            this.gridColumnDiscount.VisibleIndex = 4;
            this.gridColumnDiscount.Width = 100;
            // 
            // gridColumnAmount
            // 
            this.gridColumnAmount.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumnAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnAmount.Caption = "Net Sales";
            this.gridColumnAmount.DisplayFormat.FormatString = "#.###";
            this.gridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnAmount.FieldName = "NetSales";
            this.gridColumnAmount.GroupFormat.FormatString = "{0:#.###}";
            this.gridColumnAmount.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnAmount.MaxWidth = 100;
            this.gridColumnAmount.MinWidth = 100;
            this.gridColumnAmount.Name = "gridColumnAmount";
            this.gridColumnAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetSales", "{0:#.###}")});
            this.gridColumnAmount.Visible = true;
            this.gridColumnAmount.VisibleIndex = 5;
            this.gridColumnAmount.Width = 100;
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
            // UC_ImportFileExecuteDetail_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.gridControl1);
            this.Name = "UC_ImportFileExecuteDetail_2";
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStore;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAmount;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBrandMain;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDiscount;
    }
}
