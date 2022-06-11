// See https://aka.ms/new-console-template for more information

using Day_33_AddressBook_System_Ado_Net;

Console.WriteLine("----- Welcome to AddressBook System using ADO Library -----\n");
BookOperations obj = new BookOperations();
bool check = true;
while (check)
{
    Console.WriteLine("\nChoose the Operation :");
    Console.WriteLine("1.Add New Contact To AddressBookDB\n2.Display AddressBook Records\n3.Update Record using PersonsName\n4.Exit");
    Console.Write("\n> ENter your choice : ");
    int option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:
            Console.WriteLine("\n> Add New Contacts to AddressBookDB  ");
            Console.Write("\nHow many contacts you want to add :- ");
            int count = Convert.ToInt32(Console.ReadLine());
            int num_of_records = 0;
            while (count > 0)
            {
                BookOperations obj1 = new BookOperations();
                num_of_records++;
                Console.WriteLine("\nEnter Details for contact {0} :", num_of_records);
                var contactmodel = obj1.getContact();
                obj1.AddContact(contactmodel);
                count--;
            }
            if (count == 0)
                Console.WriteLine("Records Inserted into AddressBook DB successfully...");
            break;
        case 2:
            Console.WriteLine("\n> Dislay Records From AddressBook ");
            obj.DisplayRecords();
            Console.WriteLine("----------------------------------------------");
            break;

        case 3:
            Console.WriteLine("\n> Update Record Using Person FirstName and LastName ");
            BookOperations obj2=new BookOperations();
            AddressUpdateModel update = new AddressUpdateModel();
            Console.Write("Enter the FirstName of Person :- ");
            update.FirstName = Console.ReadLine();
            Console.Write("Enter the LastName of Person :- ");
            update.LastName=Console.ReadLine();
            Console.Write("Enter the City Name You want to change to :- ");
            update.City_Update = Console.ReadLine();
            obj2.UpdateAdressBook_City(update);
            break;

        case 4:
            check = false;
            break;

        default: Console.WriteLine("Please Enter a valid choice!!"); break;
    }
}


