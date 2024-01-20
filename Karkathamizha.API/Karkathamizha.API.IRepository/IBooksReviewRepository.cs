using Karkathamizha.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.IRepository
{
    public interface IBooksReviewRepository
    {
        List<BooksReview> GetAllBooksReview(Int16 userTypeId);
    }
}
