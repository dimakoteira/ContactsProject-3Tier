using ContactsBusinessLayer;
void testFindContact(int id)
{
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
    }
    else
    {
        Console.WriteLine("Contact not found.");
    }
}

testFindContact(20);
