using ClientDemoAngular.Server.Domain.Entities;
using ClientDemoAngular.Server.Domain.Repositories;
using ClientDemoAngular.Server.Responses.Client;
using ClientDemoAngular.Server.ViewModels.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientDemoAngular.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController(IClientRepository _repository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClientRequest model)
    {
        await _repository.AddItemAsync(model.ToClient(true));

        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] ClientRequest model)
    {
        await _repository.UpdateItemAsync(model.ToClient());
        
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var client = await _repository.AllItems
            .Include(x => x.Phones)
            .ThenInclude(x => x.SocialMedias)
            .Include(x => x.Tags)
            .Include(x => x.Passport)
            .FirstOrDefaultAsync(x => x.Id == id);
        if(client == null) return NotFound();
        
        return Ok(ClientResponse.FromClient(client));
    }
}