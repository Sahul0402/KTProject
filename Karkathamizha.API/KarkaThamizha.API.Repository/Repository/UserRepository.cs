using Karkathamizha.API.IRepository;
using Karkathamizha.API.Model;
using Karkathamizha.API.Util;
using KarkaThamizha.API.Repository.Common;
using KarkaThamizha.API.Repository.SQLObject;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using System.Reflection;

namespace KarkaThamizha.API.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionManager _connection;
        public UserRepository(IOptions<ConnectionManager> connection)
        {
            _connection = connection.Value;
        }

        public async Task<int> AddUpdateUser(User model)
        {
            int Result = 0;
            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlObjects.AddUser, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userId", SqlDbType.Int, 4).Value = model.UserId == 0 ? 0 : model.UserId;
                    //cmd.Parameters.Add("@initial", SqlDbType.NVarChar, 14).Value = model.Initial?.Trim() ?? null;
                    cmd.Parameters.Add("@userName", SqlDbType.NVarChar, 100).Value = model.UserName == "" ? "" : model.UserName.Trim();
                    cmd.Parameters.Add("@name", SqlDbType.VarChar, 35).Value = model.Name.Trim();
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 40).Value = model.Email.ToLower().Trim();
                    //cmd.Parameters.Add("@password", SqlDbType.NVarChar, 60).Value = DataSecurity.Encrypt(model.Password.Trim());
                    cmd.Parameters.Add("@mobile", SqlDbType.VarChar, 20).Value = model.Mobile.Trim();
                    cmd.Parameters.Add("@professionId", SqlDbType.TinyInt, 1).Value = model.ProfessionId;
                    cmd.Parameters.Add("@userTypeId", SqlDbType.TinyInt, 1).Value = model.UserTypeId;
                    cmd.Parameters.Add("@specialNameId", SqlDbType.TinyInt, 2).Value = model.SpecialNameId == 0 ? null : model.SpecialNameId;

                    cmd.Parameters.AddWithValue("@profile", model.UserDetail.Profile == null ? "" : model.UserDetail.Profile.Trim());
                    cmd.Parameters.AddWithValue("@protocol", model.UserDetail.Protocol);
                    cmd.Parameters.AddWithValue("@website", model.UserDetail.Website == null ? "" : model.UserDetail.Website.Trim());
                    cmd.Parameters.AddWithValue("@blog", model.UserDetail.Blog == null ? "" : model.UserDetail.Blog.Trim());
                    cmd.Parameters.AddWithValue("@blogType", model.UserDetail.BlogType == null ? "" : model.UserDetail.BlogType.Trim());
                    cmd.Parameters.AddWithValue("@faceBook", model.UserDetail.FaceBook == null ? "" : model.UserDetail.FaceBook.Trim());
                    cmd.Parameters.AddWithValue("@twitter", model.UserDetail.Twitter == null ? "" : model.UserDetail.Twitter.Trim());
                    cmd.Parameters.AddWithValue("@instagram", model.UserDetail.Instagram == null ? "" : model.UserDetail.Instagram.Trim());
                    cmd.Parameters.AddWithValue("@pinterest", model.UserDetail.Pinterest == null ? "" : model.UserDetail.Pinterest.Trim());
                    cmd.Parameters.AddWithValue("@youTube", model.UserDetail.YouTube == null ? "" : model.UserDetail.YouTube.Trim());
                    cmd.Parameters.AddWithValue("@wikipedia", model.UserDetail.Wikipedia == null ? "" : model.UserDetail.Wikipedia.Trim());
                    cmd.Parameters.AddWithValue("@dob", model.UserDetail.DOB == null ? (object)DBNull.Value : model.UserDetail.DOB);
                    cmd.Parameters.AddWithValue("@dod", model.UserDetail.DOD == null ? (object)DBNull.Value : model.UserDetail.DOD);
                    cmd.Parameters.AddWithValue("@imgComments", model.UserDetail.ImgComments == string.Empty ? "" : model.UserDetail.ImgComments);
                    cmd.Parameters.AddWithValue("@imgProfile", model.UserDetail.ImgProfile == string.Empty ? "" : model.UserDetail.ImgProfile);
                    //cmd.Parameters.AddWithValue("@imgComments", model.UserDetail.ImgComments.FileName == string.Empty ? "" : model.UserDetail.ImgComments.FileName);
                    //cmd.Parameters.AddWithValue("@imgProfile", model.UserDetail.ImgProfile.FileName == null ? "" : model.UserDetail.ImgProfile.FileName);
                    cmd.Parameters.AddWithValue("@address", model.UserDetail.Address == null ? "" : model.UserDetail.Address.Trim());
                    cmd.Parameters.AddWithValue("@cityId", model.UserDetail.CityId);
                    cmd.Parameters.AddWithValue("@isShownInMenu", model.UserDetail.IsShownInMenu);
                    cmd.Parameters.AddWithValue("@isMailSubscription", model.UserDetail.IsMailSubscription);
                    cmd.Parameters.AddWithValue("@reference", model.UserDetail.Reference == null ? "" : model.UserDetail.Reference);

                    cmd.Parameters.Add("@Result", SqlDbType.VarChar, 30);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Result = DataConversion.Convert2Int32(cmd.Parameters["@Result"].Value.ToString());
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return await Task.FromResult(Result);
        }

        public async Task<string> DeleteUser(int id)
        {
            string result = string.Empty;
            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SqlObjects.DeleteUser, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userID", id);
                    cmd.ExecuteNonQuery();
                    result = "Deleted";
                }
            }
            return result;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            List<User>? lstAuthor = null;
            UserDetails? UserDetail = null;

            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlObjects.GetAllUsers, con))
                {

                    lstAuthor = new List<User>();
                    UserDetail = new UserDetails();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                    {
                        while (await reader.ReadAsync())
                        {
                            lstAuthor.Add(new User()
                            {
                                UserId = DataConversion.Convert2Int(reader["UserId"].ToString()),
                                Initial = Convert.ToString(reader["Initial"]),
                                UserName = Convert.ToString(reader["UserName"]),
                                Name = Convert.ToString(reader["Name"]),
                                Email = Convert.ToString(reader["MailID"]),
                                Mobile = Convert.ToString(reader["Mobile"]),
                                UserDetail = new UserDetails()
                                {
                                    UserDetailsId = DataConversion.Convert2Int(reader["UserDetailId"].ToString()),
                                    Profile = Convert.ToString(reader["Profile"]),
                                    Protocol = DataConversion.Convert2TinyInt(reader["Protocol"].ToString()),
                                    Website = Convert.ToString(reader["Website"]),
                                    Blog = Convert.ToString(reader["Blog"]),
                                    BlogType = Convert.ToString(reader["BlogType"]),
                                    FaceBook = Convert.ToString(reader["FaceBook"]),
                                    Twitter = Convert.ToString(reader["Twitter"]),
                                    Pinterest = Convert.ToString(reader["Pinterest"]),
                                    YouTube = Convert.ToString(reader["YouTube"]),
                                    Instagram = Convert.ToString(reader["Instagram"]),
                                    Wikipedia = Convert.ToString(reader["Wikipedia"]),
                                    DOB = DataConversion.ConvertToDate1(reader["DOB"].ToString()),
                                    DOD = DataConversion.ConvertToDate1(reader["DOD"].ToString()),
                                    ImgProfile = Convert.ToString(reader["ImgProfile"]),
                                    ImgComments = Convert.ToString(reader["ImgComments"]),
                                    Address = Convert.ToString(reader["Address"]),
                                    CityId = DataConversion.Convert2Int16(reader["CityID"].ToString()),
                                    IsShownInMenu = DataConversion.StringToBool(reader["IsShownInMenu"].ToString()),
                                    IsMailSubscription = DataConversion.StringToBool(reader["IsMailSubscription"].ToString()),
                                    //CreatedDate = DataConversion.ConvertToDate1(reader["CreatedDate"].ToString()),
                                    //ModifiedDate = DataConversion.ConvertToDate1(reader["ModifiedDate"].ToString()),
                                    Reference = Convert.ToString(reader["Reference"]),
                                }
                            });
                        }
                    }
                    return lstAuthor;
                }
            }
        }

        public async Task<IEnumerable<User>> GetAll1()
        {
            List<User>? lstAuthor = null;
            UserDetails? UserDetail = null;

            lstAuthor = new List<User>();
            UserDetail = new UserDetails();

            lstAuthor = GetUserDetails();
            return lstAuthor;
            //using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand(SqlObjects.GetAllUsers, con))
            //    {

            //        lstAuthor = new List<User>();
            //        UserDetail = new UserDetails();
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        con.Open();
            //        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
            //        {
            //            while (await reader.ReadAsync())
            //            {
            //                lstAuthor.Add(new User()
            //                {
            //                    UserId = DataConversion.Convert2Int(reader["UserId"].ToString()),
            //                    Initial = Convert.ToString(reader["Initial"]),
            //                    UserName = Convert.ToString(reader["UserName"]),
            //                    Name = Convert.ToString(reader["Name"]),
            //                    Email = Convert.ToString(reader["MailID"]),
            //                    Mobile = Convert.ToString(reader["Mobile"]),
            //                    UserDetail = new UserDetails()
            //                    {
            //                        UserDetailsId = DataConversion.Convert2Int(reader["UserDetailId"].ToString()),
            //                        Profile = Convert.ToString(reader["Profile"]),
            //                        Protocol = DataConversion.Convert2TinyInt(reader["Protocol"].ToString()),
            //                        Website = Convert.ToString(reader["Website"]),
            //                        Blog = Convert.ToString(reader["Blog"]),
            //                        BlogType = Convert.ToString(reader["BlogType"]),
            //                        FaceBook = Convert.ToString(reader["FaceBook"]),
            //                        Twitter = Convert.ToString(reader["Twitter"]),
            //                        Pinterest = Convert.ToString(reader["Pinterest"]),
            //                        YouTube = Convert.ToString(reader["YouTube"]),
            //                        Instagram = Convert.ToString(reader["Instagram"]),
            //                        Wikipedia = Convert.ToString(reader["Wikipedia"]),
            //                        DOB = DataConversion.ConvertToDate1(reader["DOB"].ToString()),
            //                        DOD = DataConversion.ConvertToDate1(reader["DOD"].ToString()),
            //                        ImgProfile = Convert.ToString(reader["ImgProfile"]),
            //                        ImgComments = Convert.ToString(reader["ImgComments"]),
            //                        Address = Convert.ToString(reader["Address"]),
            //                        CityId = DataConversion.Convert2Int16(reader["CityID"].ToString()),
            //                        IsShownInMenu = DataConversion.StringToBool(reader["IsShownInMenu"].ToString()),
            //                        IsMailSubscription = DataConversion.StringToBool(reader["IsMailSubscription"].ToString()),
            //                        //CreatedDate = DataConversion.ConvertToDate1(reader["CreatedDate"].ToString()),
            //                        //ModifiedDate = DataConversion.ConvertToDate1(reader["ModifiedDate"].ToString()),
            //                        Reference = Convert.ToString(reader["Reference"]),
            //                    }
            //                });
            //            }
            //        }
            //        return lstAuthor;
            //    }
            //}
        }

        private List<User> GetUserDetails()
        {            
            UserDetails UserDetail = new UserDetails();

            List<User> lstAuthor = new List<User>()
            {
                new User(){ UserId = 1,UserName="கற்க",Name="karka",Email="support@karkathamizha.com",Mobile="81228801",UserDetail = new UserDetails(){ FaceBook =""} },
                new User(){ UserId = 2,UserName="தொல்காப்பியர்",Name="Tholkappiyar",Email="tholkappiyar@kt.com",Mobile="81228802",UserDetail = new UserDetails(){ FaceBook =""} },
                new User(){ UserId = 3,UserName="திருவள்ளூவர்",Name="Thiruvalluvar",Email="thiruvalluvar@kt.com",Mobile="81228803",UserDetail = new UserDetails(){ FaceBook =""} },
                new User(){ UserId = 4,UserName="எஸ்.ராகவன்",Name="S.Ragavan",Email="SRagavan@kt.com",Mobile="81228804",UserDetail = new UserDetails(){ FaceBook =""} },
                new User(){ UserId = 5,UserName="எம்.எஸ்.உதயமூர்த்தி",Name="M.S.Udayamurthy",Email="msudayamurthy@kt.com",Mobile="81228805",UserDetail = new UserDetails(){ FaceBook =""} },
                new User(){ UserId = 6,UserName="சந்தோஷ் நாராயணன்",Name="Santhosh Narayanan",Email="ensanthosh@gmail.com@kt.com",Mobile="81228806",UserDetail = new UserDetails(){ FaceBook ="santhosh.narayanan.319"} },
                new User(){ UserId = 7,UserName="முத்துக்கிருஷ்ணன்",Name="Muthukrishnan",Email="muthukrishnan@karkathamizha.com@kt.com",Mobile="81228807",UserDetail = new UserDetails(){ FaceBook ="Muthukrishnan"} },
                new User(){ UserId = 8,UserName="அதியமான்",Name="Athiyaman",Email="athiy61@yahoo.co.in@kt.com",Mobile="81228808",UserDetail = new UserDetails(){ FaceBook ="athiyaman.athiyaman.940641"} },
                new User(){ UserId = 9,UserName="வாஸந்தி",Name="Vaasanthi",Email="vaasanthi@karkathamizha.com@kt.com",Mobile="81228809",UserDetail = new UserDetails(){ FaceBook ="vaasanthi"} },
                new User(){ UserId = 10,UserName="உளிமகிழ் ராஜ்கமல்",Name="Ulimagizh Rajkamal",Email="Ulimagizh@kt.com",Mobile="81228810",UserDetail = new UserDetails(){ FaceBook ="profile.php?id=100008080955808"} },
                new User(){ UserId = 11,UserName="பாலசுப்ரமணியம்",Name="J.Balasubramaniam",Email="Balasubramaniam@kt.com",Mobile="81228811",UserDetail = new UserDetails(){ FaceBook ="BaluMIDS"} },
                new User(){ UserId = 12,UserName="ராகவன்",Name="Pa.Raghavan",Email="Raghavan@kt.com",Mobile="81228812",UserDetail = new UserDetails(){ FaceBook ="AuthorPara"} },
                new User(){ UserId = 13,UserName="ஜீவசுந்தரி",Name="B.Jeevasundari",Email="Jeevasundari@kt.com",Mobile="81228813",UserDetail = new UserDetails(){ FaceBook ="jeevasundaribalan"} },
                new User(){ UserId = 14,UserName="கணேசன்",Name="G.Ganesan",Email="Ganesan@kt.com",Mobile="81228814",UserDetail = new UserDetails(){ FaceBook ="ganesan.gurusamy.1800"} },
                new User(){ UserId = 15,UserName="முத்துநிலவன்",Name="Muthunilavan",Email="Muthunilavan@kt.com",Mobile="81228815",UserDetail = new UserDetails(){ FaceBook ="muthu.nilavan.52"} },
                new User(){ UserId = 16,UserName="தீபா",Name="J.Deepa",Email="Deepa@kt.com",Mobile="81228816",UserDetail = new UserDetails(){ FaceBook ="deepa.janakiraman.9"} },
                new User(){ UserId = 17,UserName="கருந்தேள் ராஜேஷ்",Name="Karundhel Rajesh",Email="Rajesh@kt.com",Mobile="81228817",UserDetail = new UserDetails(){ FaceBook ="rajesh.scorpi"} },
                new User(){ UserId = 18,UserName="சோம வள்ளியப்பன்",Name="Soma Valliappan",Email="Valliappan@kt.com",Mobile="81228818",UserDetail = new UserDetails(){ FaceBook ="soma.valliyappan"} },
                new User(){ UserId = 19,UserName="சிவசுப்பிரமணியன்",Name="A.Sivasubramanian",Email="Sivasubramanian@kt.com",Mobile="81228819",UserDetail = new UserDetails(){ FaceBook ="sivasubramanian.in"} },
                new User(){ UserId = 20,UserName="ராஜன் குறை",Name="Rajan Kurai Krishnan",Email="Krishnan@kt.com",Mobile="81228820",UserDetail = new UserDetails(){ FaceBook ="rajan.k.krishnan"} },
                new User(){ UserId = 21,UserName="சொக்கன்",Name="N.Chokkanathan",Email="Chokkanathan@kt.com",Mobile="81228821",UserDetail = new UserDetails(){ FaceBook ="nchokkan"} },
                new User(){ UserId = 22,UserName="பவா செல்லதுரை",Name="Bava Chelladurai",Email="Chelladurai@kt.com",Mobile="81228822",UserDetail = new UserDetails(){ FaceBook ="bavachelladurai"} },
                new User(){ UserId = 23,UserName="இந்திரன்",Name="Indran Rajendran",Email="Rajendran@kt.com",Mobile="81228823",UserDetail = new UserDetails(){ FaceBook ="indran.rajendran.7"} },
                new User(){ UserId = 24,UserName="பாலகிருஷ்ணன்",Name="R.Balakrishnan",Email="Balakrishnan@kt.com",Mobile="81228824",UserDetail = new UserDetails(){ FaceBook ="profile.php?id=100011737148867"} },
                new User(){ UserId = 25,UserName="செயராமன்",Name="Jayaraman",Email="Jayaraman@kt.com",Mobile="81228825",UserDetail = new UserDetails(){ FaceBook ="profile.php?id=100044112903885"} },
            };

            return lstAuthor;
        }

        public async Task<User> GetUserByEmailId(string email)
        {
            User user = null;
            user = GetUserDetails().Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
            return user;

            //using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand(SqlObjects.GetUserByEmailId, con))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.Add("@email", SqlDbType.VarChar, 35).Value = email;
            //        con.Open();
            //        using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
            //        {
            //            if (await reader.ReadAsync())
            //            {
            //                user = new User()
            //                {
            //                    UserId = Convert.ToInt32(reader["UserID"].ToString()),
            //                    Initial = Convert.ToString(reader["Initial"]),
            //                    Name = Convert.ToString(reader["Name"]),
            //                    UserName = Convert.ToString(reader["UserName"]),
            //                    Email = Convert.ToString(reader["MailID"]),
            //                    Mobile = Convert.ToString(reader["Mobile"]),
            //                    LastActivity = Convert.ToDateTime(reader["LastActivity"])
            //                };
            //            }
            //        }
            //        return user;
            //    }
            //}
        }

        public async Task<User> GetUserById(int id)
        {
            User? user = null;

            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlObjects.GetUserById, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userId", SqlDbType.Int, 35).Value = id;
                    con.Open();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                    {
                        if (await reader.ReadAsync())
                        {
                            user = new User()
                            {
                                UserId = DataConversion.Convert2Int(reader["UserId"].ToString()),
                                Initial = Convert.ToString(reader["Initial"]),
                                UserName = Convert.ToString(reader["UserName"]),
                                Name = Convert.ToString(reader["Name"]),
                                Email = Convert.ToString(reader["MailID"]),
                                Mobile = Convert.ToString(reader["Mobile"]),
                                UserDetail = new UserDetails()
                                {
                                    UserDetailsId = DataConversion.Convert2Int(reader["UserDetailID"].ToString()),
                                    Profile = Convert.ToString(reader["Profile"]),
                                    Protocol = DataConversion.Convert2TinyInt(reader["Protocol"].ToString()),
                                    Website = Convert.ToString(reader["Website"]),
                                    Blog = Convert.ToString(reader["Blog"]),
                                    BlogType = Convert.ToString(reader["BlogType"]),
                                    FaceBook = Convert.ToString(reader["FaceBook"]),
                                    Twitter = Convert.ToString(reader["Twitter"]),
                                    Pinterest = Convert.ToString(reader["Pinterest"]),
                                    YouTube = Convert.ToString(reader["YouTube"]),
                                    Instagram = Convert.ToString(reader["Instagram"]),
                                    Wikipedia = Convert.ToString(reader["Wikipedia"]),
                                    DOB = DataConversion.ConvertToDate1(reader["DOB"].ToString()),
                                    DOD = DataConversion.ConvertToDate1(reader["DOD"].ToString()),
                                    //ImgProfile = Convert.ToString(reader["ImgProfile"]),
                                    //ImgComments = Convert.ToString(reader["ImgComments"]),
                                    Address = Convert.ToString(reader["Address"]),
                                    CityId = DataConversion.Convert2Int16(reader["CityID"].ToString()),
                                    IsShownInMenu = DataConversion.StringToBool(reader["IsShownInMenu"].ToString()),
                                    IsMailSubscription = DataConversion.StringToBool(reader["IsMailSubscription"].ToString()),
                                    //CreatedDate = DataConversion.ConvertToDate1(reader["CreatedDate"].ToString()),
                                    //ModifiedDate = DataConversion.ConvertToDate1(reader["ModifiedDate"].ToString()),
                                    Reference = Convert.ToString(reader["Reference"]),
                                }
                            };
                        }
                    }
                    return user;
                }
            }
        }
    }
}
