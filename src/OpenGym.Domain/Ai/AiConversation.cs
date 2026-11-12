using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Accounts;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;

namespace OpenGym.Domain.Ai;

/// <summary>Conversa com a IA: chat, geração de plano ou resumo pós-treino.</summary>
[Table("ai_conversation")]
[Index(nameof(UserId), nameof(LastMessageAt))]
public class AiConversation : EntityControl
{
    [Column("user_id", TypeName = "uuid")]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    [Column("feature", TypeName = "text")]
    public AiFeature Feature { get; set; }

    [Column("title", TypeName = "text")]
    public string Title { get; set; } = string.Empty;

    [Column("model", TypeName = "text")]
    public string Model { get; set; } = string.Empty;

    [Column("last_message_at", TypeName = "timestamp with time zone")]
    public DateTime LastMessageAt { get; set; }
}
