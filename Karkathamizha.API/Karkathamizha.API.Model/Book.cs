using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.Model
{
    public class Book
    {
        public int BookId { get; set; }

        [DisplayName("Book Name")]
        [Required(ErrorMessage = "Please enter Book Name")]
        [StringLength(100, ErrorMessage = "Can not insert more than 100 characters.")]
        public string BookName { get; set; } = string.Empty!;   //Tamil

        [StringLength(60, ErrorMessage = "Can not insert more than 60 characters.")]
        public string Name { get; set; } = string.Empty;        //English

        [StringLength(60, ErrorMessage = "Can not insert more than 60 characters.")]
        [Required(ErrorMessage = "Please enter Book Name")]
        public string Tanglish { get; set; } = string.Empty;

        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        public string Status { get; set; } = string.Empty!;

        public List<int>? AuthorId { get; set; }
        [Display(Name = "Translator Name")]
        public List<int>? TranslatorId { get; set; }
        
        [Display(Name = "Text Writer Name")]
        public List<int>? TextWriterId { get; set; }
        [Display(Name = "Collect Name")]
        public List<int>? CollectorId { get; set; }
        [Display(Name = "Editor Name")]
        public List<int>? EditorId { get; set; }
        public List<Int16>? SubCategoryId { get; set; }

        public BookAuthor? BookAuthor { get; set; }
    }

    public class BookAuthor
    {
        public int AuthordId { get; set; }
        public string? AuthorName { get; set; }
        public Byte UserTypeId { get; set; }
    }
}
