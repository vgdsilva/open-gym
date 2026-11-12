using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Accounts;
using OpenGym.Domain.Catalog;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;
using OpenGym.Domain.Workouts;

namespace OpenGym.Domain.Progress;

/// <summary>Recorde pessoal, gravado ao concluir o treino. Guarda o histórico, não só o atual.</summary>
[Table("personal_record")]
[Index(nameof(UserId), nameof(ExerciseId), nameof(Type))]
public class PersonalRecord : EntityControl
{
    [Column("user_id", TypeName = "uuid")]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    [Column("exercise_id", TypeName = "uuid")]
    public Guid ExerciseId { get; set; }

    [ForeignKey(nameof(ExerciseId))]
    public Exercise? Exercise { get; set; }

    [Column("type", TypeName = "text")]
    public RecordType Type { get; set; }

    /// <summary>Valor do recorde: kg, repetições, kg × reps ou segundos, conforme o Type.</summary>
    [Column("value", TypeName = "numeric(10,2)")]
    public decimal Value { get; set; }

    [Column("reps", TypeName = "integer")]
    public int? Reps { get; set; }

    [Column("set_log_id", TypeName = "uuid")]
    public Guid SetLogId { get; set; }

    [ForeignKey(nameof(SetLogId))]
    public SetLog? SetLog { get; set; }

    [Column("achieved_at", TypeName = "timestamp with time zone")]
    public DateTime AchievedAt { get; set; }
}
