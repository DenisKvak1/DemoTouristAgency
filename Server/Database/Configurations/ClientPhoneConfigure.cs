using ClientDemoAngular.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientDemoAngular.Server.DataBase.Configurations;

public class ClientPhoneConfigure : IEntityTypeConfiguration<ClientPhone>
{
    public void Configure(EntityTypeBuilder<ClientPhone> builder)
    {
        builder.ToTable("ClientsPhones");

        builder
            .Property(x => x.Number)
            .HasMaxLength(15)
            .IsRequired();
        builder.HasIndex(x => x.Number);

        builder
            .HasMany(x => x.SocialMedias)
            .WithMany(x => x.ClientPhones);

        builder
            .HasOne(x => x.Client)
            .WithMany(x => x.Phones)
            .HasForeignKey(x => x.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}