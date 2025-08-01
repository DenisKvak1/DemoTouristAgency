using ClientDemoAngular.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientDemoAngular.Server.DataBase.Configurations;

public class ClientConfigure : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");

        builder.Property(x => x.FirstName)
            .HasMaxLength(120)
            .IsRequired();
        builder.HasIndex(x => x.FirstName);

        builder
            .Property(x => x.LastName)
            .HasMaxLength(120)
            .IsRequired();
        builder.HasIndex(x => x.LastName);

        builder
            .Property(x => x.MiddleName)
            .HasMaxLength(120)
            .IsRequired();
        builder.HasIndex(x => x.MiddleName);

        builder
            .Property(x => x.Email)
            .HasMaxLength(320)
            .IsRequired();
        builder.HasIndex(x => x.Email);

        builder
            .HasMany(x=> x.Tags)
            .WithMany(x => x.Clients);

    }
}