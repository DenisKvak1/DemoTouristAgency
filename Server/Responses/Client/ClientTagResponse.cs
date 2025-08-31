using ClientDemoAngular.Server.Domain.Entities;

namespace Server.Responses.Client;

public record ClientTagResponse(
    Guid Id,
    string Name
)
{
    public static ClientTagResponse FromTag(ClientTag phone)
    {
        return new ClientTagResponse(
            phone.Id,
            phone.Name
        );
    }
};