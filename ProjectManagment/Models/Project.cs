namespace ProjectManagment.Models
{
    public class Project
    {
        private string ProjectName { get; set; }
        private string CustomerCompany { get; set; }
        private string ExecutorCompany { get; set; }
        private Employee Employee { get; set; }
        private Employee Manager { get; set; }
        private DateTime StartDate { get; set; }
        private DateTime EndDate { get; set; }
        private int Priority { get; set; }

    }
}
