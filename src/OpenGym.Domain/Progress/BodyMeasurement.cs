using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OpenGym.Domain.Accounts;
using OpenGym.Domain.Common;
using OpenGym.Domain.Enums;

namespace OpenGym.Domain.Progress;

/// <summary>Medida corporal: peso, percentual de gordura ou circunferência.</summary>
[Table("body_measurement")]
[Index(nameof(UserId), nameof(Type), nameof(MeasuredOn))]
public class BodyMeasurement : EntityControl
{
    [Column("user_id", TypeName = "uuid")]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    [Column("type", TypeName = "text")]
    public MeasurementType Type { get; set; }

    /// <summary>Em kg, % ou cm, conforme o Type.</summary>
    [Column("value", TypeName = "numeric(6,2)")]
    public decimal Value { get; set; }

    [Column("measured_on", TypeName = "date")]
    public DateOnly MeasuredOn { get; set; }

    [Column("notes", TypeName = "text")]
    public string? Notes { get; set; }
}
