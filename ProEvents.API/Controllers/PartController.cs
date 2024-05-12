
using Event.API.Services;
using Microsoft.AspNetCore.Mvc;
using ProEvents.Application.Dtos;

namespace Event.API.Controllers;

[ApiController]
[Route("api/parts/[controller]")]
public class PartController : ControllerBase
{
    private readonly IPartService partService;
    private readonly IWebHostEnvironment environment;

    public PartController(IPartService partService, IWebHostEnvironment environment)
    {
        this.environment = environment;
        this.partService = partService;
    }

    [HttpGet("{partId}")]
    public async Task<IActionResult> GetById(int partyId) => Ok(await partService.GetPartsByPartyId(partyId));

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PartDto dto, int id)
    {
        await partService.AddPart(id, dto);
        return Ok();
    }

    [HttpDelete("{partyId}/{id}")]
    public async Task<IActionResult> Delete(int partyId, int id)
    {
        await partService.Remove(partyId, id);
        return Ok();
    }

    [HttpPut("{partyId}")]
    public async Task<IActionResult> Update([FromBody] PartDto[] dto, int partyId)
    {
        var party = await partService.Update(partyId, dto);
        return Ok(party);
    }

}
