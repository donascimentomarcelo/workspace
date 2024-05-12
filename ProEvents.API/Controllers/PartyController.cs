
using Event.API.Services;
using Microsoft.AspNetCore.Mvc;
using ProEvents.Application.Dtos;

namespace Event.API.Controllers;

[ApiController]
[Route("api/parties/[controller]")]
public class PartyController : ControllerBase
{
    private readonly IPartyService partyService;

    public PartyController(IPartyService partyService)
    {
        this.partyService = partyService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var parties = await partyService.GetAllPartiesAsync(true);
        return Ok(parties);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) => Ok(await partyService.GetPartyByIdAsync(id, true));

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PartyDto dto)
    {
        var party = await partyService.Add(dto);
        return Ok(party);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await partyService.Remove(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] PartyDto dto, int id)
    {
        var party = await partyService.Update(id, dto);
        return Ok(party);
    }

    [HttpPost("upload-image/{partyId}")]
    public async Task<IActionResult> UploadImage(int partyId)
    {
        var file = Request.Form.Files[0];
        await partyService.UploadImageParty(partyId, file);
        return Ok();
    }

}
