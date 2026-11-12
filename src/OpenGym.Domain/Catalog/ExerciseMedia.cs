using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;

namespace OpenGym.Domain.Catalog;

/// <summary>Imagem, animação ou vídeo do exercício, com licença e autoria (as mídias do openGym não podem ser usadas).</summary>
[Table("exercise_media")]
[Index(nameof(ExerciseId))]
public class ExerciseMedia : EntityControl
{
    [Column("exercise_id", TypeName = "uuid")]
    public Guid ExerciseId { get; set; }

    [ForeignKey(nameof(ExerciseId))]
    public Exercise? Exercise { get; set; }

    [Column("type", TypeName = "text")]
    public MediaType Type { get; set; }

    /// <summary>Mídia externa. Preencha Url ou StoragePath.</summary>
    [Column("url", TypeName = "text")]
    public string? Url { get; set; }

    /// <summary>Mídia guardada no servidor.</summary>
    [Column("storage_path", TypeName = "text")]
    public string? StoragePath { get; set; }

    [Column("license", TypeName = "text")]
    public string License { get; set; } = string.Empty;

    [Column("attribution", TypeName = "text")]
    public string? Attribution { get; set; }

    [Column("sort_order", TypeName = "integer")]
    public int SortOrder { get; set; }
}
