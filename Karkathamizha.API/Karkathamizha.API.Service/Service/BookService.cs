using Karkathamizha.API.IRepository;
using Karkathamizha.API.IService;
using Karkathamizha.API.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.Service.Service
{
    public class BookService: IBookService
    {
        private readonly IBookRepository _bookRepository; 
        public BookService(IBookRepository bookRepository) 
        {
            this._bookRepository = bookRepository;
        }    

        public async Task<int> AddUpdateBook(Book model)
        {
            List<int> author = model.AuthorId.Where(x => x > 0).ToList();
            author.AddRange(model.TranslatorId.Where(x => x > 0).ToList());
            author.AddRange(model.TextWriterId.Where(x => x > 0).ToList());
            author.AddRange(model.CollectorId.Where(x => x > 0).ToList());
            author.AddRange(model.EditorId.Where(x => x > 0).ToList());
            model.AuthorId = author.Where(x => x > 0).ToList();
            var dtAuthor = ConvertListToDataTable(model,"Author");
            var dtCategory = ConvertListToDataTable(model, "Category");

            return await _bookRepository.AddUpdateBook(model, dtAuthor,dtCategory);
        }

        private DataTable ConvertListToDataTable(Book model,string type)
        {
            DataTable dt = new DataTable();
            DataRow row;

            if (type == "Author")
            {
                dt.Columns.Add("AuthorId", typeof(int));
                dt.Columns.Add("BookId", typeof(int));
            }
            else if (type == "Category")
            {
                dt.Columns.Add("BookId", typeof(int));
                dt.Columns.Add("CategoryId", typeof(int));
            }

            row = dt.NewRow();
            if (type == "Author")
            {
                foreach (var id in model.AuthorId)
                {
                    row = dt.NewRow();
                    row["BookId"] = model.BookId;
                    row["AuthorId"] = id;

                    dt.Rows.Add(row);
                }
            }
            else if (type == "Category")
            {
                foreach (var id in model.SubCategoryId)
                {
                    row = dt.NewRow();
                    row["BookId"] = model.BookId;
                    row["CategoryId"] = id;
                    
                    dt.Rows.Add(row);
                }
            }
            
            return dt;
        }

        public Task<string> DeleteBook(int id)
        {
            return _bookRepository.DeleteBook(id);
        }

        public Task<IEnumerable<Book>> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public Task<Book> GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public Task<IEnumerable<Book>> GetAllBooksWithAuthor()
        {
            return _bookRepository.GetAllBooksWithAuthor();
        }
    }
}
