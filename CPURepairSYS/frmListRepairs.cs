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
    public partial class frmListRepairs : Form
    {
        frmMainMenu parent;
        Repair newRepair = new Repair();


        public frmListRepairs(frmMainMenu parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void frmListRepairs_Load(object sender, EventArgs e)
        {
            cboOrderBy.SelectedIndex = 0;
            cboYears.SelectedIndex = 0;

        }

        private void mnuBack_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Visible = true;
        }

        private void btnListRepairs_Click(object sender, EventArgs e)
        {
            //Puts the selected options into variables
            String year = cboYears.Text.Remove(0, 2);
            String orderBy = cboOrderBy.Text.ToLower();

            //Checkbox variables
            int cancelled = 0;
            int progress = 0;

            if (chkShowCancelled.Checked)
            {
                cancelled = 1;
            }
            if (chkShowInProgress.Checked)
            {
                progress = 1;
            }

            //Formatting for the sql statements
            if (orderBy == "date completed")
            {
                orderBy = "completeDate";
            }

            if (orderBy == "date started")
            {
                orderBy = "startDate";
            }

            //Calls method
            grdRepairs.DataSource = Repair.listRepairs(year, orderBy, cancelled, progress).Tables["repair"];


            if (grdRepairs.Rows.Count == 1)
            {
                MessageBox.Show("No Data Found");
                cboYears.Focus();
                return;
            }

            grdRepairs.Visible = true;


        }

     
    }
}
