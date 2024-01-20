using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.Model
{
    public class Register
    {
        public int UserId { get; set; }
        public string Initial { get; set; } = string.Empty!;

        [DataType(DataType.Text)]
        [StringLength(35, ErrorMessage = "Name can't be longer than 60 characters")]
        [MaxLength(35), MinLength(3)]
        [Required(ErrorMessage = "Name is required")]       //In English
        public string Name { get; set; } = string.Empty!;

        [StringLength(35, ErrorMessage = "Email can't be longer than 30 characters")]
        public string Email { get; set; } = string.Empty!;

        [DataType(DataType.Password)]
        [MaxLength(60), MinLength(8)]
        [Required(ErrorMessage = "Please enter Password.")]
        public string Password { get; set; } = string.Empty!;
        [MaxLength(20), MinLength(10)]
        public string Mobile { get; set; } = string.Empty!;
        public Byte UserTypeId { get; set; } 
        public Byte? ProfessionId { get; set; } = null;
        public Byte? SpecialNameId { get; set; } = null;
    }
}
