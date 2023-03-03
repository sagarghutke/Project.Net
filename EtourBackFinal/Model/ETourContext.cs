using Microsoft.EntityFrameworkCore;
using EtourBackFinal.Model;

namespace EtourBackFinal.Model
{
    public class ETourContext:DbContext
    {
        public ETourContext() { }

        public ETourContext(DbContextOptions<ETourContext> options) :base(options)
        {

        }
        public virtual DbSet<Customer_Master> CustomerMaster { get; set; }

        public virtual DbSet<Package_Master> Packages { get; set; }

        public virtual DbSet<Passenger_Master> Passengers { get; set; }

        public virtual DbSet<Booking_Header> BookingHeader { get; set; }
        
        public virtual DbSet<Category_Master> CategoryMaster { get; set; }

        public virtual DbSet<Cost_Master> CostMaster { get; set; }

        public virtual DbSet<Date_Master> DateMaster { get; set; }

        public virtual DbSet<Itnerary_Master> ItneraryMaster { get; set;}

       /* public DbSet<EtourBackFinal.Model.Search> Search { get; set; } = default!;

        public DbSet<EtourBackFinal.Model.Login> Login { get; set; } = default!;*/

       
    }
}
