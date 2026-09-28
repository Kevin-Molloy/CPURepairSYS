using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPURepairSYS
{
    public partial class frmRevAnalysis : Form
    {
        frmMainMenu parent;
        Repair newRepair = new Repair();

        public frmRevAnalysis(frmMainMenu parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        public frmRevAnalysis()
        {
            InitializeComponent();
        }

        private void frmRevAnalysis_Load(object sender, EventArgs e)
        {
            cboYears.SelectedIndex = 0;
        }

        private void mnuBack_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Visible = true;
        }

        private void btnAnalyseRevenue_Click(object sender, EventArgs e)
        {
            String year = cboYears.Text.Remove(0, 2);
            int cancelled = 0;
            if (chkInclude.Checked)
            {
                cancelled = 1;
            }
            grdRev.DataSource = Repair.getRev(year, cancelled).Tables["rev"];


            if (grdRev.Rows.Count == 1)
            {
                MessageBox.Show("No Data Found");
                cboYears.Focus();
                return;
            }

            decimal total = Repair.calcRev(year, cancelled);

            if (cancelled == 1)
            {
                lblTotalRevenue.Text = "Potential Revenue for " + cboYears.Text + " is €" + total;
            }
            else
            {
                lblTotalRevenue.Text = "Total Revenue for " + cboYears.Text + " is €" + total;
            }

            grpRev.Visible = true;
        }
    }
}
