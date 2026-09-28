namespace CPURepairSYS
{
    partial class frmUpdatePart
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
            grpUpdPart = new GroupBox();
            txtPartStatus = new TextBox();
            lblStaus = new Label();
            txtPartId = new TextBox();
            lblPartId = new Label();
            txtPartQuantity = new TextBox();
            lblPartQuantity = new Label();
            btnUpdPart = new Button();
            txtPartPrice = new TextBox();
            lblPartPrice = new Label();
            lblPartDescription = new Label();
            cboTypes = new ComboBox();
            lblPartTypeCode = new Label();
            txtPartDesc = new TextBox();
            lblPrompt = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            grdParts = new DataGridView();
            mnuInternalNavBar = new MenuStrip();
            mnuBack = new ToolStripMenuItem();
            grpUpdPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdParts).BeginInit();
            mnuInternalNavBar.SuspendLayout();
            SuspendLayout();
            // 
            // grpUpdPart
            // 
            grpUpdPart.Controls.Add(txtPartStatus);
            grpUpdPart.Controls.Add(lblStaus);
            grpUpdPart.Controls.Add(txtPartId);
            grpUpdPart.Controls.Add(lblPartId);
            grpUpdPart.Controls.Add(txtPartQuantity);
            grpUpdPart.Controls.Add(lblPartQuantity);
            grpUpdPart.Controls.Add(btnUpdPart);
            grpUpdPart.Controls.Add(txtPartPrice);
            grpUpdPart.Controls.Add(lblPartPrice);
            grpUpdPart.Controls.Add(lblPartDescription);
            grpUpdPart.Controls.Add(cboTypes);
            grpUpdPart.Controls.Add(lblPartTypeCode);
            grpUpdPart.Controls.Add(txtPartDesc);
            grpUpdPart.Location = new Point(256, 272);
            grpUpdPart.Name = "grpUpdPart";
            grpUpdPart.Size = new Size(307, 299);
            grpUpdPart.TabIndex = 3;
            grpUpdPart.TabStop = false;
            grpUpdPart.Text = "Enter Part Details";
            grpUpdPart.Visible = false;
            // 
            // txtPartStatus
            // 
            txtPartStatus.Location = new Point(255, 189);
            txtPartStatus.MaxLength = 1;
            txtPartStatus.Name = "txtPartStatus";
            txtPartStatus.Size = new Size(37, 23);
            txtPartStatus.TabIndex = 12;
            txtPartStatus.TextAlign = HorizontalAlignment.Right;
            // 
            // lblStaus
            // 
            lblStaus.AutoSize = true;
            lblStaus.Location = new Point(15, 192);
            lblStaus.Name = "lblStaus";
            lblStaus.Size = new Size(39, 15);
            lblStaus.TabIndex = 11;
            lblStaus.Text = "Status";
            // 
            // txtPartId
            // 
            txtPartId.Location = new Point(255, 42);
            txtPartId.MaxLength = 3;
            txtPartId.Name = "txtPartId";
            txtPartId.ReadOnly = true;
            txtPartId.Size = new Size(37, 23);
            txtPartId.TabIndex = 10;
            txtPartId.TextAlign = HorizontalAlignment.Right;
            // 
            // lblPartId
            // 
            lblPartId.AutoSize = true;
            lblPartId.Location = new Point(15, 50);
            lblPartId.Name = "lblPartId";
            lblPartId.Size = new Size(41, 15);
            lblPartId.TabIndex = 9;
            lblPartId.Text = "Part Id";
            // 
            // txtPartQuantity
            // 
            txtPartQuantity.Location = new Point(220, 154);
            txtPartQuantity.MaxLength = 3;
            txtPartQuantity.Name = "txtPartQuantity";
            txtPartQuantity.Size = new Size(72, 23);
            txtPartQuantity.TabIndex = 8;
            txtPartQuantity.TextAlign = HorizontalAlignment.Right;
            // 
            // lblPartQuantity
            // 
            lblPartQuantity.AutoSize = true;
            lblPartQuantity.Location = new Point(15, 157);
            lblPartQuantity.Name = "lblPartQuantity";
            lblPartQuantity.Size = new Size(53, 15);
            lblPartQuantity.TabIndex = 7;
            lblPartQuantity.Text = "Quantity";
            // 
            // btnUpdPart
            // 
            btnUpdPart.Location = new Point(92, 266);
            btnUpdPart.Name = "btnUpdPart";
            btnUpdPart.Size = new Size(124, 23);
            btnUpdPart.TabIndex = 6;
            btnUpdPart.Text = "Update Part";
            btnUpdPart.UseVisualStyleBackColor = true;
            btnUpdPart.Click += btnUpdPart_Click;
            // 
            // txtPartPrice
            // 
            txtPartPrice.Location = new Point(220, 117);
            txtPartPrice.MaxLength = 6;
            txtPartPrice.Name = "txtPartPrice";
            txtPartPrice.Size = new Size(72, 23);
            txtPartPrice.TabIndex = 5;
            txtPartPrice.Text = "0.00";
            txtPartPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // lblPartPrice
            // 
            lblPartPrice.AutoSize = true;
            lblPartPrice.Location = new Point(15, 120);
            lblPartPrice.Name = "lblPartPrice";
            lblPartPrice.Size = new Size(33, 15);
            lblPartPrice.TabIndex = 4;
            lblPartPrice.Text = "Price";
            // 
            // lblPartDescription
            // 
            lblPartDescription.AutoSize = true;
            lblPartDescription.Location = new Point(15, 84);
            lblPartDescription.Name = "lblPartDescription";
            lblPartDescription.Size = new Size(67, 15);
            lblPartDescription.TabIndex = 3;
            lblPartDescription.Text = "Description";
            // 
            // cboTypes
            // 
            cboTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTypes.FormattingEnabled = true;
            cboTypes.Location = new Point(171, 225);
            cboTypes.Name = "cboTypes";
            cboTypes.Size = new Size(121, 23);
            cboTypes.TabIndex = 2;
            // 
            // lblPartTypeCode
            // 
            lblPartTypeCode.AutoSize = true;
            lblPartTypeCode.Location = new Point(15, 228);
            lblPartTypeCode.Name = "lblPartTypeCode";
            lblPartTypeCode.Size = new Size(62, 15);
            lblPartTypeCode.TabIndex = 1;
            lblPartTypeCode.Text = "Type Code";
            // 
            // txtPartDesc
            // 
            txtPartDesc.Location = new Point(171, 76);
            txtPartDesc.MaxLength = 50;
            txtPartDesc.Name = "txtPartDesc";
            txtPartDesc.Size = new Size(121, 23);
            txtPartDesc.TabIndex = 0;
            // 
            // lblPrompt
            // 
            lblPrompt.AutoSize = true;
            lblPrompt.Location = new Point(12, 45);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(348, 15);
            lblPrompt.TabIndex = 4;
            lblPrompt.Text = "Enter the description of the part you are searching for (or part of)";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(366, 42);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(244, 23);
            txtSearch.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(616, 41);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(124, 23);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // grdParts
            // 
            grdParts.AllowUserToAddRows = false;
            grdParts.AllowUserToDeleteRows = false;
            grdParts.AllowUserToResizeColumns = false;
            grdParts.AllowUserToResizeRows = false;
            grdParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdParts.Location = new Point(42, 95);
            grdParts.Name = "grdParts";
            grdParts.RowTemplate.Height = 25;
            grdParts.Size = new Size(685, 150);
            grdParts.TabIndex = 9;
            grdParts.Visible = false;
            grdParts.CellContentClick += grdParts_CellContentClick;
            // 
            // mnuInternalNavBar
            // 
            mnuInternalNavBar.Items.AddRange(new ToolStripItem[] { mnuBack });
            mnuInternalNavBar.Location = new Point(0, 0);
            mnuInternalNavBar.Name = "mnuInternalNavBar";
            mnuInternalNavBar.Size = new Size(800, 24);
            mnuInternalNavBar.TabIndex = 10;
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
            // frmUpdatePart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 602);
            Controls.Add(mnuInternalNavBar);
            Controls.Add(grdParts);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblPrompt);
            Controls.Add(grpUpdPart);
            Name = "frmUpdatePart";
            Text = "frmUpdatePart";
            Load += frmUpdatePart_Load;
            grpUpdPart.ResumeLayout(false);
            grpUpdPart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdParts).EndInit();
            mnuInternalNavBar.ResumeLayout(false);
            mnuInternalNavBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpUpdPart;
        private TextBox txtPartId;
        private Label lblPartId;
        private TextBox txtPartQuantity;
        private Label lblPartQuantity;
        private Button btnUpdPart;
        private TextBox txtPartPrice;
        private Label lblPartPrice;
        private Label lblPartDescription;
        private ComboBox cboTypes;
        private Label lblPartTypeCode;
        private TextBox txtPartDesc;
        private Label lblStaus;
        private Label lblPrompt;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView grdParts;
        private TextBox txtPartStatus;
        private MenuStrip mnuInternalNavBar;
        private ToolStripMenuItem mnuBack;
    }
}