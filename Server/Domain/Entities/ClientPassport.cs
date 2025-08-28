using System.Text.Json.Serialization;
using ClientDemoAngular.Server.Domain.Abstract;

namespace ClientDemoAngular.Server.Domain.Entities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Sex
{
    MALE,
    FEMALE
}


public class ClientPassport : DbEntity
{
    public string SerialNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nationality { get; set; }
    public DateOnly BirthDate { get; set; }
    public Sex Gender { get; set; }
    public string PlaceOfBirth { get; set; }
    public DateOnly DateOfIssue { get; set; }
    public DateOnly DateOfExpiry { get; set; }
    public string Record { get; set; }
    public int Authority { get; set; }
    
    public Client Client { get; set; }
    public Guid ClientId { get; set; }
}