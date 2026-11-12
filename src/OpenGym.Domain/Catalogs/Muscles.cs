using OpenGym.Domain.Enums;

namespace OpenGym.Domain.Catalogs;

public sealed record MuscleDefinition(string Code, string Name, MuscleGroup Group);

/// <summary>
/// Catálogo de músculos, a partir dos alvos usados no catálogo do openGym.
/// O seeder sincroniza a tabela <c>muscle</c> a partir daqui; o código é estável e não deve mudar.
/// </summary>
public static class Muscles
{
    public const string Pectorals = "CHEST.PECTORALS";
    public const string SerratusAnterior = "CHEST.SERRATUS_ANTERIOR";
    public const string Lats = "BACK.LATS";
    public const string UpperBack = "BACK.UPPER_BACK";
    public const string Traps = "BACK.TRAPS";
    public const string LevatorScapulae = "BACK.LEVATOR_SCAPULAE";
    public const string LowerBack = "BACK.LOWER_BACK";
    public const string Delts = "SHOULDERS.DELTS";
    public const string Biceps = "ARMS.BICEPS";
    public const string Triceps = "ARMS.TRICEPS";
    public const string Forearms = "ARMS.FOREARMS";
    public const string Abs = "CORE.ABS";
    public const string Obliques = "CORE.OBLIQUES";
    public const string HipFlexors = "CORE.HIP_FLEXORS";
    public const string Quads = "LEGS.QUADS";
    public const string Hamstrings = "LEGS.HAMSTRINGS";
    public const string Calves = "LEGS.CALVES";
    public const string Adductors = "LEGS.ADDUCTORS";
    public const string Abductors = "LEGS.ABDUCTORS";
    public const string Tibialis = "LEGS.TIBIALIS";
    public const string Glutes = "GLUTES.GLUTES";
    public const string Cardiovascular = "OTHER.CARDIOVASCULAR";

    public static IReadOnlyList<MuscleDefinition> All { get; } =
    [
        new(Pectorals, "Peitoral", MuscleGroup.Chest),
        new(SerratusAnterior, "Serrátil anterior", MuscleGroup.Chest),
        new(Lats, "Dorsal", MuscleGroup.Back),
        new(UpperBack, "Costas superiores", MuscleGroup.Back),
        new(Traps, "Trapézio", MuscleGroup.Back),
        new(LevatorScapulae, "Levantador da escápula", MuscleGroup.Back),
        new(LowerBack, "Lombar", MuscleGroup.Back),
        new(Delts, "Deltoides", MuscleGroup.Shoulders),
        new(Biceps, "Bíceps", MuscleGroup.Arms),
        new(Triceps, "Tríceps", MuscleGroup.Arms),
        new(Forearms, "Antebraço", MuscleGroup.Arms),
        new(Abs, "Abdômen", MuscleGroup.Core),
        new(Obliques, "Oblíquos", MuscleGroup.Core),
        new(HipFlexors, "Flexores do quadril", MuscleGroup.Core),
        new(Quads, "Quadríceps", MuscleGroup.Legs),
        new(Hamstrings, "Posteriores da coxa", MuscleGroup.Legs),
        new(Calves, "Panturrilha", MuscleGroup.Legs),
        new(Adductors, "Adutores", MuscleGroup.Legs),
        new(Abductors, "Abdutores", MuscleGroup.Legs),
        new(Tibialis, "Tibial", MuscleGroup.Legs),
        new(Glutes, "Glúteos", MuscleGroup.Glutes),
        new(Cardiovascular, "Sistema cardiovascular", MuscleGroup.Other),
    ];

    /// <summary>Definição de um músculo pelo código (nula se não existir).</summary>
    public static MuscleDefinition? Find(string code) => All.FirstOrDefault(m => m.Code == code);
}
