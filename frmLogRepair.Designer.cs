namespace CPURepairSYS
{
    partial class frmLogRepair
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
            grpExistingCust = new GroupBox();
            btnEnter = new Button();
            txtPhone = new TextBox();
            txtFName = new TextBox();
            lblPhone = new Label();
            lblFName = new Label();
            grpExist = new GroupBox();
            btnNo = new Button();
            btnYes = new Button();
            lblExistQuestion = new Label();
            grpNewCust = new GroupBox();
            txtCustId = new TextBox();
            lblCustId = new Label();
            btnNewEnter = new Button();
            txtNewEmail = new TextBox();
            txtNewPhone = new TextBox();
            txtNewSName = new TextBox();
            lblNewEmail = new Label();
            lblnewPhone = new Label();
            lblNewSName = new Label();
            txtNewFName = new TextBox();
            lblNewFName = new Label();
            grpLogRepair = new GroupBox();
            txtRepDesc = new TextBox();
            lblRepDesc = new Label();
            btnLogRepair = new Button();
            lblTypes = new Label();
            cboTypes = new ComboBox();
            txtRepId = new TextBox();
            lblRepId = new Label();
            txtRepCust = new TextBox();
            lblRepCust = new Label();
            mnuInternalNavBar.SuspendLayout();
            grpExistingCust.SuspendLayout();
            grpExist.SuspendLayout();
            grpNewCust.SuspendLayout();
            grpLogRepair.SuspendLayout();
            SuspendLayout();
            // 
            // mnuInternalNavBar
            // 
            mnuInternalNavBar.Items.AddRange(new ToolStripItem[] { mnuBack });
            mnuInternalNavBar.Location = new Point(0, 0);
            mnuInternalNavBar.Name = "mnuInternalNavBar";
            mnuInternalNavBar.Size = new Size(800, 24);
            mnuInternalNavBar.TabIndex = 2;
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
            // grpExistingCust
            // 
            grpExistingCust.Controls.Add(btnEnter);
            grpExistingCust.Controls.Add(txtPhone);
            grpExistingCust.Controls.Add(txtFName);
            grpExistingCust.Controls.Add(lblPhone);
            grpExistingCust.Controls.Add(lblFName);
            grpExistingCust.Location = new Point(112, 215);
            grpExistingCust.Name = "grpExistingCust";
            grpExistingCust.Size = new Size(251, 144);
            grpExistingCust.TabIndex = 6;
            grpExistingCust.TabStop = false;
            grpExistingCust.Text = "Enter Information";
            grpExistingCust.Visible = false;
            // 
            // btnEnter
            // 
            btnEnter.Location = new Point(87, 107);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(75, 23);
            btnEnter.TabIndex = 6;
            btnEnter.Text = "Enter";
            btnEnter.UseVisualStyleBackColor = true;
            btnEnter.Click += btnEnter_Click;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(147, 66);
            txtPhone.MaxLength = 10;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(100, 23);
            txtPhone.TabIndex = 5;
            // 
            // txtFName
            // 
            txtFName.Location = new Point(147, 27);
            txtFName.MaxLength = 14;
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(100, 23);
            txtFName.TabIndex = 3;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(6, 69);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(88, 15);
            lblPhone.TabIndex = 2;
            lblPhone.Text = "Phone Number";
            // 
            // lblFName
            // 
            lblFName.AutoSize = true;
            lblFName.Location = new Point(6, 30);
            lblFName.Name = "lblFName";
            lblFName.Size = new Size(64, 15);
            lblFName.TabIndex = 0;
            lblFName.Text = "First Name";
            // 
            // grpExist
            // 
            grpExist.Controls.Add(btnNo);
            grpExist.Controls.Add(btnYes);
            grpExist.Controls.Add(lblExistQuestion);
            grpExist.Location = new Point(262, 28);
            grpExist.Name = "grpExist";
            grpExist.Size = new Size(200, 100);
            grpExist.TabIndex = 8;
            grpExist.TabStop = false;
            grpExist.Text = "Existing Customer?";
            // 
            // btnNo
            // 
            btnNo.Location = new Point(100, 60);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(75, 23);
            btnNo.TabIndex = 8;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = true;
            btnNo.Click += btnNo_Click;
            // 
            // btnYes
            // 
            btnYes.Location = new Point(19, 60);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(75, 23);
            btnYes.TabIndex = 7;
            btnYes.Text = "Yes";
            btnYes.UseVisualStyleBackColor = true;
            btnYes.Click += btnYes_Click;
            // 
            // lblExistQuestion
            // 
            lblExistQuestion.AutoSize = true;
            lblExistQuestion.Location = new Point(21, 32);
            lblExistQuestion.Name = "lblExistQuestion";
            lblExistQuestion.Size = new Size(154, 15);
            lblExistQuestion.TabIndex = 0;
            lblExistQuestion.Text = "Is this customer's first repair";
            // 
            // grpNewCust
            // 
            grpNewCust.Controls.Add(txtCustId);
            grpNewCust.Controls.Add(lblCustId);
            grpNewCust.Controls.Add(btnNewEnter);
            grpNewCust.Controls.Add(txtNewEmail);
            grpNewCust.Controls.Add(txtNewPhone);
            grpNewCust.Controls.Add(txtNewSName);
            grpNewCust.Controls.Add(lblNewEmail);
            grpNewCust.Controls.Add(lblnewPhone);
            grpNewCust.Controls.Add(lblNewSName);
            grpNewCust.Controls.Add(txtNewFName);
            grpNewCust.Controls.Add(lblNewFName);
            grpNewCust.Location = new Point(112, 192);
            grpNewCust.Name = "grpNewCust";
            grpNewCust.Size = new Size(254, 246);
            grpNewCust.TabIndex = 9;
            grpNewCust.TabStop = false;
            grpNewCust.Text = "Enter Information";
            grpNewCust.Visible = false;
            // 
            // txtCustId
            // 
            txtCustId.Location = new Point(191, 22);
            txtCustId.MaxLength = 15;
            txtCustId.Name = "txtCustId";
            txtCustId.ReadOnly = true;
            txtCustId.Size = new Size(47, 23);
            txtCustId.TabIndex = 13;
            // 
            // lblCustId
            // 
            lblCustId.AutoSize = true;
            lblCustId.Location = new Point(9, 27);
            lblCustId.Name = "lblCustId";
            lblCustId.Size = new Size(72, 15);
            lblCustId.TabIndex = 12;
            lblCustId.Text = "Customer Id";
            // 
            // btnNewEnter
            // 
            btnNewEnter.Location = new Point(84, 210);
            btnNewEnter.Name = "btnNewEnter";
            btnNewEnter.Size = new Size(75, 23);
            btnNewEnter.TabIndex = 11;
            btnNewEnter.Text = "Enter";
            btnNewEnter.UseVisualStyleBackColor = true;
            btnNewEnter.Click += btnNewEnter_Click;
            // 
            // txtNewEmail
            // 
            txtNewEmail.Location = new Point(138, 181);
            txtNewEmail.MaxLength = 25;
            txtNewEmail.Name = "txtNewEmail";
            txtNewEmail.Size = new Size(100, 23);
            txtNewEmail.TabIndex = 10;
            // 
            // txtNewPhone
            // 
            txtNewPhone.Location = new Point(138, 138);
            txtNewPhone.MaxLength = 10;
            txtNewPhone.Name = "txtNewPhone";
            txtNewPhone.Size = new Size(100, 23);
            txtNewPhone.TabIndex = 9;
            // 
            // txtNewSName
            // 
            txtNewSName.Location = new Point(138, 98);
            txtNewSName.MaxLength = 15;
            txtNewSName.Name = "txtNewSName";
            txtNewSName.Size = new Size(100, 23);
            txtNewSName.TabIndex = 8;
            // 
            // lblNewEmail
            // 
            lblNewEmail.AutoSize = true;
            lblNewEmail.Location = new Point(9, 181);
            lblNewEmail.Name = "lblNewEmail";
            lblNewEmail.Size = new Size(36, 15);
            lblNewEmail.TabIndex = 7;
            lblNewEmail.Text = "Email";
            // 
            // lblnewPhone
            // 
            lblnewPhone.AutoSize = true;
            lblnewPhone.Location = new Point(9, 138);
            lblnewPhone.Name = "lblnewPhone";
            lblnewPhone.Size = new Size(88, 15);
            lblnewPhone.TabIndex = 6;
            lblnewPhone.Text = "Phone Number";
            // 
            // lblNewSName
            // 
            lblNewSName.AutoSize = true;
            lblNewSName.Location = new Point(9, 97);
            lblNewSName.Name = "lblNewSName";
            lblNewSName.Size = new Size(54, 15);
            lblNewSName.TabIndex = 5;
            lblNewSName.Text = "Surname";
            // 
            // txtNewFName
            // 
            txtNewFName.Location = new Point(138, 61);
            txtNewFName.MaxLength = 15;
            txtNewFName.Name = "txtNewFName";
            txtNewFName.Size = new Size(100, 23);
            txtNewFName.TabIndex = 4;
            // 
            // lblNewFName
            // 
            lblNewFName.AutoSize = true;
            lblNewFName.Location = new Point(9, 64);
            lblNewFName.Name = "lblNewFName";
            lblNewFName.Size = new Size(64, 15);
            lblNewFName.TabIndex = 1;
            lblNewFName.Text = "First Name";
            // 
            // grpLogRepair
            // 
            grpLogRepair.Controls.Add(txtRepDesc);
            grpLogRepair.Controls.Add(lblRepDesc);
            grpLogRepair.Controls.Add(btnLogRepair);
            grpLogRepair.Controls.Add(lblTypes);
            grpLogRepair.Controls.Add(cboTypes);
            grpLogRepair.Controls.Add(txtRepId);
            grpLogRepair.Controls.Add(lblRepId);
            grpLogRepair.Controls.Add(txtRepCust);
            grpLogRepair.Controls.Add(lblRepCust);
            grpLogRepair.Location = new Point(490, 196);
            grpLogRepair.Name = "grpLogRepair";
            grpLogRepair.Size = new Size(200, 242);
            grpLogRepair.TabIndex = 11;
            grpLogRepair.TabStop = false;
            grpLogRepair.Text = "Log Repair";
            grpLogRepair.Visible = false;
            // 
            // txtRepDesc
            // 
            txtRepDesc.Location = new Point(94, 98);
            txtRepDesc.MaxLength = 40;
            txtRepDesc.Multiline = true;
            txtRepDesc.Name = "txtRepDesc";
            txtRepDesc.Size = new Size(100, 51);
            txtRepDesc.TabIndex = 21;
            // 
            // lblRepDesc
            // 
            lblRepDesc.AutoSize = true;
            lblRepDesc.Location = new Point(6, 115);
            lblRepDesc.Name = "lblRepDesc";
            lblRepDesc.Size = new Size(67, 15);
            lblRepDesc.TabIndex = 20;
            lblRepDesc.Text = "Description";
            // 
            // btnLogRepair
            // 
            btnLogRepair.Location = new Point(60, 206);
            btnLogRepair.Name = "btnLogRepair";
            btnLogRepair.Size = new Size(75, 23);
            btnLogRepair.TabIndex = 12;
            btnLogRepair.Text = "Log Repair";
            btnLogRepair.UseVisualStyleBackColor = true;
            btnLogRepair.Click += btnLogRepair_Click_1;
            // 
            // lblTypes
            // 
            lblTypes.AutoSize = true;
            lblTypes.Location = new Point(6, 169);
            lblTypes.Name = "lblTypes";
            lblTypes.Size = new Size(97, 15);
            lblTypes.TabIndex = 19;
            lblTypes.Text = "RepairTypeCodes";
            // 
            // cboTypes
            // 
            cboTypes.FormattingEnabled = true;
            cboTypes.Location = new Point(109, 169);
            cboTypes.Name = "cboTypes";
            cboTypes.Size = new Size(85, 23);
            cboTypes.TabIndex = 18;
            // 
            // txtRepId
            // 
            txtRepId.Location = new Point(147, 27);
            txtRepId.MaxLength = 15;
            txtRepId.Name = "txtRepId";
            txtRepId.ReadOnly = true;
            txtRepId.Size = new Size(47, 23);
            txtRepId.TabIndex = 17;
            // 
            // lblRepId
            // 
            lblRepId.AutoSize = true;
            lblRepId.Location = new Point(6, 30);
            lblRepId.Name = "lblRepId";
            lblRepId.Size = new Size(53, 15);
            lblRepId.TabIndex = 16;
            lblRepId.Text = "Repair Id";
            // 
            // txtRepCust
            // 
            txtRepCust.Location = new Point(147, 69);
            txtRepCust.MaxLength = 15;
            txtRepCust.Name = "txtRepCust";
            txtRepCust.ReadOnly = true;
            txtRepCust.Size = new Size(47, 23);
            txtRepCust.TabIndex = 15;
            // 
            // lblRepCust
            // 
            lblRepCust.AutoSize = true;
            lblRepCust.Location = new Point(6, 65);
            lblRepCust.Name = "lblRepCust";
            lblRepCust.Size = new Size(72, 15);
            lblRepCust.TabIndex = 14;
            lblRepCust.Text = "Customer Id";
            // 
            // frmLogRepair
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 470);
            Controls.Add(grpLogRepair);
            Controls.Add(grpNewCust);
            Controls.Add(grpExist);
            Controls.Add(grpExistingCust);
            Controls.Add(mnuInternalNavBar);
            Name = "frmLogRepair";
            Text = "Log Repair";
            Load += frmLogRepair_Load;
            mnuInternalNavBar.ResumeLayout(false);
            mnuInternalNavBar.PerformLayout();
            grpExistingCust.ResumeLayout(false);
            grpExistingCust.PerformLayout();
            grpExist.ResumeLayout(false);
            grpExist.PerformLayout();
            grpNewCust.ResumeLayout(false);
            grpNewCust.PerformLayout();
            grpLogRepair.ResumeLayout(false);
            grpLogRepair.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuInternalNavBar;
        private ToolStripMenuItem mnuBack;
        private GroupBox grpExistingCust;
        private Label lblPhone;
        private Label lblFName;
        private TextBox txtPhone;
        private TextBox txtFName;
        private Button btnEnter;
        private GroupBox grpExist;
        private Button btnNo;
        private Button btnYes;
        private Label lblExistQuestion;
        private GroupBox grpNewCust;
        private TextBox txtNewFName;
        private Label lblNewFName;
        private Button btnNewEnter;
        private TextBox txtNewEmail;
        private TextBox txtNewPhone;
        private TextBox txtNewSName;
        private Label lblNewEmail;
        private Label lblnewPhone;
        private Label lblNewSName;
        private TextBox txtCustId;
        private Label lblCustId;
        private GroupBox grpLogRepair;
        private TextBox txtRepCust;
        private Label lblRepCust;
        private TextBox txtRepId;
        private Label lblRepId;
        private Label lblTypes;
        private ComboBox cboTypes;
        private Button btnLogRepair;
        private TextBox txtRepDesc;
        private Label lblRepDesc;
    }
}