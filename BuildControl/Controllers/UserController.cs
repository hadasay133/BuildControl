using BuildControl.models.DAT;
using BuildControl.models.DTO;
using BuildControl.Models.DAT;
using BuildControl.Service.UserFolder;
using Microsoft.AspNetCore.Mvc;

namespace BuildControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UserDto>> GetAllSupervisors()
        {
            var users = SupervisorManagementScreen.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetSupervisorById(int id)
        {
            var user = SupervisorManagementScreen.GetById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            SupervisorManagementScreen.AddUser(user);
            return CreatedAtAction(nameof(GetSupervisorById), new { id = user.UserId }, user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            SupervisorManagementScreen.DeleteUser(id);
            return NoContent();
        }

        [HttpPost("{id}/worksites")]
        public IActionResult AddWorkSitesForUser(int id, [FromBody] List<WorkSite> newSites)
        {
            SupervisorManagementScreen.AddWorkSitesForUser(id, newSites);
            return Ok();
        }

        [HttpPut("{id}/worksites")]
        public IActionResult UpdateWorkSitesForUser(int id, [FromBody] List<WorkSite> newSites)
        {
            SupervisorManagementScreen.UpdateWorkSitesForUser(id, newSites);
            return Ok();
        }
    }
}
