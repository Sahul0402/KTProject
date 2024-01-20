using Karkathamizha.API.IRepository;
using Karkathamizha.API.IService;
using Karkathamizha.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.Service.Service
{
    public class BooksReviewService : IBooksReviewService
    {
        private readonly IBooksReviewRepository _bookReviewRepository;
        public BooksReviewService(IBooksReviewRepository bookReviewRepository)
        {
            this._bookReviewRepository = bookReviewRepository;
        }
        public List<BooksReview> GetAllBooksReview(Int16 userTypeId)
        {
            return _bookReviewRepository.GetAllBooksReview(userTypeId);
        }
    }
}
