using System.Collections.Generic;
using c_gregslist.DB;
using c_gregslist.Models;
using Microsoft.AspNetCore.Mvc;

namespace c_gregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
        {
            try
            {
                return Ok(FakeDB.Jobs);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        [HttpPost]
        public ActionResult<Job> Create([FromBody] Job newJob)
        {
            try
            {
                FakeDB.Jobs.Add(newJob);
                return Ok(newJob);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{jobId}")]
        public ActionResult<Job> GetJob(string jobId)
        {
            try
            {
                Job jobFound = FakeDB.Jobs.Find(j => j.Id == jobId);
                if (jobFound == null)
                {
                    throw new System.Exception("Job does not exist");
                }
                return Ok(jobFound);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{jobId}")]
        public ActionResult<string> DeleteJob(string jobId)
        {
            try
            {
                Job jobToRemove = FakeDB.Jobs.Find(j => j.Id == jobId);
                if (FakeDB.Jobs.Remove(jobToRemove))
                {
                    return Ok("Job Removed");
                }
                else
                {
                    throw new System.Exception("Job does not exist");
                }
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{jobId}")]
        public ActionResult<Job> EditJob(string jobId, [FromBody] Job updatedJob)
        {
            try
            {
                Job jobToEdit = FakeDB.Jobs.Find(j => j.Id == jobId);
                if (jobToEdit == null)
                {
                    return BadRequest("No Job Found");
                }

                jobToEdit.Description = updatedJob.Description;
                jobToEdit.Company = updatedJob.Company;
                jobToEdit.Rate = updatedJob.Rate;
                jobToEdit.Description = updatedJob.Description;

                return Ok(updatedJob);

            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    }


}