using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DespendingDbContext : DbContext
    {
        public DespendingDbContext(DbContextOptions<DespendingDbContext> options) : base(options)
        { 
            
        }
        public DbSet<GoodEntity> Goods { get; set; }
        public DbSet<CoinEntity> Coins { get; set; }

        public DbSet<MachineEntity> Secret { get; set; }

    }
}
