using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly DataContext _context;
        public ReservationController(ILogger<ReservationController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetReservations")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            return await _context.Reservations
                .Include(r => r.Car)
                .Include(r => r.User)
                .Include(r => r.Office)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> Post(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetReservation", new { id = reservation.ReservationId }, reservation);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservation>> Delete(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }
    }
}
