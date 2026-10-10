using Microsoft.Data.SqlClient;

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
                        contact.ContactID = reader["ContactID"] != DBNull.Value ? (int)reader["ContactID"] : -1;
                        contact.FirstName = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() : "";
                        contact.LastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : "";
                        contact.Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : "";
                        contact.Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "";
                        contact.Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : "";
                        contact.DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? (DateTime)reader["DateOfBirth"] : DateTime.Now;
                        contact.CountryID = reader["CountryID"] != DBNull.Value ? (int)reader["CountryID"] : -1;
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




    }
}
