using GroceryEmart.DataLayer;
using GroceryEmart.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryEmart.BusinessLayer.Services.Repository
{
    public class UserGroceryRepository : IUserGroceryRepository
    {
        /// <summary>
        /// Creating referance Variable of DbContext
        /// </summary>
        private readonly GroceryemartDbContext _groceryemartDbContext;
        
        /// <summary>
        /// Injecting Referance variable in UserGroceryRepository class Constructor
        /// </summary>
        public UserGroceryRepository(GroceryemartDbContext groceryemartDbContext)
        {
            _groceryemartDbContext = groceryemartDbContext;
        }
        /// <summary>
        /// Get User by Id from ApplicationUser table
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> GetUserById(int UserId)
        {
            try
            {
                return await _groceryemartDbContext.users.FirstOrDefaultAsync(m => m.UserId == UserId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Verify User using this method if its is registred or not
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> Login(string Email, string password)
        {
            try
            {
                var user = await _groceryemartDbContext.users.FirstOrDefaultAsync(m => m.Email == Email && m.Password == password);
                return user;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Logout function
        /// </summary>
        /// <returns></returns>
        public Task<bool> Logout()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Register new user in ApplicationUser table
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> Register(ApplicationUser user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(typeof(ApplicationUser).Name + "Object is Null");
                }
                await _groceryemartDbContext.users.AddAsync(user);
                await _groceryemartDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return user;
        }
        /// <summary>
        /// Update Registred user in ApplicationUser table
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> UpdateUser(int UserId, ApplicationUser user)
        {
            if (user == null && UserId <= 0)
            {
                throw new ArgumentNullException(typeof(ApplicationUser).Name + "Object or may be UserId is Null");
            }

            var existingUser = await _groceryemartDbContext.users.Where(x => x.UserId == UserId).FirstOrDefaultAsync();
            if(existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                existingUser.MobileNumber = user.MobileNumber;
                existingUser.PinCode = user.PinCode;
                existingUser.HouseNo_Building_Name = user.HouseNo_Building_Name;
                existingUser.Road_area = user.Road_area;
                existingUser.City = user.City;
                existingUser.State = user.State;

                await _groceryemartDbContext.SaveChangesAsync();
            }
            return existingUser;
        }
    }
}
