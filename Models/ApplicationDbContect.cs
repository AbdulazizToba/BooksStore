using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class ApplicationDbContect : DbContext
    {
        public ApplicationDbContect() : base("DefualtConnection")
        {
                
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}