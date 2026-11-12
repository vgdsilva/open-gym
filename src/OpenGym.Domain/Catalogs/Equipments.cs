namespace OpenGym.Domain.Catalogs;

public sealed record EquipmentDefinition(string Code, string Name);

/// <summary>
/// Catálogo de equipamentos. O seeder sincroniza a tabela <c>equipment</c> a partir daqui;
/// o código é estável e não deve mudar.
/// </summary>
public static class Equipments
{
    public const string BodyWeight = "BODY_WEIGHT";
    public const string Barbell = "BARBELL";
    public const string EzBar = "EZ_BAR";
    public const string TrapBar = "TRAP_BAR";
    public const string Dumbbell = "DUMBBELL";
    public const string Kettlebell = "KETTLEBELL";
    public const string Cable = "CABLE";
    public const string Machine = "MACHINE";
    public const string SmithMachine = "SMITH_MACHINE";
    public const string Bench = "BENCH";
    public const string PullUpBar = "PULL_UP_BAR";
    public const string DipBars = "DIP_BARS";
    public const string ResistanceBand = "RESISTANCE_BAND";
    public const string SuspensionTrainer = "SUSPENSION_TRAINER";
    public const string WeightPlate = "WEIGHT_PLATE";
    public const string MedicineBall = "MEDICINE_BALL";
    public const string StabilityBall = "STABILITY_BALL";
    public const string Landmine = "LANDMINE";
    public const string Sled = "SLED";
    public const string FoamRoller = "FOAM_ROLLER";

    public static IReadOnlyList<EquipmentDefinition> All { get; } =
    [
        new(BodyWeight, "Peso corporal"),
        new(Barbell, "Barra"),
        new(EzBar, "Barra EZ"),
        new(TrapBar, "Barra hexagonal"),
        new(Dumbbell, "Halter"),
        new(Kettlebell, "Kettlebell"),
        new(Cable, "Polia (cabo)"),
        new(Machine, "Máquina"),
        new(SmithMachine, "Smith"),
        new(Bench, "Banco"),
        new(PullUpBar, "Barra fixa"),
        new(DipBars, "Paralelas"),
        new(ResistanceBand, "Elástico"),
        new(SuspensionTrainer, "Suspensão (TRX)"),
        new(WeightPlate, "Anilha"),
        new(MedicineBall, "Medicine ball"),
        new(StabilityBall, "Bola suíça"),
        new(Landmine, "Landmine"),
        new(Sled, "Trenó"),
        new(FoamRoller, "Rolo"),
    ];

    /// <summary>Definição de um equipamento pelo código (nula se não existir).</summary>
    public static EquipmentDefinition? Find(string code) => All.FirstOrDefault(e => e.Code == code);
}
