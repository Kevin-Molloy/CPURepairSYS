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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CPURepairSYS
{

    public partial class frmAddPart : Form
    {
        frmMainMenu parent;

        public frmAddPart(frmMainMenu parent)
        {
            InitializeComponent();
            this.parent = parent;

        }

        public frmAddPart()
        {
            InitializeComponent();
        }

        private void frmAddPart_Load(object sender, EventArgs e)
        {
            txtPartId.Text = Part.getNextPartId().ToString("");



            DataSet ds = PartTypeCode.getPartTypeCodes();
            cboTypes.Items.Clear();





            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboTypes.Items.Add(ds.Tables[0].Rows[i][0] + " - " + ds.Tables[0].Rows[i][1]);
                
            }

            
        }

        private void mnuBack_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Visible = true;
        }

   

        private void btnAddPart_Click(object sender, EventArgs e)
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

            if (cboTypes.Text.Equals(""))
            {
                MessageBox.Show("Type Code must  be selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTypes.Focus();
                return;
            }

            //Sets an array of possible repair types to be passed into the below loop
            String[] types = { "PROC", "GCARD", "FAN", "CASE", "BATT", "POWSUP", "MTHBRD", "COOL", "RAM", "STOR", "WIFIADAP", "SCRN", "MULT", "OTH" };
            String condensedTypeCode ="";

            //Indexes through the array and adds a letter from cboTypes.Text to the condensed variable until the condensed variable is found in the array. This is done because
            //the combo box contains descriptions of the types as well as the type code themselves
            for (int i = 0; i<cboTypes.Text.Length;i++) {
                if (types.Contains(condensedTypeCode)){
                    break;
                }
                condensedTypeCode = condensedTypeCode + cboTypes.Text[i].ToString();
                Console.WriteLine(condensedTypeCode);
            }

            //Creates a new part and adds it to the database

            Part newPart = new Part(Convert.ToInt32(txtPartId.Text), txtPartDesc.Text,
                Convert.ToDecimal(txtPartPrice.Text), Convert.ToInt32(txtPartQuantity.Text),"A", 
                condensedTypeCode);

            newPart.AddPart();

            MessageBox.Show("Part Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Clears Form controls
            txtPartId.Clear();
            txtPartId.Text = Part.getNextPartId().ToString("");
            txtPartDesc.Clear();
            txtPartPrice.Clear();
            txtPartQuantity.Clear();
            cboTypes.SelectedIndex = -1;




        }


    }
}
