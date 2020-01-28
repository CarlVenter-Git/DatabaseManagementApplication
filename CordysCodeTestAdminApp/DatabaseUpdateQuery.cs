using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordysCodeTestAdminApp
{
    class DatabaseUpdateQuery
    {
        private string currentDB = DBConnectionHelper.ConnStringValue();

        public bool UpdateStores(Store store)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(currentDB))
            {
                try
                {
                    connection.Query<Store>($"UPDATE Stores SET storeID = '{ store.StoreID }', name = '{ store.Name }', address = '{ store.Address }', tel = '{ store.Tel }' " +
                        $"WHERE storeID = {store.StoreID}");

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool UpdateProducts(Product product)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(currentDB))
            {
                try
                {
                    connection.Query<Product>($"UPDATE Products SET productID = '{ product.ProductID }', description = '{ product.Description }', price = '{ product.Price }' " +
                        $"WHERE productID = {product.ProductID}");

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //I would not allow editing of sales data. I would associate it with higher rights, but that is beyond the scope of this application
        //public List<Sale> UpdateSales()
        //{
        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(currentDB))
        //    {
        //        return connection.Query<Sale>("Select * from SalesView").ToList();
        //    }
        //}
    }
}
