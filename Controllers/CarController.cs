using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace MyApp.Namespace
{
    [Route("api/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly DataContext _context;
        public CarController(ILogger<CarController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetCars")]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            var cars = await _context.Cars.Include(c => c.Office).Include(c => c.Fleet).ToListAsync();
            return cars;
        }

        [HttpGet("id/{id}", Name = "GetCar")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.Cars.Include(c => c.Office).Include(c => c.Fleet).FirstOrDefaultAsync(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        [HttpGet("license-plate/{licensePlate}", Name = "GetCarByLicensePlate")]
        public async Task<ActionResult<Car>> GetCarByLicensePlate(string licensePlate)
        {
            var car = await _context.Cars.Include(c => c.Office).Include(c => c.Fleet).FirstOrDefaultAsync(c => c.LicensePlate == licensePlate);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        [HttpGet("available-cars", Name = "GetAvailableCars")]
        public async Task<ActionResult<IEnumerable<Car>>> GetAvailableCars(int officeId, DateTime pickupDate, DateTime returnDate)
        {
            // Obtener la lista de reservas que se superponen con el rango de fechas y la oficina especificada
            var overlappingReservations = await _context.Reservations
                .Where(r => r.PickupDate <= returnDate && r.ReturnDate >= pickupDate && r.OfficeId == officeId)
                .ToListAsync();

            // Obtener la lista de todos los coches de la oficina especificada
            var allCars = await _context.Cars.Where(c => c.OfficeId == officeId).Include(c => c.Office).Include(c => c.Fleet).ToListAsync();

            // Obtener los IDs de los coches reservados en el rango de fechas especificado
            var reservedCarIds = overlappingReservations.Select(r => r.CarId);

            // Filtrar los coches disponibles
            var availableCars = allCars.Where(c => !reservedCarIds.Contains(c.Id)).ToList();

            // Devolver una respuesta HTTP 200 con la lista de coches disponibles
            return Ok(availableCars);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> Post(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetCar", new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Car>> Put(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> Delete(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }
    }
}
