namespace CPURepairSYS
{
    partial class frmAddPart
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
            grpAddPart = new GroupBox();
            txtPartQuantity = new TextBox();
            lblPartQuantity = new Label();
            btnAddPart = new Button();
            txtPartPrice = new TextBox();
            lblPartPrice = new Label();
            lblPartDescription = new Label();
            cboTypes = new ComboBox();
            lblPartTypeCode = new Label();
            txtPartDesc = new TextBox();
            lblPartId = new Label();
            txtPartId = new TextBox();
            mnuInternalNavBar.SuspendLayout();
            grpAddPart.SuspendLayout();
            SuspendLayout();
            // 
            // mnuInternalNavBar
            // 
            mnuInternalNavBar.Items.AddRange(new ToolStripItem[] { mnuBack });
            mnuInternalNavBar.Location = new Point(0, 0);
            mnuInternalNavBar.Name = "mnuInternalNavBar";
            mnuInternalNavBar.Size = new Size(800, 24);
            mnuInternalNavBar.TabIndex = 1;
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
            // grpAddPart
            // 
            grpAddPart.Controls.Add(txtPartId);
            grpAddPart.Controls.Add(lblPartId);
            grpAddPart.Controls.Add(txtPartQuantity);
            grpAddPart.Controls.Add(lblPartQuantity);
            grpAddPart.Controls.Add(btnAddPart);
            grpAddPart.Controls.Add(txtPartPrice);
            grpAddPart.Controls.Add(lblPartPrice);
            grpAddPart.Controls.Add(lblPartDescription);
            grpAddPart.Controls.Add(cboTypes);
            grpAddPart.Controls.Add(lblPartTypeCode);
            grpAddPart.Controls.Add(txtPartDesc);
            grpAddPart.Location = new Point(231, 118);
            grpAddPart.Name = "grpAddPart";
            grpAddPart.Size = new Size(307, 282);
            grpAddPart.TabIndex = 2;
            grpAddPart.TabStop = false;
            grpAddPart.Text = "Enter Part Details";
            // 
            // txtPartQuantity
            // 
            txtPartQuantity.Location = new Point(220, 157);
            txtPartQuantity.MaxLength = 3;
            txtPartQuantity.Name = "txtPartQuantity";
            txtPartQuantity.Size = new Size(72, 23);
            txtPartQuantity.TabIndex = 8;
            txtPartQuantity.TextAlign = HorizontalAlignment.Right;
            // 
            // lblPartQuantity
            // 
            lblPartQuantity.AutoSize = true;
            lblPartQuantity.Location = new Point(15, 160);
            lblPartQuantity.Name = "lblPartQuantity";
            lblPartQuantity.Size = new Size(53, 15);
            lblPartQuantity.TabIndex = 7;
            lblPartQuantity.Text = "Quantity";
            // 
            // btnAddPart
            // 
            btnAddPart.Location = new Point(113, 242);
            btnAddPart.Name = "btnAddPart";
            btnAddPart.Size = new Size(75, 23);
            btnAddPart.TabIndex = 6;
            btnAddPart.Text = "Add Part";
            btnAddPart.UseVisualStyleBackColor = true;
            btnAddPart.Click += btnAddPart_Click;
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
            cboTypes.Location = new Point(171, 196);
            cboTypes.Name = "cboTypes";
            cboTypes.Size = new Size(121, 23);
            cboTypes.TabIndex = 2;
            // 
            // lblPartTypeCode
            // 
            lblPartTypeCode.AutoSize = true;
            lblPartTypeCode.Location = new Point(15, 199);
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
            // lblPartId
            // 
            lblPartId.AutoSize = true;
            lblPartId.Location = new Point(15, 50);
            lblPartId.Name = "lblPartId";
            lblPartId.Size = new Size(41, 15);
            lblPartId.TabIndex = 9;
            lblPartId.Text = "Part Id";
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
            // frmAddPart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpAddPart);
            Controls.Add(mnuInternalNavBar);
            Name = "frmAddPart";
            Text = "frmAddPart";
            Load += frmAddPart_Load;
            mnuInternalNavBar.ResumeLayout(false);
            mnuInternalNavBar.PerformLayout();
            grpAddPart.ResumeLayout(false);
            grpAddPart.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuInternalNavBar;
        private ToolStripMenuItem mnuBack;
        private GroupBox grpAddPart;
        private Label lblPartTypeCode;
        private TextBox txtPartDesc;
        private ComboBox cboTypes;
        private Label lblPartDescription;
        private TextBox txtPartPrice;
        private Label lblPartPrice;
        private Button btnAddPart;
        private TextBox txtPartQuantity;
        private Label lblPartQuantity;
        private Label lblPartId;
        private TextBox txtPartId;
    }
}