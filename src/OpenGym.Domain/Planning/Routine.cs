using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Accounts;
using OpenGym.Domain.Ai;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;

namespace OpenGym.Domain.Planning;

/// <summary>Plano de treino do usuário (ex.: Push/Pull/Legs). UserId nulo = template global.</summary>
[Table("routine")]
[Index(nameof(UserId))]
public class Routine : EntityControl
{
    [Column("user_id", TypeName = "uuid")]
    public Guid? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    /// <summary>Programa ao qual a rotina pertence (bloco 7).</summary>
    [Column("program_id", TypeName = "uuid")]
    public Guid? ProgramId { get; set; }

    [ForeignKey(nameof(ProgramId))]
    public TrainingProgram? Program { get; set; }

    [Column("name", TypeName = "text")]
    public string Name { get; set; } = string.Empty;

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("schedule_mode", TypeName = "text")]
    public ScheduleMode ScheduleMode { get; set; }

    /// <summary>Só uma rotina ativa por usuário (regra na feature).</summary>
    [Column("is_active", TypeName = "boolean")]
    public bool IsActive { get; set; }

    [Column("is_template", TypeName = "boolean")]
    public bool IsTemplate { get; set; }

    [Column("source", TypeName = "text")]
    public DataSource Source { get; set; }
}
