namespace ScheduleService.API.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public int ServiceID { get; set; }
        public int? StaffID { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan BookingTime { get; set; }
        public string Status { get; set; } = "Pending"; // Pending/Confirmed/Completed/Cancelled
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public User? User { get; set; }
        public Service? Service { get; set; }
        public Staff? Staff { get; set; }
        public Payment? Payment { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
