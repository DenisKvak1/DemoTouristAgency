using ClientDemoAngular.Server.Domain.Entities;

namespace ClientDemoAngular.Server.ViewModels.Client;

public record CreateClientVM(
    string FirstName,
    string LastName,
    string MiddleName,
    string Email,
    bool AllowNewSletter,
    CreatePassportVM? Passport,
    List<CreateClientPhoneVM> Phones,
    List<Guid> Tags
)
{
    public Domain.Entities.Client ToClient()
    {
        var allIdsSocialMedias = Phones.SelectMany(p => p.SocialMedias).Distinct().ToList();
        var socialMediaMap = allIdsSocialMedias.ToDictionary(id => id, id => new SocialMedia { Id = id });

        return new Domain.Entities.Client
        {
            Id = Guid.NewGuid(),
            Email = this.Email,
            FirstName = this.FirstName,
            LastName = this.LastName,
            MiddleName = this.MiddleName,
            AllowNewSletter = this.AllowNewSletter,
            Passport = Passport != null
                ? new ClientPassport
                {
                    Id = Guid.NewGuid(),
                    SerialNumber = Passport.SerialNumber,
                    FirstName = Passport.FirstName,
                    LastName = Passport.LastName,
                    Nationality = Passport.Nationality,
                    BirthDate = Passport.BirthDate,
                    Gender = Passport.Gender,
                    PlaceOfBirth = Passport.PlaceOfBirth,
                    DateOfIssue = Passport.DateOfIssue,
                    DateOfExpiry = Passport.DateOfExpiry,
                    Record = Passport.Record,
                    Authority = Passport.Authority
                }
                : null,
            Phones = Phones.Select(phone => new ClientPhone
            {
                Id = Guid.NewGuid(),
                Number = phone.Number,
                SocialMedias = phone.SocialMedias.Select(id => socialMediaMap[id]).ToList()
            }).ToList(),
            Tags = Tags.Select(id => new ClientTag { Id = id }).ToList()
        };
    }
};