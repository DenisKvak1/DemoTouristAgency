using ClientDemoAngular.Server.Domain.Entities;

namespace Server.Responses.Client;

public record ClientSocialMediaResponse(
    Guid Id,
    string Name
)
{
    public static ClientSocialMediaResponse FromSocialMedia(SocialMedia phone)
    {
        return new ClientSocialMediaResponse(
            phone.Id,
            phone.Name
        );
    }
};