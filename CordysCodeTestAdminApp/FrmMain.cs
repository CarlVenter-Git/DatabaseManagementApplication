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
        private List<SaleView> sales = new List<SaleView>();

        private List<Store> storeEditList = new List<Store>();
        private List<Product> productEditList = new List<Product>();

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
            DatabaseUpdateQuery uq = new DatabaseUpdateQuery();

            switch (tabControl.SelectedIndex)
            {
                case 0:
                    if (storeEditList != null)
                    {
                        foreach (var i in storeEditList)
                        {
                            uq.UpdateStores(i);
                        }
                    }
                    break;
                case 1:
                    if (productEditList != null)
                    {
                        foreach (var i in productEditList)
                        {
                            uq.UpdateProducts(i);
                        }
                    }
                    break;
                // I will not be allowing updating of the sales table,
                //case 2:
                //    break;
                default:
                    break;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DatabaseDeleteQuery uq = new DatabaseDeleteQuery();

            switch (tabControl.SelectedIndex)
            {
                case 0:
                    if (uq.UpdateStores(int.Parse(dgvStores.SelectedRows[0].Cells[0].Value.ToString())))//ID will always be a number, no need for tryParse
                    {
                        stores.RemoveAt(dgvStores.SelectedRows[0].Index);
                        FillDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Cannot delete that item!\nThis is probably caused by one of the fields being a foreign key in another table", 
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    break;
                case 1:
                    if (uq.UpdateProducts(int.Parse(dgvProducts.SelectedRows[0].Cells[0].Value.ToString())))
                    {
                        products.RemoveAt(dgvProducts.SelectedRows[0].Index);
                        FillDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Cannot delete that item!\nThis is probably caused by one of the fields being a foreign key in another table",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
                case 2:
                    MessageBox.Show("Cannot delete from this table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    FrmStoreAdd storeAdd = new FrmStoreAdd();
                    storeAdd.ShowDialog();
                    FillDataGrid();
                    break;
                case 1:
                    FrmProductAdd productAdd = new FrmProductAdd();
                    productAdd.ShowDialog();
                    FillDataGrid();
                    break;
                case 2:
                    FrmSaleAdd saleAdd = new FrmSaleAdd();
                    saleAdd.ShowDialog();
                    FillDataGrid();
                    break;
                default:
                    break;
            }
        }

        private void dgvStores_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Store store = new Store();

            store.StoreID = int.Parse(dgvStores.Rows[e.RowIndex].Cells["StoreID"].Value.ToString());
            store.Name = dgvStores.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            store.Address = dgvStores.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            store.Tel = dgvStores.Rows[e.RowIndex].Cells["Address"].Value.ToString();

            storeEditList.Add(store);
        }

        private void dgvProducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Product product = new Product();

            product.ProductID = int.Parse(dgvProducts.Rows[e.RowIndex].Cells["ProductID"].Value.ToString());
            product.Description = dgvProducts.Rows[e.RowIndex].Cells["Description"].Value.ToString();
            product.Price = double.Parse(dgvProducts.Rows[e.RowIndex].Cells["Price"].Value.ToString());

            productEditList.Add(product);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGrid();
        }

    }
}
