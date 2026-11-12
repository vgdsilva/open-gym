using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Common;

namespace OpenGym.Domain.Catalog;

/// <summary>Equipamento necessário para o exercício.</summary>
[Table("exercise_equipment")]
[Index(nameof(ExerciseId), nameof(EquipmentId), nameof(SystemDeleted), IsUnique = true)]
public class ExerciseEquipment : EntityControl
{
    [Column("exercise_id", TypeName = "uuid")]
    public Guid ExerciseId { get; set; }

    [ForeignKey(nameof(ExerciseId))]
    public Exercise? Exercise { get; set; }

    [Column("equipment_id", TypeName = "uuid")]
    public Guid EquipmentId { get; set; }

    [ForeignKey(nameof(EquipmentId))]
    public Equipment? Equipment { get; set; }
}
