using Karkathamizha.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.IService
{
    public interface IBookService
    {
        Task<int> AddUpdateBook(Book model);
        Task<string> DeleteBook(int id);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<IEnumerable<Book>> GetAllBooksWithAuthor();
    }
}
