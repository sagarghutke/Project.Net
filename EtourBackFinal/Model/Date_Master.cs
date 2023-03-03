using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EtourBackFinal.Model
{
    public class Date_Master
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartureId{get;set;}

        [Required]  
        public DateTime DepartureDate { get;set;}

        [Required]
        public DateTime EndDate { get;set;}

        [Required]
        public int NoOfDays { get;set;}

        //[Required]
        public int? MasterId { get;set;}

        //[Required]
        [ForeignKey("MasterId")]
        public Category_Master? CategoryMaster { get;set;}

        public ICollection<Booking_Header>? BookingHeaders  { get; set;}    

    }
}
