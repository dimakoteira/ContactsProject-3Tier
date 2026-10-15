using ContactsBusinessLayer;
using System.Data;

//print contact info
void print(clsContact contact)
{

    Console.WriteLine($"Contact ID: {contact.ContactID}");
    Console.WriteLine($"First Name: {contact.FirstName}");
    Console.WriteLine($"Last Name: {contact.LastName}");
    Console.WriteLine($"Email: {contact.Email}");
    Console.WriteLine($"Phone: {contact.Phone}");
    Console.WriteLine($"Address: {contact.Address}");
    Console.WriteLine($"Date of Birth: {(contact.DateOfBirth == DateTime.MinValue ? "N/A" : contact.DateOfBirth.ToShortDateString())}");
    Console.WriteLine($"Country ID: {contact.CountryID}");
    Console.WriteLine($"Image Path: {contact.ImagePath}");
    Console.WriteLine("-------------------------------------------------------");
}

//find contact
void testFindContact()
{
    int id;
    Console.WriteLine("Enter Contact ID: ");
    while(!int.TryParse(Console.ReadLine(), out id))
    {
        Console.WriteLine("Invalid input. Please enter a valid Contact ID:");
    }

    clsContact contact = clsContact.GetContact(id);
    if (contact != null)
    {
        print(contact);
    }
    else
    {
        Console.WriteLine("Contact not found.");
    }
}

//get contact info for adding
clsContact getInfo()
{
    clsContact newContact = new clsContact();

    Console.WriteLine("Enter First Name:");
    while(string.IsNullOrWhiteSpace(newContact.FirstName = Console.ReadLine()))
    {
        Console.WriteLine("First Name cannot be empty. Please enter again:");
    }
    Console.WriteLine("Enter Last Name:");
    while(string.IsNullOrWhiteSpace(newContact.LastName = Console.ReadLine()))
    {
        Console.WriteLine("Last Name cannot be empty. Please enter again:");
    }
    Console.WriteLine("Enter Email:");
    while(string.IsNullOrWhiteSpace(newContact.Email = Console.ReadLine()))
    {
        Console.WriteLine("Email cannot be empty. Please enter again:");
    }
    Console.WriteLine("Enter Phone:");
    while(string.IsNullOrWhiteSpace(newContact.Phone = Console.ReadLine()))
    {
        Console.WriteLine("Phone cannot be empty. Please enter again:");
    }
    Console.WriteLine("Enter Address:");
    while(string.IsNullOrWhiteSpace(newContact.Address = Console.ReadLine()))
    {
        Console.WriteLine("Address cannot be empty. Please enter again:");
    }
    Console.WriteLine("Enter Date of Birth (yyyy-MM-dd):");
    while (true)//check the right format of date
    {
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dob))
        {
            newContact.DateOfBirth = dob;
            break;
        }
        else Console.WriteLine("Invalid date format. Please enter again (yyyy-MM-dd):");
    }
    Console.WriteLine("Enter Country ID:");
    while (true)//check the right format of country id
    {
        if (int.TryParse(Console.ReadLine(), out int countryId))
        {
            newContact.CountryID = countryId;
            break;
        }
        else Console.WriteLine("Invalid number. Please enter again:");
    }
    Console.WriteLine("Enter Image Path:");
    newContact.ImagePath = Console.ReadLine();
    return newContact;

}

//get info for update
void getUpdatedInfo(clsContact newContact)
{

    Console.WriteLine("Enter First Name:");
    while (string.IsNullOrWhiteSpace(newContact.FirstName = Console.ReadLine()))
    {
        Console.WriteLine("First Name cannot be empty. Please enter again:");
    }
    Console.WriteLine("Enter Last Name:");
    while (string.IsNullOrWhiteSpace(newContact.LastName = Console.ReadLine()))
    {
        Console.WriteLine("Last Name cannot be empty. Please enter again:");
    }
    Console.WriteLine("Enter Email:");
    while (string.IsNullOrWhiteSpace(newContact.Email = Console.ReadLine()))
    {
        Console.WriteLine("Email cannot be empty. Please enter again:");
    }
    Console.WriteLine("Enter Phone:");
    while (string.IsNullOrWhiteSpace(newContact.Phone = Console.ReadLine()))
    {
        Console.WriteLine("Phone cannot be empty. Please enter again:");
    }
    Console.WriteLine("Enter Address:");
    while (string.IsNullOrWhiteSpace(newContact.Address = Console.ReadLine()))
    {
        Console.WriteLine("Address cannot be empty. Please enter again:");
    }
    Console.WriteLine("Enter Date of Birth (yyyy-MM-dd):");
    while (true)//check the right format of date
    {
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dob))
        {
            newContact.DateOfBirth = dob;
            break;
        }
        else Console.WriteLine("Invalid date format. Please enter again (yyyy-MM-dd):");
    }
    Console.WriteLine("Enter Country ID:");
    while (true)//check the right format of country id
    {
        if (int.TryParse(Console.ReadLine(), out int countryId))
        {
            newContact.CountryID = countryId;
            break;
        }
        else Console.WriteLine("Invalid number. Please enter again:");
    }
    Console.WriteLine("Enter Image Path:");
    newContact.ImagePath = Console.ReadLine();
}

