using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Services;

namespace project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {

        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService _projectService;

        public ProjectController(ILogger<ProjectController> logger, IProjectService projectService)
        {
            _logger = logger;
            _projectService = projectService;
        }

        [HttpPost("PostContact")]
        public IActionResult Post([FromBody]ContactDto contact)
        {
            try
            {
                var response = _projectService.CreateContact(contact);
                return Ok(response);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPut("PutContact")]
        public IActionResult Put([FromBody]ContactDto contact, [FromQuery]int id)
        {
            try
            {
                var response = _projectService.UpdateContact(contact, id);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetAllContact")]
        public IActionResult GetAll([FromQuery]int offset = 0, [FromQuery] int limit = 50)
        {
            try
            {
                if(limit > 50)
                {
                    throw new Exception("Limit is too long. 50 is the maximum!");
                }

                var response = _projectService.GetAllContacts(offset, limit);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetContactById")]
        public IActionResult GetById([FromQuery]int idContact)
        {
            try
            {
                var response = _projectService.GetContactById(idContact);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeleteContactById")]
        public IActionResult DeleteContactById([FromQuery] int idContact)
        {
            try
            {
                _projectService.DeleteContactById(idContact);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
