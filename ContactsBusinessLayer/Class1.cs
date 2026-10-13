using ContactsDataLayer;
using System.Data;
namespace ContactsBusinessLayer
{
    public class clsContact
    {
        private enum enMode { add,update};
       private  enMode mode= enMode.add;
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
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

        //update
        private bool _UpdateContact(clsContact contact)
        {
            clsContactDTO dto = new clsContactDTO
            {
                ContactID= contact.ContactID,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Phone = contact.Phone,
                Address = contact.Address,
                DateOfBirth = contact.DateOfBirth,
                CountryID = contact.CountryID,
                ImagePath = contact.ImagePath
            };
            return clsContactData.UpdateContact(dto);
        }
        public bool save()
        {
            switch (mode)
            {
                case enMode.add:
                    { 
                    if (_AddContact(this))
                    {
                        mode = enMode.update;
                        return true;
                    }
                    else return false;
                    }

                case enMode.update:
                    return _UpdateContact(this);
                       
            }
            return false;
        }

        public static bool deleteContact(int id)
        {
            return clsContactData.DeleteContact(id);
        }

        public static DataTable GetContacts()
        {
            DataTable dt = clsContactData.ListContacts();
            if (dt.Rows.Count > 0)
                return dt;
            else return null;
        }

        public static bool isContactExist(int id)
        {
            return clsContactData.isExist(id);
        }
    }
   
}
