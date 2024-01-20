using Karkathamizha.API.Model;
using KarkaThamizha.API.Repository.Common;
using KarkaThamizha.API.Repository.SQLObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Karkathamizha.API.Model.Master;

namespace KarkaThamizha.API.Repository.Repository
{ 
    public class MasterRepository
    {
        public List<Master.Country> GetAllCountries()
        {
            List<Master.Country> lstCountry = new List<Master.Country>()
            {
                new Country{CountryId =1, Name="India" },
                new Country{CountryId =1, Name="United States" },
                new Country{CountryId =1, Name="England" },
                new Country{CountryId =1, Name="Canada" },
                new Country{CountryId =1, Name="Saudi Arabic" },
            };

            return lstCountry;
        }

        #region StateByCountryID
        public List<Master.State> GetStatesByCountryID(int countryID)
        {
            List<Master.State> lstState = new List<Master.State>() 
            { 
                new State(){StateId= 1, Name="TamilNadu",CountryId=1},
                new State(){StateId= 2, Name="Podichery",CountryId= 1},
                new State(){StateId= 3, Name="California",CountryId= 2},
                new State(){StateId= 4, Name="Texas",CountryId= 2},
                //new State(){StateId= 5, Name="",CountryId= },
                //new State(){StateId= 6, Name="",CountryId= },
                //new State(){StateId= 7, Name="",CountryId= },
                //new State(){StateId= 8, Name="",CountryId= },
                //new State(){StateId= 9, Name="",CountryId= },
                //new State(){StateId= 10, Name="",CountryId= },
                //new State(){StateId= 11, Name="",CountryId= },
            };
            return lstState;
        }
        #endregion

        #region GetCityByStateID
        public List<Master.City> GetCityByStateID(int countryID)
        {
            List<Master.City> lstCity = new List<Master.City>()
            {
                new City(){ CityId =1 , Name="Chennai",StateId=1 },
                new City(){ CityId =2 , Name="Madurai",StateId=1 },
                new City(){ CityId =3 , Name="Nellai",StateId=1 },
                new City(){ CityId =4 , Name="Los Angeles",StateId=3 },
                new City(){ CityId =5 , Name="Sacramento",StateId=3 },
                new City(){ CityId =6 , Name="Houston",StateId=4 },
                new City(){ CityId =6 , Name="Galveston",StateId=4 },
            };
            return lstCity;
        }
        #endregion

        #region Special Name
        public List<Master.SpecialName> GetAllSpecialName()
        {
            
            List<SpecialName> lstSpName = new List<SpecialName>()
            {
                new SpecialName(){ SpecialNameId = 1, Name="பேராசிரியர்"},
                new SpecialName(){ SpecialNameId = 2, Name="ஆய்வறிஞர்"},
                new SpecialName(){ SpecialNameId = 3, Name="உவமைக் கவிஞர்"},
                new SpecialName(){ SpecialNameId = 4, Name="கவிஞர்"},
                new SpecialName(){ SpecialNameId = 5, Name="கவிமணி"},
                new SpecialName(){ SpecialNameId = 6, Name="சிலம்புச் செல்வர்"},
                new SpecialName(){ SpecialNameId = 7, Name="டாக்டர்"},
            };
            return lstSpName;
        }
        #endregion
              
        public List<Master.Profession> GetAllProfession()
        {
            List<Master.Profession> lstSpName = new List<Master.Profession>();
            lstSpName = GetAllProfessions();
            return lstSpName;
        }

        private List<Master.Profession> GetAllProfessions()
        {
            List<Profession> lstSpName = new List<Profession>()
            {
                new Profession(){ ProfessionId = 1, Name="ஆசிரியர் / பேராசிரியர்"},
                new Profession(){ ProfessionId = 2, Name="உரையாசிரியர்"},
                new Profession(){ ProfessionId = 3, Name="எழுத்தாளர் / கவிஞர்"},
                new Profession(){ ProfessionId = 4, Name="தமிழறிஞர்"},
                new Profession(){ ProfessionId = 5, Name="நூலகர்"},
                new Profession(){ ProfessionId = 6, Name="பதிப்பகத்தார்"},
            };
            return lstSpName;
        }

        private List<Master.UserType> GetAllUserTypes()
        {
            List<Master.UserType> lstUserType = new List<Master.UserType>()
            {
                new Master.UserType(){ UserTypeId = 1, Name="ஆசிரியர்"},
                new Master.UserType(){ UserTypeId = 2, Name="உரையாசிரியர்"},
                new Master.UserType(){ UserTypeId = 3, Name="தொகுப்பாசிரியர்"},
                new Master.UserType(){ UserTypeId = 4, Name="பதிப்பகத்தார்"},
                new Master.UserType(){ UserTypeId = 5, Name="பதிப்பாசிரியர்"},
                new Master.UserType(){ UserTypeId = 6, Name="பயனர்"},
                new Master.UserType(){ UserTypeId = 7, Name="மொழிபெயர்ப்பாளர்"},
            };
            return lstUserType;
        }

        
    }
}
