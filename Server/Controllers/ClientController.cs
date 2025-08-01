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
        await _repository.AddItemAsync(model.ToClient());
        
        return Ok();
    }
}