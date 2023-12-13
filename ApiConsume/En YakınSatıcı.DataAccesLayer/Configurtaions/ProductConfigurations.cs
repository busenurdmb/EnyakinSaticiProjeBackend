using EnYakınSatıcı.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace En_YakınSatıcı.DataAccesLayer.Configurtaions
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // builder.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
            //veya
           builder.Property(x => x.UnitPrice).HasPrecision(18,2);       
}
    }
}
