using ClientDemoAngular.Server.Domain.Entities;
using ClientDemoAngular.Server.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClientDemoAngular.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientTagController(IClientTagRepository _repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var tags = (await _repository.ToListAsync()).Select(x => new { id = x.Id, name = x.Name });

        return Ok(tags);
    }
}