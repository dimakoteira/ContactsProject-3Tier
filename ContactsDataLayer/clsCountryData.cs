using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataLayer
{
   public class clsCountryDTO
    {
        public int CountryID { get; set; } = -1;
        public string CountryName { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string PhoneCode { get; set; } = string.Empty;

    }

   public class clsCountryData
    {
        private static readonly string logFile = @"D:\Desktop\abu hadhoud 18\contactSolution\ContactsProject-3Tier\ContactsDataLayer\ExceptionsLOGcountries.txt";

        private static object isNull(object value)
        {
            return string.IsNullOrWhiteSpace(value?.ToString()) ? DBNull.Value : (object)value;
        }

        //find country by id
        public static clsCountryDTO FindCountryByID(int Id)
        {
            clsCountryDTO country = null;
            string query = "SELECT * FROM Countries WHERE CountryID = @Id";
            using (SqlConnection connection = new SqlConnection(clsDataSetting.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", Id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        country = new clsCountryDTO();
                        country.CountryID = (int)reader["CountryID"];
                        country.CountryName = reader["CountryName"].ToString();
                        country.Code = reader["Code"] != DBNull.Value ? reader["Code"].ToString() : "";
                        country.PhoneCode = reader["PhoneCode"] != DBNull.Value ? reader["PhoneCode"].ToString() : "";
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    string message = $"{DateTime.Now}: {ex.Message}\n";
                    File.AppendAllText(logFile, message);
                    Console.WriteLine(" There was an Error");
                }
            }
            return country;
        }

        //find country by name
        public static clsCountryDTO FindCountryByName(string name)
        {
            clsCountryDTO country = null;
            string query = "SELECT * FROM Countries WHERE CountryName = @name";
            using (SqlConnection connection = new SqlConnection(clsDataSetting.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@name", name);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        country = new clsCountryDTO();
                        country.CountryID = (int)reader["CountryID"];
                        country.CountryName = reader["CountryName"] .ToString() ;
                        country.Code = reader["Code"] != DBNull.Value ? reader["Code"].ToString() : "";
                        country.PhoneCode = reader["PhoneCode"] != DBNull.Value ? reader["PhoneCode"].ToString() : "";
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    string message = $"{DateTime.Now}: {ex.Message}\n";
                    File.AppendAllText(logFile, message);
                    Console.WriteLine(" There was an Error");
                }
            }
            return country;
        }

        //add country
        public static int AddCountry(clsCountryDTO dto)
        {
            int newID = -1;
            string query = "insert into Countries (CountryName,Code,PhoneCode) values (@CountryName,@Code,@PhoneCode); SELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(clsDataSetting.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CountryName", dto.CountryName);
                cmd.Parameters.AddWithValue("@Code",isNull(dto.Code));
                cmd.Parameters.AddWithValue("@PhoneCode", isNull(dto.PhoneCode));
                try
                {
                    connection.Open();
                    object res = cmd.ExecuteScalar();
                    if (res != null && int.TryParse(res.ToString(), out int id))
                    {
                        newID = id;                    
                    }

                }
                catch (Exception ex)
                {
                    string message = $"{DateTime.Now}: {ex.Message}\n";
                    File.AppendAllText(logFile, message);

                    Console.WriteLine(" There was an Error"+ ex.Message);
                }

            }
            return newID;
        }

        //update
        public static bool UpdateCountry(clsCountryDTO country)
        {
            int rowAffected = 0;
            string query = "UPDATE Countries SET CountryName=@CountryName, Code=@Code, PhoneCode=@PhoneCode WHERE CountryID=@CountryID";
            using (SqlConnection connection = new SqlConnection(clsDataSetting.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CountryName", country.CountryName);
                cmd.Parameters.AddWithValue("@CountryID", country.CountryID);
                cmd.Parameters.AddWithValue("@Code", isNull(country.Code));
                cmd.Parameters.AddWithValue("@PhoneCode", isNull(country.PhoneCode));
                try
                {
                    connection.Open();
                    rowAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    string message = $"{DateTime.Now}: {ex.Message}\n";
                    File.AppendAllText(logFile, message);
                    Console.WriteLine(" There was an Error");
                }
            }
            return rowAffected > 0;
        }

        //for proper delete(fk-sonstraint) don;t delete any country that is used in contacts
        public static bool isCountryLinkedToContact(int id)
        {
            bool isLinked = false;
            string query = "SELECT FOUND = 1 FROM Contacts WHERE CountryID = @CountryID";

            using (SqlConnection connection = new SqlConnection(clsDataSetting.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CountryID", id);
                try
                {
                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        isLinked = true;
                    }
                }
                catch (Exception ex)
                {
                    string message = $"{DateTime.Now}: {ex.Message}\n";
                    File.AppendAllText(logFile, message);
                }
            }
            return isLinked;
        }
        
        //delete
        public static bool DeleteCountry(int countryID)
        {
            int rowAffected = 0;
            string query = "delete from Countries where countryID=@countryID";
            using (SqlConnection connection = new SqlConnection(clsDataSetting.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@countryID", countryID);
                try
                {
                    connection.Open();
                    rowAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    string message = $"{DateTime.Now}: {ex.Message}\n";
                    File.AppendAllText(logFile, message);
                    Console.WriteLine(" There was an Error"+ ex.Message);
                }
            }
            return rowAffected > 0;
        }


        //is country exist by id
        public static bool isExist(int CountryID)
        {
            bool isFound = false;
            string query = "select found=1 from Countries where CountryID=@CountryID";
            using (SqlConnection connection = new SqlConnection(clsDataSetting.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CountryID", CountryID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                            isFound = true;

                    }
                }
                catch (Exception ex)
                {
                    string message = $"{DateTime.Now}: {ex.Message}\n";
                    File.AppendAllText(logFile, message);
                    Console.WriteLine(" There was an Error");
                }

            }
            return isFound;
        }

        //is country exist by name
        public static bool isExist(string CountryName)
        {
            bool isFound = false;
            string query = "select found=1 from Countries where CountryName=@CountryName";
            using (SqlConnection connection = new SqlConnection(clsDataSetting.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CountryName", CountryName);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                            isFound = true;

                    }
                }
                catch (Exception ex)
                {
                    string message = $"{DateTime.Now}: {ex.Message}\n";
                    File.AppendAllText(logFile, message);
                    Console.WriteLine(" There was an Error");
                }

            }
            return isFound;
        }

        public static DataTable ListCountries()
        {
            DataTable dt = new DataTable();
            string query = "select * from Countries";
            using (SqlConnection connection = new SqlConnection(clsDataSetting.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    string message = $"{DateTime.Now}: {ex.Message}\n";
                    File.AppendAllText(logFile, message);
                    Console.WriteLine(" There was an Error");
                }
            }
            return dt;
        }

    }
}
