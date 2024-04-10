using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configurations
{
    public class CoinConfigurations : IEntityTypeConfiguration<CoinEntity>
    {
        public void Configure(EntityTypeBuilder<CoinEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nominal).IsRequired();
            builder.Property(x => x.Available).HasDefaultValue(true);
            builder.Property(x => x.Count).IsRequired();
        }
    }
}
