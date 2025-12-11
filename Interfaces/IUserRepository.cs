using Homeo_Mart.Models;

namespace Homeo_Mart.Interfaces
{
    public interface IUserRepository
    {
        Task<int> SaveUserSignupAsync(UserSignup userSignup);
        Task<User?> GetUserByIdAsync(int userId);
        Task<User?> GetAllUsersAsync();
        Task<int> UpdateUserAsync(User user);
    }
}