using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Common;

namespace OpenGym.Domain.Catalog;

/// <summary>Nome e textos do exercício em outro idioma.</summary>
[Table("exercise_translation")]
[Index(nameof(ExerciseId), nameof(Locale), nameof(SystemDeleted), IsUnique = true)]
public class ExerciseTranslation : EntityControl
{
    [Column("exercise_id", TypeName = "uuid")]
    public Guid ExerciseId { get; set; }

    [ForeignKey(nameof(ExerciseId))]
    public Exercise? Exercise { get; set; }

    /// <summary>Ex.: pt-BR, en.</summary>
    [Column("locale", TypeName = "text")]
    public string Locale { get; set; } = string.Empty;

    [Column("name", TypeName = "text")]
    public string Name { get; set; } = string.Empty;

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("instructions", TypeName = "text[]")]
    public List<string> Instructions { get; set; } = [];
}
