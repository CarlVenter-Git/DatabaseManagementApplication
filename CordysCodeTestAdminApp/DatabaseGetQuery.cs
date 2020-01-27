using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace CordysCodeTestAdminApp
{
    class DatabaseGetQuery
    {
        private string currentDB = DBConnectionHelper.ConnStringValue("CordysManagementDB");

        public List<Store> GetStores()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(currentDB))
            {
                return connection.Query<Store>("SELECT * FROM Stores").ToList();
            }
        }

        public List<Product> GetProducts()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(currentDB))
            {
                return connection.Query<Product>("SELECT * FROM Products").ToList();
            }
        }

        public List<SaleView> GetSales()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(currentDB))
            {
                return connection.Query<SaleView>("SELECT * FROM SalesView").ToList();
            }
        }
    }
}
