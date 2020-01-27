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
    public partial class FrmMain : Form
    {
        private List<Store> stores = new List<Store>();
        private List<Product> products = new List<Product>();
        private List<Sale> sales = new List<Sale>();
        private int deletedRows;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DatabaseGetQuery dq = new DatabaseGetQuery();

            switch (tabControl.SelectedIndex)
            {
                case 0:
                    stores = dq.GetStores();
                    dgvStores.DataSource = stores;
                    break;
                case 1:
                    products = dq.GetProducts();
                    dgvProducts.DataSource = products;
                    break;
                // I will not be allowing deletion from the sales table
                //case 2:
                //    foreach (var i in deletedRows)
                //    {
                //        uq.UpdateSales(int.Parse(i));
                //    }

                //    dgvSales.DataSource = sales;
                //    break;
                default:
                    break;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            DatabaseGetQuery dq = new DatabaseGetQuery();

            switch (tabControl.SelectedIndex)
            {
                case 0:
                    stores = dq.GetStores();
                    dgvStores.DataSource = stores;
                    break;
                case 1:
                    products = dq.GetProducts();
                    dgvProducts.DataSource = products;
                    break;
                case 2:
                    sales = dq.GetSales();
                    dgvSales.DataSource = sales;
                    break;
                default:
                    break;
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DatabaseUpdateQuery uq = new DatabaseUpdateQuery();

            switch (tabControl.SelectedIndex)
            {
                case 0:
                    uq.UpdateStores(int.Parse(dgvStores.SelectedRows[0].Cells[0].Value.ToString()));//ID will always be a number, no need for tryParse
                    stores.RemoveAt(dgvStores.SelectedRows[0].Index);
                    FillDataGrid();
                    break;
                case 1:
                    uq.UpdateProducts(int.Parse(dgvProducts.SelectedRows[0].Cells[0].Value.ToString()));
                    products.RemoveAt(dgvProducts.SelectedRows[0].Index);
                    FillDataGrid();
                    break;
                case 2:
                    MessageBox.Show("Cannot delete from this table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
            
        }
    }
}
