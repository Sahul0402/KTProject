
namespace Karkathamizha.API.Model
{
    public class BooksReview
    {
        public int BooksReviewId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; } = string.Empty;
        public string Header { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public Int16 MagazineId { get; set; }
        public string MagazineName { get; set; } = string.Empty;
        //public SelectList LstMagazine { get; set; }        
        public DateTime SourceDate { get; set; }
        public Int16 ParentId { get; set; }
        public Int16 BookCategoryId { get; set; }
        public string BookCategoryIds { get; set; } = string.Empty;
        public string BookCategory { get; set; } = string.Empty;
        public Byte UserType { get; set; }
        public User UserInfo { get; set; } 
        public UserDetails UserDetail { get; set; }
        public BookDetail BookDetail { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public Category Category { get; set; }
        //public PreviousAndNext PreviousNext { get; set; }
    }
}
