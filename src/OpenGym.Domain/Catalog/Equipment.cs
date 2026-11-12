using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Common;

namespace OpenGym.Domain.Catalog;

/// <summary>Equipamento. O catálogo vive em <c>Catalogs/Equipments.cs</c> e é sincronizado pelo seeder.</summary>
[Table("equipment")]
[Index(nameof(Code), nameof(SystemDeleted), IsUnique = true)]
public class Equipment : EntityControl
{
    [Column("code", TypeName = "text")]
    public string Code { get; set; } = string.Empty;

    [Column("name", TypeName = "text")]
    public string Name { get; set; } = string.Empty;
}
