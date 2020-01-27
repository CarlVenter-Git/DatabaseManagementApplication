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
    public partial class FrmSaleAdd : Form
    {
        public FrmSaleAdd()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DatabaseAddQuery da = new DatabaseAddQuery();
            Sale sale = new Sale();

            sale.SaleID = int.Parse(txtSaleID.Text);
            sale.ProductID = int.Parse(txtProductID.Text);
            sale.StoreID = int.Parse(txtStoreID.Text);
            sale.Date = dtDateTime.Value;
            sale.Quantity = int.Parse(txtQuantity.Text);

            da.AddSale(sale);

            MessageBox.Show($"Product { sale.SaleID } has been added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
