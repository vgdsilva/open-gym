using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Common;

namespace OpenGym.Domain.Planning;

/// <summary>Dia de treino da rotina (ex.: "Treino A").</summary>
[Table("routine_day")]
[Index(nameof(RoutineId))]
public class RoutineDay : EntityControl
{
    [Column("routine_id", TypeName = "uuid")]
    public Guid RoutineId { get; set; }

    [ForeignKey(nameof(RoutineId))]
    public Routine? Routine { get; set; }

    [Column("name", TypeName = "text")]
    public string Name { get; set; } = string.Empty;

    /// <summary>Usado quando a rotina é por dia da semana.</summary>
    [Column("day_of_week", TypeName = "text")]
    public DayOfWeek? DayOfWeek { get; set; }

    /// <summary>Usado quando a rotina é em rodízio (1 = A, 2 = B...).</summary>
    [Column("rotation_order", TypeName = "integer")]
    public int? RotationOrder { get; set; }

    [Column("notes", TypeName = "text")]
    public string? Notes { get; set; }
}
