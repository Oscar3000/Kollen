using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductApp.Models
{
    public class DataContext:IdentityDbContext<ApplicationUser>
    {
        public DataContext():base("Kollen", throwIfV1Schema: false) { }

        public static DataContext Create()
        {
            return new DataContext();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<SubscribeModel> EmailingList { get; set; }
    }
}