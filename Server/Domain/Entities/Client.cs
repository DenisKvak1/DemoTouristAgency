using ClientDemoAngular.Server.Domain.Abstract;

namespace ClientDemoAngular.Server.Domain.Entities;

public class Client : DbEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string MiddleName { get; set; }
    public required string Email { get; set; }
    public required bool AllowNewSletter { get; set; }

    public List<ClientPhone> Phones { get; set; } = [];
    public List<ClientTag> Tags { get; set; } = [];
    public ClientPassport? Passport { get; set; }
}