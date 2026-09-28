using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace CPURepairSYS
{
    public partial class frmCompleteRepair : Form
    {
        frmMainMenu parent;
        Repair newRepair = new Repair();
        Customer newCustomer = new Customer();
        String date = "";


        public frmCompleteRepair(frmMainMenu parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        public frmCompleteRepair()
        {
            InitializeComponent();
        }

        private void frmCompleteRepair_Load(object sender, EventArgs e)
        {
            //This form is essentially identical to Confirm Repair

            date = getDate();

            DataSet ds = RepairTypeCode.getRepairTypeCodes();
            cboTypes.Items.Clear();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboTypes.Items.Add(ds.Tables[0].Rows[i][0] + " - " + ds.Tables[0].Rows[i][1]);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cboTypes.Text == "")
            {
                MessageBox.Show("Repair Type must not be null ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Sets an array of possible repair types to be passed into the below loop
            String[] types = { "PROC", "GCARD", "FAN", "CASE", "BATT", "POWSUP", "MTHBRD", "COOL", "RAM", "STOR", "WIFIADAP", "SCRN", "MULT", "OTH" };
            String condensedTypeCode = "";

            //Indexes through the array and adds a letter from cboTypes.Text to the condensed variable until the condensed variable is found in the array. This is done because
            //the combo box contains descriptions of the types as well as the type code themselves
            for (int i = 0; i < cboTypes.Text.Length; i++)
            {
                if (types.Contains(condensedTypeCode))
                {
                    break;
                }
                condensedTypeCode = condensedTypeCode + cboTypes.Text[i].ToString();
                Console.WriteLine(condensedTypeCode);
            }

            //Searches for a repair like description desc and of type condensedTypeCode and displays it in a data grid
            grdRepairs.DataSource = Repair.findRepair(condensedTypeCode, 'A').Tables["repair"];

            if (grdRepairs.Rows.Count < 1)
            {
                MessageBox.Show("No Data Found");
                cboTypes.Focus();
                return;
            }

            grdRepairs.Enabled = true;
            grdRepairs.Visible = true;
            btnSearch.Enabled = false;
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtRepId.Text);
            newRepair.completeRepair(Id, date);
            MessageBox.Show("Repair Completed");
            grpComplete.Visible = false;
            grpCustDetails.Visible = false;
            grdRepairs.Visible = false;
            cboTypes.SelectedIndex = -1;
            cboTypes.Focus();
            btnSearch.Enabled = true;
        }

        private void btnDeny_Click_1(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtRepId.Text);
            newRepair.denyRepair(Id, date);
            MessageBox.Show("Repair Cancelled");
            grpComplete.Visible = false;
            grpCustDetails.Visible = false;
            grdRepairs.Visible = false;
            cboTypes.SelectedIndex = -1;
            cboTypes.Focus();
            btnSearch.Enabled = true;
        }

        private void grdRepairs_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            grdRepairs.Enabled = false;
            //extract the Id from column zero on the selected row in grid
            int Id = Convert.ToInt32(grdRepairs.Rows[grdRepairs.CurrentCell.RowIndex].Cells[0].Value.ToString());

            //instantiate repair
            newRepair.getRepair(Id);

            //move the instance variable values to the form controls
            grpCustDetails.Visible = true;

            txtRepId.Text = newRepair.getRepairId().ToString("0");
            txtRepDesc.Text = newRepair.getDescription().ToString();
            txtCustId.Text = newRepair.getCustId().ToString("0");
            txtPrice.Text = newRepair.getPrice().ToString();
            txtStartDate.Text = newRepair.getStartDate();


            newCustomer.getCustomer(Convert.ToInt32(txtCustId.Text));

            newCustomer.getCustomerName(Convert.ToInt32(txtCustId.Text));
            txtSName.Text = newCustomer.getSName();
            txtFName.Text = newCustomer.getFName();
            grpComplete.Visible = true;
        }

        private void mnuBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
            parent.Visible = true;
        }

        public String getDate()
        {
            DateTime today = DateTime.Today;
            String date = today.ToString();
            date = date[0..10];

            date = date.Remove(6, 2);

            int month = Convert.ToInt32(date[3].ToString() + date[4].ToString());
            String stringMonth = "";

            switch (month)
            {
                case 1:
                    stringMonth = "JAN";
                    break;
                case 2:
                    stringMonth = "FEB";
                    break;
                case 3:
                    stringMonth = "MAR";
                    break;
                case 4:
                    stringMonth = "APR";
                    break;
                case 5:
                    stringMonth = "MAY";
                    break;
                case 6:
                    stringMonth = "JUN";
                    break;
                case 7:
                    stringMonth = "JUL";
                    break;

                case 8:
                    stringMonth = "AUG";
                    break;

                case 9:
                    stringMonth = "SEP";
                    break;

                case 10:
                    stringMonth = "OCT";
                    break;

                case 11:
                    stringMonth = "NOV";
                    break;

                case 12:
                    stringMonth = "DEC";
                    break;
            }



            date = date.Remove(3, 2);
            date = date.Insert(3, stringMonth);



            return date;
        }

        
    }
}
