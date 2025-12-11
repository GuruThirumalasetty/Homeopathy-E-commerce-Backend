using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace Homeo_Mart.Services
{
    public abstract class BaseRepository
    {
        protected readonly string _connectionString;

        protected BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("DefaultConnection");
            
        }

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        protected async Task<IEnumerable<T>> QueryListAsync<T>(string sp, DynamicParameters parameters) // Get
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<T>(sp, parameters, commandType: CommandType.StoredProcedure);
        }

        protected async Task<T> QuerySingleAsync<T>(string sp, DynamicParameters parameters) // Update/Insert
        {
            using var conn = GetConnection();
            return await conn.QueryFirstOrDefaultAsync<T>(sp, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
