using GroceryEmart.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryEmart.BusinessLayer.Interfaces
{
    public interface IAdminGroceryServices
    {
        Task<Category> AddCategory(Category category);
        Task<bool> RemoveCategory(int Id);
        Task<Category> UpdateCategory(int Id, Category category);
        Task<Product> AddProduct(Product product);
        Task<bool> RemoveProduct(int ProductId);
        Task<Product> UpdateProduct(int ProductId, Product product);
        Task<Category> GetCategoryById(int Id);
        Task<Product> GetProductById(int ProductId);
        Task<ProductOrder> GetOrderById(int OrderId);
        Task<IEnumerable<ProductOrder>> AllOrder();
        Task<IEnumerable<Product>> AllProduct();
        Task<IEnumerable<ApplicationUser>> GetAllUser();
    }
}
