using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESportsMatchTracker.API.Data.Entities;

/// <summary>
/// 比赛实体，包含比赛的基本信息和外键信息。
/// </summary>
public class Match
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  /// <summary>
  /// 游戏名称
  /// </summary>
  [Required]
  public string Game { get; set; } = null!;

  /// <summary>
  /// 参赛队伍，存储为JSON字符串
  /// </summary>
  [Required]
  public string TeamsJson { get; set; } = null!;

  /// <summary>
  /// 比赛开始时间
  /// </summary>
  public DateTime StartTime { get; set; }

  /// <summary>
  /// 比赛状态
  /// </summary>
  [Required]
  public string Status { get; set; } = null!;

  /// <summary>
  /// 比赛阶段
  /// </summary>
  [Required]
  public string Stage { get; set; } = null!;

  /// <summary>
  /// 所属锦标赛
  /// </summary>
  [Required]
  public string Tournament { get; set; } = null!;

  /// <summary>
  /// 直播流地址
  /// </summary>
  [Required]
  public string StreamUrl { get; set; } = null!;

  /// <summary>
  /// 当前地图（仅直播时有）
  /// </summary>
  public string? CurrentMap { get; set; }

  /// <summary>
  /// 当前比分（仅直播和已结束时有），存储为JSON字符串
  /// </summary>
  public string? ScoreJson { get; set; }

  /// <summary>
  /// 每张地图比分（仅直播和已结束时有），存储为JSON字符串
  /// </summary>
  public string? MapScoresJson { get; set; }

  /// <summary>
  /// 获胜方（仅已结束时有）
  /// </summary>
  public string? Winner { get; set; }

  /// <summary>
  /// 外键，关联MatchDetails
  /// </summary>
  [ForeignKey("MatchDetails")]
  public int MatchDetailsId { get; set; }
  public MatchDetails MatchDetails { get; set; } = null!;

  /// <summary>
  /// 创建时间
  /// </summary>
  public DateTime CreatedOn { get; set; }
  /// <summary>
  /// 创建人
  /// </summary>
  public string? CreatedBy { get; set; }
  /// <summary>
  /// 修改时间
  /// </summary>
  public DateTime? ModifiedOn { get; set; }
  /// <summary>
  /// 修改人
  /// </summary>
  public string? ModifiedBy { get; set; }
}