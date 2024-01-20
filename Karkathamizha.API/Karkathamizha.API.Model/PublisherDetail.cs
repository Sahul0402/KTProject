using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.Model
{
    public class PublisherDetail
    {
        public Int16 PublisherID { get; set; }
        public string Mobile { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string Blog { get; set; } = string.Empty;
        public string BlogType { get; set; } = string.Empty;
        public string FaceBook { get; set; } = string.Empty;
        public string Twitter { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Int16 CountryID { get; set; }
        public Int32 StateID { get; set; }
        public Int32 CityID { get; set; }
    }
}
