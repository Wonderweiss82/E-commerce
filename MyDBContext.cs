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



            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(Localhost)\;Database=NameOfDatabase;Trusted_Connection=True;
                MultipleActiveResultSets=true");
            }
        }
    }

