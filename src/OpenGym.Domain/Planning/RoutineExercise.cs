using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Catalog;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;

namespace OpenGym.Domain.Planning;

/// <summary>Exercício planejado num dia da rotina. Exercícios com o mesmo SupersetGroup formam um superset.</summary>
[Table("routine_exercise")]
[Index(nameof(RoutineDayId))]
public class RoutineExercise : EntityControl
{
    [Column("routine_day_id", TypeName = "uuid")]
    public Guid RoutineDayId { get; set; }

    [ForeignKey(nameof(RoutineDayId))]
    public RoutineDay? RoutineDay { get; set; }

    [Column("exercise_id", TypeName = "uuid")]
    public Guid ExerciseId { get; set; }

    [ForeignKey(nameof(ExerciseId))]
    public Exercise? Exercise { get; set; }

    [Column("sort_order", TypeName = "integer")]
    public int SortOrder { get; set; }

    [Column("superset_group", TypeName = "integer")]
    public int? SupersetGroup { get; set; }

    [Column("rest_seconds", TypeName = "integer")]
    public int RestSeconds { get; set; }

    [Column("progression", TypeName = "text")]
    public ProgressionStrategy Progression { get; set; }

    [Column("weight_increment_kg", TypeName = "numeric(6,2)")]
    public decimal WeightIncrementKg { get; set; }

    [Column("notes", TypeName = "text")]
    public string? Notes { get; set; }
}
