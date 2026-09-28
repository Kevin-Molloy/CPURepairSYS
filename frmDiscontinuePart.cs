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
    public partial class frmDiscontinuePart : Form
    {
        frmMainMenu parent;
        Part newPart = new Part();

        public frmDiscontinuePart(frmMainMenu parent)
        {
            InitializeComponent();
            this.parent = parent;

        }

        public frmDiscontinuePart()
        {
            InitializeComponent();
        }

        private void frmDiscontinuePart_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {   
            //Searches for part 
            grpDisPart.Visible = false;
            grdParts.DataSource = Part.disFindPart(txtSearch.Text).Tables["part"];

            if (grdParts.Rows.Count < 1)
            {
                MessageBox.Show("No Data Found");
                txtSearch.Focus();
                return;
            }

            grdParts.Visible = true;
        }

        private void grdParts_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int Id = Convert.ToInt32(grdParts.Rows[grdParts.CurrentCell.RowIndex].Cells[0].Value.ToString());

            newPart.getPart(Id);

            txtPartId.Text = newPart.getPartId().ToString("0");
            txtPartDesc.Text = newPart.getDescription();
            txtPartPrice.Text = newPart.getPrice().ToString("###0.00");
            txtPartQuantity.Text = newPart.getQuantity().ToString("000");
            txtPartStatus.Text = newPart.getStatus();

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

            //make the data availale for updating
            grpDisPart.Visible = true;
        }

        private void btnDisPart_Click(object sender, EventArgs e)
        {
            //Warning message
            DialogResult dr = MessageBox.Show("Warning! You are about to discontinue " + txtPartDesc.Text + ".Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No)
            {
                btnDisPart.Focus();
                return;
            }

            //Updates Status
            txtPartStatus.Text = "D";
            newPart.discontinuePart();

            //Display confirmation message
            MessageBox.Show("Product Discontinued", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Reset UI
            grdParts.Visible = false;
            txtPartId.Clear();
            txtPartDesc.Clear();
            txtPartPrice.Clear();
            txtPartQuantity.Clear();
            cboTypes.SelectedIndex = -1;
            grpDisPart.Visible = false;

            txtSearch.Clear();
            txtSearch.Focus();

        }

        private void mnuBack_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Visible = true;
        }
    }
}
