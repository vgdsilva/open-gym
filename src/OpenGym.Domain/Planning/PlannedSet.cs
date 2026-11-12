using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;

namespace OpenGym.Domain.Planning;

/// <summary>Série-alvo de um exercício planejado. Faixa de repetições (8 a 12) habilita a dupla progressão.</summary>
[Table("planned_set")]
[Index(nameof(RoutineExerciseId))]
public class PlannedSet : EntityControl
{
    [Column("routine_exercise_id", TypeName = "uuid")]
    public Guid RoutineExerciseId { get; set; }

    [ForeignKey(nameof(RoutineExerciseId))]
    public RoutineExercise? RoutineExercise { get; set; }

    [Column("sort_order", TypeName = "integer")]
    public int SortOrder { get; set; }

    [Column("set_type", TypeName = "text")]
    public SetType SetType { get; set; }

    [Column("reps_min", TypeName = "integer")]
    public int? RepsMin { get; set; }

    [Column("reps_max", TypeName = "integer")]
    public int? RepsMax { get; set; }

    [Column("weight_kg", TypeName = "numeric(6,2)")]
    public decimal? WeightKg { get; set; }

    [Column("target_rir", TypeName = "integer")]
    public int? TargetRir { get; set; }

    [Column("duration_seconds", TypeName = "integer")]
    public int? DurationSeconds { get; set; }
}
