namespace OpenGym.Domain.Catalogs;

public sealed record ConfigurationDefinition(string Key, string DefaultValue);

/// <summary>
/// Catálogo das configurações globais conhecidas (UserId nulo) e seus valores padrão.
/// O seeder cria as que faltam e nunca sobrescreve um valor já editado.
/// As chaves <c>Defaults:*</c> também podem ser gravadas por usuário (UserId preenchido) como preferência.
/// </summary>
public static class ConfigurationKeys
{
    public const string Locale = "Defaults:Locale";
    public const string TimeZone = "Defaults:TimeZone";
    public const string WeightUnit = "Defaults:WeightUnit";
    public const string IntensityScale = "Defaults:IntensityScale";
    public const string RestSeconds = "Defaults:RestSeconds";

    public const string AuditRetentionDays = "Audit:RetentionDays";

    /// <summary>IA ligada. Fica falso até existir a chave OPENAI_API_KEY no ambiente.</summary>
    public const string AiEnabled = "Ai:Enabled";

    /// <summary>Modelo da OpenAI usado pelo Coach IA. Vazio = definir na tela de IA.</summary>
    public const string AiModel = "Ai:Model";

    public const string AiDailyTokenLimitPerUser = "Ai:DailyTokenLimitPerUser";

    public const string ImportMaxFileMb = "Import:MaxFileMb";

    public static IReadOnlyList<ConfigurationDefinition> All { get; } =
    [
        new(Locale, "pt-BR"),
        new(TimeZone, "America/Sao_Paulo"),
        new(WeightUnit, "Kg"),
        new(IntensityScale, "Rir"),
        new(RestSeconds, "90"),
        new(AuditRetentionDays, "365"),
        new(AiEnabled, "false"),
        new(AiModel, ""),
        new(AiDailyTokenLimitPerUser, "50000"),
        new(ImportMaxFileMb, "50"),
    ];
}
