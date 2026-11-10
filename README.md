# Open Gym

A **self-hosted** strength training app built entirely on **.NET**: plan your routines, log workouts from your phone (even with no signal at the gym), track your progress, and use AI to build and adjust plans from your own data.

> **Status:** planning. There is no code yet; this repository is still being set up.

## About

Open Gym is a personal evolution of [openGym](https://github.com/DuarteSantos8/openGym) by Duarte Santos, rewritten from scratch in .NET. The goal is to keep what the original does well (routine planning, guided workouts, automatic progression, an AI coach) and fix a few structural points:

- **A relational database** instead of per-user JSON files, so data is easy to query, report on, and feed to the AI.
- **Real roles** (Admin and User), with a full admin area instead of a list of IDs in an environment variable.
- **Built-in AI** behind a single abstraction, so the provider can be swapped without code changes.

## Planned features

**For users**

- Routines by day of the week or by rotation (A, B, C), programs, supersets, drop sets, and rest-pause
- Exercise catalog with search, filters by muscle and equipment, and custom exercises
- Guided workouts: prefilled weights, rest timer, PR detection, RIR/RPE, and plate calculator
- Offline support during workouts, syncing afterwards
- Progress: progression engine, estimated 1RM, charts, body weight, and measurements
- Import history from openGym and other apps (Strong, Hevy)

**AI assistant**

- Plan generator from a short interview (goal, days, equipment, injuries)
- Post-workout summary with PRs and comparison with previous weeks
- Chat with your data ("how much has my bench press improved in 3 months?"), querying the database through tool calling
- Plan adjustment suggestions (plateaus, deloads) that the user accepts or rejects

**Admin area**

- User management: invite, block, change role, reset access
- Open sign-up or invite-only
- AI configuration (provider, model, per-user usage limits)
- Audit log, system health, and backups

## Tech stack

| Layer | Technology |
| --- | --- |
| Frontend | Blazor WebAssembly as an installable PWA |
| Backend | ASP.NET Core (.NET 10) |
| Database | PostgreSQL with EF Core |
| Authentication | ASP.NET Core Identity with roles and passkeys |
| AI | OpenAI via Microsoft.Extensions.AI (`IChatClient`) |
| Deployment | Docker Compose |

The solution structure is still being defined and will be documented here once code lands.

## Roadmap

1. **Foundation:** solution, database, authentication with roles, Docker Compose, and CI
2. **Exercise catalog**
3. **Planning:** routines and schedule
4. **Guided workouts** with offline mode
5. **Progress** and charts
6. **Admin area**
7. **AI:** plan generator, post-workout summary, and chat
8. **Import** from other apps

## Credits and license

This project is inspired by [openGym](https://github.com/DuarteSantos8/openGym) and may port parts of its domain logic (such as progression, 1RM, and muscle recovery). All credit for the original ideas and work goes to the openGym author and contributors.

For that reason, Open Gym is released under the same license, the **GNU Affero General Public License v3.0** ([LICENSE](LICENSE)). In short: you are free to use, modify, and host it, but if you make a modified instance available to other people over a network, you must offer them its source code.

openGym's exercise photos and animations are **not** used here, since they are licensed separately for that app only. Media for this project will come from open sources or from users themselves.
