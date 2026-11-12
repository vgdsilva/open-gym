using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Accounts;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;

namespace OpenGym.Domain.Ai;

/// <summary>Consumo de IA por usuário, dia e função. Aplica o limite diário definido pelo admin.</summary>
[Table("ai_usage")]
[Index(nameof(UserId), nameof(Date), nameof(Feature), nameof(SystemDeleted), IsUnique = true)]
public class AiUsage : EntityControl
{
    [Column("user_id", TypeName = "uuid")]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    [Column("date", TypeName = "date")]
    public DateOnly Date { get; set; }

    [Column("feature", TypeName = "text")]
    public AiFeature Feature { get; set; }

    [Column("requests", TypeName = "integer")]
    public int Requests { get; set; }

    [Column("input_tokens", TypeName = "bigint")]
    public long InputTokens { get; set; }

    [Column("output_tokens", TypeName = "bigint")]
    public long OutputTokens { get; set; }

    [Column("estimated_cost_usd", TypeName = "numeric(10,4)")]
    public decimal EstimatedCostUsd { get; set; }
}
