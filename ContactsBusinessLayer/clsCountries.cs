using ContactsDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBusinessLayer
{
   public class clsCountries
    {
        public int CountryID { get; set; } = -1;
        public string CountryName { get; set; } = string.Empty;

        private clsCountries(clsCountryDTO dto)
        {
            this.CountryID = dto.CountryID;
            this.CountryName = dto.CountryName;
        }
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
    }
}
