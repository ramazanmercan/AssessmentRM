using GuideFinder.API.Model;
using GuideFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideFinder.DataAccess
{
    public class GuideDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-AL25QRA\\RAMAZAN01; Database=GuideDb; uid=sa; pwd=1234;;TrustServerCertificate=True");
        }

        public DbSet<Guide> Guides { get; set; }
        public DbSet<GuideDetail> GuideDetails { get; set; }
        public DbSet<ReportType> ReportTypes { get; set; }
    }
}
