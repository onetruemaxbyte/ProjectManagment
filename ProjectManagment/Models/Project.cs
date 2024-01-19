using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagment.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CustomerCompany { get; set; }

        [Required]
        public string ExecutorCompany { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int Priority { get; set; }

        public int? ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        public Employee Manager { get; set; }

        public ICollection<ProjectAssignment> ProjectAssignments { get; set; }
    }
}
