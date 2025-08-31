using ClientDemoAngular.Server.Domain.Entities;

namespace ClientDemoAngular.Server.Responses;

public record ClientPassportResponse(
    Guid Id,
    string SerialNumber,
    string FirstName,
    string LastName,
    string Nationality,
    DateOnly BirthDate,
    Sex Gender,
    string PlaceOfBirth,
    DateOnly DateOfIssue,
    DateOnly DateOfExpiry,
    string Record,
    int Authority
)
{
    public static ClientPassportResponse FromPassport(ClientPassport passport)
    {
        return new ClientPassportResponse(
            passport.Id,
            passport.SerialNumber,
            passport.FirstName,
            passport.LastName,
            passport.Nationality,
            passport.BirthDate,
            passport.Gender,
            passport.PlaceOfBirth,
            passport.DateOfIssue,
            passport.DateOfExpiry,
            passport.Record,
            passport.Authority
        );
    }
};