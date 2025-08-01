using ClientDemoAngular.Server.Domain.Abstract;

namespace ClientDemoAngular.Server.Domain.Entities;

public class ClientPhone : DbEntity
{
    public required string Number { get; set; }

    public Guid ClientId { get; set; }
    public Client Client { get; set; }
    public List<SocialMedia> SocialMedias { get; set; } = [];
}