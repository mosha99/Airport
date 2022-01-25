namespace Airport.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PasengerController : ControllerBase
{
    // GET: api/<PasengerController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<PasengerController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<PasengerController>
    [HttpPost]
    public void Post([FromBody] string value)
    {

    }

    // PUT api/<PasengerController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {

    }

    // DELETE api/<PasengerController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {

    }
}

