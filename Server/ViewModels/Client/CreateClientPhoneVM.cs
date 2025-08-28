using System.ComponentModel.DataAnnotations;
using ClientDemoAngular.Server.Domain.Entities;

namespace ClientDemoAngular.Server.ViewModels.Client;

public record CreateClientPhoneVM(
    [Required] Guid ClientId,
    [Required] string Number,
    List<Guid> SocialMedias);