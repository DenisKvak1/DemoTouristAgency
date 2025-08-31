using System.ComponentModel.DataAnnotations;
using ClientDemoAngular.Server.Domain.Entities;

namespace ClientDemoAngular.Server.ViewModels.Client;

public record ClientRequest(
    Guid Id,
    [Required] string FirstName,
    [Required] string LastName,
    [Required] string MiddleName,
    [Required] string Email,
    [Required] bool AllowNewSletter,
    PassportRequest? Passport,
    List<ClientPhoneRequest> Phones,
    List<Guid> Tags
)
{
    public Domain.Entities.Client ToClient(bool newEntity = false)
    {
        var allIdsSocialMedias = Phones.SelectMany(p => p.SocialMedias).Distinct().ToList();
        var socialMediaMap = allIdsSocialMedias.ToDictionary(id => id, id => new SocialMedia { Id = id });

        return new Domain.Entities.Client
        {
            Id = newEntity ? Guid.NewGuid() : Id,
            Email = this.Email,
            FirstName = this.FirstName,
            LastName = this.LastName,
            MiddleName = this.MiddleName,
            AllowNewSletter = this.AllowNewSletter,
            Passport = Passport != null
                ? new ClientPassport
                {
                    Id = newEntity ? Guid.NewGuid() : Passport.Id,
                    ClientId = Id,
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
                Id = newEntity ? Guid.NewGuid() : phone.Id,
                ClientId = Id,
                Number = phone.Number,
                SocialMedias = phone.SocialMedias.Select(id => socialMediaMap[id]).ToList()
            }).ToList(),
            Tags = Tags.Select(id => new ClientTag { Id = id }).ToList()
        };
    }
};