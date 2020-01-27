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
        private string currentDB = DBConnectionHelper.ConnStringValue("CordysManagementDB");

        public bool UpdateStores(int id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(currentDB))
            {
                connection.Query<Store>($"DELETE FROM Stores WHERE storeID = {id}");

                return true;
            }
        }

        public bool UpdateProducts(int id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(currentDB))
            {
                connection.Query<Product>($"DELETE FROM Products WHERE productID = {id}");

                return true;
            }
        }

        //I would not allow deletion of sales data. I would allow it with higher rights, but that is beyond the scope of this application
        //public List<Sale> UpdateSales()
        //{
        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(currentDB))
        //    {
        //        return connection.Query<Sale>("Select * from SalesView").ToList();
        //    }
        //}
    }
}
