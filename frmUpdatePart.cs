using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CPURepairSYS
{
    public partial class frmUpdatePart : Form
    {

        frmMainMenu parent;
        Part newPart = new Part();

        public frmUpdatePart(frmMainMenu parent)
        {
            InitializeComponent();
            this.parent = parent;

        }

        private void mnuBack_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Visible = true;
        }

        public frmUpdatePart()
        {
            InitializeComponent();
        }

        private void frmUpdatePart_Load(object sender, EventArgs e)
        {
            DataSet ds = PartTypeCode.getPartTypeCodes();
            cboTypes.Items.Clear();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboTypes.Items.Add(ds.Tables[0].Rows[i][0] + " - " + ds.Tables[0].Rows[i][1]);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Validation

            decimal a;

            if (txtSearch.Text == "")
            {
                MessageBox.Show("Part Description must not be null ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if (decimal.TryParse(txtSearch.Text, out a))
            {
                MessageBox.Show("Part Description must not be numeric ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            grpUpdPart.Visible = false;

            //Searches for a part
            grdParts.DataSource = Part.findPart(txtSearch.Text).Tables["part"];

            if (grdParts.Rows.Count < 1)
            {
                MessageBox.Show("No Data Found");
                txtSearch.Focus();
                return;
            }

            grdParts.Visible = true;
        }

        private void grdParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //extract the PartId from column zero on the selected row in grid
            int Id = Convert.ToInt32(grdParts.Rows[grdParts.CurrentCell.RowIndex].Cells[0].Value.ToString());

            //Gets part of id Id
            newPart.getPart(Id);

            //move the instance variable values to the form controls
            txtPartId.Text = newPart.getPartId().ToString("0");
            txtPartDesc.Text = newPart.getDescription();
            txtPartStatus.Text = newPart.getStatus();
            txtPartPrice.Text = newPart.getPrice().ToString("###0.00");
            txtPartQuantity.Text = newPart.getQuantity().ToString("000");


            //Load TypeCodes into combo box and set current value
            DataSet ds = PartTypeCode.getPartTypeCodes();
            int typeIndex = 0;
            cboTypes.Items.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboTypes.Items.Add(ds.Tables[0].Rows[i][0] + " - " + ds.Tables[0].Rows[i][1]);
                if (ds.Tables[0].Rows[i][0].Equals(newPart.getPartTypeCode())) typeIndex = i;
            }
            cboTypes.SelectedIndex = typeIndex;

            //make the product data availale for updating
            grpUpdPart.Visible = true;
        }
        private void btnUpdPart_Click(object sender, EventArgs e)
        {
            //Validation

            decimal a;

            if (txtPartDesc.Text.Equals(""))
            {
                MessageBox.Show("Description must not be null ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPartDesc.Focus();
                return;
            }

            if (decimal.TryParse(txtPartDesc.Text, out a))
            {
                MessageBox.Show("Description must not be numeric ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPartDesc.Clear();
                txtPartDesc.Focus();
                return;
            }

            if (!decimal.TryParse(txtPartPrice.Text, out a))
            {
                MessageBox.Show("Price must be numeric ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPartPrice.Clear();
                txtPartPrice.Focus();
                return;
            }

            if (txtPartPrice.Text.Equals("0.00"))
            {
                DialogResult dr = MessageBox.Show("Warning! Price is 0.00. Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    txtPartPrice.Focus();
                    return;
                }
            }

            if (txtPartPrice.Text.Equals(""))
            {
                MessageBox.Show("Price must not be null ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPartPrice.Focus();
                return;

            }

            if (!decimal.TryParse(txtPartQuantity.Text, out a))
            {
                MessageBox.Show("Quantity must be numeric ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPartQuantity.Clear();
                txtPartQuantity.Focus();
                return;
            }

            if (txtPartQuantity.Text.Equals(""))
            {
                MessageBox.Show("Quantity must not be null ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPartQuantity.Focus();
                return;

            }

            if (txtPartStatus.Text.Equals(""))
            {
                MessageBox.Show("Status must not be null ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPartStatus.Focus();
                return;
            }

            if (decimal.TryParse(txtPartStatus.Text, out a))
            {
                MessageBox.Show("Status must not be numeric ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPartStatus.Focus();
                return;
            }


            if (!(txtPartStatus.Text.ToString().Equals("A") || txtPartStatus.Text.ToString().Equals("O")))
            {
                MessageBox.Show("Status must be either A - Available or O - Out of Stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPartStatus.Focus();
                return;
            }
        


            if (txtPartStatus.Text.Equals("D"))
            {
                MessageBox.Show("To Discontinue a part, please go to the Discontinue Part page", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPartStatus.Focus();
                return;
            }

            if (cboTypes.Text.Equals(""))
            {
                MessageBox.Show("Type Code must  be selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTypes.Focus();
                return;
            }

            if (txtPartStatus.Text.Equals("O"))
            {
                txtPartQuantity.Text = "0";
            }

            //Same formula used as add part, see line 132 for explaination
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

            //Setting the values
            newPart.setPartId(Convert.ToInt32(txtPartId.Text));
            newPart.setDescription(txtPartDesc.Text);
            newPart.setPrice(Convert.ToDecimal(txtPartPrice.Text));
            newPart.setQuantity(Convert.ToInt32(txtPartQuantity.Text));
            newPart.setStatus(txtPartStatus.Text.ToString());
            newPart.setPartTypeCode(condensedTypeCode);

            

            //update the data in the database
            newPart.updatePart();

            //Display confirmation message
            MessageBox.Show("Part Updated", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Reset UI
            grdParts.Visible = false;
            txtPartId.Clear();
            txtPartDesc.Clear();
            txtPartPrice.Clear();
            txtPartQuantity.Clear();
            cboTypes.SelectedIndex = -1;
            grpUpdPart.Visible = false;

            txtSearch.Clear();
            txtSearch.Focus();

        }
    }
}
