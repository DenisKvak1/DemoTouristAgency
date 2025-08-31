using System.ComponentModel.DataAnnotations;
using ClientDemoAngular.Server.Domain.Entities;

namespace ClientDemoAngular.Server.ViewModels.Client;

public record ClientPhoneRequest(
    Guid Id,
    [Required] string Number,
    List<Guid> SocialMedias);