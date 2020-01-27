using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CordysCodeTestAdminApp
{
    public partial class FrmProductAdd : Form
    {
        public FrmProductAdd()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DatabaseAddQuery da = new DatabaseAddQuery();
            Product product = new Product();

            product.ProductID = int.Parse(txtProductID.Text);
            product.Description = txtProductDescription.Text;
            product.Price = double.Parse(txtProductPrice.Text);

            da.AddProduct(product);

            MessageBox.Show($"Product {product.Description} has been added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            //TODO: add input masking to ensure data integrity
        }

        private void txtProductDescription_TextChanged(object sender, EventArgs e)
        {
            //TODO: add input masking to ensure data integrity
        }

        private void txtProductPrice_TextChanged(object sender, EventArgs e)
        {
            //TODO: add input masking to ensure data integrity
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
