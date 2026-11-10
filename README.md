# Open Gym

App de treino de musculação **self-hosted**, feito 100% em **.NET**: planeje rotinas, registre treinos pelo celular (inclusive sem sinal na academia), acompanhe sua evolução e use IA para montar e ajustar planos a partir dos seus próprios dados.

> **Status:** em planejamento. Ainda não há código; este repositório está sendo estruturado.

## Sobre o projeto

O Open Gym é uma evolução pessoal do [openGym](https://github.com/DuarteSantos8/openGym), de Duarte Santos, reescrita do zero em .NET. A ideia é manter o que o original faz bem (planejamento de rotinas, treino guiado, progressão automática, AI Coach) e resolver pontos estruturais:

- **Banco relacional** em vez de arquivos JSON por usuário, para consultar, relatar e dar contexto à IA de forma eficiente.
- **Papéis de verdade** (Administrador e Usuário), com uma área administrativa completa em vez de uma lista de IDs em variável de ambiente.
- **IA integrada** por uma abstração única, para trocar de provedor sem mudar código.

## Funcionalidades planejadas

**Para o usuário**

- Rotinas por dia da semana ou por rotação (A, B, C), programas, supersets, drop sets e rest-pause
- Catálogo de exercícios com busca, filtros por músculo e equipamento, e exercícios próprios
- Treino guiado: cargas pré-preenchidas, timer de descanso, detecção de PR, RIR/RPE e cálculo de anilhas
- Funcionamento offline durante o treino, com sincronização depois
- Progresso: motor de progressão, 1RM estimado, gráficos, peso corporal e medidas
- Importação do histórico do openGym e de outros apps (Strong, Hevy)

**Assistente de IA**

- Gerador de plano a partir de uma entrevista curta (objetivo, dias, equipamento, lesões)
- Resumo pós-treino com PRs e comparação com semanas anteriores
- Chat com seus dados ("quanto evoluí no supino em 3 meses?"), consultando o banco por *tool calling*
- Sugestões de ajuste de plano (estagnação, deload) que o usuário aceita ou recusa

**Área administrativa**

- Gestão de usuários: convidar, bloquear, trocar papel, redefinir acesso
- Cadastro aberto ou só por convite
- Configuração da IA (provedor, modelo, limite de uso por usuário)
- Log de auditoria, saúde do sistema e backup

## Stack

| Camada | Tecnologia |
| --- | --- |
| Interface | Blazor WebAssembly como PWA instalável |
| Backend | ASP.NET Core (.NET 10) |
| Banco de dados | PostgreSQL com EF Core |
| Autenticação | ASP.NET Core Identity com papéis e passkeys |
| IA | OpenAI via Microsoft.Extensions.AI (`IChatClient`) |
| Deploy | Docker Compose |

A estrutura da solução ainda está sendo definida e será documentada aqui quando o código chegar.

## Roadmap

1. **Fundação:** solução, banco, autenticação com papéis, Docker Compose e CI
2. **Catálogo** de exercícios
3. **Planejamento** de rotinas e agenda
4. **Treino guiado** com modo offline
5. **Progresso** e gráficos
6. **Área administrativa**
7. **IA:** gerador de plano, resumo pós-treino e chat
8. **Importação** de dados de outros apps

## Créditos e licença

Este projeto é inspirado no [openGym](https://github.com/DuarteSantos8/openGym) e pode portar partes da sua lógica de domínio (como progressão, 1RM e recuperação muscular). Todo o crédito pelas ideias e pelo trabalho original é do autor e dos contribuidores do openGym.

Por isso, o Open Gym é distribuído sob a mesma licença, a **GNU Affero General Public License v3.0** ([LICENSE](LICENSE)). Na prática: você pode usar, modificar e hospedar livremente, mas se disponibilizar uma instância modificada para outras pessoas pela rede, precisa oferecer o código-fonte a elas.

As fotos e animações de exercícios do openGym **não** são usadas aqui, pois são licenciadas separadamente apenas para aquele app. A mídia deste projeto virá de fontes abertas ou do próprio usuário.
