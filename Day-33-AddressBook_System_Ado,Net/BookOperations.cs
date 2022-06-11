using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_33_AddressBook_System_Ado_Net
{
    public class BookOperations
    {
        //path for Database Connection
        public const  string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookDB_Day_33;Integrated Security=True;Connect Timeout=40;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Represents a connection to MS Sql Server Database
        SqlConnection connection = new SqlConnection(connectionString);
         
        public ContactModel getContact()
        {
            ContactModel contact = new ContactModel();
            //Console.Write("Enter Contact ID :- ");
            //contact.PersonId =Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter First Name :- ");
            contact.FirstName=Console.ReadLine();
            Console.Write("Enter Last Name :- ");
            contact.LastName=Console.ReadLine();
            Console.Write("Enter Address :- ");
            contact.Address= Console.ReadLine();
            Console.Write("Enter City :- ");
            contact.City=Console.ReadLine();
            Console.Write("Enter State :- ");
            contact.State=Console.ReadLine();
            Console.Write("Enter Mobile Number :- ");
            contact.MobileNo=Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter Email ID :- ");
            contact.EmailId=Console.ReadLine(); 
            return contact;
        }

        ////Method to ADD New Contact in AddressBook DB
        public void AddContact(ContactModel model) //passing obj of ContactModel
        {
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SpAdd_AddressBook_Details", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("@PersonId", model.PersonId);//we are not taking this bcoz we assigned it as identity
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@MobileNo", model.MobileNo);
                    command.Parameters.AddWithValue("@EmailId", model.EmailId);

                    connection.Open();
                    var result = command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        //Method to Update Contacts Address in AddressBookDB 
        public void UpdateAdressBook_City(AddressUpdateModel addressUpdateModel)
        {
            try
            {
                using (connection)
                {   
                    SqlCommand command = new SqlCommand("SpUpdate_AddressBook_Details", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", addressUpdateModel.FirstName);
                    command.Parameters.AddWithValue("@LastName", addressUpdateModel.LastName);
                    command.Parameters.AddWithValue("@City", addressUpdateModel.City_Update);
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("\n> Record Updated Successfully...");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        //Method TO Display All the records in AddressBook DB
        public void DisplayRecords()
        {
            ContactModel model = new ContactModel();
            //Opens Connection
            this.connection.Open();
            string query = @"select * from AddressBook";
            //Pass query to TSql
            SqlCommand sqlCommand = new SqlCommand(query, this.connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //Check if sqlDataReader has Rows
            if (sqlDataReader.HasRows)
            {
                Console.WriteLine("\n>> Records Retrieved From DataBase : ");
                //Read each row
                while (sqlDataReader.Read())
                {
                    //Read data from Employee_payroll_33 DataBase using SqlDataReader and Display them 
                    model.PersonId = sqlDataReader.GetInt32(0);
                    model.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
                    model.LastName = Convert.ToString(sqlDataReader["LastName"]);
                    model.Address = Convert.ToString(sqlDataReader["Address"]);
                    model.City = sqlDataReader["City"].ToString();
                    model.State = Convert.ToString(sqlDataReader["State"]);
                    model.MobileNo = Convert.ToInt64(sqlDataReader["MobileNo"]);            
                    model.EmailId = Convert.ToString(sqlDataReader["EmailId"]);

                    //Display Data
                    Console.WriteLine("\nPerson ID :- {0} \nFirstName :- {1} \nLastName :- {2} \n Address :- {3} \nCity :- {4} \nState :- {5} \nMobile No. :- {6} \nEmail ID :- {7}", model.PersonId, model.FirstName, model.LastName, model.Address, model.City,
                        model.State, model.MobileNo, model.EmailId);
                }
                //Close sqlDataReader Connection
                sqlDataReader.Close();
            }
            //Close Connection
            connection.Close();
        
        }

    }

}
