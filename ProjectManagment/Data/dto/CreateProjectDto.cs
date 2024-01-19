using System.ComponentModel.DataAnnotations;

namespace ProjectManagment.Data.dto
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public string CustomerCompany { get; set; }
        public string ExecutorCompany { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public int? ManagerId { get; set; }
    }
}
