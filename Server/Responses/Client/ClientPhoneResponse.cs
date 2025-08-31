using ClientDemoAngular.Server.Domain.Entities;
using Server.Responses.Client;

namespace ClientDemoAngular.Server.Responses.Client;

public record ClientPhoneResponse(
    Guid Id,
    string Number,
    List<ClientSocialMediaResponse> SocialMedias
)
{
    public static ClientPhoneResponse FromPhone(ClientPhone phone)
    {
        return new ClientPhoneResponse(
            phone.Id,
            phone.Number,
            phone.SocialMedias
                .Select(ClientSocialMediaResponse.FromSocialMedia)
                .ToList()
        );
    }
};