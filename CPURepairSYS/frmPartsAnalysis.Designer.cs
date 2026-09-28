namespace CPURepairSYS
{
    partial class frmPartsAnalysis
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mnuInternalNavBar = new MenuStrip();
            mnuBack = new ToolStripMenuItem();
            grpPartDetails = new GroupBox();
            cboYears = new ComboBox();
            chkShowDiscontinued = new CheckBox();
            chkShowOutOfStock = new CheckBox();
            cboOrderBy = new ComboBox();
            lblOrderBy = new Label();
            btnAnalyseParts = new Button();
            lblPrompt = new Label();
            grdParts = new DataGridView();
            mnuInternalNavBar.SuspendLayout();
            grpPartDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdParts).BeginInit();
            SuspendLayout();
            // 
            // mnuInternalNavBar
            // 
            mnuInternalNavBar.Items.AddRange(new ToolStripItem[] { mnuBack });
            mnuInternalNavBar.Location = new Point(0, 0);
            mnuInternalNavBar.Name = "mnuInternalNavBar";
            mnuInternalNavBar.Size = new Size(800, 24);
            mnuInternalNavBar.TabIndex = 17;
            mnuInternalNavBar.Text = "menuStrip1";
            // 
            // mnuBack
            // 
            mnuBack.Alignment = ToolStripItemAlignment.Right;
            mnuBack.Name = "mnuBack";
            mnuBack.Size = new Size(44, 20);
            mnuBack.Text = "Back";
            mnuBack.Click += mnuBack_Click;
            // 
            // grpPartDetails
            // 
            grpPartDetails.Controls.Add(cboYears);
            grpPartDetails.Controls.Add(chkShowDiscontinued);
            grpPartDetails.Controls.Add(chkShowOutOfStock);
            grpPartDetails.Controls.Add(cboOrderBy);
            grpPartDetails.Controls.Add(lblOrderBy);
            grpPartDetails.Controls.Add(btnAnalyseParts);
            grpPartDetails.Controls.Add(lblPrompt);
            grpPartDetails.Location = new Point(89, 37);
            grpPartDetails.Name = "grpPartDetails";
            grpPartDetails.Size = new Size(248, 223);
            grpPartDetails.TabIndex = 18;
            grpPartDetails.TabStop = false;
            grpPartDetails.Text = "Enter Details";
            // 
            // cboYears
            // 
            cboYears.DropDownStyle = ComboBoxStyle.DropDownList;
            cboYears.FormattingEnabled = true;
            cboYears.Items.AddRange(new object[] { "2021", "2022", "2023", "2024", "2025" });
            cboYears.Location = new Point(83, 33);
            cboYears.Name = "cboYears";
            cboYears.Size = new Size(121, 23);
            cboYears.TabIndex = 7;
            // 
            // chkShowDiscontinued
            // 
            chkShowDiscontinued.AutoSize = true;
            chkShowDiscontinued.Location = new Point(18, 140);
            chkShowDiscontinued.Name = "chkShowDiscontinued";
            chkShowDiscontinued.Size = new Size(162, 19);
            chkShowDiscontinued.TabIndex = 6;
            chkShowDiscontinued.Text = "Show Discontinued Parts?";
            chkShowDiscontinued.UseVisualStyleBackColor = true;
            // 
            // chkShowOutOfStock
            // 
            chkShowOutOfStock.AutoSize = true;
            chkShowOutOfStock.Location = new Point(18, 106);
            chkShowOutOfStock.Name = "chkShowOutOfStock";
            chkShowOutOfStock.Size = new Size(205, 19);
            chkShowOutOfStock.TabIndex = 5;
            chkShowOutOfStock.Text = "Show currently out of stock Parts?";
            chkShowOutOfStock.UseVisualStyleBackColor = true;
            // 
            // cboOrderBy
            // 
            cboOrderBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOrderBy.FormattingEnabled = true;
            cboOrderBy.Items.AddRange(new object[] { "Description", "Price", "Quantity" });
            cboOrderBy.Location = new Point(83, 69);
            cboOrderBy.Name = "cboOrderBy";
            cboOrderBy.Size = new Size(121, 23);
            cboOrderBy.TabIndex = 4;
            // 
            // lblOrderBy
            // 
            lblOrderBy.AutoSize = true;
            lblOrderBy.Location = new Point(18, 69);
            lblOrderBy.Name = "lblOrderBy";
            lblOrderBy.Size = new Size(53, 15);
            lblOrderBy.TabIndex = 3;
            lblOrderBy.Text = "Order By";
            // 
            // btnAnalyseParts
            // 
            btnAnalyseParts.Location = new Point(69, 182);
            btnAnalyseParts.Name = "btnAnalyseParts";
            btnAnalyseParts.Size = new Size(121, 23);
            btnAnalyseParts.TabIndex = 1;
            btnAnalyseParts.Text = "Retrieve Parts";
            btnAnalyseParts.UseVisualStyleBackColor = true;
            btnAnalyseParts.Click += btnAnalyseParts_Click;
            // 
            // lblPrompt
            // 
            lblPrompt.AutoSize = true;
            lblPrompt.Location = new Point(18, 36);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(59, 15);
            lblPrompt.TabIndex = 0;
            lblPrompt.Text = "Enter Year";
            // 
            // grdParts
            // 
            grdParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdParts.Location = new Point(362, 46);
            grdParts.Name = "grdParts";
            grdParts.RowTemplate.Height = 25;
            grdParts.Size = new Size(386, 150);
            grdParts.TabIndex = 19;
            grdParts.Visible = false;
            // 
            // frmPartsAnalysis
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grdParts);
            Controls.Add(grpPartDetails);
            Controls.Add(mnuInternalNavBar);
            Name = "frmPartsAnalysis";
            Text = "frmPartsAnalysis";
            Load += frmPartsAnalysis_Load;
            mnuInternalNavBar.ResumeLayout(false);
            mnuInternalNavBar.PerformLayout();
            grpPartDetails.ResumeLayout(false);
            grpPartDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdParts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuInternalNavBar;
        private ToolStripMenuItem mnuBack;
        private GroupBox grpPartDetails;
        private ComboBox cboYears;
        private CheckBox chkShowDiscontinued;
        private CheckBox chkShowOutOfStock;
        private ComboBox cboOrderBy;
        private Label lblOrderBy;
        private Button btnAnalyseParts;
        private Label lblPrompt;
        private DataGridView grdParts;
    }
}