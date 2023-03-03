using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EtourBackFinal.Model
{
    public class Package_Master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackageId { get; set; }

        [NotNull]
        public string PackageName { get; set; }

        [NotNull]
        public int? MasterId { get; set; }

        [ForeignKey("MasterId")]
        public Category_Master? CategoryMaster { get; set; }
    }
}
