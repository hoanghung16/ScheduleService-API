namespace ScheduleService.API.Models
{
    public class ServiceCategory
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

        // Navigation properties
        public ICollection<Service> Services { get; set; } = new List<Service>();
    }
}
