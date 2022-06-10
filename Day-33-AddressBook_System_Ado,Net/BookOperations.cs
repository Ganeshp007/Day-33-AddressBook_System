using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_33_AddressBook_System_Ado_Net
{
    public class BookOperations
    {
        //path for Database Connection
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookDB_Day_33;Integrated Security=True;Connect Timeout=40;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Represents a connection to MS Sql Server Database
        SqlConnection connection = new SqlConnection(connectionString);
         
        public ContactModel getContact()
        {
            ContactModel contact = new ContactModel();
            //Console.Write("Enter Contact ID :- ");
            //contact.PersonId =Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter First Name :- ");
            contact.FirstName=Console.ReadLine();
            Console.Write("Enter Last Name :- ");
            contact.LastName=Console.ReadLine();
            Console.WriteLine("Enter Address :- ");
            contact.Address= Console.ReadLine();
            Console.WriteLine("Enter City :- ");
            contact.City=Console.ReadLine();
            Console.WriteLine("Enter State :- ");
            contact.State=Console.ReadLine();
            Console.WriteLine("Enter Mobile Number :- ");
            contact.MobileNo=Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Email ID :- ");
            contact.EmailId=Console.ReadLine(); 
            return contact;
        }

        public void AddContact(ContactModel model)
        {
            try
            {      
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAdd_AddressBook_Details", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("@PersonId", model.PersonId);//we are not taking this bcoz we assigned it as identity
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@MobileNo", model.MobileNo);
                    command.Parameters.AddWithValue("@EmailId", model.EmailId);
                  
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

    }

}
