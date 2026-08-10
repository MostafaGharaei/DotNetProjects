# ProjectContext

## Repository
- Name: DotNetProjects
- Repository URL: https://github.com/MostafaGharaei/DotNetProjects
- Local clone path example: `D:\My Github\DotNetProjects`
- Primary branch: `master`

---

## Summary
A multi-project .NET solution containing educational, runnable implementations of SOLID principles and common design patterns. Each pattern is implemented in its own class library and demonstrated from a central console application.

Purpose: Help developers learn C#/.NET architecture with small, isolated, runnable examples. All code comments are in English and examples must be minimal and self-contained.

---

## Targets
- Frameworks: .NET 10
- OS Support: Windows, Linux, macOS

---

## Solution Structure (root)
- `DotNetProjects.sln` (solution)
- `/01-SolidPrinciples` (examples for SOLID)
- `/02-DesignPatterns` (pattern demos + console runner)
- `/tests` (future tests)

---

## 02-DesignPatterns Structure
- `02-DesignPatterns/DesignPatternsConsole` — Console App (main entry point)
  - Main file: `02-DesignPatterns/DesignPatternsConsole/Program.cs`
  - The console app must discover and call each demo's `DemoRunner.Run()` (or similar) method.
- Individual pattern projects (Class Libraries) live under `02-DesignPatterns`:
  - `FactoryDemo`
  - `RepositoryDemo`
  - `SingletonDemo`
  - `StrategyDemo`
  - `UnitOfWorkDemo`
  - (New demos go here — see "New Design Patterns To Add")

Each demo project must contain:
- Pattern implementation classes
- English comments explaining intent
- A `DemoRunner` class with a `public static void Run()` method demonstrating usage and printing to console

---

## Existing Design Patterns
1. Singleton  
2. Factory  
3. Strategy  
4. Repository  
5. UnitOfWork  

---

## New Design Patterns To Add (required)
Add the following new pattern demos inside `/02-DesignPatterns`:
- `DecoratorDemo`
- `MediatorDemo`
- `ObserverDemo`
- `AdapterDemo`
- `CqrsDemo` (use `CqrsDemo` or `CQRS` casing consistently; prefer `CqrsDemo` for PascalCase)

For each new pattern demo follow these rules:
- Folder/project name: PascalCase with `Demo` suffix (e.g., `DecoratorDemo`)
- Add a class `DemoRunner` with `public static void Run()` that prints a short demonstration to console
- Keep examples minimal, educational, and runnable without external services
- Use only in-repo code or document any required NuGet dependency in this file
- Add English inline comments explaining roles and responsibilities
- Include README or short header comment describing pattern intent and key classes

Recommended demo layout example for `DecoratorDemo`:
- `02-DesignPatterns/DecoratorDemo/IDecoratedService.cs`
- `02-DesignPatterns/DecoratorDemo/BaseService.cs`
- `02-DesignPatterns/DecoratorDemo/LoggingDecorator.cs`
- `02-DesignPatterns/DecoratorDemo/DemoRunner.cs` (contains `public static void Run()`)

Repeat similarly for `MediatorDemo`, `ObserverDemo`, `AdapterDemo`, and `CqrsDemo`. For CQRS:
- Provide simple command and query handlers, an in-memory dispatcher, and a small demo showing separation of read/write responsibilities.
- Keep persistence in-memory for simplicity.

---

## How to Add a New Pattern Demo (step-by-step)
1. Create new class library project under `02-DesignPatterns` named `<PatternName>Demo` (e.g., `DecoratorDemo`).
2. Implement the pattern (small set of classes) with English comments.
3. Add `DemoRunner` with `public static void Run()` that demonstrates the pattern and prints results.
4. Update `02-DesignPatterns/DesignPatternsConsole/Program.cs` to add a menu entry and call the demo runner.
   - Example: add `DesignPatternsConsole` menu item and call `DecoratorDemo.DemoRunner.Run();`
5. Build and run to verify:
   - Build: __dotnet build__
   - Run: __dotnet run --project 02-DesignPatterns/DesignPatternsConsole__
6. Add short README or header comments inside the demo folder describing the pattern, key classes, and how to run the demo.
7. Open a PR against `master` with clear description and reference to `ProjectContext.md`.

---

## How DesignPatternsConsole should discover demos
- Explicit registration (preferred): update `Program.cs` menu and call each demo's `DemoRunner.Run()`.
- Keep discovery simple and explicit for educational clarity.

---

## Dependencies
- No external packages required by default.
- If a demo needs a NuGet package, document it inside the demo folder and `ProjectContext.md`.

---

## DevNotes
- No secrets or environment variables required.
- All examples must be runnable directly from the console using the run instructions above.
- Use PascalCase for classes and folders. Suffix demo entry types with `Demo` and runner classes with `DemoRunner`.
- Adhere to repository `.editorconfig` rules. If `.editorconfig` does not exist, add one following .NET conventions.

---

## Tests
- No tests currently included.
- Future tests go under `/tests/*` using xUnit or NUnit for educational assertions.

---

## CI
- GitHub Actions is the suggested CI system.
- Suggested triggers: push to `main` or PR.
- CI should run: __dotnet restore__, __dotnet build__ and optionally unit tests.

---

## Updating this file
Update `ProjectContext.md` whenever:
- New design patterns are added
- Folder structure changes
- Build/run instructions change
- Any required dependencies are introduced

---

## Access & Copilot Web note
- This file documents repository layout and instructions; it does not change permissions.
- To let GitHub Copilot for Web or any collaborator access repository content, use GitHub repository settings on the web (invite collaborators, or make the repo public if appropriate).
- To refer Copilot Web to this file use the raw or blob URL: `https://github.com/MostafaGharaei/DotNetProjects/blob/master/ProjectContext.md`

---

## Suggested message (use in GitHub Copilot Web, issues, or PR description)
You can paste this message into GitHub Copilot Web, an issue, or a PR body to request adding the new patterns:

"I want to add the following new design pattern demos to this repository: Decorator, Mediator, Observer, Adapter, and CQRS. Each demo should be a class library under `02-DesignPatterns` named `<PatternName>Demo`, include a `DemoRunner.Run()` entry point, and be callable from `02-DesignPatterns/DesignPatternsConsole/Program.cs`. Please use in-memory examples, English comments, and avoid external services. Repository reference: https://github.com/MostafaGharaei/DotNetProjects/blob/master/ProjectContext.md"

---

## Contacts & CONTRIBUTING
- See `CONTRIBUTING.md` for contribution rules, formatting, and demo requirements.
- Quick checklist for PRs:
  - Builds (`__dotnet build__`)
  - Demo runnable from console
  - English comments
  - No secrets

---