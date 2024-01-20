using Karkathamizha.API.IRepository;
using Karkathamizha.API.Model;
using KarkaThamizha.API.Repository.Common;
using KarkaThamizha.API.Repository.SQLObject;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaThamizha.API.Repository.Repository
{
    public sealed class ArticleRepository: IArticleRepository
    {
        private readonly ConnectionManager _connection;
        public ArticleRepository(IOptions<ConnectionManager> connection)
        {
            _connection = connection.Value;
        }
        public async Task<IEnumerable<Article>> GetAllArticle()
        {
            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlObjects.GetAllArticle, con))
                {
                    List<Article> lstBooksContent = new List<Article>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                    {
                        while (await reader.ReadAsync())
                        {
                            lstBooksContent.Add(new Article()
                            {
                                ArticleId = DataConversion.Convert2Int32(reader["ArticleID"].ToString()),
                                //ArticleType = new ArticleType()
                                //{
                                //    ArticleTypeID = DataConversion.Convert2TinyInt(reader["ArticleTypeID"].ToString()),
                                //    ArticleType = Convert.ToString(reader["ArticleType"]),
                                //},
                                Header = Convert.ToString(reader["Header"]),
                                Description = Convert.ToString(reader["Description"]),
                                ImgPath = reader["Image"] == null ? "" : Convert.ToString(reader["ImgPath"]),
                                //MagazineName = new MagazineModels()
                                //{
                                //    MagazineID = DataConversion.Convert2Int16(reader["MagazineID"].ToString()),
                                //    Magazine = Convert.ToString(reader["Magazine"]),
                                //},
                                //UserDetail = new UserDetails()
                                //{
                                //    UserId = DataConversion.Convert2Int(Convert.ToString(reader["UserId"])),
                                //    ImgComments = Convert.ToString(reader["ImgComments"] == null ? "" : reader["ImgComments"]),
                                //},
                                SourceDate = Convert.ToDateTime(reader["SourceDate"] == DBNull.Value ? (DateTime?)null : (DateTime?)reader["SourceDate"]),
                            });
                        }
                    }
                    return lstBooksContent;
                }
            }
        }
        public string AddArticle(Article newArticle)
        {
            string result = "";
            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlObjects.AddArticle, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArticleID", newArticle.ArticleId);
                    //cmd.Parameters.AddWithValue("@ArticleTypeID", newArticle.ArticleType.ArticleTypeID);
                    //cmd.Parameters.AddWithValue("@AuthorID", newArticle.Author.UserID == 0 ? null : Convert.ToString(newArticle.Author.UserID));
                    cmd.Parameters.AddWithValue("@Header", newArticle.Header == null ? "" : Convert.ToString(newArticle.Header).Trim());
                    cmd.Parameters.AddWithValue("@Description", newArticle.Description == null ? "" : Convert.ToString(newArticle.Description).Trim());
                    //cmd.Parameters.AddWithValue("@MagazineID", newArticle.MagazineName.MagazineID);
                    cmd.Parameters.AddWithValue("@SourceDate", newArticle.SourceDate == null ? (object)DBNull.Value : newArticle.SourceDate);
                    cmd.Parameters.AddWithValue("@ImgName", newArticle.ImgPath == null ? "" : Convert.ToString(newArticle.ImgPath).Trim());
                    cmd.Parameters.AddWithValue("@InterviewBy", 1);
                    cmd.Parameters.AddWithValue("@EnteredBy", 1);

                    cmd.Parameters.Add("@Result", SqlDbType.VarChar, 7);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                    try
                    {
                        con.Open();
                        if (cmd.ExecuteNonQuery() == 0)
                            result = cmd.Parameters["@Result"].Value.ToString();
                        else
                            result = cmd.Parameters["@Result"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        result = ex.InnerException.ToString();
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return result;
        }
    }
}
