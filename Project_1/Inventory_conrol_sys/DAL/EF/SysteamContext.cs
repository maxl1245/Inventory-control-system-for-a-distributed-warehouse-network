using System;
using DAL.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class SysteamContext
        : DbContext
    {
        public DbSet<Systeam> Phones { get; set; }
        public DbSet<Shop> Orders { get; set; }
        public SysteamContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
