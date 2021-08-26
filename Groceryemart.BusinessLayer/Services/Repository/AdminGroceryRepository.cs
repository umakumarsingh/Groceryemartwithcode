using GroceryEmart.DataLayer;
using GroceryEmart.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace GroceryEmart.BusinessLayer.Services.Repository
{
    public class AdminGroceryRepository : IAdminGroceryRepository
    {
        /// <summary>
        /// Creating referance Variable of DbContext
        /// </summary>
        private readonly GroceryemartDbContext _groceryemartDbContext;
        /// <summary>
        /// Injecting Referance variable in AdminGroceryRepository class Constructor
        /// </summary>
        /// <param name="context"></param>
        public AdminGroceryRepository(GroceryemartDbContext groceryemartDbContext)
        {
            _groceryemartDbContext = groceryemartDbContext;
        }
        /// <summary>
        /// Add New Category in Sql database table
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<Category> AddCategory(Category category)
        {
            try
            {
                if (category == null)
                {
                    throw new ArgumentNullException(typeof(Category).Name + "Object is Null");
                }
                await _groceryemartDbContext.categories.AddAsync(category);
                await _groceryemartDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            return category;
        }
        /// <summary>
        /// Add New Product In sql product table
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException(typeof(Product).Name + "Object is Null");
                }
                await _groceryemartDbContext.products.AddAsync(product);
                await _groceryemartDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            }
            return product;
        }
        /// <summary>
        /// Get All order from ProductOrder table
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductOrder>> AllOrder()
        {
            try
            {
                return await _groceryemartDbContext.productOrders.OrderByDescending(x => x.OrderId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get all Product from product table
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> AllProduct()
        {
            try
            {
                return await _groceryemartDbContext.products.OrderByDescending(x => x.ProductName).ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get all User from ApplicationUser table
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUser>> GetAllUser()
        {
            try
            {
                return await _groceryemartDbContext.users.OrderByDescending(x => x.UserId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get category by CategoryId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Category> GetCategoryById(int Id)
        {
            try
            {
                return await _groceryemartDbContext.categories
                                 .Where(x => x.CatId == Id)
                                 .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get ordere by Order Id
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public async Task<ProductOrder> GetOrderById(int OrderId)
        {
            try
            {
                return await _groceryemartDbContext.productOrders
                                 .Where(x => x.OrderId == OrderId)
                                 .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get product by Id from Product tbale
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public async Task<Product> GetProductById(int ProductId)
        {
            try
            {
                return await _groceryemartDbContext.products.Where(x => x.ProductId == ProductId)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Remove category from Category tbale
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveCategory(int Id)
        {
            try
            {
                bool res = false;
                if(_groceryemartDbContext != null)
                {
                    var cat = await _groceryemartDbContext.categories.Where(x => x.Id == Id)
                    .FirstOrDefaultAsync();
                    if(cat != null)
                    {
                        _groceryemartDbContext.categories.Remove(cat);
                        await _groceryemartDbContext.SaveChangesAsync();
                    }
                    res = true;
                }
                return res;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Remove Product from Product table
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public async Task<bool> RemoveProduct(int ProductId)
        {
            try
            {
                bool res = false;
                if (_groceryemartDbContext != null)
                {
                    var pro = await _groceryemartDbContext.products.Where(x => x.ProductId == ProductId)
                    .FirstOrDefaultAsync();
                    if (pro != null)
                    {
                        _groceryemartDbContext.products.Remove(pro);
                        await _groceryemartDbContext.SaveChangesAsync();
                    }
                    res = true;
                }
                return res;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Upadet category in sql Category table
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<Category> UpdateCategory(int Id, Category category)
        {
            if (category == null && Id <= 0)
            {
                throw new ArgumentNullException(typeof(Category).Name + "Object or may be CategoryId is Null");
            }
            var cat = await _groceryemartDbContext.categories.Where(x => x.Id == Id)
                    .FirstOrDefaultAsync();
            if(cat != null)
            {
                cat.CatId = category.CatId;
                cat.Title = category.Title;
                cat.Url = category.Url;
                cat.OpenInNewWindow = category.OpenInNewWindow;

                await _groceryemartDbContext.SaveChangesAsync();
            }
            return category;
        }
        /// <summary>
        /// Upadet Product in Sql Product table
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<Product> UpdateProduct(int Id, Product product)
        {
            if (product == null && Id <= 0)
            {
                throw new ArgumentNullException(typeof(Product).Name + "Object or may be CategoryId is Null");
            }
            var pro = await _groceryemartDbContext.products.Where(x => x.ProductId == Id).FirstOrDefaultAsync();
            if(pro != null)
            {
                pro.ProductName = product.ProductName;
                pro.Description = product.Description;
                pro.Amount = product.Amount;
                pro.stock = product.stock;
                pro.photo = product.photo;
                pro.CatId = product.CatId;

                await _groceryemartDbContext.SaveChangesAsync();
            }
            return product;
        }
    }
}
