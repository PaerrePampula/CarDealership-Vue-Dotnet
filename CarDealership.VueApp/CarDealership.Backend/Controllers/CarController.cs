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
            return CreatedAtAction(nameof(Create), new { id = car.Key}, car);
        }
        [HttpDelete]
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
            return CreatedAtAction(nameof(Delete), new { id = id});
        }
    }
}
