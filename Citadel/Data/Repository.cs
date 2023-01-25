using Citadel.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Citadel.Data
{
    public class Repository : DbContext
    {
        public virtual DbSet<NameModel> Names { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "NamesDb");
        }
    }
}
