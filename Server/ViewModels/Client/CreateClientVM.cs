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
)
{
    public Domain.Entities.Client ToClient()
    {
        return new Domain.Entities.Client
        {
            Id = Guid.NewGuid(),
            Email = this.Email,
            FirstName = this.FirstName,
            LastName = this.LastName,
            MiddleName = this.MiddleName,
            AllowNewSletter = this.AllowNewSletter,
            Phones = this.Phones.Select(phone => new ClientPhone
            {
                Id = Guid.NewGuid(),
                Number = phone.Number,
                SocialMedias = phone.SocialMedias.Select(id => new SocialMedia
                {
                    Id = id
                }).ToList()
            }).ToList(),
            Tags = this.Tags.Select(id => new ClientTag { Id = id }).ToList()
        };
    }
};