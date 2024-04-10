using DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configurations
{
    public class MachineConfigurations : IEntityTypeConfiguration<MachineEntity>
    {
        public void Configure(EntityTypeBuilder<MachineEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Secret).IsRequired();
        }
    }
}
