using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
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
            var cars = await _context.Cars.Include(c => c.Office).ToListAsync();
            return cars;
        }

        [HttpGet("{id}", Name = "GetCar")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.Cars.Include(c => c.Office).FirstOrDefaultAsync(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
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