//add contact
void testAddContact()
{
    clsContact newContact = getInfo();
    if (newContact.save())
    {
        Console.WriteLine("Contact added successfully with ID: " + newContact.ContactID);
    }
    else
    {
        Console.WriteLine("Failed to add contact.");
    }


}

//update contact
void testUpdateContact()
{
    clsContact contact = new clsContact();

    Console.WriteLine("enter contact id you want to update");
    while (true)//check the right format of  id
    {
        if (int.TryParse(Console.ReadLine(), out int ContactId))
        {
            contact.ContactID = ContactId;
            break;
        }
        else Console.WriteLine("Invalid number. Please enter again:");
    }
    contact = clsContact.GetContact(contact.ContactID);//check if contact is found
    if (contact != null)
    {
        print(contact);
         getUpdatedInfo(contact);//if it's found then enter the updated info
        if (contact.save())
            Console.WriteLine("contact updated succesfully");
        else { Console.WriteLine("there was an error updating this contact"); }
    }
    else Console.WriteLine("contact not found");
}

//delete contact
void testDeleteContact()
{
    int id=0;
    Console.WriteLine("enter contact id you want to delete: ");
    while (true)//check the right format of  id
    {
        if (int.TryParse(Console.ReadLine(), out int ContactId))
        {
            id = ContactId;
            break;
        }
        else Console.WriteLine("Invalid number. Please enter again:");
    }

    if (clsContact.isContactExist(id))
    {
        if (clsContact.deleteContact(id))
            Console.WriteLine("contact deleted succesfully");
        else { Console.WriteLine("there was an error deleting this contact"); }
    }
    else { Console.WriteLine("contact was not found"); }
}

//list contacts
void testListContacts()
{
    DataTable dt = clsContact.GetContacts();
    if (dt != null)
    {
        Console.WriteLine("-------------------- Contacts List ------------------------");

        // طباعة رؤوس الأعمدة مع تحديد عرض ثابت لكل عمود
        string headerFormat = "{0,-6} | {1,-12} | {2,-12} | {3,-22} | {4,-12} | {5,-15} | {6,-12} | {7,-9}";

        Console.WriteLine(string.Format(headerFormat, "ID", "FirstName", "LastName", "Email", "Phone", "Address", "DateOfBirth", "Country", "ImagePath"));
        Console.WriteLine(new string('-', 130)); 
        foreach (DataRow row in dt.Rows)
        {
            int id = (int)row["ContactID"];
            string firstName = row["FirstName"].ToString();
            string lastName = row["LastName"].ToString();
            string email = row["Email"].ToString();
            string phone = row["Phone"].ToString();
            string address = row["Address"].ToString();

            string dob = Convert.ToDateTime(row["DateOfBirth"]).ToString("yyyy-MM-dd");

            int countryID = (int)row["CountryID"];

            Console.WriteLine(string.Format(headerFormat, id, firstName, lastName, email, phone, address, dob, countryID));
        }
    }
    else Console.WriteLine("contacts not found");
}

//is contact exist
void testIsContactExist()
{
    int id;
    Console.WriteLine("Enter Contact ID: ");
    while (!int.TryParse(Console.ReadLine(), out id))
    {
        Console.WriteLine("Invalid input. Please enter a valid Contact ID:");
    }
    if (clsContact.isContactExist(id))
        Console.WriteLine("contact found");
    else Console.WriteLine("contact is not found");

}


void printCountryInfo(clsCountries country)
{
    Console.WriteLine($"Country ID: {country.CountryID}");
    Console.WriteLine($"Country Name: {country.CountryName}");
    Console.WriteLine($"Country Code: {country.Code}");
    Console.WriteLine($"Phone Code: {country.PhoneCode}");
}
//test find country by id
void testFindCountry()
{
    int id;
    Console.WriteLine("Enter Country ID: ");
    while (!int.TryParse(Console.ReadLine(), out id))
    {
        Console.WriteLine("Invalid input. Please enter a valid Country ID:");
    }
    clsCountries country = clsCountries.GetCountry(id);
    if (country != null)
    {
        Console.WriteLine($"Found");
        printCountryInfo(country);
    }
    else
    {
        Console.WriteLine("Country not found.");
    }
}

//find country by name
void testFindCountryByName()
{
    string name;
    Console.WriteLine("enter country name: ");
    while (string.IsNullOrWhiteSpace(name = Console.ReadLine()))
    {
        Console.WriteLine("Country Name cannot be empty. Please enter again:");
    }
    clsCountries country = clsCountries.GetCountry(name);
    if (country != null)
    {
        Console.WriteLine("found");
        printCountryInfo(country);

    }
    else
    {
        Console.WriteLine("Country not found.");
    }

}

