using System.Collections.Generic;
using c_gregslist.DB;
using c_gregslist.Models;
using Microsoft.AspNetCore.Mvc;

namespace c_gregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
                return Ok(FakeDB.Cars);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
                FakeDB.Cars.Add(newCar);
                return Ok(newCar);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{carId}")]
        public ActionResult<Car> GetCar(string carId)
        {
            try
            {
                Car carFound = FakeDB.Cars.Find(c => c.id == carId);
                if (carFound == null)
                {
                    throw new System.Exception("Car does not exist");
                }
                return Ok(carFound);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{carId}")]
        public ActionResult<string> DeleteCar(string carId)
        {
            try
            {
                Car carToRemove = FakeDB.Cars.Find(c => c.id == carId);
                if (FakeDB.Cars.Remove(carToRemove))
                {
                    return Ok("Car destroyed");
                }
                else
                {
                    throw new System.Exception("Car does not exist");
                }
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{carId}")]
        public ActionResult<Car> EditCar(string carId, [FromBody] Car updatedCar)
        {
            try
            {
                Car carToEdit = FakeDB.Cars.Find(c => c.id == carId);
                if (carToEdit == null)
                {
                    return BadRequest("No Car Found");
                }

                carToEdit.Model = updatedCar.Model;
                carToEdit.Year = updatedCar.Year;
                carToEdit.Miles = updatedCar.Miles;
                carToEdit.Price = updatedCar.Price;

                return Ok(updatedCar);

            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    }


}