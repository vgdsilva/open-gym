using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Common;

namespace OpenGym.Domain.Accounts;

/// <summary>Usuário do sistema. Admin acessa todos os menus ativos, sem linhas em user_menu_permission.</summary>
[Table("users")]
[Index(nameof(UserName), nameof(SystemDeleted), IsUnique = true)]
public class User : EntityControl
{
    /// <summary>Sempre em minúsculas (normalizado pela feature de usuários).</summary>
    [Column("user_name", TypeName = "text")]
    public string UserName { get; set; } = string.Empty;

    [Column("display_name", TypeName = "text")]
    public string DisplayName { get; set; } = string.Empty;

    [Column("password_hash", TypeName = "text")]
    public string PasswordHash { get; set; } = string.Empty;

    [Column("is_admin", TypeName = "boolean")]
    public bool IsAdmin { get; set; }

    /// <summary>Bloqueado não consegue entrar; as permissões continuam guardadas.</summary>
    [Column("is_blocked", TypeName = "boolean")]
    public bool IsBlocked { get; set; }

    [Column("last_login_at", TypeName = "timestamp with time zone")]
    public DateTime? LastLoginAt { get; set; }
}
