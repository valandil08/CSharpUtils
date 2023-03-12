using CSharpUtils.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CSharpUtils.EntityModel
{

    public class RequestsToProcess
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("data_as_json")]
        public string? DataAsJson { get; set; }

        [Required]
        [Column("processing_status")]
        public ProcessingStatus ProcessingStatus { get; set; } = ProcessingStatus.NotScheduled;

        [Required]
        [Column("fail_count")]
        [Range(0, int.MaxValue)]
        public int FailCount { get; set; } = 0;

        [Required]
        [Column("when_created")]
        public DateTime WhenCreated { get; set; } = DateTime.Now;

        [Required]
        [Column("when_last_updated")]
        public DateTime WhenLastUpdated { get; set; } = DateTime.Now;
    }
}
