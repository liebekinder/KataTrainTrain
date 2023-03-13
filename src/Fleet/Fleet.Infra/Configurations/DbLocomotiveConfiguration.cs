using Fleet.Infra.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fleet.Infra.Configurations;

internal sealed class DbLocomotiveConfiguration : IEntityTypeConfiguration<DbLocomotive>
{
    public void Configure(EntityTypeBuilder<DbLocomotive> builder)
    {
        builder.ToTable("Locomotive");

        builder.Property(l => l.Name)
            .HasMaxLength(256);

        builder.Property(l => l.Brand)
            .HasMaxLength(256);

        builder.Property(l => l.Model)
            .HasConversion(new EnumToStringConverter<DbLocomotiveModel>());

        builder.Property(l => l.WeightInTons)
            .HasPrecision(10, 3);

        builder.Property(l => l.MaxTractionInTons)
            .HasPrecision(10, 3);
    }
}

