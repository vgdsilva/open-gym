# OpenGym.Domain

O domínio do Open Gym: só **entidades**, **enums** e **catálogos**. Não tem regra de negócio nem `DbContext`
(isso fica na API, em `Features/` e `Data/`, no mesmo padrão do open-finance).

## Pastas

| Pasta | Conteúdo | Bloco |
| --- | --- | --- |
| `Common/` | `EntityControl`, a base de todas as entidades | — |
| `Accounts/` | `User`, `UserProfile`, `MenuItem`, `UserMenuPermission`, `Configuration`, `PasskeyCredential` | 1 e 9 |
| `Administration/` | `AuditLog` | 2 |
| `Catalog/` | `Exercise`, `ExerciseTranslation`, `Muscle`, `ExerciseMuscle`, `Equipment`, `ExerciseEquipment`, `ExerciseMedia` | 3 |
| `Planning/` | `Routine`, `RoutineDay`, `RoutineExercise`, `PlannedSet` | 4 |
| `Workouts/` | `WorkoutSession`, `SessionExercise`, `SetLog` | 5 |
| `Progress/` | `PersonalRecord`, `BodyMeasurement` | 6 |
| `Ai/` | `TrainingProgram`, `AiConversation`, `AiMessage`, `AiSuggestion`, `AiUsage` | 7 |
| `Imports/` | `ImportJob` | 8 |
| `Enums/` | todos os enums | — |
| `Catalogs/` | listas definidas em código: `Menus`, `ConfigurationKeys`, `Muscles`, `Equipments` | — |

## Convenções

- Toda entidade herda `EntityControl` (`id` Guid v7, `create_at`, `update_at`, `system_deleted`, `system_deleted_at`)
  e é configurada **por atributos** (`[Table]`, `[Column]`, `[Index]`, `[ForeignKey]`). Tabelas e colunas em snake_case.
- Exclusão lógica: `system_deleted = Guid.Empty` (ativo) ou o próprio `Id` (excluído). Todo índice único inclui `SystemDeleted`.
- Datas de auditoria em UTC (`timestamptz`); datas de negócio em `DateOnly` (`date`).
- Peso sempre em kg (`numeric(6,2)`); a conversão para lb é só de exibição.
- Enums são gravados como texto. Isso exige, no `AppDbContext` da API:
  `configurationBuilder.Properties<Enum>().HaveConversion<string>()` em `ConfigureConventions`.
- O filtro global de exclusão lógica, os carimbos de data e o `NULLS NOT DISTINCT` dos índices únicos
  também ficam no `AppDbContext`, como no open-finance.
- A única dependência externa é `Microsoft.EntityFrameworkCore.Abstractions` (atributo `[Index]`).
