using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Karkathamizha.API.Model
{
    public class Article
    {
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string Header { get; set; } = string.Empty!;        
        public string Description { get; set; } = string.Empty;
        public string ImgPath { get; set; } = string.Empty!;
        public Nullable<DateTime> SourceDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; } 
        //public Master.SeriesType SeriesType { get; set; }
        //public WeekDays WeekDays { get; set; }
        [Display(Name = "Interview By")]
        public Int32? InterviewBy { get; set; }
        [Display(Name = "Admin User")]
        public Int32? BookDetailsID { get; set; }
        [Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }
        //public SelectList SelectLstArticle { get; set; }
        //public ArticleType ArticleType { get; set; }
        public User Author { get; set; } = null;
        //public UserDetails UserDetail { get; set; }
        //public Magazine MagazineName { get; set; }
        //public List<Books> LstBooks { get; set; }
        //public List<Article> LstArticle { get; set; }
        //public List<Series> LstAuthorSeries { get; set; }
    }
}
