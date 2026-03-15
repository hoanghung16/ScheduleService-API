using Microsoft.EntityFrameworkCore;
using ScheduleService.API.Models;

namespace ScheduleService.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User Configuration
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserID);
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // ServiceCategory Configuration
            modelBuilder.Entity<ServiceCategory>()
                .HasKey(sc => sc.CategoryID);
            modelBuilder.Entity<ServiceCategory>()
                .Property(sc => sc.CategoryName)
                .IsRequired()
                .HasMaxLength(100);

            // Service Configuration
            modelBuilder.Entity<Service>()
                .HasKey(s => s.ServiceID);
            modelBuilder.Entity<Service>()
                .Property(s => s.ServiceName)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Service>()
                .Property(s => s.Price)
                .HasPrecision(10, 2);
            modelBuilder.Entity<Service>()
                .HasOne(s => s.Category)
                .WithMany(sc => sc.Services)
                .HasForeignKey(s => s.CategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            // Staff Configuration
            modelBuilder.Entity<Staff>()
                .HasKey(st => st.StaffID);
            modelBuilder.Entity<Staff>()
                .HasOne(st => st.User)
                .WithOne(u => u.Staff)
                .HasForeignKey<Staff>(st => st.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            // Booking Configuration
            modelBuilder.Entity<Booking>()
                .HasKey(b => b.BookingID);
            modelBuilder.Entity<Booking>()
                .Property(b => b.Status)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Service)
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.ServiceID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Staff)
                .WithMany(st => st.Bookings)
                .HasForeignKey(b => b.StaffID)
                .OnDelete(DeleteBehavior.SetNull);

            // Review Configuration
            modelBuilder.Entity<Review>()
                .HasKey(r => r.ReviewID);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Booking)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookingID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Service)
                .WithMany(s => s.Reviews)
                .HasForeignKey(r => r.ServiceID)
                .OnDelete(DeleteBehavior.Restrict);

            // Payment Configuration
            modelBuilder.Entity<Payment>()
                .HasKey(p => p.PaymentID);
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(10, 2);
            modelBuilder.Entity<Payment>()
                .Property(p => p.Status)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithOne(b => b.Payment)
                .HasForeignKey<Payment>(p => p.BookingID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
