using System;

namespace AddressBookLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Address Book System using Linq");
 
            ContactDataManager contactDataManager = new ContactDataManager();
            contactDataManager.CreateDataTable();
            contactDataManager.AddValues();
            contactDataManager.Display();
        }
    }
}
