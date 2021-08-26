using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryEmart.BusinessLayer.Interfaces;
using GroceryEmart.BusinessLayer.ViewModels;
using GroceryEmart.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryEmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Creating referance variable of IUserGroceryServices and IAdminGroceryServices
        /// </summary>
        private readonly IUserGroceryServices _userGS;
        private readonly IAdminGroceryServices _adminGS;
        /// <summary>
        /// Injecting referance variable into UserController constructor
        /// </summary>
        public UserController(IUserGroceryServices userGroceryServices, IAdminGroceryServices adminGroceryServices)
        {
            _userGS = userGroceryServices;
            _adminGS = adminGroceryServices;
        }
        /// <summary>
        /// Get All registred user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ApplicationUser>> AllUser()
        {
            return await _adminGS.GetAllUser();
        }
        /// <summary>
        /// Register new user and provide all information by applicationuser class object
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> AddNewUser([FromBody] UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ApplicationUser newuser = new ApplicationUser
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                MobileNumber = model.MobileNumber,
                PinCode = model.PinCode,
                HouseNo_Building_Name = model.HouseNo_Building_Name,
                Road_area = model.Road_area,
                City = model.City,
                State = model.State
            };
            await _userGS.Register(newuser);
            return Ok("User Addeed...");
        }
        /// <summary>
        /// Update an existing User, get user first then update user info.
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Updateuser/{UserId}")]
        public async Task<IActionResult> UpdateUser(int UserId, [FromBody] ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getuser = _userGS.GetUserById(UserId);
            if (getuser == null)
            {
                return NotFound();
            }
            await _userGS.UpdateUser(UserId, user);
            return Ok("User Updated...");
        }
    }
}
