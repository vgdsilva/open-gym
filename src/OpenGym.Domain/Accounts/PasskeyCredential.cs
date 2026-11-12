using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Common;

namespace OpenGym.Domain.Accounts;

/// <summary>Passkey (WebAuthn) do usuário. Bloco 9, opcional.</summary>
[Table("passkey_credential")]
[Index(nameof(CredentialId), nameof(SystemDeleted), IsUnique = true)]
public class PasskeyCredential : EntityControl
{
    [Column("user_id", TypeName = "uuid")]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    [Column("credential_id", TypeName = "bytea")]
    public byte[] CredentialId { get; set; } = [];

    [Column("public_key", TypeName = "bytea")]
    public byte[] PublicKey { get; set; } = [];

    [Column("sign_count", TypeName = "bigint")]
    public long SignCount { get; set; }

    /// <summary>Nome dado pelo usuário, ex.: "iPhone".</summary>
    [Column("name", TypeName = "text")]
    public string Name { get; set; } = string.Empty;

    [Column("transports", TypeName = "text")]
    public string? Transports { get; set; }

    [Column("last_used_at", TypeName = "timestamp with time zone")]
    public DateTime? LastUsedAt { get; set; }
}
