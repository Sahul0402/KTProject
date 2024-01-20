using Karkathamizha.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.IRepository
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllArticle();
        string AddArticle(Article newArticle);
    }
}
