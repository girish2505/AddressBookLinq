using System;

namespace AddressBookLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Address Book System using Linq");
 
            ContactDataManager contactDataManager = new ContactDataManager();
            //contactDataManager.CreateDataTable();
            //contactDataManager.AddValues();
            //contactDataManager.ModifyDataTableUsingName("eswar", "LastName");
            //contactDataManager.DeleteRecordUsingName("abc");
            //contactDataManager.RetrieveData("nellore","telengana");
            //contactDataManager.Display();
            //contactDataManager.CountBasedOnCityorState();
            contactDataManager.Sort("andhra");
        }
    }
}
