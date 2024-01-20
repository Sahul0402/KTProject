using Karkathamizha.API.IRepository;
using Karkathamizha.API.Model;
using KarkaThamizha.API.Repository.Common;
using Karkathamizha.API.Util;
using KarkaThamizha.API.Repository.SQLObject;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KarkaThamizha.API.Repository.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly ConnectionManager _connection;
        public PublisherRepository(IOptions<ConnectionManager> connection)
        {
            _connection = connection.Value;
        }
        public async Task<Int16> AddUpdatePublisher(Publisher model)
        {
            Int16 Result = 0;
            List<Publisher> lstPublisher = null;
            List<PublisherDetail> lstPublisherInfo = null;
            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand com = new SqlCommand(SqlObjects.AddPublisher, con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@PublisherId", SqlDbType.Int, 4).Value = model.PublisherId == 0 ? 0 : model.PublisherId;
                    com.Parameters.AddWithValue("@Publisher", model.PublisherName.Trim());
                    com.Parameters.AddWithValue("@Name", model.Name == null ? "" : model.Name.Trim());
                    com.Parameters.AddWithValue("@ContactName", model.ContactName == null ? "" : Convert.ToString(model.ContactName).Trim());
                    com.Parameters.AddWithValue("@Mobile", Convert.ToString(model.Mobile) == null ? "" : Convert.ToString(model.Mobile).Trim());
                    com.Parameters.AddWithValue("@MailID", Convert.ToString(model.MailID) == null ? "" : Convert.ToString(model.MailID).Trim());
                    com.Parameters.AddWithValue("@logo", model.PubLogo == null ? string.Empty : Convert.ToString(model.PubLogo).Trim());
                    com.Parameters.Add("@showInMenu", SqlDbType.Bit, 1).Value = model.ShowInMenu;

                    com.Parameters.AddWithValue("@Phone", model.PubDetail.Phone == null ? "" : model.PubDetail.Phone.Trim());
                    com.Parameters.AddWithValue("@Fax", model.PubDetail.Fax == null ? "" : model.PubDetail.Fax.Trim());
                    com.Parameters.AddWithValue("@Website", model.PubDetail.Website == null ? "" : model.PubDetail.Website.Trim());
                    com.Parameters.AddWithValue("@Blog", model.PubDetail.Blog == null ? "" : model.PubDetail.Blog.Trim());
                    com.Parameters.AddWithValue("@BlogType", model.PubDetail.Blog == null ? "" : model.PubDetail.BlogType.Trim());
                    com.Parameters.AddWithValue("@FaceBook", model.PubDetail.FaceBook == null ? "" : model.PubDetail.FaceBook.Trim());
                    com.Parameters.AddWithValue("@Twitter", model.PubDetail.Twitter == null ? "" : model.PubDetail.Twitter.Trim());
                    com.Parameters.AddWithValue("@Address", model.PubDetail.Address == null ? "" : model.PubDetail.Address.Trim());
                    com.Parameters.AddWithValue("@CityID", model.PubDetail.CityID);

                    com.Parameters.Add("@Result", SqlDbType.VarChar, 4);
                    com.Parameters["@Result"].Direction = ParameterDirection.Output;

                    con.Open();
                    com.ExecuteNonQuery();
                    Result = DataConversion.Convert2Int16(com.Parameters["@Result"].Value.ToString());
                }
                return Result;
            }
            return await Task.FromResult(Result);
        }

        public async Task<string> DeletePublisher(Int16 id)
        {
            string result = string.Empty;
            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SqlObjects.DeletePublisher, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                    result = "Deleted";
                }
            }
            return result;
        }

        public async Task<IEnumerable<Publisher>> GetAll()
        {
            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlObjects.GetAllPublishers, con))
                {
                    List<Publisher> lstPublisher = new List<Publisher>();
                    List<PublisherDetail> lstPublisherInfo = new List<PublisherDetail>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            lstPublisher.Add(new Publisher()
                            {
                                PublisherId = DataConversion.Convert2Int16(reader["PublisherID"].ToString()),
                                PublisherName = Convert.ToString(reader["Publisher"]),
                                Name = Convert.ToString(reader["Name"]),
                                ContactName = Convert.ToString(reader["ContactName"]),
                                Mobile = Convert.ToString(reader["Mobile"]),
                                MailID = Convert.ToString(reader["MailID"]),
                                //PubLogo = Convert.ToString(reader["Logo"]),
                                PubDetail = new PublisherDetail()
                                {
                                    Phone = Convert.ToString(reader["Phone"]),
                                    Fax = Convert.ToString(reader["Fax"]),
                                    FaceBook = Convert.ToString(reader["FaceBook"]),
                                    Twitter = Convert.ToString(reader["Twitter"]),
                                    Address = Convert.ToString(reader["Address"]),
                                    CountryID = DataConversion.Convert2Int16(reader["CountryID"].ToString()),
                                    StateID = DataConversion.Convert2Int16(reader["StateID"].ToString()),
                                    CityID = DataConversion.Convert2Int16(reader["CityID"].ToString()),
                                }
                            });
                        }
                    }
                    return lstPublisher;
                }
            }
        }

        public async Task<Publisher> GetPublisherById(Int16 id)
        {
            Publisher? publisher = null;

            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlObjects.GetPublisherById, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int, 4).Value = id;
                    con.Open();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                    {
                        if (await reader.ReadAsync())
                        {
                            publisher = new Publisher()
                            {
                                PublisherId = DataConversion.Convert2Int16(reader["PublisherID"].ToString()),
                                PublisherName = Convert.ToString(reader["Publisher"]),
                                Name = Convert.ToString(reader["Name"]),
                                ContactName = Convert.ToString(reader["ContactName"]),
                                Mobile = Convert.ToString(reader["Mobile"]),
                                MailID = Convert.ToString(reader["MailID"]),
                                //PubLogo = Convert.ToString(reader["Logo"]),
                                PubDetail = new PublisherDetail()
                                {
                                    Phone = Convert.ToString(reader["Phone"]),
                                    Fax = Convert.ToString(reader["Fax"]),
                                    FaceBook = Convert.ToString(reader["FaceBook"]),
                                    Twitter = Convert.ToString(reader["Twitter"]),
                                    Address = Convert.ToString(reader["Address"]),
                                    CountryID = DataConversion.Convert2Int16(reader["CountryID"].ToString()),
                                    StateID = DataConversion.Convert2Int16(reader["StateID"].ToString()),
                                    CityID = DataConversion.Convert2Int16(reader["CityID"].ToString()),
                                }
                            };
                        }
                    }
                    return publisher;
                }
            }
        }
    }
}
