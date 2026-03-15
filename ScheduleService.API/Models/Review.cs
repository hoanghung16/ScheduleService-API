namespace ScheduleService.API.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public int ServiceID { get; set; }
        public int Rating { get; set; } // 1-5
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public Booking? Booking { get; set; }
        public User? User { get; set; }
        public Service? Service { get; set; }
    }
}
