using CarDealership.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarDealership.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        public CarController(CarDBContext db)
        {
            Db = db;
        }

        private readonly CarDBContext Db;
        //GET all cars, so no extra routing
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await Db.Cars.ToListAsync() });
        }
        //GET single cars, this works by id, so pass in id in route
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Db.Cars.FindAsync(id);
            return Json(result);
        }
        //POST new car, or edit an old one (upsert)
        [HttpPost]
        [ActionName(nameof(Create))]
        public async Task<IActionResult> Create(Car car)
        {
            if (car.Key == 0)
            {
                Db.Cars.Add(car);
            }
            else
            {
                Db.Cars.Update(car);
            }
            //Inserting requires to await changes, changes otherwise will not be visible.
            await Db.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), new { id = car.Key }, car);
        }
        [HttpPut]
        [Route("{id}")]

        [ActionName(nameof(Put))]
        public async Task<IActionResult> Put(int id, Car car)
        {
            Db.Cars.Update(car);
            //Inserting requires to await changes, changes otherwise will not be visible.
            await Db.SaveChangesAsync();
            return CreatedAtAction(nameof(Put), new { id = car.Key }, car);
        }
        //DELETE existing car, or return fail if not found
        [HttpDelete]
        [Route("{id}")]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> Delete(int id)
        {
            Car car = (Car)await Db.Cars.FirstOrDefaultAsync(x => x.Key == id);
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                Db.Cars.Remove(car);
            }
            await Db.SaveChangesAsync();
            return CreatedAtAction(nameof(Delete), new { id = id });
        }
    }
}