using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESportsMatchTracker.API.Data.Entities;

/// <summary>
///     比赛详情实体，对应比赛的详细信息，如赛制和地图池。
/// </summary>
public class MatchDetails
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Format { get; set; } = null!;

    [Required]
    public string MapPoolJson { get; set; } = null!; // 存储为JSON字符串
    
    [Required]
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    [Required]
    public string CreatedBy { get; set; } = null!;
    public DateTime? ModifiedOn { get; set; }
    public string? ModifiedBy { get; set; }

    public ICollection<Match> Matches { get; set; } = new List<Match>();
}