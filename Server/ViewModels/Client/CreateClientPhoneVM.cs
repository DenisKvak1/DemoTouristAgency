using ClientDemoAngular.Server.Domain.Entities;

namespace ClientDemoAngular.Server.ViewModels.Client;

public record CreateClientPhoneVM(Guid ClientId, string Number, List<Guid> SocialMedias);