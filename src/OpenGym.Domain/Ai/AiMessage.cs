using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;

namespace OpenGym.Domain.Ai;

/// <summary>Mensagem da conversa. Guarda as chamadas de ferramenta, para auditar o que a IA consultou.</summary>
[Table("ai_message")]
[Index(nameof(ConversationId))]
public class AiMessage : EntityControl
{
    [Column("conversation_id", TypeName = "uuid")]
    public Guid ConversationId { get; set; }

    [ForeignKey(nameof(ConversationId))]
    public AiConversation? Conversation { get; set; }

    [Column("role", TypeName = "text")]
    public AiMessageRole Role { get; set; }

    [Column("content", TypeName = "text")]
    public string Content { get; set; } = string.Empty;

    [Column("tool_name", TypeName = "text")]
    public string? ToolName { get; set; }

    [Column("tool_payload", TypeName = "jsonb")]
    public string? ToolPayload { get; set; }

    [Column("input_tokens", TypeName = "integer")]
    public int InputTokens { get; set; }

    [Column("output_tokens", TypeName = "integer")]
    public int OutputTokens { get; set; }
}
