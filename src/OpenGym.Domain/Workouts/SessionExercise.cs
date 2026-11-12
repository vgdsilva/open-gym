using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Catalog;
using OpenGym.Domain.Common;
using OpenGym.Domain.Planning;

namespace OpenGym.Domain.Workouts;

/// <summary>Exercício feito no treino. Pode divergir do plano (troca ou exercício extra).</summary>
[Table("session_exercise")]
[Index(nameof(WorkoutSessionId))]
[Index(nameof(ExerciseId))]
public class SessionExercise : EntityControl
{
    [Column("workout_session_id", TypeName = "uuid")]
    public Guid WorkoutSessionId { get; set; }

    [ForeignKey(nameof(WorkoutSessionId))]
    public WorkoutSession? WorkoutSession { get; set; }

    [Column("exercise_id", TypeName = "uuid")]
    public Guid ExerciseId { get; set; }

    [ForeignKey(nameof(ExerciseId))]
    public Exercise? Exercise { get; set; }

    [Column("routine_exercise_id", TypeName = "uuid")]
    public Guid? RoutineExerciseId { get; set; }

    [ForeignKey(nameof(RoutineExerciseId))]
    public RoutineExercise? RoutineExercise { get; set; }

    [Column("sort_order", TypeName = "integer")]
    public int SortOrder { get; set; }

    [Column("superset_group", TypeName = "integer")]
    public int? SupersetGroup { get; set; }

    [Column("notes", TypeName = "text")]
    public string? Notes { get; set; }
}
