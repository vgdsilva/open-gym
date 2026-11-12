using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;

namespace OpenGym.Domain.Catalog;

/// <summary>Músculo trabalhado pelo exercício, como primário ou secundário.</summary>
[Table("exercise_muscle")]
[Index(nameof(ExerciseId), nameof(MuscleId), nameof(SystemDeleted), IsUnique = true)]
public class ExerciseMuscle : EntityControl
{
    [Column("exercise_id", TypeName = "uuid")]
    public Guid ExerciseId { get; set; }

    [ForeignKey(nameof(ExerciseId))]
    public Exercise? Exercise { get; set; }

    [Column("muscle_id", TypeName = "uuid")]
    public Guid MuscleId { get; set; }

    [ForeignKey(nameof(MuscleId))]
    public Muscle? Muscle { get; set; }

    [Column("role", TypeName = "text")]
    public MuscleRole Role { get; set; }
}
