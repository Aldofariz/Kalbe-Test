using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaLabApi.Models
{
    [Table("m_ca_sample_types")]
    public class McaSampleType
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("created_by")]
        [StringLength(100)]
        public string? CreatedBy { get; set; }

        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }

        [Column("last_updated_by")]
        [StringLength(100)]
        public string? LastUpdatedBy { get; set; }

        [Column("last_updated_on")]
        public DateTime? LastUpdatedOn { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Column("code")]
        [StringLength(50)]
        public string? Code { get; set; }

        [Column("description")]
        [StringLength(255)]
        public string? Description { get; set; }

        public ICollection<McaAnalysis> Analyses { get; set; } = new List<McaAnalysis>();
    }
}