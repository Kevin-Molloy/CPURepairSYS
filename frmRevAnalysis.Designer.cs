namespace CPURepairSYS
{
    partial class frmRevAnalysis
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
            grpListDetails = new GroupBox();
            chkInclude = new CheckBox();
            cboYears = new ComboBox();
            btnAnalyseRevenue = new Button();
            lblPrompt = new Label();
            grdRev = new DataGridView();
            grpRev = new GroupBox();
            lblTotalRevenue = new Label();
            mnuInternalNavBar.SuspendLayout();
            grpListDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdRev).BeginInit();
            grpRev.SuspendLayout();
            SuspendLayout();
            // 
            // mnuInternalNavBar
            // 
            mnuInternalNavBar.Items.AddRange(new ToolStripItem[] { mnuBack });
            mnuInternalNavBar.Location = new Point(0, 0);
            mnuInternalNavBar.Name = "mnuInternalNavBar";
            mnuInternalNavBar.Size = new Size(800, 24);
            mnuInternalNavBar.TabIndex = 18;
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
            // grpListDetails
            // 
            grpListDetails.Controls.Add(chkInclude);
            grpListDetails.Controls.Add(cboYears);
            grpListDetails.Controls.Add(btnAnalyseRevenue);
            grpListDetails.Controls.Add(lblPrompt);
            grpListDetails.Location = new Point(99, 60);
            grpListDetails.Name = "grpListDetails";
            grpListDetails.Size = new Size(248, 152);
            grpListDetails.TabIndex = 19;
            grpListDetails.TabStop = false;
            grpListDetails.Text = "Enter Details";
            // 
            // chkInclude
            // 
            chkInclude.AutoSize = true;
            chkInclude.Location = new Point(18, 72);
            chkInclude.Name = "chkInclude";
            chkInclude.Size = new Size(166, 19);
            chkInclude.TabIndex = 8;
            chkInclude.Text = "Include Cancelled Repairs?";
            chkInclude.UseVisualStyleBackColor = true;
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
            // btnAnalyseRevenue
            // 
            btnAnalyseRevenue.Location = new Point(63, 110);
            btnAnalyseRevenue.Name = "btnAnalyseRevenue";
            btnAnalyseRevenue.Size = new Size(121, 23);
            btnAnalyseRevenue.TabIndex = 1;
            btnAnalyseRevenue.Text = "Calculate Revenue";
            btnAnalyseRevenue.UseVisualStyleBackColor = true;
            btnAnalyseRevenue.Click += btnAnalyseRevenue_Click;
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
            // grdRev
            // 
            grdRev.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdRev.Location = new Point(18, 21);
            grdRev.Name = "grdRev";
            grdRev.RowTemplate.Height = 25;
            grdRev.Size = new Size(248, 150);
            grdRev.TabIndex = 20;
            // 
            // grpRev
            // 
            grpRev.Controls.Add(lblTotalRevenue);
            grpRev.Controls.Add(grdRev);
            grpRev.Location = new Point(374, 72);
            grpRev.Name = "grpRev";
            grpRev.Size = new Size(284, 211);
            grpRev.TabIndex = 21;
            grpRev.TabStop = false;
            grpRev.Text = "Results";
            grpRev.Visible = false;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Location = new Point(26, 181);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(0, 15);
            lblTotalRevenue.TabIndex = 21;
            // 
            // frmRevAnalysis
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpRev);
            Controls.Add(grpListDetails);
            Controls.Add(mnuInternalNavBar);
            Name = "frmRevAnalysis";
            Text = "frmRevAnalysis";
            Load += frmRevAnalysis_Load;
            mnuInternalNavBar.ResumeLayout(false);
            mnuInternalNavBar.PerformLayout();
            grpListDetails.ResumeLayout(false);
            grpListDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdRev).EndInit();
            grpRev.ResumeLayout(false);
            grpRev.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuInternalNavBar;
        private ToolStripMenuItem mnuBack;
        private GroupBox grpListDetails;
        private ComboBox cboYears;
        private CheckBox chkShowDiscontinued;
        private CheckBox chkShowOutOfStock;
        private ComboBox cboOrderBy;
        private Label lblOrderBy;
        private Button btnAnalyseRevenue;
        private Label lblPrompt;
        private DataGridView grdRev;
        private GroupBox grpRev;
        private Label lblTotalRevenue;
        private CheckBox chkInclude;
    }
}