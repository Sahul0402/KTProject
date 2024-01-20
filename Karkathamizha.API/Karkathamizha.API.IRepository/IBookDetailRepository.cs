using Karkathamizha.API.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.IRepository
{
    public interface IBookDetailRepository
    {
        Task<int> AddUpdateBook(Book model, DataTable dtAuthor, DataTable dtCategory);
        Task<string> DeleteBook(int id);
        Task<IEnumerable<BookDetail>> GetAll();
        Task<Book> GetBookById(int id);
    }
}
