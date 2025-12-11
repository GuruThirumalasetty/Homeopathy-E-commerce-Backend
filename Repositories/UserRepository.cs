using Dapper;
using Homeo_Mart.Interfaces;
using Homeo_Mart.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Homeo_Mart.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("DefaultConnection");
        }

        public async Task<int> SaveUserSignupAsync(UserSignup userSignup)
        {
            using var connection = new MySqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("p_FirstName", userSignup.FirstName);
            parameters.Add("p_LastName", userSignup.LastName);
            parameters.Add("p_Email", userSignup.Email);
            parameters.Add("p_Mobile", userSignup.Mobile);
            parameters.Add("p_PasswordHash", userSignup.PasswordHash);
            parameters.Add("p_Gender", userSignup.Gender);
            parameters.Add("p_DateOfBirth", userSignup.DateOfBirth);
            parameters.Add("p_AddressLine1", userSignup.AddressLine1);
            parameters.Add("p_AddressLine2", userSignup.AddressLine2);
            parameters.Add("p_City", userSignup.City);
            parameters.Add("p_State", userSignup.State);
            parameters.Add("p_Country", userSignup.Country);
            parameters.Add("p_Pincode", userSignup.Pincode);
            parameters.Add("p_NewUserId", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

            await connection.ExecuteAsync("HM_PR_Save_User_Signup", parameters, commandType: System.Data.CommandType.StoredProcedure);

            return parameters.Get<int>("p_NewUserId");
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            using var connection = new MySqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("p_UserId", userId);

            var user = await connection.QueryFirstOrDefaultAsync<User>("HM_PR_Get_User_By_Id", parameters, commandType: CommandType.StoredProcedure);

            return user;
        }
        public async Task<User?> GetAllUsersAsync()
        {
            using var connection = new MySqlConnection(_connectionString);

            var user = await connection.QueryFirstOrDefaultAsync<User>("HM_PR_Get_All_Users", commandType: CommandType.StoredProcedure);

            return user;
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            using var connection = new MySqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("p_UserId", user.UserId);
            parameters.Add("p_FirstName", user.FirstName);
            parameters.Add("p_LastName", user.LastName);
            parameters.Add("p_Email", user.Email);
            parameters.Add("p_Mobile", user.Mobile);
            parameters.Add("p_Gender", user.Gender);
            parameters.Add("p_DateOfBirth", user.DateOfBirth);
            parameters.Add("p_AddressLine1", user.AddressLine1);
            parameters.Add("p_AddressLine2", user.AddressLine2);
            parameters.Add("p_City", user.City);
            parameters.Add("p_State", user.State);
            parameters.Add("p_Country", user.Country);
            parameters.Add("p_Pincode", user.Pincode);
            parameters.Add("p_IsUpdated", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await connection.ExecuteAsync("HM_PR_Update_User", parameters, commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("p_IsUpdated");
        }
    }
}