using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace WasteAway.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Zipcode> Zipcodes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Weekday> Weekdays { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<Pickup> Pickups { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Role> Roles { get; set; }
        
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}