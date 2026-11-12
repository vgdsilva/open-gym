using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;

namespace OpenGym.Domain.Catalog;

/// <summary>Músculo. O catálogo vive em <c>Catalogs/Muscles.cs</c> e é sincronizado pelo seeder.</summary>
[Table("muscle")]
[Index(nameof(Code), nameof(SystemDeleted), IsUnique = true)]
public class Muscle : EntityControl
{
    [Column("code", TypeName = "text")]
    public string Code { get; set; } = string.Empty;

    [Column("name", TypeName = "text")]
    public string Name { get; set; } = string.Empty;

    [Column("muscle_group", TypeName = "text")]
    public MuscleGroup Group { get; set; }
}
