using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TesteSoftDesign.Domain.Entity;

namespace TesteSoftDesign.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Rental> Rental { get; set; }

        public DataContext() : base("connection")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }

}