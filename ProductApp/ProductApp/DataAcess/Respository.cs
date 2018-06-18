using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductApp.Models;
using System.Data.Entity;

namespace ProductApp.DataAccess
{
    public class Respository : IRepository
    {
        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> getAllProducts()
        {
            using(var context = new DataContext())
            {
                return context.Products.AsNoTracking().OrderByDescending(n=>n.ProductId).ToList();
            }
        }

        public IList<SubscribeModel> getEmails()
        {
            throw new NotImplementedException();
        }

        public Product getProductById(int? id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> getProductsByCategory(string name)
        {
            throw new NotImplementedException();
        }

        public IList<Product> getProductsByPriceRange()
        {
            throw new NotImplementedException();
        }

        public IList<Product> getProductsByType(string name)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicationUser> getUsers()
        {
            throw new NotImplementedException();
        }

        public void CreateProduct(Product product)
        {
            using(var context = new DataContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            using(var context = new DataContext())
            {
                context.Entry(product).State = EntityState.Modified;
                if(product.Picture == null)
                {
                    context.Entry(product).Property(n => n.Picture).IsModified = false;
                }
                context.SaveChanges();
            }
        }

        public Product getProduct(string name, int? code, string category)
        {
            using(var context = new DataContext())
            {
                return context.Products.Where(n => n.Name == name && n.ProductId == code && n.Category == category).FirstOrDefault();
            }
        }
    }
}