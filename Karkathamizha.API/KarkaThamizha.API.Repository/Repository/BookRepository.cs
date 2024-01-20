using Karkathamizha.API.IRepository;
using Karkathamizha.API.Model;
using KarkaThamizha.API.Repository.Common;
using KarkaThamizha.API.Repository.SQLObject;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using static Karkathamizha.API.Model.Master;

namespace KarkaThamizha.API.Repository.Repository
{
    public class BookRepository: IBookRepository
    {
        private readonly ConnectionManager _connection;
        public BookRepository(IOptions<ConnectionManager> connection) 
        { _connection = connection.Value; }

        #region Add / Update Books
        public async Task<int> AddUpdateBook(Book model, DataTable dtAuthor, DataTable dtCategory)
        {
            int Result = 0;
            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlObjects.AddBook, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", model.BookId == 0 ? 0 : model.BookId);
                    cmd.Parameters.AddWithValue("@Book", model.BookName.Trim());
                    cmd.Parameters.AddWithValue("@Name", model.Name == null ? string.Empty : model.Name.Trim());
                    cmd.Parameters.AddWithValue("@Tanglish", model.Tanglish == null ? "" : model.Tanglish.Trim());
                    cmd.Parameters.AddWithValue("@BookDescription", model.Description == null ? "" : model.Description.Trim());
                    cmd.Parameters.AddWithValue("@AdminID", 1);
                    cmd.Parameters.Add("@BookStatus", SqlDbType.Char, 1).Value = Convert.ToString(model.Status);

                    var authorParam = cmd.Parameters.AddWithValue("@Authors", dtAuthor);
                    authorParam.SqlDbType = SqlDbType.Structured;

                    var categoryParam = cmd.Parameters.AddWithValue("@Categories", dtCategory);
                    categoryParam.SqlDbType = SqlDbType.Structured;

                    cmd.Parameters.Add("@Result", SqlDbType.VarChar, 30);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                    try
                    {
                        con.Open();
                        try
                        {
                            cmd.ExecuteNonQuery();
                            Result = DataConversion.Convert2Int32(cmd.Parameters["@Result"].Value.ToString());
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    //DataSet ds = new DataSet();
                    //SqlDataAdapter da = new SqlDataAdapter();
                    //da.SelectCommand = cmd;
                    //try
                    //{
                    //    da.Fill(ds);
                    //}
                    //catch (Exception)
                    //{
                    //    throw;
                    //}

                }
            }
            return await Task.FromResult(Result);
        }
        #endregion

        #region Delete Books
        public async Task<string> DeleteBook(int id)
        {
            string result = string.Empty;
            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SqlObjects.DeleteBook, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bookId", id);
                    cmd.ExecuteNonQuery();
                    result = "Deleted";
                }
            }
            return result;
        }
        #endregion

        #region Get All Books
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlObjects.GetAllBooks, con))
                {
                    List<Book> lstBook = new List<Book>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                    {
                        while (await reader.ReadAsync())
                        {
                            lstBook.Add(new Book()
                            {
                                BookId = DataConversion.Convert2Int(reader["BookID"].ToString()),
                                BookName = Convert.ToString(reader["Book"]),
                                Name = Convert.ToString(reader["Name"]),
                                Tanglish = Convert.ToString(reader["Tanglish"]),
                                Description = Convert.ToString(reader["BookDescription"]),
                                Status = Convert.ToString(reader["RecStatus"])
                            });
                        }
                    }
                    return lstBook;
                }
            }
        }
        #endregion

        #region Get Book By Id
        public async Task<Book> GetBookById(int id)
        {
            Book book = null;

            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlObjects.GetBookById, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@bookId", SqlDbType.Int, 35).Value = id;
                    con.Open();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                    {
                        if (await reader.ReadAsync())
                        {
                            book = new Book()
                            {
                                BookId = DataConversion.Convert2Int(reader["BookID"].ToString()),
                                BookName = Convert.ToString(reader["Book"]),
                                Name = Convert.ToString(reader["Name"]),
                                Tanglish = Convert.ToString(reader["Tanglish"]),
                                Description = Convert.ToString(reader["BookDescription"]),
                                Status = Convert.ToString(reader["RecStatus"]),
                            };
                        }
                    }
                    return book;
                }
            }
        }
        #endregion

        #region Get All Book Include Author Name
        public async Task<IEnumerable<Book>> GetAllBooksWithAuthor()
        {
            List<Book> Books = new List<Book>();
            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlObjects.GetAllBooksWithAuthor, con))
                {
                    List<Book> lstBooks = new List<Book>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            lstBooks.Add(new Book()
                            {
                                BookId = DataConversion.Convert2Int32(reader["BookID"].ToString()),
                                BookName = Convert.ToString(reader["BookName"]),
                                Name = Convert.ToString(reader["Name"]),
                                Tanglish = Convert.ToString(reader["Tanglish"]),
                                BookAuthor = new BookAuthor()
                                {
                                    AuthordId = DataConversion.Convert2Int32(Convert.ToString(reader["AuthorId"])),
                                    AuthorName = Convert.ToString(reader["Author"] == null ? "" : reader["Author"]),
                                },
                            });
                        }
                    }
                    return lstBooks;
                }
            }
        }
        #endregion

        #region Get AuthorId By BookId
        public async Task<IEnumerable<BookAuthor>> GetAuthorIdByBookId(int bookId)  //GetSelectedAuthor() previous App
        {
            List<BookAuthor> Books = new List<BookAuthor>();
            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlObjects.GetAuthorIdByBookId, con))
                {
                    List<BookAuthor> lstBooks = new List<BookAuthor>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            lstBooks.Add(new BookAuthor()
                            {
                                AuthordId = DataConversion.Convert2Int32(Convert.ToString(reader["AuthorId"])),
                                AuthorName = Convert.ToString(reader["Author"] == null ? "" : reader["Author"]),
                            });
                        }
                    }
                    return lstBooks;
                }
            }
        }
        #endregion
    }
}
