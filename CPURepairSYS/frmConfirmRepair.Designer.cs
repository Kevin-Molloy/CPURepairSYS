namespace CPURepairSYS
{
    partial class frmConfirmRepair
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
            grpRepSearch = new GroupBox();
            lblPrompt = new Label();
            cboTypes = new ComboBox();
            btnSearch = new Button();
            grdRepairs = new DataGridView();
            grpCustDetails = new GroupBox();
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
            grpConfirm = new GroupBox();
            btnDeny = new Button();
            btnConfirm = new Button();
            lblPrompt2 = new Label();
            mnuInternalNavBar.SuspendLayout();
            grpRepSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdRepairs).BeginInit();
            grpCustDetails.SuspendLayout();
            grpConfirm.SuspendLayout();
            SuspendLayout();
            // 
            // mnuInternalNavBar
            // 
            mnuInternalNavBar.Items.AddRange(new ToolStripItem[] { mnuBack });
            mnuInternalNavBar.Location = new Point(0, 0);
            mnuInternalNavBar.Name = "mnuInternalNavBar";
            mnuInternalNavBar.Size = new Size(800, 24);
            mnuInternalNavBar.TabIndex = 22;
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
            // grpRepSearch
            // 
            grpRepSearch.Controls.Add(lblPrompt);
            grpRepSearch.Controls.Add(cboTypes);
            grpRepSearch.Controls.Add(btnSearch);
            grpRepSearch.Location = new Point(118, 91);
            grpRepSearch.Name = "grpRepSearch";
            grpRepSearch.Size = new Size(295, 100);
            grpRepSearch.TabIndex = 23;
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
            // grdRepairs
            // 
            grdRepairs.AllowUserToAddRows = false;
            grdRepairs.AllowUserToDeleteRows = false;
            grdRepairs.AllowUserToResizeColumns = false;
            grdRepairs.AllowUserToResizeRows = false;
            grdRepairs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdRepairs.Location = new Point(469, 44);
            grdRepairs.Name = "grdRepairs";
            grdRepairs.RowTemplate.Height = 25;
            grdRepairs.Size = new Size(254, 94);
            grdRepairs.TabIndex = 24;
            grdRepairs.Visible = false;
            grdRepairs.CellClick += grdRepairs_CellClick;
            // 
            // grpCustDetails
            // 
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
            grpCustDetails.Location = new Point(469, 144);
            grpCustDetails.Name = "grpCustDetails";
            grpCustDetails.Size = new Size(255, 285);
            grpCustDetails.TabIndex = 25;
            grpCustDetails.TabStop = false;
            grpCustDetails.Text = "Customer Details";
            grpCustDetails.Visible = false;
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
            lblPrice.Location = new Point(6, 94);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(33, 15);
            lblPrice.TabIndex = 10;
            lblPrice.Text = "Price";
            // 
            // txtRepId
            // 
            txtRepId.Location = new Point(126, 149);
            txtRepId.Name = "txtRepId";
            txtRepId.Size = new Size(123, 23);
            txtRepId.TabIndex = 9;
            // 
            // lblRepId
            // 
            lblRepId.AutoSize = true;
            lblRepId.Location = new Point(6, 149);
            lblRepId.Name = "lblRepId";
            lblRepId.Size = new Size(53, 15);
            lblRepId.TabIndex = 8;
            lblRepId.Text = "Repair Id";
            // 
            // txtRepDesc
            // 
            txtRepDesc.Location = new Point(6, 192);
            txtRepDesc.Multiline = true;
            txtRepDesc.Name = "txtRepDesc";
            txtRepDesc.Size = new Size(243, 87);
            txtRepDesc.TabIndex = 7;
            // 
            // lblRepDesc
            // 
            lblRepDesc.AutoSize = true;
            lblRepDesc.Location = new Point(6, 174);
            lblRepDesc.Name = "lblRepDesc";
            lblRepDesc.Size = new Size(103, 15);
            lblRepDesc.TabIndex = 6;
            lblRepDesc.Text = "Repair Description";
            // 
            // lblCustId
            // 
            lblCustId.AutoSize = true;
            lblCustId.Location = new Point(6, 121);
            lblCustId.Name = "lblCustId";
            lblCustId.Size = new Size(72, 15);
            lblCustId.TabIndex = 5;
            lblCustId.Text = "Customer Id";
            // 
            // lblCustSName
            // 
            lblCustSName.AutoSize = true;
            lblCustSName.Location = new Point(6, 61);
            lblCustSName.Name = "lblCustSName";
            lblCustSName.Size = new Size(81, 15);
            lblCustSName.TabIndex = 4;
            lblCustSName.Text = "Second Name";
            // 
            // lblCustFName
            // 
            lblCustFName.AutoSize = true;
            lblCustFName.Location = new Point(6, 26);
            lblCustFName.Name = "lblCustFName";
            lblCustFName.Size = new Size(64, 15);
            lblCustFName.TabIndex = 3;
            lblCustFName.Text = "First Name";
            // 
            // txtSName
            // 
            txtSName.Location = new Point(126, 58);
            txtSName.Name = "txtSName";
            txtSName.Size = new Size(123, 23);
            txtSName.TabIndex = 2;
            // 
            // txtFName
            // 
            txtFName.Location = new Point(126, 22);
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(123, 23);
            txtFName.TabIndex = 1;
            // 
            // txtCustId
            // 
            txtCustId.Location = new Point(126, 118);
            txtCustId.Name = "txtCustId";
            txtCustId.Size = new Size(123, 23);
            txtCustId.TabIndex = 0;
            // 
            // grpConfirm
            // 
            grpConfirm.Controls.Add(btnDeny);
            grpConfirm.Controls.Add(btnConfirm);
            grpConfirm.Controls.Add(lblPrompt2);
            grpConfirm.Location = new Point(123, 257);
            grpConfirm.Name = "grpConfirm";
            grpConfirm.Size = new Size(290, 100);
            grpConfirm.TabIndex = 26;
            grpConfirm.TabStop = false;
            grpConfirm.Text = "Confirm / Deny";
            grpConfirm.Visible = false;
            // 
            // btnDeny
            // 
            btnDeny.Location = new Point(177, 61);
            btnDeny.Name = "btnDeny";
            btnDeny.Size = new Size(106, 23);
            btnDeny.TabIndex = 14;
            btnDeny.Text = "No";
            btnDeny.UseVisualStyleBackColor = true;
            btnDeny.Click += btnDeny_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(29, 61);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(106, 23);
            btnConfirm.TabIndex = 13;
            btnConfirm.Text = "Yes";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lblPrompt2
            // 
            lblPrompt2.AutoSize = true;
            lblPrompt2.Location = new Point(49, 36);
            lblPrompt2.Name = "lblPrompt2";
            lblPrompt2.Size = new Size(207, 15);
            lblPrompt2.TabIndex = 0;
            lblPrompt2.Text = "Has the customer approved the price?";
            // 
            // frmConfirmRepair
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpConfirm);
            Controls.Add(grpCustDetails);
            Controls.Add(grdRepairs);
            Controls.Add(grpRepSearch);
            Controls.Add(mnuInternalNavBar);
            Name = "frmConfirmRepair";
            Text = "frmConfirmRepair";
            Load += frmConfirmRepair_Load;
            mnuInternalNavBar.ResumeLayout(false);
            mnuInternalNavBar.PerformLayout();
            grpRepSearch.ResumeLayout(false);
            grpRepSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdRepairs).EndInit();
            grpCustDetails.ResumeLayout(false);
            grpCustDetails.PerformLayout();
            grpConfirm.ResumeLayout(false);
            grpConfirm.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuInternalNavBar;
        private ToolStripMenuItem mnuBack;
        private GroupBox grpRepSearch;
        private Label lblPrompt;
        private ComboBox cboTypes;
        private Button btnSearch;
        private DataGridView grdRepairs;
        private GroupBox grpCustDetails;
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
        private TextBox txtPrice;
        private Label lblPrice;
        private GroupBox grpConfirm;
        private Label lblPrompt2;
        private Button btnDeny;
        private Button btnConfirm;
    }
}