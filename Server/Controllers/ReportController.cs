namespace DrivingJournal.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController : ControllerBase
{
    private readonly DatabaseContext _context;

    public ReportController(DatabaseContext context)
    {
        _context = context;
    }

    // GET: api/Object/$count
    [HttpGet("$count")]
    public ActionResult<int> GetCount()
    {
        return _context.Reports.Count();
    }

    [HttpGet]
    [EnableQuery]
    public ActionResult<IQueryable<Report>> GetReports()
    {
        return Ok(_context.Reports);
    }

    // GET: api/Object/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Report>> GetReport(int id)
    {
        var domain = await _context.Reports.FindAsync(id);

        if (domain == null)
        {
            return NotFound();
        }

        return domain;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutReport(int id, Report report)
    {
        if (id != report.Id)
        {
            return BadRequest();
        }

        _context.Entry(report).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReportExists(id))
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
    public async Task<ActionResult<Report>> PostReport(Report report)
    {
        _context.Reports.Add(report);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetReport", new { id = report.Id }, report);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReport(int id)
    {
        var report = await _context.Reports.FindAsync(id);
        if (report == null)
        {
            return NotFound();
        }

        _context.Reports.Remove(report);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ReportExists(int id)
    {
        return _context.Reports.Any(e => e.Id == id);
    }
}

