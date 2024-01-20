using Karkathamizha.API.IRepository;
using Karkathamizha.API.Model;
using KarkaThamizha.API.Repository.Common;
using KarkaThamizha.API.Repository.SQLObject;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace KarkaThamizha.API.Repository.Repository
{
    public class BooksReviewRepository : IBooksReviewRepository
    {
        private readonly ConnectionManager _connection;
        public BooksReviewRepository(IOptions<ConnectionManager> connection)
        { _connection = connection.Value; }

        public List<BooksReview> GetBooksReview()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(SqlObjects.GetBooksReview, con))
                    {
                        List<BooksReview> lstBooksReview = new List<BooksReview>();
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@userTypeID", userTypeID);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (reader.Read())
                            {
                                lstBooksReview.Add(new BooksReview()
                                {
                                    BooksReviewId = DataConversion.Convert2Int32(reader["BooksReviewId"].ToString()),
                                    BookId = DataConversion.Convert2Int32(reader["BookId"].ToString()),
                                    BookName = Convert.ToString(reader["Book"]),
                                    Header = Convert.ToString(reader["Header"]),
                                    Description = Convert.ToString(reader["Description"]),
                                    ParentId = DataConversion.Convert2Int16(reader["ParentId"].ToString()),
                                    BookCategoryIds = Convert.ToString(reader["CategoryId"].ToString()),
                                    BookCategory = Convert.ToString(reader["BookCategory"]),
                                    SourceDate = Convert.ToDateTime(reader["CreatedDate"].ToString()),
                                    BookDetail = new BookDetail()
                                    {
                                        BookDetailId = DataConversion.Convert2Int32(reader["BookDetailsId"].ToString()),
                                        ImgBookSmallFS = Convert.ToString(reader["ImgBookSmallFS"]),
                                    },
                                    UserInfo = new User()
                                    {
                                        UserId = DataConversion.Convert2Int32(reader["UserId"].ToString()),
                                        UserName = Convert.ToString(reader["UserName"].ToString()),
                                    },
                                });
                            }
                        }
                        return lstBooksReview;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<BooksReview> GetAllBooksReview(Int16 userTypeId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(SqlObjects.GetAllBooksReview, con))
                    {
                        List<BooksReview> lstBooksReview = new List<BooksReview>();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userTypeID", userTypeId);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (reader.Read())
                            {
                                lstBooksReview.Add(new BooksReview()
                                {
                                    BooksReviewId = DataConversion.Convert2Int32(reader["BooksReviewID"].ToString()),
                                    BookId = DataConversion.Convert2Int32(reader["BookID"].ToString()),
                                    Header = Convert.ToString(reader["Header"]),
                                    Description = Convert.ToString(reader["Description"]),
                                    ParentId = DataConversion.Convert2Int16(reader["ParentID"].ToString()),
                                    BookCategoryId = DataConversion.Convert2Int16(reader["CategoryID"].ToString()),
                                    BookCategory = Convert.ToString(reader["BookCategory"]),
                                    SourceDate = DateTime.Now,
                                    BookDetail = new BookDetail()
                                    {
                                        BookDetailId = DataConversion.Convert2Int32(reader["BookDetailsID"].ToString()),
                                        ImgBookSmallFS = Convert.ToString(reader["ImgBookSmallFS"]),
                                    },
                                    UserInfo = new User()
                                    {
                                        UserId = DataConversion.Convert2Int32(reader["UserId"].ToString()),
                                        UserName = Convert.ToString(reader["UserName"].ToString()),
                                    },
                                    UserDetail = new UserDetails()
                                    {
                                        ImgComments = Convert.ToString(reader["ImgComments"]),
                                    },
                                });
                            }
                        }
                        return lstBooksReview;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
