# Copilot instructions for Asg (C# exercises)

Purpose
- Short guide to help AI coding agents work productively in this repository of small C# console exercises.

Big picture
- This repo is a Visual Studio solution `Asg.sln` containing many small, independent console projects (one exercise per folder). Example: `LoopsAndJumpStatements/PrimeNumber/` contains `PrimeNumber.csproj` and `Program.cs`.
- Each project is a standalone executable targeting `net10.0` (see `<TargetFramework>net10.0</TargetFramework>` in project files).

Important workflows
- Build entire solution: `dotnet build Asg.sln`
- Run a single exercise: `dotnet run --project <path-to-project.csproj>`
  - Example: `dotnet run --project LoopsAndJumpStatements/PrimeNumber/PrimeNumber.csproj`
- Open the solution in Visual Studio / VS Code using `Asg.sln` for full debugging support.

Project conventions and patterns
- One project per folder; project file is named `<FolderName>.csproj` and contains minimal SDK settings.
- Program entry point is `Main` inside `Program.cs` (or a single class named after the exercise). Keep changes minimal and consistent with the small-console pattern.
- Input handling frequently uses `TryParse` and `Console.ReadLine()`; outputs use `Console.WriteLine()`.

Integration points & dependencies
- There are no external NuGet packages or service integrations present. Projects are self-contained console apps.

What AI agents should do (concrete guidance)
- Preserve project targets (`net10.0`) unless the user asks to change framework versions.
- When adding a new exercise, follow existing structure: create a folder, add `<Name>.csproj` (SDK-style, target `net10.0`), add `Program.cs` with `Main`.
- Keep modifications local to a single project unless the change requires solution-wide updates; always run `dotnet build Asg.sln` after edits.
- Avoid changing shared solution-level files (like `Asg.sln`) without explicit approval.

Common TODOs you may encounter
- Fix typos in console messages or input validation (safe, project-local).
- Improve input validation (use `TryParse`) and make messages clearer.

Files to inspect when orienting yourself
- `Asg.sln` (solution root)
- Example projects: `LoopsAndJumpStatements/PrimeNumber/PrimeNumber.csproj` and `LoopsAndJumpStatements/PrimeNumber/Program.cs`
- Other exercise entries under top-level folders (e.g., `ConditionalStatements/Program.cs`).

What not to do
- Do not introduce heavy frameworks, databases, or extra packages without owner approval.
- Do not refactor multiple projects at once; these are intended as isolated exercises.

If anything is unclear, please ask the repo owner for preferred framework version, CI expectations, or test harness details.
