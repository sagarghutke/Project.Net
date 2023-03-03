using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EtourBackFinal.Model
{
    public enum Gender
    {
        Male = 'M',
        Female = 'F'
    }

    public class Customer_Master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(30)]
        [NotNull]
        public string? CustomerName { get; set; }

       /* [StringLength(10)]
        public string? UserName { get;set; }*/

        [EmailAddress]
        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        /*[MaxLength(15,ErrorMessage ="Length Can't exceed 15 Characters")]
        [MinLength(8,ErrorMessage ="Length Can't be less than 8 Characters")]
        [DataType(DataType.Password)]*/
        public string Password { get; set; }

        [Required]
       /* [RegularExpression(@"^[0-9]*$")]
        [StringLength(10,ErrorMessage ="Enter valid phone number")]*/
        public string PhoneNumber { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Address { get;set; }

        [Required]
        public int CountryCode { get; set; }

        [Required]
        public string IdVerificationType { get; set; }

        [Required]
        [MaxLength(6)]
        public string Gender { get; set; }

        public ICollection<Booking_Header>? BookingHeaders { get; set; }

        /*public ICollection<Passenger_Master>? Passengers { get; set; }*/
    }
}
