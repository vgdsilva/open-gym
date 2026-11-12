using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;

namespace OpenGym.Domain.Workouts;

/// <summary>Série registrada. Os campos usados dependem do TrackingType do exercício.</summary>
[Table("set_log")]
[Index(nameof(SessionExerciseId))]
public class SetLog : EntityControl
{
    [Column("session_exercise_id", TypeName = "uuid")]
    public Guid SessionExerciseId { get; set; }

    [ForeignKey(nameof(SessionExerciseId))]
    public SessionExercise? SessionExercise { get; set; }

    [Column("sort_order", TypeName = "integer")]
    public int SortOrder { get; set; }

    [Column("set_type", TypeName = "text")]
    public SetType SetType { get; set; }

    [Column("reps", TypeName = "integer")]
    public int? Reps { get; set; }

    [Column("weight_kg", TypeName = "numeric(6,2)")]
    public decimal? WeightKg { get; set; }

    [Column("duration_seconds", TypeName = "integer")]
    public int? DurationSeconds { get; set; }

    [Column("distance_meters", TypeName = "numeric(8,1)")]
    public decimal? DistanceMeters { get; set; }

    [Column("rir", TypeName = "integer")]
    public int? Rir { get; set; }

    [Column("rpe", TypeName = "numeric(3,1)")]
    public decimal? Rpe { get; set; }

    [Column("is_completed", TypeName = "boolean")]
    public bool IsCompleted { get; set; }

    [Column("completed_at", TypeName = "timestamp with time zone")]
    public DateTime? CompletedAt { get; set; }
}
