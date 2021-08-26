using GroceryEmart.Entities;
using System.Threading.Tasks;

namespace GroceryEmart.BusinessLayer.Services.Repository
{
    public interface IUserGroceryRepository
    {
        Task<ApplicationUser> Register(ApplicationUser user);
        Task<ApplicationUser> GetUserById(int UserId);
        Task<ApplicationUser> UpdateUser(int UserId, ApplicationUser user);
        Task<ApplicationUser> Login(string Email, string password);
        Task<bool> Logout();
    }
}
