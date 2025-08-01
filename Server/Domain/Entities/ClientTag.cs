using ClientDemoAngular.Server.Domain.Abstract;

namespace ClientDemoAngular.Server.Domain.Entities;

public class ClientTag : DbEntity
{
    public string Name { get; set; }

    public List<Client> Clients { get; set; } = [];
}