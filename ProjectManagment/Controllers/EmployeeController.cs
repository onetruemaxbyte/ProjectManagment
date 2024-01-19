using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagment.Data;
using ProjectManagment.Data.dto;
using ProjectManagment.Models;

namespace ProjectManagment.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext context;

        public EmployeeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Project>> GetEmployeeById(int id)
        {
            var project = await context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);

            if (project != null)
            {
                return Ok(project);
            }

            return NotFound(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Project>> CreateEmployee([FromBody] CreateEmployeeDto employeeDto)
        {
            var employee = new Employee()
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Patronymic = employeeDto.Patronymic,
            };

            context.Employees.Add(employee);
            await context.SaveChangesAsync();

            return Ok(employee);
        }
    }
}
