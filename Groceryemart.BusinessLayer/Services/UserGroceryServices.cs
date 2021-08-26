using GroceryEmart.BusinessLayer.Interfaces;
using GroceryEmart.BusinessLayer.Services.Repository;
using GroceryEmart.Entities;
using System;
using System.Threading.Tasks;

namespace GroceryEmart.BusinessLayer.Services
{
    public class UserGroceryServices : IUserGroceryServices
    {
        /// <summary>
        /// Creating referance Variable of IUserGroceryRepository and injecting in UserGroceryServices constructor
        /// </summary>
        private readonly IUserGroceryRepository _userGroceryRepository;
        public UserGroceryServices(IUserGroceryRepository userGroceryRepository)
        {
            _userGroceryRepository = userGroceryRepository;
        }
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Task<ApplicationUser> GetUserById(int UserId)
        {
            var result = _userGroceryRepository.GetUserById(UserId);
            return result;
        }
        /// <summary>
        /// Loging user to check is registred or not
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<ApplicationUser> Login(string Email, string password)
        {
            var result = _userGroceryRepository.Login(Email, password);
            return result;
        }
        /// <summary>
        /// Log out 
        /// </summary>
        /// <returns></returns>
        public Task<bool> Logout()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Registred new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<ApplicationUser> Register(ApplicationUser user)
        {
            var result = _userGroceryRepository.Register(user);
            return result;
        }
        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<ApplicationUser> UpdateUser(int UserId, ApplicationUser user)
        {
            var update = _userGroceryRepository.UpdateUser(UserId, user);
            return update;
        }
    }
}