void getUpdatedCountryInfo( clsCountries country)
{

    Console.WriteLine("Enter Country name:");
    while (string.IsNullOrWhiteSpace(country.CountryName = Console.ReadLine()))
    {
        Console.WriteLine("country Name cannot be empty. Please enter again:");
    }
    Console.WriteLine("Enter Code:");
    country.Code = Console.ReadLine();
    Console.WriteLine("Enter Phone Code:");
    country.PhoneCode = Console.ReadLine();
}

clsCountries getCountryInfo()
{
    clsCountries country = new clsCountries();
    Console.WriteLine("enter country name: ");
    while (string.IsNullOrWhiteSpace(country.CountryName = Console.ReadLine()))
    {
        Console.WriteLine("Country Name cannot be empty. Please enter again:");
    }
    Console.WriteLine("enter country code: ");
    country.Code = Console.ReadLine();
    Console.WriteLine("enter Phone Code: ");
    country.PhoneCode = Console.ReadLine();
    return country;

}
//add country
void testAddCountry()
{
    clsCountries country = getCountryInfo();
    if (clsCountries.isCountryExist(country.CountryName) )
    {
        Console.WriteLine("country already exist in the database");
        return;
    }
    else
    {
        if (country.save())
        {
            Console.WriteLine("country added succesfully with id: " + country.CountryID);
        }
        else
        {
            Console.WriteLine("there was an error adding this country");

        }
    }
}

//update country
void testUpdateCountry()
{
    clsCountries country = new clsCountries();
    Console.WriteLine("enter country id you want to update");
    while (true)//check the right format of  id
    {
        if (int.TryParse(Console.ReadLine(), out int CountryId))
        {
            country.CountryID = CountryId;
            break;
        }
        else Console.WriteLine("Invalid number. Please enter again:");
    }

    country = clsCountries.GetCountry(country.CountryID);
    if (country!=null)
    {
        printCountryInfo(country);
        getUpdatedCountryInfo(country);
        if (country.save())
        {
            Console.WriteLine("country updated suuccesfully");
        }
        else { Console.WriteLine("there was an error updating this country"); }
    }
    else Console.WriteLine("country was not found");
}

//delete country
void testDeleteCountry()
{
    int id = 0;
    Console.WriteLine("Enter Country ID: ");
    while (true)//check the right format of  id
    {
        if (int.TryParse(Console.ReadLine(), out int CountryId))
        {
           id = CountryId;
            break;
        }
        else Console.WriteLine("Invalid number. Please enter again:");
    }
    if (clsCountries.isCountryExist(id))
    {
        if (clsCountries.deleteCountry(id))
        { Console.WriteLine("country deleted succesfully"); }
        else { Console.WriteLine("there was an error deleting this country"); }
    }
    else Console.WriteLine("country was not found");
}

//is country exist
void testIsCountryExist()
{
    int id;
    Console.WriteLine("Enter Country ID: ");
    while (!int.TryParse(Console.ReadLine(), out id))
    {
        Console.WriteLine("Invalid input. Please enter a valid Country ID:");
    }
    if (clsCountries.isCountryExist(id))
        Console.WriteLine("country found");
    else Console.WriteLine("country not found");
}
void testIsCountryExistByName()
{
    string name;
    Console.WriteLine("enter country name: ");
    while (string.IsNullOrWhiteSpace(name = Console.ReadLine()))
    {
        Console.WriteLine("Country Name cannot be empty. Please enter again:");
    }
    if (clsCountries.isCountryExist(name))
        Console.WriteLine("country found");
    else
    {
        Console.WriteLine("country not found");
    }
}

void testListCountries()
{
    DataTable dt = clsCountries.GetCountries();
    if (dt != null)
    {
        Console.WriteLine("-------------------- Country List ------------------------");

        // طباعة رؤوس الأعمدة مع تحديد عرض ثابت لكل عمود
        string headerFormat = "{0,-6} | {1,-12} | {2,-12} | {3,-22} | ";

        Console.WriteLine(string.Format(headerFormat, "CountryID", "CountryName","Code","Phone Code"));
        Console.WriteLine(new string('-', 100));
        foreach (DataRow row in dt.Rows)
        {
            int id = (int)row["CountryID"];
            string countryName = row["CountryName"].ToString();
            string code = row["Code"].ToString();
            string phoneCode = row["PhoneCode"].ToString();
            Console.WriteLine(string.Format(headerFormat, id, countryName,code,phoneCode));
        }
    }
    else Console.WriteLine("countries not found");
}



//testFindContact();
//testAddContact();
//testUpdateContact();
//testDeleteContact();
//testListContacts();
//testIsContactExist();
// testFindCountryByName();
//testFindCountry();
//testAddCountry();
//testUpdateCountry();
testDeleteCountry();
//testIsCountryExist();
//testIsCountryExistByName();
//testListCountries();

