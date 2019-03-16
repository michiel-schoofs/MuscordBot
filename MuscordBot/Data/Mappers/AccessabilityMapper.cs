using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuscordBot.Domain;

namespace MuscordBot.Data.Mappers {
    public class AccessabilityMapper : IEntityTypeConfiguration<Accesability> {
        public void Configure(EntityTypeBuilder<Accesability> builder) {
            builder.ToTable("Accessability");

            builder.HasKey(a => a.id);
        }
    }
}
