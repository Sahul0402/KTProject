using Karkathamizha.API.IService;
using Karkathamizha.API.Model;

namespace Karkathamizha.API.Controllers
{
    public class BooksReviewController
    {
        private readonly IBooksReviewService _booksReviewService;

        public BooksReviewController(IBooksReviewService booksReviewService)
        {
            _booksReviewService = booksReviewService;
        }
        public List<BooksReview> GetAllBooksReview(Int16 userTypeId)
        {
            return _booksReviewService.GetAllBooksReview(userTypeId);
        }
    }
}
