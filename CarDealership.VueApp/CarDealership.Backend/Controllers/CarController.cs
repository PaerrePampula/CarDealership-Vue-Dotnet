using CarDealership.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarDealership.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        public CarController(CarDBContext db)
        {
            Db = db;
        }

        private readonly CarDBContext Db;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await Db.Cars.ToListAsync() });
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Create(Car car)
        {
            Db.Cars.Add(car);
            //Inserting requires to await changes, changes otherwise will not be visible.
            await Db.SaveChangesAsync();
            return CreatedAtAction("Car created", new { id = car.Key}, car);
        }
    }
}
