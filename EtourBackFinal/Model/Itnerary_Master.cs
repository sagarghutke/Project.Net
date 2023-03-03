using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EtourBackFinal.Model
{
    public class Itnerary_Master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItneraryId { get; set; }

        [Required]
        public int TourDuration { get; set; }

        //[StringLength(Max)]
        [Required]
        public string? Itnerarydetails { get; set; }

        public int? MasterId { get; set; }

        [ForeignKey("MasterId")]
        public Category_Master? CategoryMaster { get; set; }
    }
}
