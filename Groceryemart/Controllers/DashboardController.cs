using System;
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
    public class DashboardController : ControllerBase
    {
        /// <summary>
        /// Creating referance variable of IAdminGroceryServices
        /// </summary>
        private readonly IAdminGroceryServices _adminGS;
        /// <summary>
        /// Injecting referance variable into DashboardController constructor
        /// </summary>
        /// <param name="adminGroceryServices"></param>
        public DashboardController(IAdminGroceryServices adminGroceryServices)
        {
            _adminGS = adminGroceryServices;
        }
        /// <summary>
        /// Get All order plced by user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ProductOrder>> AllOrder()
        {
            return await _adminGS.AllOrder();
        }
        /// <summary>
        /// Get product Order By Id
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("OrderById/{OrderId}")]
        public async Task<IActionResult> OrderById(int OrderId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getorder = await _adminGS.GetOrderById(OrderId);
            if (getorder == null)
            {
                return NotFound();
            }
            return CreatedAtAction("AllOrder", new { OrderId = getorder.OrderId }, getorder);
        }
        /// <summary>
        /// Add new category in sql table
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddNewCategory([FromBody] CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Category newcategory = new Category
            {
                CatId = model.CatId,
                Title = model.Title,
                Url = model.Url,
                OpenInNewWindow = model.OpenInNewWindow
            };
            await _adminGS.AddCategory(newcategory);
            return Ok("New Category Addeed...");
        }
        /// <summary>
        /// Add new Product in sql table
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Product newproduct = new Product
            {
                ProductName = model.ProductName,
                Description = model.Description,
                Amount = model.Amount,
                stock = model.stock,
                photo = model.photo,
                CatId = model.CatId
            };
            await _adminGS.AddProduct(newproduct);
            return Ok("Product Addeed...");
        }
        /// <summary>
        /// Updatecategory in sql table
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Updatecategory/{Id}")]
        public async Task<IActionResult> Updatecategory(int Id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getcategory = _adminGS.GetCategoryById(Id);
            if (getcategory == null)
            {
                return NotFound();
            }
            await _adminGS.UpdateCategory(Id, category);
            return Ok("Category Updated...");
        }
        /// <summary>
        /// Update Product in sql table
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateProduct/{string ProductId}")]
        public async Task<IActionResult> UpdateProduct(int ProductId, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getproduct = _adminGS.GetProductById(ProductId);
            if (getproduct == null)
            {
                return NotFound();
            }
            await _adminGS.UpdateProduct(ProductId, product);
            return Ok("Product Updated...");
        }
        /// <summary>
        /// Remove Category form sql categeory table by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Removecategory/{Id}")]
        public async Task<IActionResult> RemoveCategory(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }
            try
            {
                var result = await _adminGS.RemoveCategory(Id);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("Category Deleted");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Remove Product from sql databse from product table
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Removeproduct/{ProductId}")]
        public async Task<IActionResult> RemoveProduct(int ProductId)
        {
            if (ProductId <= 0)
            {
                return BadRequest();
            }
            try
            {
                var result = await _adminGS.RemoveProduct(ProductId);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("Product Deleted");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
