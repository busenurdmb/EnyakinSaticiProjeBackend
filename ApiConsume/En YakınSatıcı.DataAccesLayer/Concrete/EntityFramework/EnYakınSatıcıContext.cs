using Core.Entities.Concrete;
using En_YakınSatıcı.DataAccesLayer.Configurtaions;
using EnYakınSatıcı.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace En_YakınSatıcı.DataAccesLayer.Concrete.EntityFramework
{
    //Context:Db Tabloları ile proje classlarını bağlamak
    public class EnYakınSatıcıContext:DbContext
    {
        //Hangi veritabanı
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-493DFJA\\SQLEXPRESS;database=EnYakinSaticiDB;integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfigurations());
        }

        //veri tabanında Hnagi tabloya ne karşılık geliyor
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
