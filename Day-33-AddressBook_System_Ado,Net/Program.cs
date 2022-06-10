// See https://aka.ms/new-console-template for more information

using Day_33_AddressBook_System_Ado_Net;

Console.WriteLine("----- Welcome to AddressBook System using ADO Library -----\n");
BookOperations obj = new BookOperations();
bool check = true;
while(check)
{
    Console.WriteLine("\nChoose the Operation :");
    Console.WriteLine("1.Add New Contact To AddressBookDB\n2.Exit");
    Console.Write("> ENter your choice : ");
    int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                Console.WriteLine("> Add New Contacts to AddressBookDB  ");
                Console.Write("How many contacts you want to add :- ");
                int count = Convert.ToInt32(Console.ReadLine());
                int num_of_records = 0;
                while (count > 0)
                {   num_of_records++; 
                    Console.WriteLine("Enter Details for contact {0} :",num_of_records);
                    var contactmodel = obj.getContact();
                    obj.AddContact(contactmodel);
                    count--;
                }
                break;

            case 2:
                check=false;
                break;

            default: Console.WriteLine("Please Enter a valid choice!!"); break;
        }
}    


