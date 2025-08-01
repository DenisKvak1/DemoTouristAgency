using ClientDemoAngular.Server.Domain.Abstract;

namespace ClientDemoAngular.Server.Domain.Entities;

public class SocialMedia : DbEntity
{
    public string Name { get; set; }
    public string SecretKey { get; set; }

    public List<ClientPhone> ClientPhones { get; set; } = [];
}