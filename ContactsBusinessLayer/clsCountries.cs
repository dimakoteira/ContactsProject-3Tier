using ContactsDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBusinessLayer
{
   public class clsCountries
    {
        private enum enMode { add, update };
        private static enMode mode = enMode.add;
        public int CountryID { get; set; } = -1;
        public string CountryName { get; set; } = string.Empty;
        public string Code { get; set; }= string.Empty;

        public string   PhoneCode { get; set; } = string.Empty;


        private clsCountries(clsCountryDTO dto)
        {
            this.CountryID = dto.CountryID;
            this.CountryName = dto.CountryName;
            this.Code = dto.Code;
            this.PhoneCode = dto.PhoneCode;
            mode = enMode.update;
        }
        public clsCountries() { }
        public static clsCountries GetCountry(int Id)
        {
            clsCountryDTO dto = clsCountryData.FindCountryByID(Id);
            if (dto != null)
                return new clsCountries(dto);
            else
                return null;
        }

        public static clsCountries GetCountry(string name)
        {
            clsCountryDTO dto = clsCountryData.FindCountryByName(name);
            if (dto != null)
                return new clsCountries(dto);
            else
                return null;
        }

        private bool _AddCountry()
        {
            clsCountryDTO dto = new clsCountryDTO
            {
                CountryName = this.CountryName,
                Code = this.Code,
                PhoneCode = this.PhoneCode,
            };
            this.CountryID = clsCountryData.AddCountry(dto);
            return this.CountryID != -1;
        }

        //update
        private bool _UpdateCountry()
        {
            clsCountryDTO dto = new clsCountryDTO
            {
                CountryID = this.CountryID,
                CountryName = this.CountryName,
                Code = this.Code,
                PhoneCode = this.PhoneCode,
            };
            return clsCountryData.UpdateCountry(dto);
        }
        public bool save()
        {
            switch (mode)
            {
                case enMode.add:
                    {
                        if (_AddCountry())
                        {
                            mode = enMode.update;
                            return true;
                        }
                        else return false;
                    }

                case enMode.update:
                    return _UpdateCountry();

            }
            return false;
        }

        //delete
        public static bool deleteCountry(int id)
        {
            if(clsCountryData.isCountryLinkedToContact(id))
                return false;
            return clsCountryData.DeleteCountry(id);
        }

        //exist by id
        public static bool isCountryExist(int id)
        {
            mode = enMode.update;

            return clsCountryData.isExist(id);
        }

       // exist by name
        public static bool isCountryExist(string name)
        {
            mode = enMode.update;
            return clsCountryData.isExist(name);
        }

        public static DataTable GetCountries()
        {
            DataTable dt = clsCountryData.ListCountries();
            if (dt.Rows.Count > 0)
                return dt;
            else return null;
        }
    }
}
