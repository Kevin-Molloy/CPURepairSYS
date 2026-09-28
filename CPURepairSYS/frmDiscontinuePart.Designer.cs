namespace CPURepairSYS
{
    partial class frmDiscontinuePart
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
            grdParts = new DataGridView();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblPrompt = new Label();
            grpDisPart = new GroupBox();
            cboTypes = new ComboBox();
            txtPartStatus = new TextBox();
            lblStaus = new Label();
            txtPartId = new TextBox();
            lblPartId = new Label();
            txtPartQuantity = new TextBox();
            lblPartQuantity = new Label();
            btnDisPart = new Button();
            txtPartPrice = new TextBox();
            lblPartPrice = new Label();
            lblPartDescription = new Label();
            lblPartTypeCode = new Label();
            txtPartDesc = new TextBox();
            mnuInternalNavBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdParts).BeginInit();
            grpDisPart.SuspendLayout();
            SuspendLayout();
            // 
            // mnuInternalNavBar
            // 
            mnuInternalNavBar.Items.AddRange(new ToolStripItem[] { mnuBack });
            mnuInternalNavBar.Location = new Point(0, 0);
            mnuInternalNavBar.Name = "mnuInternalNavBar";
            mnuInternalNavBar.Size = new Size(800, 24);
            mnuInternalNavBar.TabIndex = 15;
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
            // grdParts
            // 
            grdParts.AllowUserToAddRows = false;
            grdParts.AllowUserToDeleteRows = false;
            grdParts.AllowUserToResizeColumns = false;
            grdParts.AllowUserToResizeRows = false;
            grdParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdParts.Location = new Point(53, 91);
            grdParts.Name = "grdParts";
            grdParts.RowTemplate.Height = 25;
            grdParts.Size = new Size(685, 150);
            grdParts.TabIndex = 14;
            grdParts.Visible = false;
            grdParts.CellContentClick += grdParts_CellContentClick_1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(627, 37);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(124, 23);
            btnSearch.TabIndex = 13;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(377, 38);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(244, 23);
            txtSearch.TabIndex = 12;
            // 
            // lblPrompt
            // 
            lblPrompt.AutoSize = true;
            lblPrompt.Location = new Point(23, 41);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(348, 15);
            lblPrompt.TabIndex = 11;
            lblPrompt.Text = "Enter the description of the part you are searching for (or part of)";
            // 
            // grpDisPart
            // 
            grpDisPart.Controls.Add(cboTypes);
            grpDisPart.Controls.Add(txtPartStatus);
            grpDisPart.Controls.Add(lblStaus);
            grpDisPart.Controls.Add(txtPartId);
            grpDisPart.Controls.Add(lblPartId);
            grpDisPart.Controls.Add(txtPartQuantity);
            grpDisPart.Controls.Add(lblPartQuantity);
            grpDisPart.Controls.Add(btnDisPart);
            grpDisPart.Controls.Add(txtPartPrice);
            grpDisPart.Controls.Add(lblPartPrice);
            grpDisPart.Controls.Add(lblPartDescription);
            grpDisPart.Controls.Add(lblPartTypeCode);
            grpDisPart.Controls.Add(txtPartDesc);
            grpDisPart.Location = new Point(242, 247);
            grpDisPart.Name = "grpDisPart";
            grpDisPart.Size = new Size(307, 299);
            grpDisPart.TabIndex = 16;
            grpDisPart.TabStop = false;
            grpDisPart.Text = "Part Details";
            grpDisPart.Visible = false;
            // 
            // cboTypes
            // 
            cboTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTypes.Enabled = false;
            cboTypes.FormattingEnabled = true;
            cboTypes.Location = new Point(171, 225);
            cboTypes.Name = "cboTypes";
            cboTypes.Size = new Size(121, 23);
            cboTypes.TabIndex = 13;
            // 
            // txtPartStatus
            // 
            txtPartStatus.Location = new Point(255, 189);
            txtPartStatus.MaxLength = 1;
            txtPartStatus.Name = "txtPartStatus";
            txtPartStatus.ReadOnly = true;
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
            txtPartQuantity.ReadOnly = true;
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
            // btnDisPart
            // 
            btnDisPart.Location = new Point(92, 266);
            btnDisPart.Name = "btnDisPart";
            btnDisPart.Size = new Size(124, 23);
            btnDisPart.TabIndex = 6;
            btnDisPart.Text = "Discontinue Part";
            btnDisPart.UseVisualStyleBackColor = true;
            btnDisPart.Click += btnDisPart_Click;
            // 
            // txtPartPrice
            // 
            txtPartPrice.Location = new Point(220, 117);
            txtPartPrice.MaxLength = 6;
            txtPartPrice.Name = "txtPartPrice";
            txtPartPrice.ReadOnly = true;
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
            txtPartDesc.ReadOnly = true;
            txtPartDesc.Size = new Size(121, 23);
            txtPartDesc.TabIndex = 0;
            // 
            // frmDiscontinuePart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 575);
            Controls.Add(grpDisPart);
            Controls.Add(mnuInternalNavBar);
            Controls.Add(grdParts);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblPrompt);
            Name = "frmDiscontinuePart";
            Text = "frmDiscontinuePart";
            Load += frmDiscontinuePart_Load;
            mnuInternalNavBar.ResumeLayout(false);
            mnuInternalNavBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdParts).EndInit();
            grpDisPart.ResumeLayout(false);
            grpDisPart.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuInternalNavBar;
        private ToolStripMenuItem mnuBack;
        private DataGridView grdParts;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lblPrompt;
        private GroupBox grpDisPart;
        private TextBox txtPartStatus;
        private Label lblStaus;
        private TextBox txtPartId;
        private Label lblPartId;
        private TextBox txtPartQuantity;
        private Label lblPartQuantity;
        private Button btnDisPart;
        private TextBox txtPartPrice;
        private Label lblPartPrice;
        private Label lblPartDescription;
        private Label lblPartTypeCode;
        private TextBox txtPartDesc;
        private ComboBox cboTypes;
    }
}