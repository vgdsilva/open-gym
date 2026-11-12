namespace OpenGym.Domain.Catalogs;

public sealed record MenuDefinition(string Code, string Description, string? ParentCode, string? Icon, string? Url, int SortOrder);

/// <summary>
/// Catálogo de menus do sistema. Cada página, endpoint e tool de IA declara o código que exige.
/// Para um menu novo: adicione a constante e a definição aqui (pais antes dos filhos);
/// o seeder cria a linha no banco na próxima inicialização. Menu que sair do catálogo é desativado pelo seeder.
/// <para>
/// A URL da página segue o caminho do menu (em pt-BR, minúsculo). Menu sem URL é só agrupador
/// (título de seção); menus de primeiro nível com URL ficam na seção "Principal".
/// </para>
/// </summary>
public static class Menus
{
    // Principal
    public const string Dashboard = "DASHBOARD";
    public const string Workout = "WORKOUT";
    public const string Progress = "PROGRESS";
    public const string Coach = "COACH"; // Coach IA (chat)

    // Cadastros
    public const string Registry = "REG";
    public const string Exercises = "REG.EXERCISES";
    public const string Routines = "REG.ROUTINES";
    public const string Measurements = "REG.MEASUREMENTS";

    // Configurações
    public const string Settings = "CONFIG";
    public const string Users = "CONFIG.USERS";
    public const string GlobalCatalog = "CONFIG.CATALOG";
    public const string Ai = "CONFIG.AI";
    public const string Import = "CONFIG.IMPORT";

    public static IReadOnlyList<MenuDefinition> All { get; } =
    [
        new(Dashboard, "Dashboard", null, "chart", "/dashboard", 10),
        new(Workout, "Treinar", null, "dumbbell", "/treinar", 20),
        new(Progress, "Progresso", null, "trending", "/progresso", 30),
        new(Coach, "Coach IA", null, "chat", "/coach-ia", 40),

        new(Registry, "Cadastros", null, "folder", null, 50),
        new(Exercises, "Exercícios", Registry, "list", "/cadastros/exercicios", 51),
        new(Routines, "Rotinas", Registry, "calendar", "/cadastros/rotinas", 52),
        new(Measurements, "Medidas", Registry, "ruler", "/cadastros/medidas", 53),

        new(Settings, "Configurações", null, "gear", null, 90),
        new(Users, "Usuários", Settings, "people", "/configuracoes/usuarios", 91),
        new(GlobalCatalog, "Catálogo global", Settings, "book", "/configuracoes/catalogo", 92),
        new(Ai, "IA", Settings, "sparkles", "/configuracoes/ia", 93),
        new(Import, "Importação", Settings, "upload", "/configuracoes/importacao", 94),
    ];

    /// <summary>Menus liberados por padrão a um usuário comum recém-criado.</summary>
    public static IReadOnlyList<string> DefaultForNewUser { get; } =
    [
        Dashboard, Workout, Progress, Coach, Exercises, Routines, Measurements, Import,
    ];

    /// <summary>URL da página de um menu (nula se for só agrupador ou se o código não existir).</summary>
    public static string? UrlOf(string code) => Find(code)?.Url;

    /// <summary>Definição de um menu pelo código (nula se não existir).</summary>
    public static MenuDefinition? Find(string code) => All.FirstOrDefault(m => m.Code == code);
}
