using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Karkathamizha.API.Model
{
    public class Publisher
    {
        public Int16 PublisherId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string PublisherName { get; set; } = string.Empty!;
        public string Name { get; set; } = string.Empty;
        [DisplayName("Owner Name")]
        public string ContactName { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string MailID { get; set; } = string.Empty;        
        public IFormFile PubLogo { get; set; } 
        public bool ShowInMenu { get; set; }
        public PublisherDetail PubDetail { get; set; }
    }
}
