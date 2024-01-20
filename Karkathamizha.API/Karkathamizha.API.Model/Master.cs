using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.Model
{
    public class Master
    {
        public class Profession
        {
            public Byte ProfessionId { get; set; }
            [Required(ErrorMessage = "Profession is required")]
            public string Name { get; set; } = string.Empty!;
            //public SelectList lstProfession { get; set; }
        }

        public class UserType
        {
            public Byte UserTypeId { get; set; }
            public string Name { get; set; } = string.Empty!;
            public string ShortCode { get; set; } = string.Empty;
            //public SelectList LstUserType { get; set; }
        }

        public class SpecialName
        {            
            public Byte? SpecialNameId { get; set; }
            public string Name { get; set; } = string.Empty!;
            //public SelectList lstSpecialName { get; set; }
        }

        public class Country
        {
            public Byte? CountryId { get; set; }
            public string Name { get; set; } = string.Empty!;
        }

        public class State
        {
            public Byte? StateId { get; set; }
            public Byte? CountryId { get; set; }
            public string Name { get; set; } = string.Empty!;
        }

        public class City   
        {
            public Byte? CityId { get; set; }
            public int? StateId { get; set; }
            public string Name { get; set; } = string.Empty!;
        }
    }
}
