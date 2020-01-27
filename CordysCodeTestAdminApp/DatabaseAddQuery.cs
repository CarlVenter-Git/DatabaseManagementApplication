using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordysCodeTestAdminApp
{
    class DatabaseAddQuery
    {
        private string currentDB = DBConnectionHelper.ConnStringValue("CordysManagementDB");

        public bool AddStore(Store store)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(currentDB))
            {
                connection.Query<Store>($"INSERT INTO Stores VALUES ('{ store.StoreID }', '{ store.Name }', '{ store.Address }', '{ store.Tel }')");

                return true;
            }
        }

        public bool AddProduct(Product product)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(currentDB))
            {
                connection.Query<Product>($"INSERT INTO Products VALUES ('{ product.ProductID }', '{ product.Description }', '{ product.Price }')");

                return true;
            }
        }

        public bool AddSale(Sale sale)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(currentDB))
            {
                connection.Query<SaleView>($"INSERT INTO ProductSales VALUES ('{ sale.SaleID }', '{ sale.ProductID }', '{ sale.StoreID }', '{ sale.Date }', '{ sale.Quantity }')");

                return true;
            }
        }
    }
}
