using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Accounts;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;

namespace OpenGym.Domain.Accounts;

/// <summary>Dados de treino do usuário (1:1 com User). É o contexto que a IA lê.</summary>
[Table("user_profile")]
[Index(nameof(UserId), nameof(SystemDeleted), IsUnique = true)]
public class UserProfile : EntityControl
{
    [Column("user_id", TypeName = "uuid")]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    [Column("birth_date", TypeName = "date")]
    public DateOnly? BirthDate { get; set; }

    [Column("height_cm", TypeName = "numeric(5,1)")]
    public decimal? HeightCm { get; set; }

    [Column("sex", TypeName = "text")]
    public Sex Sex { get; set; }

    [Column("experience_level", TypeName = "text")]
    public ExperienceLevel ExperienceLevel { get; set; }

    [Column("goal", TypeName = "text")]
    public TrainingGoal Goal { get; set; }

    /// <summary>Lesões e restrições em texto livre, usadas pelo gerador de plano.</summary>
    [Column("injuries", TypeName = "text")]
    public string? Injuries { get; set; }
}
