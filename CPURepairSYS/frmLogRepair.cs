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
    public partial class frmLogRepair : Form
    {
        frmMainMenu parent;
        Customer newCust = new Customer();
    
        //flag variable for if customer is new or not
        int newCheck = 0;



        public frmLogRepair(frmMainMenu parent)
        {
            InitializeComponent();
            this.parent = parent;
           

        }

        public frmLogRepair()
        {
            InitializeComponent();
        }

        private void frmLogRepair_Load(object sender, EventArgs e)
        {
            //Gets relevant ids and loads them to the forms
            txtCustId.Text = Customer.getNextCustId().ToString("");
            txtRepId.Text = Repair.getNextRepairId().ToString("");
           
        }

        private void mnuBack_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Visible = true;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {

            //Makes relevant controls visible/invisible

            grpNewCust.Visible = true;
            grpExistingCust.Visible = false;
            txtNewEmail.Clear();
            txtNewFName.Clear();
            txtNewSName.Clear();
            txtNewPhone.Clear();


        }

        private void btnNo_Click(object sender, EventArgs e)
        {   
            //Makes relevant controls visible/invisible
            grpExistingCust.Visible = true;
            grpNewCust.Visible = false;

            txtFName.Clear();
            txtPhone.Clear();
            enableCust();


        }

        //EXISTING CUSTOMER
        private void btnEnter_Click(object sender, EventArgs e)
        {
            decimal a;

            if (txtFName.Text.Equals(""))
            {
                MessageBox.Show("Name must not be null ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFName.Focus();
                return;
            }

            if (decimal.TryParse(txtFName.Text, out a))
            {
                MessageBox.Show("Name must not be numeric ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFName.Clear();
                txtFName.Focus();
                return;
            }

            if (txtPhone.Text.Equals(""))
            {
                MessageBox.Show("Phone Number must not be null ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
                return;
            }

            if (!decimal.TryParse(txtPhone.Text, out a))
            {
                MessageBox.Show("Phone Number must be numeric ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Clear();
                txtPhone.Focus();
                return;
            }

            //Creates new customer object and gives it the properties of the existing customer
            Customer existingCust = new Customer();
            int flag = existingCust.findCustomer(txtPhone.Text, txtFName.Text.ToUpper());
            
            if (flag == 1)
            {
                MessageBox.Show("No Data Found");
                txtFName.Focus();
                return;
            }

            txtCustId.Text = existingCust.getCustId().ToString();
            txtNewFName.Text = existingCust.getFName();
            txtNewSName.Text = existingCust.getSName();
            txtNewPhone.Text = existingCust.getPhone().ToString();
            txtNewEmail.Text = existingCust.getEmail();
            grpNewCust.Visible = true;

            txtRepCust.Text = txtCustId.Text;
            disableCust();
            

            DataSet ds = RepairTypeCode.getRepairTypeCodes();
            cboTypes.Items.Clear();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboTypes.Items.Add(ds.Tables[0].Rows[i][0] + " - " + ds.Tables[0].Rows[i][1]);
            }

            //Makes the next layer of form controls visible

            grpExistingCust.Visible = false;
            grpExist.Enabled = false;
            grpNewCust.Visible = true;

            grpLogRepair.Visible = true;


        }

        //FIRST TIME CUSTOMER
        private void btnNewEnter_Click(object sender, EventArgs e)
        {
            decimal a;

            if (txtNewFName.Text.Equals(""))
            {
                MessageBox.Show("First Name must not be null ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewFName.Focus();
                return;
            }

            if (decimal.TryParse(txtNewFName.Text, out a))
            {
                MessageBox.Show("First Name must not be numeric ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewFName.Clear();
                txtNewFName.Focus();
                return;
            }

            if (txtNewSName.Text.Equals(""))
            {
                MessageBox.Show("Surname must not be null ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewSName.Focus();
                return;
            }

            if (decimal.TryParse(txtNewSName.Text, out a))
            {
                MessageBox.Show("Surname must not be numeric ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewSName.Clear();
                txtNewSName.Focus();
                return;
            }

            if (txtNewPhone.Text.Equals(""))
            {
                MessageBox.Show("Phone Number must not be null ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPhone.Focus();
                return;
            }

            if (!decimal.TryParse(txtNewPhone.Text, out a))
            {
                MessageBox.Show("Phone Number must be numeric ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPhone.Clear();
                txtNewPhone.Focus();
                return;
            }

            if (txtNewEmail.Text.Equals(""))
            {
                MessageBox.Show("Email must not be null ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewEmail.Focus();
                return;
            }

            if (decimal.TryParse(txtNewEmail.Text, out a))
            {
                MessageBox.Show("Email must not be numeric ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewEmail.Clear();
                txtNewEmail.Focus();
                return;
            }
            //Gets the values from the form and gives them to newCust

            int newId = Convert.ToInt32(txtCustId.Text);
            String newFName = txtNewFName.Text.ToUpper();
            String newSName = txtNewSName.Text.ToUpper();
            String newPhone = txtNewPhone.Text;
            String newEmail = txtNewEmail.Text;
            newCheck = 1;
            newCust = new Customer(newId, newFName,newSName,newPhone,newEmail);
            
            //Customer is not actually added here
            MessageBox.Show("Customer Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            DataSet ds = RepairTypeCode.getRepairTypeCodes();
            cboTypes.Items.Clear();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboTypes.Items.Add(ds.Tables[0].Rows[i][0] + " - " + ds.Tables[0].Rows[i][1]);
            }

            //Unlocks the next layer of form controls

            disableCust();
            grpExist.Enabled = false;
            txtRepCust.Text = txtCustId.Text;

            grpLogRepair.Visible = true;

        }
        public void disableCust()
        {
            //kill
            txtNewFName.Enabled = false;
            txtNewSName.Enabled = false;
            txtNewPhone.Enabled = false;
            txtNewEmail.Enabled = false;
            btnNewEnter.Enabled = false;
        }

        public void enableCust()
        {
            //unkill
            txtNewFName.Enabled = true;
            txtNewSName.Enabled = true;
            txtNewPhone.Enabled = true;
            txtNewEmail.Enabled = true;
            btnNewEnter.Enabled = true;

        }

    

        private void btnLogRepair_Click_1(object sender, EventArgs e)
        {
            decimal a;

            if (txtRepDesc.Text.Equals(""))
            {
                MessageBox.Show("Description must not be null ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRepDesc.Focus();
                return;
            }

            if (decimal.TryParse(txtRepDesc.Text, out a))
            {
                MessageBox.Show("Description must not be numeric ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRepDesc.Clear();
                txtRepDesc.Focus();
                return;
            }

            if (cboTypes.Text == "")
            {
                MessageBox.Show("Repair Type Codes cannnot be null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTypes.Focus();
                return;
            }

            String[] types = { "PROC", "GCARD", "FAN", "CASE", "BATT", "POWSUP", "MTHBRD", "COOL", "RAM", "STOR", "WIFIADAP", "SCRN", "MULT", "OTH" };
            String condensedTypeCode = "";

            for (int i = 0; i < cboTypes.Text.Length; i++)
            {
                if (types.Contains(condensedTypeCode))
                {
                    break;
                }
                condensedTypeCode = condensedTypeCode + cboTypes.Text[i].ToString();
                Console.WriteLine(condensedTypeCode);

            }


            //Gets the current date and formats it
            DateTime t = DateTime.Now;
            String d = t.ToString("dd/MMM/yy");

            //Creates a new repair object
            Repair newRepair = new Repair(Convert.ToInt32(txtRepId.Text), txtRepDesc.Text, "L", 0, d, "", condensedTypeCode, Convert.ToInt32(txtRepCust.Text));
            if (newCheck == 1)
            {
                //Finally preforms addCustomer on newCust
                newCust.AddCustomer();
            }

            //Preforms logRepair on newRepair
            newRepair.LogRepair();

            MessageBox.Show("Done!");
        }

 
    }
}
