namespace ScheduleService.API.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
        public int UserID { get; set; }
        public string Specialization { get; set; }
        public TimeSpan AvailableFrom { get; set; }
        public TimeSpan AvailableTo { get; set; }
        public bool IsAvailable { get; set; } = true;

        // Navigation properties
        public User? User { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
