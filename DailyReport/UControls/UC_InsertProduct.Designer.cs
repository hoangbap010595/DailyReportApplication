namespace DailyReport.UControls
{
    partial class UC_InsertProduct
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
            this.btnChooseFile1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtPathFile1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.cbbSheet = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPathFile1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSheet.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChooseFile1
            // 
            this.btnChooseFile1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnChooseFile1.Appearance.Options.UseFont = true;
            this.btnChooseFile1.Location = new System.Drawing.Point(166, 9);
            this.btnChooseFile1.Name = "btnChooseFile1";
            this.btnChooseFile1.Size = new System.Drawing.Size(75, 26);
            this.btnChooseFile1.TabIndex = 1;
            this.btnChooseFile1.Text = "Chọn...";
            this.btnChooseFile1.Click += new System.EventHandler(this.btnChooseFile1_Click);
            // 
            // txtPathFile1
            // 
            this.txtPathFile1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathFile1.Location = new System.Drawing.Point(11, 38);
            this.txtPathFile1.Name = "txtPathFile1";
            this.txtPathFile1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtPathFile1.Properties.Appearance.Options.UseFont = true;
            this.txtPathFile1.Properties.ReadOnly = true;
            this.txtPathFile1.Size = new System.Drawing.Size(679, 26);
            this.txtPathFile1.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(11, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(162, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Chọn file cần import:";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Location = new System.Drawing.Point(11, 79);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(679, 241);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "View Detail";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 23);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(675, 216);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnStart.Appearance.Options.UseFont = true;
            this.btnStart.Location = new System.Drawing.Point(576, 9);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 26);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Thực hiện";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cbbSheet
            // 
            this.cbbSheet.Location = new System.Drawing.Point(247, 10);
            this.cbbSheet.Name = "cbbSheet";
            this.cbbSheet.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cbbSheet.Properties.Appearance.Options.UseFont = true;
            this.cbbSheet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbSheet.Size = new System.Drawing.Size(100, 26);
            this.cbbSheet.TabIndex = 3;
            this.cbbSheet.SelectedIndexChanged += new System.EventHandler(this.cbbSheet_SelectedIndexChanged);
            // 
            // UC_InsertProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbbSheet);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnChooseFile1);
            this.Controls.Add(this.txtPathFile1);
            this.Controls.Add(this.labelControl1);
            this.Name = "UC_InsertProduct";
            this.Size = new System.Drawing.Size(700, 324);
            ((System.ComponentModel.ISupportInitialize)(this.txtPathFile1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSheet.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnChooseFile1;
        private DevExpress.XtraEditors.TextEdit txtPathFile1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraEditors.ComboBoxEdit cbbSheet;
    }
}
