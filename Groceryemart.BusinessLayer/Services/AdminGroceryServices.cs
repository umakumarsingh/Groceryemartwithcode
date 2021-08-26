using GroceryEmart.BusinessLayer.Interfaces;
using GroceryEmart.BusinessLayer.Services.Repository;
using GroceryEmart.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryEmart.BusinessLayer.Services
{
    public class AdminGroceryServices : IAdminGroceryServices
    {
        /// <summary>
        /// Creating referance Variable of IAdminGroceryRepository and injecting in AdminGroceryServices constructor
        /// </summary>
        private readonly IAdminGroceryRepository _adminRepository;

        public AdminGroceryServices(IAdminGroceryRepository adminGroceryRepository)
        {
            _adminRepository = adminGroceryRepository;
        }
        /// <summary>
        /// Add new category in category sql database
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<Category> AddCategory(Category category)
        {
            var result = await _adminRepository.AddCategory(category);
            return result;
        }
        /// <summary>
        /// Add new Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<Product> AddProduct(Product product)
        {
            var result = await _adminRepository.AddProduct(product);
            return result;
        }
        /// <summary>
        /// Get all order
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductOrder>> AllOrder()
        {
            return await _adminRepository.AllOrder();
        }
        /// <summary>
        /// get all product
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> AllProduct()
        {
            return await _adminRepository.AllProduct();

        }
        /// <summary>
        /// Get all user
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ApplicationUser>> GetAllUser()
        {
            var result = _adminRepository.GetAllUser();
            return result;
        }
        /// <summary>
        /// Get Category ById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<Category> GetCategoryById(int Id)
        {
            var result = _adminRepository.GetCategoryById(Id);
            return result;
        }
        /// <summary>
        /// Get Order By Id
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public Task<ProductOrder> GetOrderById(int OrderId)
        {
            var result = _adminRepository.GetOrderById(OrderId);
            return result;
        }
        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public Task<Product> GetProductById(int ProductId)
        {
            var result = _adminRepository.GetProductById(ProductId);
            return result;
        }
        /// <summary>
        /// Remove Category
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveCategory(int Id)
        {
            return await _adminRepository.RemoveCategory(Id);
        }
        /// <summary>
        /// Remove Product
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveProduct(int Id)
        {
            return await _adminRepository.RemoveProduct(Id);
        }
        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public Task<Category> UpdateCategory(int Id, Category category)
        {
            var result = _adminRepository.UpdateCategory(Id, category);
            return result;
        }
        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public Task<Product> UpdateProduct(int ProductId, Product product)
        {
            var result = _adminRepository.UpdateProduct(ProductId, product);
            return result;
        }
    }
}
