using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Accounts;
using OpenGym.Domain.Common;

namespace OpenGym.Domain.Administration;

/// <summary>Registro de auditoria, só inserção. Action é texto (ex.: user.blocked, menu.granted) para não exigir migration a cada ação nova.</summary>
[Table("audit_log")]
[Index(nameof(EntityType), nameof(EntityId))]
[Index(nameof(OccurredAt))]
public class AuditLog : EntityControl
{
    /// <summary>Quem fez a ação; nulo = o próprio sistema.</summary>
    [Column("actor_id", TypeName = "uuid")]
    public Guid? ActorId { get; set; }

    [ForeignKey(nameof(ActorId))]
    public User? Actor { get; set; }

    [Column("action", TypeName = "text")]
    public string Action { get; set; } = string.Empty;

    [Column("entity_type", TypeName = "text")]
    public string EntityType { get; set; } = string.Empty;

    [Column("entity_id", TypeName = "uuid")]
    public Guid? EntityId { get; set; }

    [Column("data", TypeName = "jsonb")]
    public string? Data { get; set; }

    [Column("ip_address", TypeName = "text")]
    public string? IpAddress { get; set; }

    [Column("occurred_at", TypeName = "timestamp with time zone")]
    public DateTime OccurredAt { get; set; }
}
