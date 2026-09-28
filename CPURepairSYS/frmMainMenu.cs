using System.Windows.Forms;

namespace CPURepairSYS
{
    /*
    TO DO
    
     */
    public partial class frmMainMenu : Form
    {
        frmMainMenu parent;
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
           
        }

    

        private void mnuNavBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnuAddPart_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAddPart nextForm = new frmAddPart(this);
            nextForm.Show();
        }

        private void mnuUpdatePart_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUpdatePart nextForm = new frmUpdatePart(this);
            nextForm.Show();
        }

        private void mnuDiscontinuePart_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDiscontinuePart nextForm = new frmDiscontinuePart(this);
            nextForm.Show();
        }

        private void mnuLogRepair_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogRepair nextForm = new frmLogRepair(this);
            nextForm.Show();
        }

        private void mnuEstimatePrice_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEstimatePrice nextForm = new frmEstimatePrice(this);
            nextForm.Show();
        }

        private void mnuConfirmRepair_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmConfirmRepair nextForm = new frmConfirmRepair(this);
            nextForm.Show();
        }

        private void mnuCompleteRepair_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCompleteRepair nextForm = new frmCompleteRepair(this);
            nextForm.Show();
        }

        private void mnuListRepair_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmListRepairs nextForm = new frmListRepairs(this);
            nextForm.Show();
        }

        private void mnuShowYearlyRevenueAnalysis_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRevAnalysis nextForm = new frmRevAnalysis(this);
            nextForm.Show();
        }

        private void mnuShowYearlyPartsAnalysis_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPartsAnalysis nextForm = new frmPartsAnalysis(this);
            nextForm.Show();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
