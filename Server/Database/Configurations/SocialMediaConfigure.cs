using ClientDemoAngular.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientDemoAngular.Server.DataBase.Configurations;

public class SocialMediaConfigure : IEntityTypeConfiguration<SocialMedia>
{
    public void Configure(EntityTypeBuilder<SocialMedia> builder)
    {
        builder.ToTable("SocialMedias");

        builder.Property(x => x.Name)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(x => x.SecretKey)
            .HasMaxLength(120)
            .IsRequired();

        builder
            .HasData([
                new SocialMedia { Id = Guid.NewGuid(), Name = "SMS", SecretKey = "" },
                new SocialMedia { Id = Guid.NewGuid(), Name = "Telegram", SecretKey = "" },
                new SocialMedia { Id = Guid.NewGuid(), Name = "Viber", SecretKey = "" },
                new SocialMedia { Id = Guid.NewGuid(), Name = "WhatsApp", SecretKey = "" },
            ]);
    }
}