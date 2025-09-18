using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaLabApi.Models
{
    [Table("m_ca_analyses")]
    public class McaAnalysis
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

        [Column("parameter_id")]
        public int? ParameterId { get; set; }

        [ForeignKey("ParameterId")]
        public McaParameter? Parameter { get; set; }

        [Column("method_id")]
        public int? MethodId { get; set; }

        [ForeignKey("MethodId")]
        public McaMethod? Method { get; set; }

        [Column("sample_type_id")]
        public int? SampleTypeId { get; set; }

        [Column("sample_typeId")]
        public McaSampleType? SampleType { get; set; }

        [Column("lead_time")]
        public TimeSpan? LeadTime { get; set; }

        // // Navigation properties
        // [ForeignKey("MethodId")]
        // public McaMethod? Method { get; set; }
    }
}