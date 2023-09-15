using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using talenthubBE.Data;
using talenthubBE.Models.Jobs;

namespace talenthubBE.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobsRepository _repository;

        public JobsController(IJobsRepository jobsRepository)
        {
            _repository = jobsRepository;
        }

        // GET: api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDTO>>> GetJobs()
        {
          IEnumerable<JobDTO>? response = await _repository.GetAllJobs();
          if(response == null)
          {
            return NotFound();
          }
            return Ok(response);
        }

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobDTO>> GetJob(Guid id)
        {
            JobDTO? response = await _repository.GetJob(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        // PUT: api/Jobs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<JobDTO>> PutJob(Guid id, Job job)
        {
            if (id != job.Id)
            {
                return BadRequest();
            }

            JobDTO? response = await _repository.PutJob(id, job);
            if(response == null)
            {
                return NotFound(new {message = "No such skill found"});
            }
            try
            {
                return Ok(response);
            }
            catch(Exception)
            {
                return Conflict(new {message = "There has been an issue handling your request"});
            }
        }

        // POST: api/Jobs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobDTO>> PostJob(CreateJobRequest request)
        {
            JobDTO? response = await _repository.PostJob(request);
            if(response == null)
            {
                return Conflict(new {message = "Job already saved"});
            }

            return CreatedAtAction("GetJob", new { id = response.Id }, response);
        }

        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(Guid id)
        {
            try
            {
                await _repository.DeleteJob(id);
            }
            catch (Exception e)
            {
                return NotFound(new {message = e.Message});
            }
            return NoContent();
        }
    }
}
