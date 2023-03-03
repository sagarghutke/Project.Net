using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EtourBackFinal.Model
{
    public class Cost_Master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CostId { get; set; }

        [Required]
        public double Cost { get; set; }

        [Required]
        public double SinglePersonCost { get; set; }

        [Required]
        public double ExtraPersonCost { get; set; }

        [Required]
        public double ChildWithBed { get; set; }

        [Required]
        public double ChildWithoutBed { get;set; }


        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get;set; }    

        public int? MasterId { get; set; }

        [ForeignKey("MasterId")]
        public Category_Master? Category_Master { get; set; }



    }
}
