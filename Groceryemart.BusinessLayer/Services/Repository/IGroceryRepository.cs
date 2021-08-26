using GroceryEmart.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryEmart.BusinessLayer.Services.Repository
{
    public interface IGroceryRepository
    {
        //List of method to perform all related operation
        Task<bool> PlaceOrder(int ProductId, int UserId);
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProductById(int ProductId);
        Task<IEnumerable<Product>> GetProductByCategory(int CatId);
        Task<IEnumerable<Product>> ProductByName(string ProductName);
        IList<Category> CategoryList();
    }
}
