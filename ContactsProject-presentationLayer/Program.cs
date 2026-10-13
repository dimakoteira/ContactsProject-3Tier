using ContactsBusinessLayer;

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
        Console.WriteLine($"Contact ID: {contact.ContactID}");
        Console.WriteLine($"First Name: {contact.FirstName}");
        Console.WriteLine($"Last Name: {contact.LastName}");
        Console.WriteLine($"Email: {contact.Email}");
        Console.WriteLine($"Phone: {contact.Phone}");
        Console.WriteLine($"Address: {contact.Address}");
        Console.WriteLine($"Date of Birth: {contact.DateOfBirth.ToShortDateString()}");
        Console.WriteLine($"Country ID: {contact.CountryID}");
        Console.WriteLine($"Image Path: {contact.ImagePath}");
    }
    else
    {
        Console.WriteLine("Contact not found.");
    }
}

//get contact info for adding/updating
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

void testAddContact()
{
    clsContact newContact = getInfo();
    if (newContact.save(newContact))
    {
        Console.WriteLine("Contact added successfully with ID: " + newContact.ContactID);
    }
    else
    {
        Console.WriteLine("Failed to add contact.");
    }


}

testFindContact();
//testAddContact();
