using ProjectManagment.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagment.Data.dto
{
    public class CreateEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
    }
}
