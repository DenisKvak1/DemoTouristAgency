using System.ComponentModel.DataAnnotations;
using ClientDemoAngular.Server.Domain.Entities;

namespace ClientDemoAngular.Server.ViewModels.Client;

public record CreatePassportVM(
    [Required] string SerialNumber,
    [Required] string FirstName,
    [Required] string LastName,
    [Required] string Nationality,
    [Required] DateOnly BirthDate,
    [Required] Sex Gender,
    [Required] string PlaceOfBirth,
    [Required] DateOnly DateOfIssue,
    [Required] DateOnly DateOfExpiry,
    [Required] string Record,
    [Required] int Authority,
    Guid ClientId
);