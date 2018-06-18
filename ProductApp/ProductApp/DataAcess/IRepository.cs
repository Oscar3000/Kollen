using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApp.DataAccess
{
    public interface IRepository
    {
        IList<ApplicationUser> getUsers();
        IList<Product> getAllProducts();
        IList<Product> getProductsByCategory(string name);
        IList<Product> getProductsByType(string name);
        IList<Product> getProductsByPriceRange();
        IList<SubscribeModel> getEmails();
        Product getProductById(int? id);
        Product getProduct(string name, int? code, string category);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}