using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagment.Data;
using ProjectManagment.Data.dto;
using ProjectManagment.Models;

namespace ProjectManagment.Controllers
{
    [ApiController]
    [Route("api/project")]
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProjectController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
            var project = await context.Projects.FirstOrDefaultAsync(x => x.ProjectId == id);

            if (project != null)
            {
                return Ok(project);
            }

            return NotFound(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Project>> CreateProject([FromBody] CreateProjectDto projectDto)
        {
            var project = new Project()
            {
                Name = projectDto.Name,
                CustomerCompany = projectDto.CustomerCompany,
                ExecutorCompany = projectDto.ExecutorCompany,
                StartDate = projectDto.StartDate,
                EndDate = projectDto.EndDate,
                Priority = projectDto.Priority,
                ManagerId = projectDto.ManagerId,
            };

            context.Projects.Add(project);
            await context.SaveChangesAsync();

            return Ok(project);
        }
    }
}
