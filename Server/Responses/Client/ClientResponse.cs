using Server.Responses.Client;

namespace ClientDemoAngular.Server.Responses.Client;

public record ClientResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string MiddleName,
    string Email,
    bool AllowNewSletter,
    ClientPassportResponse? Passport,
    List<ClientPhoneResponse> Phones,
    List<ClientTagResponse> Tags
)
{
    public static ClientResponse FromClient(Domain.Entities.Client client)
    {
        return new ClientResponse(
            client.Id,
            client.FirstName,
            client.LastName,
            client.MiddleName,
            client.Email,
            client.AllowNewSletter,
            client.Passport != null ? ClientPassportResponse.FromPassport(client.Passport) : null,
            client.Phones.Select(ClientPhoneResponse.FromPhone).ToList(),
            client.Tags.Select(ClientTagResponse.FromTag).ToList()
        );
    }
};