using ClientDemoAngular.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientDemoAngular.Server.DataBase.Configurations;

public class ClientTagConfigure : IEntityTypeConfiguration<ClientTag>
{
    public void Configure(EntityTypeBuilder<ClientTag> builder)
    {
        builder.ToTable("ClientTags");

        builder
            .Property(x => x.Name)
            .HasMaxLength(30)
            .IsRequired();

        builder
            .HasData([
                new ClientTag { Id = Guid.NewGuid(), Name = "VIP" },
                new ClientTag { Id = Guid.NewGuid(), Name = "Пляжный отдых" },
                new ClientTag { Id = Guid.NewGuid(), Name = "Гірнолижний отдых" },
                new ClientTag { Id = Guid.NewGuid(), Name = "Постоянный клиент" },
                new ClientTag { Id = Guid.NewGuid(), Name = "Экскурсионный отдых" },
                new ClientTag { Id = Guid.NewGuid(), Name = "Эконом" },
                new ClientTag { Id = Guid.NewGuid(), Name = "Активный отдых" },
                new ClientTag { Id = Guid.NewGuid(), Name = "Ездит один" },
                new ClientTag { Id = Guid.NewGuid(), Name = "Семейный отдых" }
            ]);
    }
}