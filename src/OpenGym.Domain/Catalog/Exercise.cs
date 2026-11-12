using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Accounts;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;

namespace OpenGym.Domain.Catalog;

/// <summary>OwnerId nulo = catálogo global; preenchido = exercício personalizado, visível só para o dono.</summary>
[Table("exercise")]
[Index(nameof(Slug), nameof(OwnerId), nameof(SystemDeleted), IsUnique = true)]
public class Exercise : EntityControl
{
    [Column("name", TypeName = "text")]
    public string Name { get; set; } = string.Empty;

    [Column("slug", TypeName = "text")]
    public string Slug { get; set; } = string.Empty;

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    /// <summary>Passo a passo, um item por linha.</summary>
    [Column("instructions", TypeName = "text[]")]
    public List<string> Instructions { get; set; } = [];

    [Column("category", TypeName = "text")]
    public ExerciseCategory Category { get; set; }

    [Column("body_region", TypeName = "text")]
    public BodyRegion BodyRegion { get; set; }

    [Column("mechanic", TypeName = "text")]
    public Mechanic? Mechanic { get; set; }

    [Column("force", TypeName = "text")]
    public ForceType? Force { get; set; }

    [Column("level", TypeName = "text")]
    public ExperienceLevel? Level { get; set; }

    [Column("tracking_type", TypeName = "text")]
    public TrackingType TrackingType { get; set; }

    [Column("owner_id", TypeName = "uuid")]
    public Guid? OwnerId { get; set; }

    [ForeignKey(nameof(OwnerId))]
    public User? Owner { get; set; }

    /// <summary>Exercício do qual este é uma variação.</summary>
    [Column("variant_of_id", TypeName = "uuid")]
    public Guid? VariantOfId { get; set; }

    [ForeignKey(nameof(VariantOfId))]
    public Exercise? VariantOf { get; set; }

    [Column("is_archived", TypeName = "boolean")]
    public bool IsArchived { get; set; }

    [Column("source", TypeName = "text")]
    public DataSource Source { get; set; }
}
