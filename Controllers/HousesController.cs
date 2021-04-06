using System.Collections.Generic;
using c_gregslist.DB;
using c_gregslist.Models;
using Microsoft.AspNetCore.Mvc;

namespace c_gregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HousesController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<House>> Get()
        {
            try
            {
                return Ok(FakeDB.Houses);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        [HttpPost]
        public ActionResult<House> Create([FromBody] House newHouse)
        {
            try
            {
                FakeDB.Houses.Add(newHouse);
                return Ok(newHouse);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{houseId}")]
        public ActionResult<House> GetHouse(string houseId)
        {
            try
            {
                House houseFound = FakeDB.Houses.Find(h => h.Id == houseId);
                if (houseFound == null)
                {
                    throw new System.Exception("House does not exist");
                }
                return Ok(houseFound);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{houseId}")]
        public ActionResult<string> DeleteHouse(string houseId)
        {
            try
            {
                House houseToRemove = FakeDB.Houses.Find(h => h.Id == houseId);
                if (FakeDB.Houses.Remove(houseToRemove))
                {
                    return Ok("House destroyed");
                }
                else
                {
                    throw new System.Exception("House does not exist");
                }
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{houseId}")]
        public ActionResult<House> EditHouse(string houseId, [FromBody] House updatedHouse)
        {
            try
            {
                House houseToEdit = FakeDB.Houses.Find(h => h.Id == houseId);
                if (houseToEdit == null)
                {
                    return BadRequest("No House Found");
                }

                houseToEdit.Bathrooms = updatedHouse.Bathrooms;
                houseToEdit.Year = updatedHouse.Year;
                houseToEdit.Bedrooms = updatedHouse.Bedrooms;
                houseToEdit.Price = updatedHouse.Price;
                houseToEdit.Description = updatedHouse.Description;

                return Ok(updatedHouse);

            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    }


}