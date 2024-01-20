using Karkathamizha.API.IRepository;
using Karkathamizha.API.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaThamizha.API.Repository.Repository
{
    public class BookDetailRepository : IBookDetailRepository
    {
        public Task<int> AddUpdateBook(Book model, DataTable dtAuthor, DataTable dtCategory)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
