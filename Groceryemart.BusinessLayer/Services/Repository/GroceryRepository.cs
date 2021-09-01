using GroceryEmart.DataLayer;
using GroceryEmart.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryEmart.BusinessLayer.Services.Repository
{
    public class GroceryRepository : IGroceryRepository
    {
        /// <summary>
        /// Creating referance Variable of DbContext
        /// </summary>
        private readonly GroceryemartDbContext _groceryemartDbContext;
        public GroceryRepository(GroceryemartDbContext groceryemartDbContext)
        {
            _groceryemartDbContext = groceryemartDbContext;
        }
        /// <summary>
        /// Get All Poduct from Product table
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            try
            {
                var result = await _groceryemartDbContext.products.
                OrderByDescending(x => x.ProductId).Take(10).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get Product from Product table by Product Id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public async Task<Product> GetProductById(int ProductId)
        {
            try
            {
                return await _groceryemartDbContext.products.FirstOrDefaultAsync(m => m.ProductId == ProductId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get List of Category from Category table
        /// </summary>
        /// <returns></returns>
        public IList<Category> CategoryList()
        {
            try
            {
                var list = _groceryemartDbContext.categories.ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Place Order and verify registred user
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<bool> PlaceOrder(int ProductId, int UserId)
        {
            try
            {
                var res = false;
                if(ProductId > 0 && UserId > 0)
                {
                    var findProduct = _groceryemartDbContext.products.FirstOrDefault(p => p.ProductId == ProductId);
                    if (findProduct != null)
                    {
                        var order = new ProductOrder()
                        {
                            ProductId = findProduct.ProductId,
                            UserId = UserId
                        };
                        await _groceryemartDbContext.AddAsync(order);
                        await _groceryemartDbContext.SaveChangesAsync();
                    }
                    res = true;
                }
                else
                {
                    return false;
                }
                return res;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get product by name from Product table
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> ProductByName(string ProductName)
        {
            try
            {
                return await _groceryemartDbContext.products.Where(x => x.ProductName == ProductName)
                    .Take(10).ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get product by categoryId from Product table
        /// </summary>
        /// <param name="CatId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProductByCategory(int CatId)
        {
            try
            {
                return await _groceryemartDbContext.products.Where(x => x.CatId == CatId).Take(10).ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
