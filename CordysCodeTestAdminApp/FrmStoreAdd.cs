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
    public partial class FrmStoreAdd : Form
    {
        public FrmStoreAdd()
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
            Store store = new Store();

            store.StoreID = int.Parse(txtStoreID.Text);
            store.Name = txtName.Text;
            store.Address = txtAddress.Text;
            store.Tel = txtTel.Text;

            da.AddStore(store);

            MessageBox.Show($"Store {store.Name} has been added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
