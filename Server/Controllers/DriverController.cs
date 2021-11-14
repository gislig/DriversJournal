namespace DrivingJournal.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class DriverController : ControllerBase
{
    private readonly DatabaseContext _context;

    public DriverController(DatabaseContext context)
    {
        _context = context;
    }

    // GET: api/Object/$count
    [HttpGet("$count")]
    public ActionResult<int> GetCount()
    {
        return _context.Drivers.Count();
    }

    [HttpGet]
    [EnableQuery]
    public ActionResult<IQueryable<Driver>> GetDrivers()
    {
        return Ok(_context.Drivers);
    }

    // GET: api/Object/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Driver>> GetDriver(int id)
    {
        var domain = await _context.Drivers.FindAsync(id);

        if (domain == null)
        {
            return NotFound();
        }

        return domain;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDriver(int id, Driver driver)
    {
        if (id != driver.Id)
        {
            return BadRequest();
        }

        _context.Entry(driver).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DriverExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Driver>> PostDriver(Driver driver)
    {
        _context.Drivers.Add(driver);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDriver", new { id = driver.Id }, driver);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDriver(int id)
    {
        var driver = await _context.Drivers.FindAsync(id);
        if (driver == null)
        {
            return NotFound();
        }

        _context.Drivers.Remove(driver);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DriverExists(int id)
    {
        return _context.Drivers.Any(e => e.Id == id);
    }
}

