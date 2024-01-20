using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.Model
{
    public class BookDetail
    {
        public int BookDetailId { get; set; }
        public Book Books { get; set; }
        public List<Book> BookList { get; set; }
        public string BookCode { get; set; } = string.Empty;
        [Required]
        public Decimal Price { get; set; }
        [Required]
        public int Pages { get; set; }
        public Int16 PublisherID { get; set; }
        public Publisher PublisherName { get; set; }
        //public SelectList PublisherList { get; set; }
        [Required]
        [DefaultValue(1)]
        public Byte NoofCopy { get; set; }
        [DisplayName("Book Format")]
        public Int16 BookFormatID { get; set; }
        public string CoverDesign { get; set; } = string.Empty; //அட்டை ஓவியம்
        public string CoverFormat { get; set; } = string.Empty;  //அட்டை வடிவமைப்பு

        [DisplayName("Small Image- FS")]
        public string ImgBookSmallFS { get; set; } = string.Empty;

        [DisplayName("Small Image- BS")]
        public string ImgBookSmallBS { get; set; } = string.Empty;

        [DisplayName("Large Image")]
        public string ImgBookLarge { get; set; } = string.Empty;

        public string ISBN13 { get; set; } = string.Empty;
        public string FirstEdition { get; set; } = string.Empty;
        public string CurrentEdition { get; set; } = string.Empty;
        public string Dimensions { get; set; } = string.Empty;
        public User Users { get; set; }
        public bool IsKarkaBook { get; set; }
        public BookFormat BookFormat { get; set; }
        public Category Category { get; set; }
        public BooksReview BooksReview { get; set; }
        public int BooksReviewID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public Int16 CategoryID { get; set; }
        public List<BookDetail> AuthorBooks { get; set; }
        public List<Feedback> Feedback { get; set; }
        public Byte UserTypeID { get; set; }
        public XtraBookDetails XtraBookDetails { get; set; }
        //public BooksImages BooksImages { get; set; }
    }
}
