using Karkathamizha.API.IRepository;
using Karkathamizha.API.Model;
using Karkathamizha.API.Util;
using KarkaThamizha.API.Repository.Common;
using KarkaThamizha.API.Repository.SQLObject;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace KarkaThamizha.API.Repository.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ConnectionManager _connection;
        public AuthenticationRepository(IOptions<ConnectionManager> connection) 
        {
            _connection = connection.Value; 
        }

        public async Task<int> Registeration(Register model)
        {
            int Result = 0;
            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlObjects.AddUser, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = model.UserId == 0 ? 0 : model.UserId;
                    cmd.Parameters.Add("@Initial", SqlDbType.NVarChar, 14).Value = model.Initial?.Trim() ?? null;
                    cmd.Parameters.Add("@User", SqlDbType.NVarChar, 100).Value = model.Name == "" ? "" : model.Name.Trim();
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 35).Value = model.Name.Trim();
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 40).Value = model.Email.ToLower().Trim();
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 60).Value = DataSecurity.Encrypt(model.Password.Trim());
                    cmd.Parameters.Add("@Mobile", SqlDbType.VarChar, 20).Value = model.Mobile.Trim();
                    cmd.Parameters.Add("@ProfessionID", SqlDbType.TinyInt, 1).Value = model.ProfessionId;
                    cmd.Parameters.Add("@UserTypeID", SqlDbType.TinyInt, 1).Value = model.UserTypeId;
                    cmd.Parameters.Add("@SpecialNameID", SqlDbType.TinyInt, 2).Value = model.SpecialNameId == null ? null : model.SpecialNameId;

                    cmd.Parameters.Add("@Result", SqlDbType.VarChar, 30);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Result = DataConversion.Convert2Int32(cmd.Parameters["@Result"].Value.ToString());
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return await Task.FromResult(Result);
        }

        public async Task<LoginSuccess> Login(Login account)
        {
            LoginSuccess success = null;
            return success;
        }
    }
}
