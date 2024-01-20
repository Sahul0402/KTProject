using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Karkathamizha.API.Model
{
    public class UserDetails
    {
        public int UserDetailsId { get; set; }
        public int UserId { get; set; }
        [MaxLength(500)]
        public string Profile { get; set; } = string.Empty;
        public Byte Protocol { get; set; }
        [MaxLength(30)]
        public string Website { get; set; } = string.Empty;
        [MaxLength(20)]
        public string Blog { get; set; } = string.Empty;
        public string BlogType { get; set; } = string.Empty;
        public string FaceBook { get; set; } = string.Empty;
        [MaxLength(30)]
        public string Twitter { get; set; } = string.Empty;
        [MaxLength(25)]
        public string Pinterest { get; set; } = string.Empty;
        [MaxLength(32)]
        public string YouTube { get; set; } = string.Empty;
        [MaxLength(15)]
        public string Instagram { get; set; } = string.Empty;
        public string Wikipedia { get; set; } = string.Empty;
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> DOB { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> DOD { get; set; }
        public bool OldAuthorDOD { get; set; }
        public string ImgProfile { get; set; } = string.Empty;
        public string ImgComments { get; set; } = string.Empty;

        //File Upload Process
        //public IFormFile? ImgProfile { get; set; } = null;        
        //public IFormFile? ImgComments { get; set; } = null;
        public string Address { get; set; } = string.Empty;
        public Int16 CityId { get; set; }
        public Int16 CountryId { get; set; }
        public Int32 StateId { get; set; }
        public bool IsShownInMenu { get; set; }
        public bool IsMailSubscription { get; set; }
        [MaxLength(250)]
        public string Reference { get; set; } = string.Empty;
    }
}
