using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ContactsDataLayer
{
    public class clsContactDTO
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
    }
    public class clsContactData
    {

        private static object isNull(object value)
        {
            return string.IsNullOrWhiteSpace(value?.ToString()) ? DBNull.Value : (object)value;
        }

        //find contact by id
        public static clsContactDTO FindContact(int Id)
        {
            clsContactDTO contact = null;
            string query = "SELECT * FROM Contacts WHERE ContactID = @ContactID";
            using (SqlConnection connection = new SqlConnection(clsDataSetting.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ContactID", Id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        contact = new clsContactDTO();
                        contact.ContactID = (int)reader["ContactID"];
                        contact.FirstName = (string)reader["FirstName"];
                        contact.LastName = (string)reader["LastName"];
                        contact.Address = (string)reader["Address"];
                        contact.Email = (string)reader["Email"];
                        contact.Phone =(string) reader["Phone"];
                        contact.DateOfBirth =(DateTime) reader["DateOfBirth"];
                        contact.CountryID =(int) reader["CountryID"];
                        contact.ImagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"].ToString() : "";
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return contact;
        }

        //add contact
     public static int AddContact(clsContactDTO contact)
        {
            int newID = -1;
            string query="insert into Contacts (FirstName, LastName, Email, Phone, Address, DateOfBirth, CountryID, ImagePath) values (@FirstName, @LastName, @Email, @Phone, @Address, @DateOfBirth, @CountryID, @ImagePath); SELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(clsDataSetting.connectionString))
                using(SqlCommand cmd=new SqlCommand(query,connection))
            {
                cmd.Parameters.AddWithValue("@FirstName",contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName",contact.LastName);
                cmd.Parameters.AddWithValue("@Email",contact.Email);
                cmd.Parameters.AddWithValue("@Phone",contact.Phone);
                cmd.Parameters.AddWithValue("@Address",contact.Address);
                cmd.Parameters.AddWithValue("@DateOfBirth",contact.DateOfBirth);
                cmd.Parameters.AddWithValue("@CountryID",contact.CountryID);
                cmd.Parameters.AddWithValue("@ImagePath",isNull(contact.ImagePath));
                try
                {
                    connection.Open();
                    object res = cmd.ExecuteScalar();
                    if(res!=null&&int .TryParse(res.ToString(),out int id))
                    {
                        newID = id;
                        contact.ContactID = newID;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

            }
            return newID;
        }

      
    }
}
