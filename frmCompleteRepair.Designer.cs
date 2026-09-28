namespace CPURepairSYS
{
    partial class frmCompleteRepair
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
            grpComplete = new GroupBox();
            btnCancel = new Button();
            btnComplete = new Button();
            lblPrompt2 = new Label();
            grpCustDetails = new GroupBox();
            txtStartDate = new TextBox();
            lblStartDate = new Label();
            txtPrice = new TextBox();
            lblPrice = new Label();
            txtRepId = new TextBox();
            lblRepId = new Label();
            txtRepDesc = new TextBox();
            lblRepDesc = new Label();
            lblCustId = new Label();
            lblCustSName = new Label();
            lblCustFName = new Label();
            txtSName = new TextBox();
            txtFName = new TextBox();
            txtCustId = new TextBox();
            grdRepairs = new DataGridView();
            grpRepSearch = new GroupBox();
            lblPrompt = new Label();
            cboTypes = new ComboBox();
            btnSearch = new Button();
            mnuInternalNavBar = new MenuStrip();
            mnuBack = new ToolStripMenuItem();
            grpComplete.SuspendLayout();
            grpCustDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdRepairs).BeginInit();
            grpRepSearch.SuspendLayout();
            mnuInternalNavBar.SuspendLayout();
            SuspendLayout();
            // 
            // grpComplete
            // 
            grpComplete.Controls.Add(btnCancel);
            grpComplete.Controls.Add(btnComplete);
            grpComplete.Controls.Add(lblPrompt2);
            grpComplete.Location = new Point(123, 268);
            grpComplete.Name = "grpComplete";
            grpComplete.Size = new Size(295, 100);
            grpComplete.TabIndex = 31;
            grpComplete.TabStop = false;
            grpComplete.Text = "Complete / Cancel";
            grpComplete.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(172, 61);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(106, 23);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "No";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnDeny_Click_1;
            // 
            // btnComplete
            // 
            btnComplete.Location = new Point(20, 61);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(106, 23);
            btnComplete.TabIndex = 13;
            btnComplete.Text = "Yes";
            btnComplete.UseVisualStyleBackColor = true;
            btnComplete.Click += btnConfirm_Click_1;
            // 
            // lblPrompt2
            // 
            lblPrompt2.AutoSize = true;
            lblPrompt2.Location = new Point(101, 36);
            lblPrompt2.Name = "lblPrompt2";
            lblPrompt2.Size = new Size(100, 15);
            lblPrompt2.TabIndex = 0;
            lblPrompt2.Text = "Complete Repair?";
            // 
            // grpCustDetails
            // 
            grpCustDetails.Controls.Add(txtStartDate);
            grpCustDetails.Controls.Add(lblStartDate);
            grpCustDetails.Controls.Add(txtPrice);
            grpCustDetails.Controls.Add(lblPrice);
            grpCustDetails.Controls.Add(txtRepId);
            grpCustDetails.Controls.Add(lblRepId);
            grpCustDetails.Controls.Add(txtRepDesc);
            grpCustDetails.Controls.Add(lblRepDesc);
            grpCustDetails.Controls.Add(lblCustId);
            grpCustDetails.Controls.Add(lblCustSName);
            grpCustDetails.Controls.Add(lblCustFName);
            grpCustDetails.Controls.Add(txtSName);
            grpCustDetails.Controls.Add(txtFName);
            grpCustDetails.Controls.Add(txtCustId);
            grpCustDetails.Enabled = false;
            grpCustDetails.Location = new Point(475, 55);
            grpCustDetails.Name = "grpCustDetails";
            grpCustDetails.Size = new Size(255, 313);
            grpCustDetails.TabIndex = 30;
            grpCustDetails.TabStop = false;
            grpCustDetails.Text = "Customer Details";
            grpCustDetails.Visible = false;
            // 
            // txtStartDate
            // 
            txtStartDate.Location = new Point(126, 115);
            txtStartDate.Name = "txtStartDate";
            txtStartDate.Size = new Size(123, 23);
            txtStartDate.TabIndex = 13;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(9, 118);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(58, 15);
            lblStartDate.TabIndex = 12;
            lblStartDate.Text = "Start Date";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(126, 89);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(123, 23);
            txtPrice.TabIndex = 11;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(9, 92);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(33, 15);
            lblPrice.TabIndex = 10;
            lblPrice.Text = "Price";
            // 
            // txtRepId
            // 
            txtRepId.Location = new Point(126, 164);
            txtRepId.Name = "txtRepId";
            txtRepId.Size = new Size(123, 23);
            txtRepId.TabIndex = 9;
            // 
            // lblRepId
            // 
            lblRepId.AutoSize = true;
            lblRepId.Location = new Point(9, 167);
            lblRepId.Name = "lblRepId";
            lblRepId.Size = new Size(53, 15);
            lblRepId.TabIndex = 8;
            lblRepId.Text = "Repair Id";
            // 
            // txtRepDesc
            // 
            txtRepDesc.Location = new Point(6, 220);
            txtRepDesc.Multiline = true;
            txtRepDesc.Name = "txtRepDesc";
            txtRepDesc.Size = new Size(243, 87);
            txtRepDesc.TabIndex = 7;
            // 
            // lblRepDesc
            // 
            lblRepDesc.AutoSize = true;
            lblRepDesc.Location = new Point(9, 202);
            lblRepDesc.Name = "lblRepDesc";
            lblRepDesc.Size = new Size(103, 15);
            lblRepDesc.TabIndex = 6;
            lblRepDesc.Text = "Repair Description";
            // 
            // lblCustId
            // 
            lblCustId.AutoSize = true;
            lblCustId.Location = new Point(6, 143);
            lblCustId.Name = "lblCustId";
            lblCustId.Size = new Size(72, 15);
            lblCustId.TabIndex = 5;
            lblCustId.Text = "Customer Id";
            // 
            // lblCustSName
            // 
            lblCustSName.AutoSize = true;
            lblCustSName.Location = new Point(9, 66);
            lblCustSName.Name = "lblCustSName";
            lblCustSName.Size = new Size(81, 15);
            lblCustSName.TabIndex = 4;
            lblCustSName.Text = "Second Name";
            // 
            // lblCustFName
            // 
            lblCustFName.AutoSize = true;
            lblCustFName.Location = new Point(9, 41);
            lblCustFName.Name = "lblCustFName";
            lblCustFName.Size = new Size(64, 15);
            lblCustFName.TabIndex = 3;
            lblCustFName.Text = "First Name";
            // 
            // txtSName
            // 
            txtSName.Location = new Point(126, 63);
            txtSName.Name = "txtSName";
            txtSName.Size = new Size(123, 23);
            txtSName.TabIndex = 2;
            // 
            // txtFName
            // 
            txtFName.Location = new Point(126, 38);
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(123, 23);
            txtFName.TabIndex = 1;
            // 
            // txtCustId
            // 
            txtCustId.Location = new Point(126, 140);
            txtCustId.Name = "txtCustId";
            txtCustId.Size = new Size(123, 23);
            txtCustId.TabIndex = 0;
            // 
            // grdRepairs
            // 
            grdRepairs.AllowUserToAddRows = false;
            grdRepairs.AllowUserToDeleteRows = false;
            grdRepairs.AllowUserToResizeColumns = false;
            grdRepairs.AllowUserToResizeRows = false;
            grdRepairs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdRepairs.Location = new Point(123, 161);
            grdRepairs.Name = "grdRepairs";
            grdRepairs.RowTemplate.Height = 25;
            grdRepairs.Size = new Size(295, 94);
            grdRepairs.TabIndex = 29;
            grdRepairs.Visible = false;
            grdRepairs.CellClick += grdRepairs_CellClick_1;
            // 
            // grpRepSearch
            // 
            grpRepSearch.Controls.Add(lblPrompt);
            grpRepSearch.Controls.Add(cboTypes);
            grpRepSearch.Controls.Add(btnSearch);
            grpRepSearch.Location = new Point(123, 55);
            grpRepSearch.Name = "grpRepSearch";
            grpRepSearch.Size = new Size(295, 100);
            grpRepSearch.TabIndex = 28;
            grpRepSearch.TabStop = false;
            grpRepSearch.Text = "Repair Search";
            // 
            // lblPrompt
            // 
            lblPrompt.AutoSize = true;
            lblPrompt.Location = new Point(20, 24);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(97, 15);
            lblPrompt.TabIndex = 10;
            lblPrompt.Text = "Enter Repair Type";
            // 
            // cboTypes
            // 
            cboTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTypes.FormattingEnabled = true;
            cboTypes.Location = new Point(129, 24);
            cboTypes.Name = "cboTypes";
            cboTypes.Size = new Size(121, 23);
            cboTypes.TabIndex = 14;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(82, 71);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(124, 23);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // mnuInternalNavBar
            // 
            mnuInternalNavBar.Items.AddRange(new ToolStripItem[] { mnuBack });
            mnuInternalNavBar.Location = new Point(0, 0);
            mnuInternalNavBar.Name = "mnuInternalNavBar";
            mnuInternalNavBar.Size = new Size(800, 24);
            mnuInternalNavBar.TabIndex = 27;
            mnuInternalNavBar.Text = "menuStrip1";
            // 
            // mnuBack
            // 
            mnuBack.Alignment = ToolStripItemAlignment.Right;
            mnuBack.Name = "mnuBack";
            mnuBack.Size = new Size(44, 20);
            mnuBack.Text = "Back";
            mnuBack.Click += mnuBack_Click_1;
            // 
            // frmCompleteRepair
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpComplete);
            Controls.Add(grpCustDetails);
            Controls.Add(grdRepairs);
            Controls.Add(grpRepSearch);
            Controls.Add(mnuInternalNavBar);
            Name = "frmCompleteRepair";
            Text = "frmCompleteRepair";
            Load += frmCompleteRepair_Load;
            grpComplete.ResumeLayout(false);
            grpComplete.PerformLayout();
            grpCustDetails.ResumeLayout(false);
            grpCustDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdRepairs).EndInit();
            grpRepSearch.ResumeLayout(false);
            grpRepSearch.PerformLayout();
            mnuInternalNavBar.ResumeLayout(false);
            mnuInternalNavBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpComplete;
        private Button btnCancel;
        private Button btnComplete;
        private Label lblPrompt2;
        private GroupBox grpCustDetails;
        private TextBox txtPrice;
        private Label lblPrice;
        private TextBox txtRepId;
        private Label lblRepId;
        private TextBox txtRepDesc;
        private Label lblRepDesc;
        private Label lblCustId;
        private Label lblCustSName;
        private Label lblCustFName;
        private TextBox txtSName;
        private TextBox txtFName;
        private TextBox txtCustId;
        private DataGridView grdRepairs;
        private GroupBox grpRepSearch;
        private Label lblPrompt;
        private ComboBox cboTypes;
        private Button btnSearch;
        private MenuStrip mnuInternalNavBar;
        private ToolStripMenuItem mnuBack;
        private TextBox txtStartDate;
        private Label lblStartDate;
    }
}