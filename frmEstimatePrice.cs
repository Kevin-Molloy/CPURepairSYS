using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CPURepairSYS
{
    public partial class frmEstimatePrice : Form
    {
        frmMainMenu parent;
        //New repair
        Repair newRepair = new Repair();
        //NewCustomer
        Customer newCustomer = new Customer();

        //List of part ids used in the repair
        List<int> partIdList = new List<int>();

        //list of the quantities for each part used
        List<int> quantityList = new List<int>();

        //Binary list stating if after the operation a given part's quantity will be 0
        List<int> flagList = new List<int>();

        //List of prices which corespond to the parts
        List<decimal> priceList = new List<decimal>();

        //Storage variables which allow you to remove the most recently added part
        decimal storedPrice;
        int storedQty;
        String displayPart;

        public frmEstimatePrice(frmMainMenu parent)
        {
            InitializeComponent();
            this.parent = parent;
            btnRmvPart.Enabled = false;

        }


        public frmEstimatePrice()
        {
            InitializeComponent();
        }

        private void frmEstimatePrice_Load(object sender, EventArgs e)
        {
            //On load populate the combobox
            DataSet ds = RepairTypeCode.getRepairTypeCodes();
            cboTypes.Items.Clear();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboTypes.Items.Add(ds.Tables[0].Rows[i][0] + " - " + ds.Tables[0].Rows[i][1]);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)//SEARCHING FOR A REPAIR
        {

            //Validation

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
            grdRepairs.DataSource = Repair.findRepair(condensedTypeCode, 'L').Tables["repair"];

            if (grdRepairs.Rows.Count < 1)
            {
                MessageBox.Show("No Data Found");
                cboTypes.Focus();
                return;
            }

            grdRepairs.Visible = true;
            btnSearch.Enabled = false;

        }


        private void btnSearchPart_Click(object sender, EventArgs e)//Searching for a part
        {
            //Searches for part like description desc and loads to the grid
            grdParts.DataSource = Part.estFindPart(txtPartDesc.Text).Tables["part"];

            if (grdParts.Rows.Count < 1)
            {
                MessageBox.Show("No Data Found");
                txtPartDesc.Focus();
                return;
            }

            grdParts.Visible = true;
            txtPartPrice.Text = grdParts.Rows[grdParts.CurrentCell.RowIndex].Cells[2].ToString();


        }


        private void grdRepairs_CellClick(object sender, DataGridViewCellEventArgs e)
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

            newCustomer.getCustomer(Convert.ToInt32(txtCustId.Text));

            newCustomer.getCustomerName(Convert.ToInt32(txtCustId.Text));
            txtSName.Text = newCustomer.getSName();
            txtFName.Text = newCustomer.getFName();

            grpPartSearch.Visible = true;
        }

        private void txtPartDesc_TextChanged(object sender, EventArgs e)
        {
            //Searches while you are typing
            grdParts.DataSource = Part.estFindPart(txtPartDesc.Text).Tables["part"];
            grdParts.Visible = true;
        }

        private void grdParts_Click(object sender, EventArgs e)
        {
            //Takes contents of grid and puts them into variables
            int id = Convert.ToInt32(grdParts.Rows[grdParts.CurrentCell.RowIndex].Cells[0].Value.ToString());
            decimal pr = Repair.findPrice(id);
            txtPartPrice.Text = pr.ToString();
            txtPartQty.Text = "1";
        }

        private void btnEstimatePrice_Click(object sender, EventArgs e)
        {
            //makes an array of the part id list. I could have just used the list but im more comfortable with arrays
            int[] partIdArray = partIdList.ToArray();
            int[] quantityArray = quantityList.ToArray();
            int[] flagArray = flagList.ToArray();
            decimal[] priceArray = priceList.ToArray();


            //Calls estimate price 
            newRepair.estimateRepairPrice(Convert.ToInt32(txtCustId.Text), Convert.ToInt32(txtRepId.Text), Convert.ToDecimal(txtTotalPrice.Text), partIdArray, quantityArray, flagArray, priceArray);

            MessageBox.Show("Final price of " + txtTotalPrice.Text + " has been sent to the customer for approval");
            Reset();




        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            btnRmvPart.Enabled = true;

            int a;

            int chosenQuantity = Convert.ToInt32(txtPartQty.Text);
            int totalQuantity = Convert.ToInt32(grdParts.Rows[grdParts.CurrentCell.RowIndex].Cells[3].Value.ToString());
            //Checks the part quantity against the entered quantity
            if (chosenQuantity > totalQuantity || storedQty + 1 > totalQuantity || !int.TryParse(txtPartQty.Text, out a))
            {
                MessageBox.Show("Error. Invalid Quantity");
                txtPartQty.Focus();
                return;
            }

            


            //puts the id into a variable
            int id = Convert.ToInt32(grdParts.Rows[grdParts.CurrentCell.RowIndex].Cells[0].Value.ToString());

            //Sets the storage variables
            storedPrice = Convert.ToDecimal(txtPartPrice.Text);
            storedQty = Convert.ToInt32(txtPartQty.Text);

            String desc = grdParts.Rows[grdParts.CurrentCell.RowIndex].Cells[1].Value.ToString();

            //If the part id list does not contain the current part id. ie if its a new part
            if (!partIdList.Contains(id))
            {
                //Adds different variables to different lists, displays price, qty and description
                displayPart = desc + ": Price: " + storedPrice + " Qty: " + storedQty;
                lstPartBasket.Items.Add(displayPart);
                partIdList.Add(id);
                quantityList.Add(Convert.ToInt32(txtPartQty.Text));
                priceList.Add(Convert.ToDecimal(txtPartPrice.Text) * Convert.ToInt32(txtPartQty.Text));

                //Either adds a 1 or a 0 to the flaglist, depending on if the quantity will be zero after the operation
                if (storedQty - Convert.ToInt32(grdParts.Rows[grdParts.CurrentCell.RowIndex].Cells[3].Value.ToString()) == 0)
                {
                    flagList.Add(1);
                }
                else
                {
                    flagList.Add(0);
                }

            }
            else   //IF THE PART ID IS ALREADY IN THE PART ID LIST
            {
                //Gets the index of the part
                int index = partIdList.IndexOf(id);

                //Updates the Storage variables

                quantityList[index] += storedQty;
                priceList[index] += storedPrice;
                storedQty = quantityList[index];
                storedPrice = priceList[index];

                //Updates the display
                displayPart = desc + ": Price: " + storedPrice + ". Qty: " + storedQty;
                lstPartBasket.Items.RemoveAt(Convert.ToInt32(index));
                lstPartBasket.Items.Add(displayPart);

                if (storedQty - Convert.ToInt32(grdParts.Rows[grdParts.CurrentCell.RowIndex].Cells[3].Value.ToString()) == 0)
                {
                    flagList[index] = 1;
                }

            }
            //Updates total price
            decimal ttl = (Convert.ToDecimal(txtTotalPrice.Text) + (Convert.ToDecimal(txtPartPrice.Text) * Convert.ToDecimal(txtPartQty.Text)));
            txtTotalPrice.Text = ttl.ToString();

        }

        private void mnuBack_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Visible = true;
        }

        private void btnRmvPart_Click(object sender, EventArgs e)
        {   //There was at one point a rounding error here, where the decrement was off by 98 cent, but i cant recreate it and it seems adding in what is on line 287
            //has fixed the issue


            //Decrements price
            txtTotalPrice.Text = (Convert.ToDecimal(txtTotalPrice.Text) - storedPrice ).ToString();

            //Removes from the display
            lstPartBasket.Items.RemoveAt(Convert.ToInt32(lstPartBasket.Items.Count - 1));

            //Removes from lists
            partIdList.RemoveAt(partIdList.Count - 1);
            quantityList.RemoveAt(quantityList.Count - 1);
            priceList.RemoveAt(priceList.Count - 1);
            flagList.RemoveAt(flagList.Count - 1);

            //Basically if the part you removed is the first part you added, this sets everything to zero and doesnt crash the form
            try
            {
                storedPrice = priceList[priceList.Count - 1];
                storedQty = quantityList[quantityList.Count - 1];
            }
            catch (System.ArgumentOutOfRangeException)
            {
                storedPrice = 0;
                txtTotalPrice.Text = "0";
                storedQty = 0;
                btnRmvPart.Enabled = false;
            }


        }

        public void Reset()
        {
            //Resets the ui and brings you back to the start
            partIdList.Clear();
            quantityList.Clear();
            flagList.Clear();
            priceList.Clear();
            storedPrice = 0;
            storedQty = 0;
            displayPart = "";
            grdRepairs.Visible = false;
            grpCustDetails.Visible = false;
            grpPartSearch.Visible = false;
            cboTypes.SelectedIndex = 0;
            cboTypes.Focus();
            btnSearch.Enabled = true;
        }

       
    }
}
