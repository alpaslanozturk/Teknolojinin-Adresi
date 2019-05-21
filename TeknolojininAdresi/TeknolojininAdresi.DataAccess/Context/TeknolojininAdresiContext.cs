using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TeknolojininAdresi.Entities.Concrete;

namespace TeknolojininAdresi.DataAccess.Context
{
    public class TeknolojininAdresiContext : DbContext
    {
        public TeknolojininAdresiContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<CartLines> CartLines { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Pictures> Pictures { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
    }
}
