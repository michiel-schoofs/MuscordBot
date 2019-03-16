using Microsoft.EntityFrameworkCore;
using MuscordBot.Data.Mappers;
using MuscordBot.Domain;

namespace MuscordBot.Data {
    class ApplicationDbContext:DbContext {
        public DbSet<Museum> Musea { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Muscord;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                        .ApplyConfiguration<Museum>(new MuseumMapper())
                        .ApplyConfiguration<Accesability>(new AccessabilityMapper());
        }
    }
}
