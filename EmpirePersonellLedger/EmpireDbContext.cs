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
                .HasKey(t => t.TrooperId);
            modelBuilder
                .Entity<Trooper>()
                .Property(t => t.TrooperId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .IsRequired();

            modelBuilder
                .Entity<TrooperType>()
                .HasKey(tt => tt.TypeName);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Trooper> Troopers { get; set; }
        public DbSet<TrooperType> TrooperTypes { get; set; }
    }
}
