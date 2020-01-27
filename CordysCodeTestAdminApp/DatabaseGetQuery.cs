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
        public List<Store> GetStores()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBConnectionHelper.ConnStringValue("CordysManagementDB")))
            {
                return connection.Query<Store>("Select * from Stores").ToList();
            }
        }

        public List<Product> GetProducts()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBConnectionHelper.ConnStringValue("CordysManagementDB")))
            {
                return connection.Query<Product>("Select * from Products").ToList();
            }
        }

        public List<Sale> GetSales()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBConnectionHelper.ConnStringValue("CordysManagementDB")))
            {
                return connection.Query<Sale>("Select * from SalesView").ToList();
            }
        }
    }
}
