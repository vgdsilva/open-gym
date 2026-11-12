using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Accounts;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;
using OpenGym.Domain.Planning;

namespace OpenGym.Domain.Ai;

/// <summary>Ajuste sugerido pela IA. A IA nunca altera o plano sozinha: aceitar aplica o Payload na rotina.</summary>
[Table("ai_suggestion")]
[Index(nameof(UserId), nameof(Status))]
public class AiSuggestion : EntityControl
{
    [Column("user_id", TypeName = "uuid")]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    [Column("conversation_id", TypeName = "uuid")]
    public Guid? ConversationId { get; set; }

    [ForeignKey(nameof(ConversationId))]
    public AiConversation? Conversation { get; set; }

    [Column("type", TypeName = "text")]
    public SuggestionType Type { get; set; }

    [Column("status", TypeName = "text")]
    public SuggestionStatus Status { get; set; }

    [Column("title", TypeName = "text")]
    public string Title { get; set; } = string.Empty;

    [Column("rationale", TypeName = "text")]
    public string Rationale { get; set; } = string.Empty;

    [Column("payload", TypeName = "jsonb")]
    public string Payload { get; set; } = string.Empty;

    [Column("target_routine_id", TypeName = "uuid")]
    public Guid? TargetRoutineId { get; set; }

    [ForeignKey(nameof(TargetRoutineId))]
    public Routine? TargetRoutine { get; set; }

    [Column("decided_at", TypeName = "timestamp with time zone")]
    public DateTime? DecidedAt { get; set; }
}
