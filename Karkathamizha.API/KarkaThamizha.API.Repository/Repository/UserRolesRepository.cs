using Karkathamizha.API.Model;
using KarkaThamizha.API.Repository.SQLObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Karkathamizha.API.IRepository;

namespace KarkaThamizha.API.Repository.Repository
{
    public class UserRolesRepository: IUserRolesRepository
    {
        private readonly ConnectionManager _connection;
        public UserRolesRepository(IOptions<ConnectionManager> connection)
        {
            _connection = connection.Value;
        }
        public async Task<List<UserRoles>> GetUserRole(int userId)
        {
            List<UserRoles> roles = null;

            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlObjects.GetUserRole, con))
                {
                    roles = new List<UserRoles>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userid", SqlDbType.VarChar, 35).Value = userId;
                    con.Open();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                    {
                        while (await reader.ReadAsync())
                        {
                            roles.Add(new UserRoles() 
                            {
                                UserId = Convert.ToInt32(reader["UserID"].ToString()),
                                RoleId = Convert.ToInt16(reader["RoleID"].ToString()),
                                RoleName = Convert.ToString(reader["Name"]),
                            });
                        }
                    }
                    return roles;
                }
            }
        }
    }
}
