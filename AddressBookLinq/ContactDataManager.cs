using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AddressBookLinq
{
    class ContactDataManager
    {
        DataTable dataTable;
        public void CreateDataTable()
        {
            dataTable = new DataTable();
            
            DataColumn dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "FirstName";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "LastName";
            dtColumn.Caption = "Last Name";
            dtColumn.AutoIncrement = false;

            dataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Address";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "City";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "State";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Email";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int64);
            dtColumn.ColumnName = "PhoneNumber";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int64);
            dtColumn.ColumnName = "Zip";
            dtColumn.Caption = "Zip";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int64);
            dtColumn.ColumnName = "ContactId";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "ContactType";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

        }
        public int AddValues()
        {
            CreateDataTable();
            ContactData DataManager = new ContactData();
            ContactData DataManager1 = new ContactData();

            DataManager.firstName = "Girish";
            DataManager.lastName = "Guptha";
            DataManager.phoneNumber = 7660094458;
            DataManager.emailId = "girish@gimail.com";
            DataManager.address = "bazar Street";
            DataManager.city = "nellore";
            DataManager.state = "andhra";
            DataManager.zipCode = 524406;
            DataManager.contactType = "Profession";
            InsertintoDataTable(DataManager);

            DataManager1.firstName = "eswar";
            DataManager1.lastName = "yashas";
            DataManager1.phoneNumber = 9440855581;
            DataManager1.emailId = "eswar@gmail.com";
            DataManager1.address = "nizampet";
            DataManager1.city = "hyderabad";
            DataManager1.state = "telengana";
            DataManager1.zipCode = 531678;
            DataManager1.contactType = "Family";
            InsertintoDataTable(DataManager1);

            DataManager1.firstName = "abc";
            DataManager1.lastName = "xyz";
            DataManager1.phoneNumber = 8975214458;
            DataManager1.emailId = "abc@gmail.com";
            DataManager1.address = "abc xyz";
            DataManager1.city = "cde";
            DataManager1.state = "wwe";
            DataManager1.zipCode = 543212;
            DataManager1.contactType = "Friend";
            InsertintoDataTable(DataManager1);
            return dataTable.Rows.Count;
        }
       
        public void InsertintoDataTable(ContactData contactDataManager)
        {
            DataRow dtRow = dataTable.NewRow();
            dtRow["FirstName"] = contactDataManager.firstName;
            dtRow["LastName"] = contactDataManager.lastName;
            dtRow["Address"] = contactDataManager.address;
            dtRow["City"] = contactDataManager.city;
            dtRow["State"] = contactDataManager.state;
            dtRow["Zip"] = contactDataManager.zipCode;
            dtRow["PhoneNumber"] = contactDataManager.phoneNumber;
            dtRow["Email"] = contactDataManager.emailId;
            dtRow["ContactType"] = contactDataManager.contactType;
            dataTable.Rows.Add(dtRow);

        }
        
        public bool ModifyDataTableUsingName(string FirstName, string ColumnName)
        {
            AddValues();
            var modifiedList = (from Contact in dataTable.AsEnumerable() where Contact.Field<string>("FirstName") == FirstName select Contact).LastOrDefault();
            if (modifiedList != null)
            {
                modifiedList[ColumnName] = "padarthi";
                Display();
                return true;
            }
            return false;
        }
        public bool DeleteRecordUsingName(string FirstName)
        {
            AddValues();
            var modifiedList = (from Contact in dataTable.AsEnumerable() where Contact.Field<string>("FirstName") == FirstName select Contact).FirstOrDefault();
            if (modifiedList != null)
            {
                modifiedList.Delete();
                Console.WriteLine("*After Deletion");
                Display();
                return true;
            }
            return false;
        }
        public string RetrieveData(string CityName, string StateName)
        {
            AddValues();
            string nameList = null;
            var modifiedList = (from Contact in dataTable.AsEnumerable() where (Contact.Field<string>("State") == StateName || Contact.Field<string>("City") == CityName) select Contact);
            foreach (var dtRows in modifiedList)
            {
                if (dtRows != null)
                {
                    Console.WriteLine("{0} | {1} | {2} |  {3} | {4} | {5} | {6} | {7} \n", dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);
                    nameList += dtRows["FirstName"] + " ";
                }
                else
                {
                    nameList = null;
                }
            }
            return nameList;
        }
        public string CountBasedOnCityorState()
        {
            AddValues();
            string result = "";
            var modifiedList = (from Contact in dataTable.AsEnumerable().GroupBy(r => new { City = r["City"], StateName = r["State"] }) select Contact);
            Console.WriteLine("After Count of City And State");
            foreach (var i in modifiedList)
            {
                result += i.Count() + " ";
                Console.WriteLine("Count Key" + i.Key);
                foreach (var dtRows in i)
                {
                    if (dtRows != null)
                    {
                        Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7} \n", dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);
                    }
                    else
                    {
                        result = null;
                    }
                }
            }
            Console.WriteLine(result);
            return result;
        }
        public string Sort(string CityName)
        {
            AddValues();
            string result = null;
            var modifiedRecord = (from Contact in dataTable.AsEnumerable() orderby Contact.Field<string>("FirstName") where Contact.Field<string>("City") == CityName select Contact);
            Console.WriteLine("After Sorting Their Name For a given city");
            foreach (var dtRows in modifiedRecord)
            {
                if (dtRows != null)
                {
                    Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7}\n", dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);
                    result += dtRows["FirstName"] + " ";
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }
        public string CountBasedOnContactType()
        {
            AddValues();
            string result = null;
            var modifiedList = (from Contact in dataTable.AsEnumerable().GroupBy(r => new { ContactType = r["ContactType"] }) select Contact);
            Console.WriteLine("*******Äfter Group by the count*****");
            foreach (var j in modifiedList)
            {
                result += j.Count() + " ";
                Console.WriteLine("Count Key" + j.Key);
                foreach (var dtRows in j)
                {
                    Console.WriteLine("{0} | {1} | {2} | {3} |  {4} |  {5} |  {6} | {7} | {8} | {9}\n", dtRows["ContactId"], dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"], dtRows["ContactType"]);
                }
                Console.WriteLine(result);
            }
            return result;
        }
        public void Display()
        {
            foreach (DataRow dtRows in dataTable.Rows)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7}\n", dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);
            }
        }
    }
}
