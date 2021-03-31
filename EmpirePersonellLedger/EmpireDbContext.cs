using EmpirePersonellLedger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace EmpirePersonellLedger
{
    public class EmpireDbContext : DbContext
    {
        public EmpireDbContext(DbContextOptions<EmpireDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Trooper>()
                .HasKey(trooper => trooper.TrooperId);

            modelBuilder
                .Entity<Trooper>()
                .Property(trooper => trooper.TrooperId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .IsRequired();

            modelBuilder
                .Entity<TrooperType>()
                .HasKey(trooperType => trooperType.TypeName);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Trooper> Troopers { get; set; }
        public DbSet<TrooperType> TrooperTypes { get; set; }
    }
}
