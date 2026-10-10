using ContactsDataLayer;
namespace ContactsBusinessLayer
{
    public class clsContact
    {
        public int ContactID { get; set; } = -1;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public int CountryID { get; set; } = -1;
        public string ImagePath { get; set; } = "";

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


    }
   
}
