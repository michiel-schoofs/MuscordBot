using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuscordBot.Domain;

namespace MuscordBot.Data.Mappers {
    class MuseumMapper : IEntityTypeConfiguration<Museum> {
        public void Configure(EntityTypeBuilder<Museum> builder) {
            builder.HasKey(m => m.Naam);

            builder
                .HasOne(m => m.Accesability)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(m => m.Likes)
                .IsRequired();
        }
    }
}
