using Event.API.Data;
using Event.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Event.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PartyController : ControllerBase
{
    private readonly DataContext context;

    public PartyController(DataContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public IEnumerable<Party> Get()
    {
        return this.context.Parties;
    }

    [HttpGet("{id}")]
    public Party GetById(int id) => context.Parties.FirstOrDefault(ev => ev.Id == id);

    [HttpPost]
    public ActionResult<Party> Post([FromBody] Party party)
    {
        context.Parties.Add(party);
        context.SaveChanges();
        return Ok();
    }

}
