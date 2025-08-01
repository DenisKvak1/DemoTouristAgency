using ClientDemoAngular.Server.Domain.Entities;
using ClientDemoAngular.Server.Domain.Repositories;
using ClientDemoAngular.Server.ViewModels.Client;
using Microsoft.AspNetCore.Mvc;

namespace ClientDemoAngular.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController(IClientRepository _repository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClientVM model)
    {
        var client = new Client
        {
            Id = Guid.NewGuid(),
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            MiddleName = model.MiddleName,
            AllowNewSletter = model.AllowNewSletter,
            Phones = model.Phones.Select(phone => new ClientPhone
            {
                Id = Guid.NewGuid(),
                Number = phone.Number,
                SocialMedias = phone.SocialMedias.Select(id => new SocialMedia
                {
                    Id = id
                }).ToList()
            }).ToList(),
            Tags = model.Tags.Select(id => new ClientTag { Id = id }).ToList()
        };
        await _repository.AddItemAsync(client);

        return Ok();
    }
}