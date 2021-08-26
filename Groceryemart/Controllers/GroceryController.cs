using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryEmart.BusinessLayer.Interfaces;
using GroceryEmart.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryEmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryController : ControllerBase
    {
        /// <summary>
        /// Creating referance variable of IGroceryServices and IUserGroceryServices
        /// </summary>
        private readonly IGroceryServices _groceryServices;
        private readonly IUserGroceryServices _userGroceryServices;
        /// <summary>
        /// Injecting referance variable into GroceryController constructor
        /// </summary>
        public GroceryController(IGroceryServices groceryServices, IUserGroceryServices userGroceryServices)
        {
            _groceryServices = groceryServices;
            _userGroceryServices = userGroceryServices;
        }
        /// <summary>
        /// Get All product and show Index Page for user
        /// </summary>
        /// <returns></returns>
        // GET: api/<GroceryController>
        [HttpGet]
        public async Task<IEnumerable<Product>> AllProduct()
        {
            return await _groceryServices.GetAllProduct();
        }
        /// <summary>
        /// Get Product Details
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ProductById/{ProductId}")]
        public async Task<IActionResult> ProductById(int ProductId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getproduct = await _groceryServices.GetProductById(ProductId);
            if (getproduct == null)
            {
                return NotFound();
            }
            return CreatedAtAction("AllProduct", new { ProductId = getproduct.ProductId }, getproduct);
        }
        /// <summary>
        /// Get All product by CategoryId
        /// </summary>
        /// <param name="CatId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ProductByCategory/{CatId}")]
        public async Task<IEnumerable<Product>> ProductByCategory(int CatId)
        {
            return await _groceryServices.GetProductByCategory(CatId);
        }
        /// <summary>
        /// Get product by product Name
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ProductByName/{ProductName}")]
        public async Task<IEnumerable<Product>> ProductByName(string ProductName)
        {
            return await _groceryServices.ProductByName(ProductName);
        }
        /// <summary>
        /// Get all category list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Categorylist")]
        public IActionResult GetCategoryList()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getcategory = _groceryServices.CategoryList();
            if (getcategory == null)
            {
                return NotFound();
            }
            return CreatedAtAction("AllProduct", getcategory);
        }
        /// <summary>
        /// Place order for Registred user, make sure user must be register
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Placeorder/{ProductId}/{email}/{password}")]
        public async Task<IActionResult> Placeorder(int ProductId, string email, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _userGroceryServices.Login(email, password);
            if(result != null)
            {
                await _groceryServices.PlaceOrder(ProductId, result.UserId);
                return Ok("Order Placed...");
            }
            return Ok("Order not placed user not exists");
        }
    }
}