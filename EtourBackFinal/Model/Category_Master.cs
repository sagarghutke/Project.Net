using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EtourBackFinal.Model
{
    public class Category_Master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MasterId { get; set; }

        [Required]
        [StringLength(5)]
        [NotNull]
        public string? CategoryId { get; set; }

        //[Required]
        [StringLength(5)]
        //[NotNull]
        public string? SubCategoryId { get; set; }

        [Required]
        [StringLength(45)]
        [NotNull]
        public string? CategoryName{get;set;}

        
        public string? CategoryImage { get; set; }

        [Required]
        public bool ToNewTab { get; set; }

        public ICollection<Itnerary_Master>? Itneraries { get; set; }

        public ICollection<Date_Master>? Dates { get; set; }

        public ICollection<Booking_Header>? Bookings { get; set; }


        public ICollection<Package_Master>? Packages { get; set; }

        public ICollection<Cost_Master>? Costs { get; set; }

    }
}
