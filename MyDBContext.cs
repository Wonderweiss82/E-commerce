using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce.Model;


namespace E_commerce
{
    internal class MyDBContext : DbContext
    {

        
            public DbSet<Product> Product { get; set; }
            public DbSet<Categorie> Categorie { get; set; }
            
            public DbSet<Klant> Klant { get; set; }

            public DbSet<Bestelling> Bestellings { get; set; }

            public DbSet<BestelRegel> BestelRegels { get; set; }



            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=E-Commerce;Trusted_Connection=True;
                MultipleActiveResultSets=true;TrustServerCertificate=true");
            }
        }
    }

