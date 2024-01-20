using Karkathamizha.API.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.IRepository
{
    public interface IBookRepository
    {
        Task<int> AddUpdateBook(Book model, DataTable dtAuthor, DataTable dtCategory);
        Task<string> DeleteBook(int id);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<IEnumerable<Book>> GetAllBooksWithAuthor();
    }
}
