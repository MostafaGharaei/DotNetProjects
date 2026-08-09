New-Item -Path . -Name ProjectContext.md -ItemType File -Force -Value @"
# ProjectContext

## Summary
- Name: <Repository name>
- ShortDescription: <One-line description>
- Purpose: <Why this repo exists (3 sentences max)>

## Targets
- Frameworks: .NET 10
- OS/support: <Windows/Linux/macOS if relevant>

## KeyFiles
- Solution: /path/to.sln
- Startup projects: /src/Project.Api/Project.Api.csproj
- Important folders: /src, /tests, /docs

## HowToBuild
- Build: `dotnet build` from repo root
- Test: `dotnet test` from repo root
- Run (dev): `dotnet run --project src/Project.Api`

## EntryPoints
- Main API project: `src/Project.Api/Program.cs`
- CLI tool: `src/Project.Cli/Program.cs`

## Dependencies
- Notable packages: `Serilog`, `AutoMapper`, `Dapper`
- Package restore: `dotnet restore`

## DevNotes
- Environment variables required: `ASPNETCORE_ENVIRONMENT`, `CONNECTION_STRING`
- Secrets: DO NOT store secrets in the repo. Reference local `secrets.json` or OS keyring.

## Tests
- Unit tests location: `/tests/*`.
- Minimum necessary steps to run tests: `dotnet test src/MyProject.Tests`.

## CI
- CI system: GitHub Actions (or specify)
- How to trigger a full pipeline: push to `main` or open PR.

## Updating
- Update `ProjectContext.md` whenever: project structure changes, new startup projects, or build instructions change.
"@