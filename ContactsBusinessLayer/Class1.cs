using ContactsDataLayer;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
namespace ContactsBusinessLayer
{
    public class clsContact
    {
        private enum enMode { add,update};
       private  enMode mode= enMode.add;
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set} 
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public int CountryID { get; set; } 
        public string ImagePath { get; set; } 

        public clsContact() {
            ContactID = -1;
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Address = "";
            DateOfBirth = DateTime.Now;
            CountryID = -1;
            ImagePath = "";
           mode= enMode.add;
        }
        private clsContact(clsContactDTO dto)
        {
            this.ContactID = dto.ContactID;
            this.FirstName = dto.FirstName;
            this.LastName = dto.LastName;
            this.Email = dto.Email;
            this.Phone = dto.Phone;
            this.Address = dto.Address;
            this.DateOfBirth = dto.DateOfBirth;
            this.CountryID = dto.CountryID;
            this.ImagePath = dto.ImagePath;
            mode = enMode.update;
        }

        //find contact by id and return a clsContact object
        public static clsContact GetContact(int Id)
            {
                clsContactDTO dto = clsContactData.FindContact(Id);
                if (dto != null)
                    return new clsContact(dto);
                else
                    return null;
            }

        //add contact to database 
        private bool _AddContact(clsContact contact)
        {
            clsContactDTO dto = new clsContactDTO
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Phone = contact.Phone,
                Address = contact.Address,
                DateOfBirth = contact.DateOfBirth,
                CountryID = contact.CountryID,
                ImagePath = contact.ImagePath
            };
            this.ContactID = clsContactData.AddContact(dto);
            return this.ContactID!=-1;
        }
        public bool save(clsContact contact)
        {
            switch(mode)
            {
                case enMode.add:
                    if (_AddContact(contact))
                    {
                        mode = enMode.update;
                        return true;
                    }
                    else return false;
            }
            return false;
        }

    }
   
}
