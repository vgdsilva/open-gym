using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Accounts;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;
using OpenGym.Domain.Planning;

namespace OpenGym.Domain.Workouts;

/// <summary>Treino realizado. RoutineDayId nulo = treino livre.</summary>
[Table("workout_session")]
[Index(nameof(UserId), nameof(StartedAt))]
[Index(nameof(UserId), nameof(ClientId), nameof(SystemDeleted), IsUnique = true)]
public class WorkoutSession : EntityControl
{
    [Column("user_id", TypeName = "uuid")]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    [Column("routine_day_id", TypeName = "uuid")]
    public Guid? RoutineDayId { get; set; }

    [ForeignKey(nameof(RoutineDayId))]
    public RoutineDay? RoutineDay { get; set; }

    [Column("name", TypeName = "text")]
    public string Name { get; set; } = string.Empty;

    [Column("status", TypeName = "text")]
    public SessionStatus Status { get; set; }

    [Column("started_at", TypeName = "timestamp with time zone")]
    public DateTime StartedAt { get; set; }

    [Column("finished_at", TypeName = "timestamp with time zone")]
    public DateTime? FinishedAt { get; set; }

    [Column("body_weight_kg", TypeName = "numeric(6,2)")]
    public decimal? BodyWeightKg { get; set; }

    /// <summary>Esforço percebido do treino, de 1 a 10.</summary>
    [Column("perceived_effort", TypeName = "integer")]
    public int? PerceivedEffort { get; set; }

    [Column("notes", TypeName = "text")]
    public string? Notes { get; set; }

    /// <summary>Id gerado no aparelho (offline), para a sincronização não duplicar o treino.</summary>
    [Column("client_id", TypeName = "uuid")]
    public Guid ClientId { get; set; }

    [Column("source", TypeName = "text")]
    public DataSource Source { get; set; }
}
