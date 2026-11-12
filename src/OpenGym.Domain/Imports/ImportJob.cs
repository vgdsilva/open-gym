using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Accounts;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;

namespace OpenGym.Domain.Imports;

/// <summary>Importação de histórico (openGym, Strong, Hevy, CSV), processada em segundo plano.</summary>
[Table("import_job")]
[Index(nameof(UserId))]
public class ImportJob : EntityControl
{
    [Column("user_id", TypeName = "uuid")]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    [Column("source", TypeName = "text")]
    public DataSource Source { get; set; }

    [Column("status", TypeName = "text")]
    public ImportStatus Status { get; set; }

    [Column("file_name", TypeName = "text")]
    public string FileName { get; set; } = string.Empty;

    [Column("started_at", TypeName = "timestamp with time zone")]
    public DateTime? StartedAt { get; set; }

    [Column("finished_at", TypeName = "timestamp with time zone")]
    public DateTime? FinishedAt { get; set; }

    [Column("imported_sessions", TypeName = "integer")]
    public int ImportedSessions { get; set; }

    [Column("errors", TypeName = "jsonb")]
    public string? Errors { get; set; }
}
