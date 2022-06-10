using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_33_AddressBook_System_Ado_Net
{
    internal class BookOperations
    {
        //path for Database Connection
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookDB_Day_33;Integrated Security=True;Connect Timeout=40;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //method to establish connection
        public SqlConnection getConnection()
        {
            //Represents a connection to MS Sql Server Database
            SqlConnection connection = new SqlConnection(connectionString);
            Console.WriteLine("\n=> Connection Established successfully...");
            return connection;
        }


    }

}
