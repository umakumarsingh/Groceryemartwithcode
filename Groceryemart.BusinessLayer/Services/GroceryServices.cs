using GroceryEmart.BusinessLayer.Interfaces;
using GroceryEmart.BusinessLayer.Services.Repository;
using GroceryEmart.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryEmart.BusinessLayer.Services
{
    public class GroceryServices : IGroceryServices
    {
        /// <summary>
        /// Creating referance Variable of IGroceryRepository and injecting in GroceryServices constructor
        /// </summary>
        private readonly IGroceryRepository _groceryRepository;
        public GroceryServices(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }
        /// <summary>
        /// Get all product
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Product>> GetAllProduct()
        {
            var result = _groceryRepository.GetAllProduct();
            return result;
        }
        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public Task<Product> GetProductById(int ProductId)
        {
            var result = _groceryRepository.GetProductById(ProductId);
            return result;
        }
        /// <summary>
        /// Get acategory list
        /// </summary>
        /// <returns></returns>
        public IList<Category> CategoryList()
        {
            var result = _groceryRepository.CategoryList();
            return result;
        }
        /// <summary>
        /// Get Product by name
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        public Task<IEnumerable<Product>> ProductByName(string ProductName)
        {
            var result = _groceryRepository.ProductByName(ProductName);
            return result;
        }
        /// <summary>
        /// Get Product By Category
        /// </summary>
        /// <param name="CatId"></param>
        /// <returns></returns>
        public Task<IEnumerable<Product>> GetProductByCategory(int CatId)
        {
            var result = _groceryRepository.GetProductByCategory(CatId);
            return result;
        }
        /// <summary>
        /// Place order
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Task<bool> PlaceOrder(int ProductId, int UserId)
        {
            var result = _groceryRepository.PlaceOrder(ProductId, UserId);
            return result;
        }
    }
}
