namespace CPURepairSYS
{
    partial class frmMainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            addPartToolStripMenuItem = new ToolStripMenuItem();
            updatePartToolStripMenuItem = new ToolStripMenuItem();
            dToolStripMenuItem = new ToolStripMenuItem();
            mnuNavBar = new MenuStrip();
            mnuParts = new ToolStripMenuItem();
            mnuAddPart = new ToolStripMenuItem();
            mnuUpdatePart = new ToolStripMenuItem();
            mnuDiscontinuePart = new ToolStripMenuItem();
            mnuRepairs = new ToolStripMenuItem();
            mnuLogRepair = new ToolStripMenuItem();
            mnuEstimatePrice = new ToolStripMenuItem();
            mnuConfirmRepair = new ToolStripMenuItem();
            mnuCompleteRepair = new ToolStripMenuItem();
            mnuListRepair = new ToolStripMenuItem();
            mnuAdmin = new ToolStripMenuItem();
            mnuShowYearlyRevenueAnalysis = new ToolStripMenuItem();
            mnuShowYearlyPartsAnalysis = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            mnuNavBar.SuspendLayout();
            SuspendLayout();
            // 
            // addPartToolStripMenuItem
            // 
            addPartToolStripMenuItem.Name = "addPartToolStripMenuItem";
            addPartToolStripMenuItem.Size = new Size(32, 19);
            // 
            // updatePartToolStripMenuItem
            // 
            updatePartToolStripMenuItem.Name = "updatePartToolStripMenuItem";
            updatePartToolStripMenuItem.Size = new Size(32, 19);
            // 
            // dToolStripMenuItem
            // 
            dToolStripMenuItem.Name = "dToolStripMenuItem";
            dToolStripMenuItem.Size = new Size(32, 19);
            // 
            // mnuNavBar
            // 
            mnuNavBar.Items.AddRange(new ToolStripItem[] { mnuParts, mnuRepairs, mnuAdmin, mnuExit });
            mnuNavBar.Location = new Point(0, 0);
            mnuNavBar.Name = "mnuNavBar";
            mnuNavBar.Size = new Size(935, 24);
            mnuNavBar.TabIndex = 0;
            mnuNavBar.Text = "menuStrip1";
            mnuNavBar.ItemClicked += mnuNavBar_ItemClicked;
            // 
            // mnuParts
            // 
            mnuParts.DropDownItems.AddRange(new ToolStripItem[] { mnuAddPart, mnuUpdatePart, mnuDiscontinuePart });
            mnuParts.Name = "mnuParts";
            mnuParts.Size = new Size(45, 20);
            mnuParts.Text = "Parts";
            // 
            // mnuAddPart
            // 
            mnuAddPart.Name = "mnuAddPart";
            mnuAddPart.Size = new Size(180, 22);
            mnuAddPart.Text = "Add Part";
            mnuAddPart.Click += mnuAddPart_Click;
            // 
            // mnuUpdatePart
            // 
            mnuUpdatePart.Name = "mnuUpdatePart";
            mnuUpdatePart.Size = new Size(180, 22);
            mnuUpdatePart.Text = "Update Part";
            mnuUpdatePart.Click += mnuUpdatePart_Click;
            // 
            // mnuDiscontinuePart
            // 
            mnuDiscontinuePart.Name = "mnuDiscontinuePart";
            mnuDiscontinuePart.Size = new Size(180, 22);
            mnuDiscontinuePart.Text = "Discontinue Part";
            mnuDiscontinuePart.Click += mnuDiscontinuePart_Click;
            // 
            // mnuRepairs
            // 
            mnuRepairs.DropDownItems.AddRange(new ToolStripItem[] { mnuLogRepair, mnuEstimatePrice, mnuConfirmRepair, mnuCompleteRepair, mnuListRepair });
            mnuRepairs.Name = "mnuRepairs";
            mnuRepairs.Size = new Size(57, 20);
            mnuRepairs.Text = "Repairs";
            // 
            // mnuLogRepair
            // 
            mnuLogRepair.Name = "mnuLogRepair";
            mnuLogRepair.Size = new Size(162, 22);
            mnuLogRepair.Text = "Log Repair";
            mnuLogRepair.Click += mnuLogRepair_Click;
            // 
            // mnuEstimatePrice
            // 
            mnuEstimatePrice.Name = "mnuEstimatePrice";
            mnuEstimatePrice.Size = new Size(162, 22);
            mnuEstimatePrice.Text = "Estimate Price";
            mnuEstimatePrice.Click += mnuEstimatePrice_Click;
            // 
            // mnuConfirmRepair
            // 
            mnuConfirmRepair.Name = "mnuConfirmRepair";
            mnuConfirmRepair.Size = new Size(162, 22);
            mnuConfirmRepair.Text = "Confirm Repair";
            mnuConfirmRepair.Click += mnuConfirmRepair_Click;
            // 
            // mnuCompleteRepair
            // 
            mnuCompleteRepair.Name = "mnuCompleteRepair";
            mnuCompleteRepair.Size = new Size(162, 22);
            mnuCompleteRepair.Text = "Complete Repair";
            mnuCompleteRepair.Click += mnuCompleteRepair_Click;
            // 
            // mnuListRepair
            // 
            mnuListRepair.Name = "mnuListRepair";
            mnuListRepair.Size = new Size(162, 22);
            mnuListRepair.Text = "List Repairs";
            mnuListRepair.Click += mnuListRepair_Click;
            // 
            // mnuAdmin
            // 
            mnuAdmin.DropDownItems.AddRange(new ToolStripItem[] { mnuShowYearlyRevenueAnalysis, mnuShowYearlyPartsAnalysis });
            mnuAdmin.Name = "mnuAdmin";
            mnuAdmin.Size = new Size(55, 20);
            mnuAdmin.Text = "Admin";
            // 
            // mnuShowYearlyRevenueAnalysis
            // 
            mnuShowYearlyRevenueAnalysis.Name = "mnuShowYearlyRevenueAnalysis";
            mnuShowYearlyRevenueAnalysis.Size = new Size(231, 22);
            mnuShowYearlyRevenueAnalysis.Text = "Show Yearly Revenue Analysis";
            mnuShowYearlyRevenueAnalysis.Click += mnuShowYearlyRevenueAnalysis_Click;
            // 
            // mnuShowYearlyPartsAnalysis
            // 
            mnuShowYearlyPartsAnalysis.Name = "mnuShowYearlyPartsAnalysis";
            mnuShowYearlyPartsAnalysis.Size = new Size(231, 22);
            mnuShowYearlyPartsAnalysis.Text = "Show Yearly Parts Analysis";
            mnuShowYearlyPartsAnalysis.Click += mnuShowYearlyPartsAnalysis_Click;
            // 
            // mnuExit
            // 
            mnuExit.Alignment = ToolStripItemAlignment.Right;
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(38, 20);
            mnuExit.Text = "Exit";
            mnuExit.Click += mnuExit_Click;
            // 
            // frmMainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 621);
            Controls.Add(mnuNavBar);
            MainMenuStrip = mnuNavBar;
            Name = "frmMainMenu";
            Text = "CPURepairSYS";
            Load += frmMainMenu_Load;
            mnuNavBar.ResumeLayout(false);
            mnuNavBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStripMenuItem addPartToolStripMenuItem;
        private ToolStripMenuItem updatePartToolStripMenuItem;
        private ToolStripMenuItem dToolStripMenuItem;
        private MenuStrip mnuNavBar;
        private ToolStripMenuItem mnuParts;
        private ToolStripMenuItem mnuAddPart;
        private ToolStripMenuItem mnuUpdatePart;
        private ToolStripMenuItem mnuDiscontinuePart;
        private ToolStripMenuItem mnuRepairs;
        private ToolStripMenuItem mnuLogRepair;
        private ToolStripMenuItem mnuEstimatePrice;
        private ToolStripMenuItem mnuConfirmRepair;
        private ToolStripMenuItem mnuCompleteRepair;
        private ToolStripMenuItem mnuListRepair;
        private ToolStripMenuItem mnuAdmin;
        private ToolStripMenuItem mnuShowYearlyRevenueAnalysis;
        private ToolStripMenuItem mnuShowYearlyPartsAnalysis;
        private ToolStripMenuItem mnuExit;
    }
}
