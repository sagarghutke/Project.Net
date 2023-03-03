using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EtourBackFinal.Model
{
    public class Booking_Header
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public int NoOfPassenger { get; set; }

        [Required]
        public double TourAmount { get; set; }

        [Required]
        public double Taxes { get; set; }

        [Required]
        public double TotalAmount { get; set; }

        
        public int? MasterId { get; set; }

        [ForeignKey("MasterId")]
        public Category_Master? CategoryMaster { get; set; }

       
         public int? CustomerId { get;set; }

        [ForeignKey("CustomerId")]
        public Customer_Master? CustomerMaster { get; set; }

       
        public int? DepartureId { get; set; }

        [ForeignKey("DepartureId")]
        public Date_Master? DateMaster { get; set;}

        [JsonIgnore]
        public ICollection<Passenger_Master>? Passengers { get; set; }


    }
}
