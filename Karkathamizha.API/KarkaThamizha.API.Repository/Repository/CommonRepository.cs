using Karkathamizha.API.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using KarkaThamizha.API.Repository.SQLObject;
using Microsoft.Extensions.Options;

namespace KarkaThamizha.API.Repository.Repository
{
    public class CommonRepository : ICommonRepository
    {
        private readonly ConnectionManager _connection;

        public CommonRepository(IOptions<ConnectionManager> connection)
        {
            _connection = connection.Value;
        }
        public async Task<bool> IsEmailExists(string email)
        {
            bool flag = false;
            using (SqlConnection con = new SqlConnection(_connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlObjects.CheckMailExists, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EMail", SqlDbType.VarChar, 35).Value = email;
                    con.Open();
                    flag = Convert.ToBoolean(await cmd.ExecuteScalarAsync());
                    return flag;
                }
            }
        }
    }
}
