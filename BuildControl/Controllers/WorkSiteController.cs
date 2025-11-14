using BuildControl.models.DAT;
using BuildControl.models.DTO;
using BuildControl.Service.workSiteFolder;
using Microsoft.AspNetCore.Mvc;

namespace BuildControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkSiteController : Controller
    {
        [HttpGet]
        public ActionResult<List<WorkSiteDto>> GetAllWorkSite()
        {
            var WorkSiteList = WorkSiteManegmentScreen.GetAll();
            return Ok(WorkSiteList);
        }

        [HttpGet("{id}")]
        public ActionResult<WorkSiteDto> GetWorkSiteById(int id)
        {
            var workSite = WorkSiteManegmentScreen.GetWorkSiteById(id);
            if (workSite == null)
                return NotFound();

            return Ok(workSite);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] WorkSite workSite)
        {
            WorkSiteManegmentScreen.AddWorkSite(workSite);
            return CreatedAtAction(nameof(GetWorkSiteById), new { id = workSite.Id }, workSite);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            WorkSiteManegmentScreen.DeleteWorkSite(id);
            return NoContent();
        }
    }
}
