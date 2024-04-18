using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace MyApp.Namespace
{
    [Route("api/fleet")]
    [ApiController]
    public class FleetController : ControllerBase
    {
        private readonly ILogger<FleetController> _logger;
        private readonly DataContext _context;
        public FleetController(ILogger<FleetController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetFleet")]
        public async Task<ActionResult<IEnumerable<Fleet>>> GetFleet()
        {
            var fleet = await _context.Fleet.ToListAsync();
            return fleet;
        }

        [HttpPost]
        public async Task<ActionResult<Fleet>> Post(Fleet fleet)
        {
            _context.Fleet.Add(fleet);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetFleet", new { id = fleet.Id }, fleet);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Fleet>> Put(int id, Fleet fleet)
        {
            if (id != fleet.Id)
            {
                return BadRequest();
            }

            _context.Entry(fleet).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Fleet>> Delete(int id)
        {
            var fleet = await _context.Fleet.FindAsync(id);

            if (fleet == null)
            {
                return NotFound();
            }

            _context.Fleet.Remove(fleet);
            await _context.SaveChangesAsync();

            return fleet;
        }
    }
}
