namespace CPURepairSYS
{
    partial class frmListRepairs
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
            cboYears = new ComboBox();
            chkShowCancelled = new CheckBox();
            chkShowInProgress = new CheckBox();
            cboOrderBy = new ComboBox();
            lblOrderBy = new Label();
            btnListRepairs = new Button();
            lblPrompt = new Label();
            grdRepairs = new DataGridView();
            mnuInternalNavBar.SuspendLayout();
            grpListDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdRepairs).BeginInit();
            SuspendLayout();
            // 
            // mnuInternalNavBar
            // 
            mnuInternalNavBar.Items.AddRange(new ToolStripItem[] { mnuBack });
            mnuInternalNavBar.Location = new Point(0, 0);
            mnuInternalNavBar.Name = "mnuInternalNavBar";
            mnuInternalNavBar.Size = new Size(800, 24);
            mnuInternalNavBar.TabIndex = 16;
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
            grpListDetails.Controls.Add(cboYears);
            grpListDetails.Controls.Add(chkShowCancelled);
            grpListDetails.Controls.Add(chkShowInProgress);
            grpListDetails.Controls.Add(cboOrderBy);
            grpListDetails.Controls.Add(lblOrderBy);
            grpListDetails.Controls.Add(btnListRepairs);
            grpListDetails.Controls.Add(lblPrompt);
            grpListDetails.Location = new Point(88, 41);
            grpListDetails.Name = "grpListDetails";
            grpListDetails.Size = new Size(248, 223);
            grpListDetails.TabIndex = 17;
            grpListDetails.TabStop = false;
            grpListDetails.Text = "Enter Details";
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
            // chkShowCancelled
            // 
            chkShowCancelled.AutoSize = true;
            chkShowCancelled.Location = new Point(18, 140);
            chkShowCancelled.Name = "chkShowCancelled";
            chkShowCancelled.Size = new Size(156, 19);
            chkShowCancelled.TabIndex = 6;
            chkShowCancelled.Text = "Show Cancelled Repairs?";
            chkShowCancelled.UseVisualStyleBackColor = true;
            // 
            // chkShowInProgress
            // 
            chkShowInProgress.AutoSize = true;
            chkShowInProgress.Location = new Point(18, 106);
            chkShowInProgress.Name = "chkShowInProgress";
            chkShowInProgress.Size = new Size(189, 19);
            chkShowInProgress.TabIndex = 5;
            chkShowInProgress.Text = "Show only Completed Repairs?";
            chkShowInProgress.UseVisualStyleBackColor = true;
            // 
            // cboOrderBy
            // 
            cboOrderBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOrderBy.FormattingEnabled = true;
            cboOrderBy.Items.AddRange(new object[] { "Date Completed", "Date Started", "Price" });
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
            // btnListRepairs
            // 
            btnListRepairs.Location = new Point(83, 182);
            btnListRepairs.Name = "btnListRepairs";
            btnListRepairs.Size = new Size(121, 23);
            btnListRepairs.TabIndex = 1;
            btnListRepairs.Text = "View Repairs";
            btnListRepairs.UseVisualStyleBackColor = true;
            btnListRepairs.Click += btnListRepairs_Click;
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
            // grdRepairs
            // 
            grdRepairs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdRepairs.Location = new Point(373, 50);
            grdRepairs.Name = "grdRepairs";
            grdRepairs.RowTemplate.Height = 25;
            grdRepairs.Size = new Size(386, 150);
            grdRepairs.TabIndex = 18;
            grdRepairs.Visible = false;
            // 
            // frmListRepairs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grdRepairs);
            Controls.Add(grpListDetails);
            Controls.Add(mnuInternalNavBar);
            Name = "frmListRepairs";
            Text = "frmListRepairs";
            Load += frmListRepairs_Load;
            mnuInternalNavBar.ResumeLayout(false);
            mnuInternalNavBar.PerformLayout();
            grpListDetails.ResumeLayout(false);
            grpListDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdRepairs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuInternalNavBar;
        private ToolStripMenuItem mnuBack;
        private GroupBox grpListDetails;
        private Button btnListRepairs;
        private Label lblPrompt;
        private DataGridView grdRepairs;
        private ComboBox cboOrderBy;
        private Label lblOrderBy;
        private ComboBox cboYears;
        private CheckBox chkShowCancelled;
        private CheckBox chkShowInProgress;
    }
}