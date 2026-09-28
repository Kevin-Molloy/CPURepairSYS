using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPURepairSYS
{
    public partial class frmPartsAnalysis : Form
    {
        frmMainMenu parent;
        Part newPart = new Part();

        public frmPartsAnalysis(frmMainMenu parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        public frmPartsAnalysis()
        {
            InitializeComponent();
        }

        private void frmPartsAnalysis_Load(object sender, EventArgs e)
        {
            //The two analysis files are essentially identical to the list repairs form
            cboOrderBy.SelectedIndex = 0;
            cboYears.SelectedIndex = 0;
        }

        private void mnuBack_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Visible = true;
        }

        private void btnAnalyseParts_Click(object sender, EventArgs e)
        {
            String year = cboYears.Text.Remove(0, 2);
            String orderBy = cboOrderBy.Text;
            int oos = 0;
            int discontinued = 0;
            if (chkShowOutOfStock.Checked)
            {
                oos = 1;
            }
            if (chkShowDiscontinued.Checked)
            {
                discontinued = 1;
            }

            grdParts.DataSource = Part.analyseParts(year, orderBy, discontinued, oos).Tables["part"];


            if (grdParts.Rows.Count == 1)
            {
                MessageBox.Show("No Parts were used under the specifed criteria");
                cboYears.Focus();
                return;
            }

            grdParts.Visible = true;


        }
    }
}
