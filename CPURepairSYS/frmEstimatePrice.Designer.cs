namespace CPURepairSYS
{
    partial class frmEstimatePrice
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
            grdRepairs = new DataGridView();
            btnSearch = new Button();
            lblPrompt = new Label();
            grpPartSearch = new GroupBox();
            btnRmvPart = new Button();
            txtPartPrice = new TextBox();
            lblPartPrice = new Label();
            btnAddPart = new Button();
            btnEstimatePrice = new Button();
            txtTotalPrice = new TextBox();
            lblTotalPrice = new Label();
            txtPartQty = new TextBox();
            lblpartQuantity = new Label();
            lstPartBasket = new ListBox();
            grdParts = new DataGridView();
            txtPartDesc = new TextBox();
            lblPrompt2 = new Label();
            cboTypes = new ComboBox();
            grpRepSearch = new GroupBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            grpCustDetails = new GroupBox();
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
            mnuInternalNavBar = new MenuStrip();
            mnuBack = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)grdRepairs).BeginInit();
            grpPartSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdParts).BeginInit();
            grpRepSearch.SuspendLayout();
            grpCustDetails.SuspendLayout();
            mnuInternalNavBar.SuspendLayout();
            SuspendLayout();
            // 
            // grdRepairs
            // 
            grdRepairs.AllowUserToAddRows = false;
            grdRepairs.AllowUserToDeleteRows = false;
            grdRepairs.AllowUserToResizeColumns = false;
            grdRepairs.AllowUserToResizeRows = false;
            grdRepairs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdRepairs.Location = new Point(368, 59);
            grdRepairs.Name = "grdRepairs";
            grdRepairs.RowTemplate.Height = 25;
            grdRepairs.Size = new Size(254, 94);
            grdRepairs.TabIndex = 13;
            grdRepairs.Visible = false;
            grdRepairs.CellClick += grdRepairs_CellClick;
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
            // lblPrompt
            // 
            lblPrompt.AutoSize = true;
            lblPrompt.Location = new Point(20, 24);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(97, 15);
            lblPrompt.TabIndex = 10;
            lblPrompt.Text = "Enter Repair Type";
            // 
            // grpPartSearch
            // 
            grpPartSearch.Controls.Add(btnRmvPart);
            grpPartSearch.Controls.Add(txtPartPrice);
            grpPartSearch.Controls.Add(lblPartPrice);
            grpPartSearch.Controls.Add(btnAddPart);
            grpPartSearch.Controls.Add(btnEstimatePrice);
            grpPartSearch.Controls.Add(txtTotalPrice);
            grpPartSearch.Controls.Add(lblTotalPrice);
            grpPartSearch.Controls.Add(txtPartQty);
            grpPartSearch.Controls.Add(lblpartQuantity);
            grpPartSearch.Controls.Add(lstPartBasket);
            grpPartSearch.Controls.Add(grdParts);
            grpPartSearch.Controls.Add(txtPartDesc);
            grpPartSearch.Controls.Add(lblPrompt2);
            grpPartSearch.Location = new Point(12, 212);
            grpPartSearch.Name = "grpPartSearch";
            grpPartSearch.Size = new Size(515, 326);
            grpPartSearch.TabIndex = 17;
            grpPartSearch.TabStop = false;
            grpPartSearch.Text = "Part Search";
            grpPartSearch.Visible = false;
            // 
            // btnRmvPart
            // 
            btnRmvPart.Location = new Point(233, 192);
            btnRmvPart.Name = "btnRmvPart";
            btnRmvPart.Size = new Size(276, 23);
            btnRmvPart.TabIndex = 22;
            btnRmvPart.Text = "Remove Newest";
            btnRmvPart.UseVisualStyleBackColor = true;
            btnRmvPart.Click += btnRmvPart_Click;
            // 
            // txtPartPrice
            // 
            txtPartPrice.Enabled = false;
            txtPartPrice.Location = new Point(69, 248);
            txtPartPrice.Name = "txtPartPrice";
            txtPartPrice.Size = new Size(61, 23);
            txtPartPrice.TabIndex = 29;
            // 
            // lblPartPrice
            // 
            lblPartPrice.AutoSize = true;
            lblPartPrice.Location = new Point(10, 248);
            lblPartPrice.Name = "lblPartPrice";
            lblPartPrice.Size = new Size(33, 15);
            lblPartPrice.TabIndex = 28;
            lblPartPrice.Text = "Price";
            // 
            // btnAddPart
            // 
            btnAddPart.Location = new Point(42, 277);
            btnAddPart.Name = "btnAddPart";
            btnAddPart.Size = new Size(75, 23);
            btnAddPart.TabIndex = 27;
            btnAddPart.Text = "Add Part";
            btnAddPart.UseVisualStyleBackColor = true;
            btnAddPart.Click += btnAddPart_Click;
            // 
            // btnEstimatePrice
            // 
            btnEstimatePrice.Location = new Point(342, 277);
            btnEstimatePrice.Name = "btnEstimatePrice";
            btnEstimatePrice.Size = new Size(155, 23);
            btnEstimatePrice.TabIndex = 26;
            btnEstimatePrice.Text = "Checkout";
            btnEstimatePrice.UseVisualStyleBackColor = true;
            btnEstimatePrice.Click += btnEstimatePrice_Click;
            // 
            // txtTotalPrice
            // 
            txtTotalPrice.Enabled = false;
            txtTotalPrice.Location = new Point(457, 221);
            txtTotalPrice.Name = "txtTotalPrice";
            txtTotalPrice.Size = new Size(52, 23);
            txtTotalPrice.TabIndex = 25;
            txtTotalPrice.Text = "00.00";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Location = new Point(375, 224);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(76, 15);
            lblTotalPrice.TabIndex = 24;
            lblTotalPrice.Text = "Current Price";
            // 
            // txtPartQty
            // 
            txtPartQty.Location = new Point(69, 218);
            txtPartQty.Name = "txtPartQty";
            txtPartQty.Size = new Size(38, 23);
            txtPartQty.TabIndex = 23;
            txtPartQty.Text = "1";
            // 
            // lblpartQuantity
            // 
            lblpartQuantity.AutoSize = true;
            lblpartQuantity.Location = new Point(10, 218);
            lblpartQuantity.Name = "lblpartQuantity";
            lblpartQuantity.Size = new Size(53, 15);
            lblpartQuantity.TabIndex = 22;
            lblpartQuantity.Text = "Quantity";
            // 
            // lstPartBasket
            // 
            lstPartBasket.FormattingEnabled = true;
            lstPartBasket.ItemHeight = 15;
            lstPartBasket.Location = new Point(233, 80);
            lstPartBasket.Name = "lstPartBasket";
            lstPartBasket.Size = new Size(276, 109);
            lstPartBasket.TabIndex = 21;
            // 
            // grdParts
            // 
            grdParts.AllowUserToAddRows = false;
            grdParts.AllowUserToDeleteRows = false;
            grdParts.AllowUserToResizeColumns = false;
            grdParts.AllowUserToResizeRows = false;
            grdParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdParts.Location = new Point(10, 80);
            grdParts.Name = "grdParts";
            grdParts.RowTemplate.Height = 25;
            grdParts.Size = new Size(217, 109);
            grdParts.TabIndex = 20;
            grdParts.Visible = false;
            grdParts.Click += grdParts_Click;
            // 
            // txtPartDesc
            // 
            txtPartDesc.Location = new Point(136, 22);
            txtPartDesc.Name = "txtPartDesc";
            txtPartDesc.Size = new Size(154, 23);
            txtPartDesc.TabIndex = 19;
            txtPartDesc.TextChanged += txtPartDesc_TextChanged;
            // 
            // lblPrompt2
            // 
            lblPrompt2.AutoSize = true;
            lblPrompt2.Location = new Point(10, 22);
            lblPrompt2.Name = "lblPrompt2";
            lblPrompt2.Size = new Size(120, 15);
            lblPrompt2.TabIndex = 16;
            lblPrompt2.Text = "Enter part description";
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
            // grpRepSearch
            // 
            grpRepSearch.Controls.Add(lblPrompt);
            grpRepSearch.Controls.Add(cboTypes);
            grpRepSearch.Controls.Add(btnSearch);
            grpRepSearch.Location = new Point(58, 53);
            grpRepSearch.Name = "grpRepSearch";
            grpRepSearch.Size = new Size(295, 100);
            grpRepSearch.TabIndex = 19;
            grpRepSearch.TabStop = false;
            grpRepSearch.Text = "Repair Search";
            // 
            // grpCustDetails
            // 
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
            grpCustDetails.Location = new Point(533, 212);
            grpCustDetails.Name = "grpCustDetails";
            grpCustDetails.Size = new Size(255, 254);
            grpCustDetails.TabIndex = 20;
            grpCustDetails.TabStop = false;
            grpCustDetails.Text = "Customer Details";
            grpCustDetails.Visible = false;
            // 
            // txtRepId
            // 
            txtRepId.Location = new Point(126, 51);
            txtRepId.Name = "txtRepId";
            txtRepId.Size = new Size(123, 23);
            txtRepId.TabIndex = 9;
            // 
            // lblRepId
            // 
            lblRepId.AutoSize = true;
            lblRepId.Location = new Point(6, 54);
            lblRepId.Name = "lblRepId";
            lblRepId.Size = new Size(53, 15);
            lblRepId.TabIndex = 8;
            lblRepId.Text = "Repair Id";
            // 
            // txtRepDesc
            // 
            txtRepDesc.Location = new Point(6, 161);
            txtRepDesc.Multiline = true;
            txtRepDesc.Name = "txtRepDesc";
            txtRepDesc.Size = new Size(243, 87);
            txtRepDesc.TabIndex = 7;
            // 
            // lblRepDesc
            // 
            lblRepDesc.AutoSize = true;
            lblRepDesc.Location = new Point(6, 143);
            lblRepDesc.Name = "lblRepDesc";
            lblRepDesc.Size = new Size(103, 15);
            lblRepDesc.TabIndex = 6;
            lblRepDesc.Text = "Repair Description";
            // 
            // lblCustId
            // 
            lblCustId.AutoSize = true;
            lblCustId.Location = new Point(6, 30);
            lblCustId.Name = "lblCustId";
            lblCustId.Size = new Size(72, 15);
            lblCustId.TabIndex = 5;
            lblCustId.Text = "Customer Id";
            // 
            // lblCustSName
            // 
            lblCustSName.AutoSize = true;
            lblCustSName.Location = new Point(6, 109);
            lblCustSName.Name = "lblCustSName";
            lblCustSName.Size = new Size(81, 15);
            lblCustSName.TabIndex = 4;
            lblCustSName.Text = "Second Name";
            // 
            // lblCustFName
            // 
            lblCustFName.AutoSize = true;
            lblCustFName.Location = new Point(6, 83);
            lblCustFName.Name = "lblCustFName";
            lblCustFName.Size = new Size(64, 15);
            lblCustFName.TabIndex = 3;
            lblCustFName.Text = "First Name";
            // 
            // txtSName
            // 
            txtSName.Location = new Point(126, 111);
            txtSName.Name = "txtSName";
            txtSName.Size = new Size(123, 23);
            txtSName.TabIndex = 2;
            // 
            // txtFName
            // 
            txtFName.Location = new Point(126, 80);
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(123, 23);
            txtFName.TabIndex = 1;
            // 
            // txtCustId
            // 
            txtCustId.Location = new Point(126, 22);
            txtCustId.Name = "txtCustId";
            txtCustId.Size = new Size(123, 23);
            txtCustId.TabIndex = 0;
            // 
            // mnuInternalNavBar
            // 
            mnuInternalNavBar.Items.AddRange(new ToolStripItem[] { mnuBack });
            mnuInternalNavBar.Location = new Point(0, 0);
            mnuInternalNavBar.Name = "mnuInternalNavBar";
            mnuInternalNavBar.Size = new Size(800, 24);
            mnuInternalNavBar.TabIndex = 21;
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
            // frmEstimatePrice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 734);
            Controls.Add(mnuInternalNavBar);
            Controls.Add(grpCustDetails);
            Controls.Add(grpRepSearch);
            Controls.Add(grpPartSearch);
            Controls.Add(grdRepairs);
            Name = "frmEstimatePrice";
            Text = "frmEstimatePrice";
            Load += frmEstimatePrice_Load;
            ((System.ComponentModel.ISupportInitialize)grdRepairs).EndInit();
            grpPartSearch.ResumeLayout(false);
            grpPartSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdParts).EndInit();
            grpRepSearch.ResumeLayout(false);
            grpRepSearch.PerformLayout();
            grpCustDetails.ResumeLayout(false);
            grpCustDetails.PerformLayout();
            mnuInternalNavBar.ResumeLayout(false);
            mnuInternalNavBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grdRepairs;
        private Button btnSearch;
        private Label lblPrompt;
        private GroupBox grpPartSearch;
        private TextBox txtPartDesc;
        private Label lblPrompt2;
        private ComboBox cboTypes;
        private GroupBox grpRepSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ListBox lstPartBasket;
        private DataGridView grdParts;
        private Label lblpartQuantity;
        private TextBox txtPartQty;
        private GroupBox grpCustDetails;
        private Label lblCustId;
        private Label lblCustSName;
        private Label lblCustFName;
        private TextBox txtSName;
        private TextBox txtFName;
        private TextBox txtCustId;
        private TextBox txtRepDesc;
        private Label lblRepDesc;
        private TextBox txtRepId;
        private Label lblRepId;
        private TextBox txtPartPrice;
        private Label lblPartPrice;
        private Button btnAddPart;
        private Button btnEstimatePrice;
        private TextBox txtTotalPrice;
        private Label lblTotalPrice;
        private MenuStrip mnuInternalNavBar;
        private ToolStripMenuItem mnuBack;
        private Button btnRmvPart;
    }
}