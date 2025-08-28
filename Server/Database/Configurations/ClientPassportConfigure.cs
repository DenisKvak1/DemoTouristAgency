using ClientDemoAngular.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientDemoAngular.Server.DataBase.Configurations;

public class ClientPassportConfigure : IEntityTypeConfiguration<ClientPassport>
{
    public void Configure(EntityTypeBuilder<ClientPassport> builder)
    {
        builder.ToTable("ClientsPassports");

        builder
            .Property(x => x.SerialNumber)
            .HasMaxLength(100)
            .IsRequired();
        builder.HasIndex(x => x.SerialNumber);

        builder
            .Property(x => x.FirstName)
            .HasMaxLength(100)
            .IsRequired();
        builder.HasIndex(x => x.FirstName);

        builder
            .Property(x => x.LastName)
            .HasMaxLength(100)
            .IsRequired();
        builder.HasIndex(x => x.LastName);

        builder
            .Property(x => x.Nationality)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.BirthDate)
            .HasColumnType("date");

        builder
            .Property(p => p.Gender)
            .HasConversion<string>()
            .HasMaxLength(30);
        
        builder
            .Property(x => x.PlaceOfBirth)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(e => e.DateOfIssue)
            .HasColumnType("date");
        
        builder.Property(e => e.DateOfExpiry)
            .HasColumnType("date");
        
        builder
            .Property(x => x.Record)
            .HasMaxLength(50)
            .IsRequired();
                
        builder
            .Property(x => x.Authority)
            .IsRequired();
    }
}