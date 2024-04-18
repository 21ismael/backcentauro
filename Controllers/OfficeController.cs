using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace MyApp.Namespace
{
    [Route("api/office")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly ILogger<OfficeController> _logger;
        private readonly DataContext _context;
        public OfficeController(ILogger<OfficeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "getOffices")]
        public async Task<ActionResult<IEnumerable<Office>>> GetOffices()
        {
            return await _context.Offices.ToListAsync();
        }

        [HttpGet("{id}", Name = "getOffice")]
        public async Task<ActionResult<Office>> GetOffice(int id)
        {
            var office = await _context.Offices.FindAsync(id);

            if (office == null)
            {
                return NotFound();
            }

            return office;
        }

        [HttpGet("name/{name}", Name = "getOfficeByName")]
        public async Task<ActionResult<Office>> GetOfficeByName(string name)
        {
            var office = await _context.Offices.FirstOrDefaultAsync(o => o.Name.ToLower() == name.ToLower());

            if (office == null)
            {
                return NotFound();
            }

            return office;
        }

        [HttpPost]
        public async Task<ActionResult<Office>> Post(Office office)
        {
            _context.Offices.Add(office);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetOffice", new { id = office.Id }, office);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Office>> Put(int id, Office office)
        {
            if (id != office.Id)
            {
                return BadRequest();
            }

            _context.Entry(office).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Office>> Delete(int id)
        {
            var office = await _context.Offices.FindAsync(id);

            if (office == null)
            {
                return NotFound();
            }

            _context.Offices.Remove(office);
            await _context.SaveChangesAsync();

            return office;
        }

        /*[HttpGet("office-names")]
        public async Task<ActionResult<IEnumerable<string>>> GetOfficeNames()
        {
            var uniqueNames = await _context.Offices
                                          .Select(o => o.Name)
                                          .Distinct()
                                          .Where(name => name != null)
                                          .Select(name => name!)
                                          .ToListAsync();
            return Ok(uniqueNames);
        }*/
    }
}
