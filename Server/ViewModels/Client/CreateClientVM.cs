using ClientDemoAngular.Server.Domain.Entities;

namespace ClientDemoAngular.Server.ViewModels.Client;

public record CreateClientVM(
    string FirstName,
    string LastName,
    string MiddleName,
    string Email,
    bool AllowNewSletter,
    List<CreateClientPhoneVM> Phones,
    List<Guid> Tags
);