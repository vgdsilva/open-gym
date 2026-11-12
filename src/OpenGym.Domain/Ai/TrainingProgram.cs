using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Accounts;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;

namespace OpenGym.Domain.Ai;

/// <summary>Programa de várias semanas que agrupa rotinas (ex.: 8 semanas de hipertrofia). Montado pelo gerador de plano.
/// Chamado de TrainingProgram para não colidir com a classe Program da API.</summary>
[Table("training_program")]
[Index(nameof(UserId))]
public class TrainingProgram : EntityControl
{
    [Column("user_id", TypeName = "uuid")]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    [Column("name", TypeName = "text")]
    public string Name { get; set; } = string.Empty;

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("goal", TypeName = "text")]
    public TrainingGoal Goal { get; set; }

    [Column("duration_weeks", TypeName = "integer")]
    public int DurationWeeks { get; set; }

    [Column("start_date", TypeName = "date")]
    public DateOnly? StartDate { get; set; }

    [Column("is_active", TypeName = "boolean")]
    public bool IsActive { get; set; }
}
