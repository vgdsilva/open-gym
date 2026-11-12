using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Common;

namespace OpenGym.Domain.Accounts;

/// <summary>UserId nulo = configuração global; preenchido = preferência do usuário, que sobrescreve a global.
/// As chaves conhecidas e seus padrões ficam em <c>Catalogs/ConfigurationKeys.cs</c>.</summary>
[Table("configuration")]
[Index(nameof(Key), nameof(UserId), nameof(SystemDeleted), IsUnique = true)]
public class Configuration : EntityControl
{
    [Column("key", TypeName = "text")]
    public string Key { get; set; } = string.Empty;

    [Column("user_id", TypeName = "uuid")]
    public Guid? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    [Column("value", TypeName = "text")]
    public string Value { get; set; } = string.Empty;
}
