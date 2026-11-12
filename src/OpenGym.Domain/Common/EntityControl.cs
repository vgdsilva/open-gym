using System.ComponentModel.DataAnnotations.Schema;

namespace OpenGym.Domain.Common;

/// <summary>
/// Base de todas as entidades: id (Guid v7), datas de auditoria em UTC e exclusão lógica.
/// O preenchimento das datas e a conversão de Remove em exclusão lógica ficam no AppDbContext.
/// </summary>
public abstract class EntityControl
{
    [Column("id", TypeName = "uuid")]
    public Guid Id { get; set; } = Guid.CreateVersion7();

    [Column("create_at", TypeName = "timestamp with time zone")]
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    [Column("update_at", TypeName = "timestamp with time zone")]
    public DateTime UpdateAt { get; set; } = DateTime.UtcNow;

    /// <summary>Guid.Empty = ativo; excluído guarda o próprio Id (permite índice único só entre ativos).</summary>
    [Column("system_deleted", TypeName = "uuid")]
    public Guid? SystemDeleted { get; set; } = Guid.Empty;

    [Column("system_deleted_at", TypeName = "timestamp with time zone")]
    public DateTime? SystemDeletedAt { get; set; }
}
