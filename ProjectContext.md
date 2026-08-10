# ProjectContext

#region Repository
- Name: DotNetProjects
- Repository URL: https://github.com/MostafaGharaei/DotNetProjects
- Local clone path example: `D:\My Github\DotNetProjects`
- Primary branch: `master`
#endregion

#region Summary
A multi-project .NET 10 solution with educational, runnable implementations of SOLID principles and selected design patterns. Each pattern (or principle) lives in its own project and is executed from the console runner(s).

Note: This file now lists only files discovered in the workspace. If you want every file included, allow a repository scan or tell me which folders to add.
#endregion

#region Solution (root)
- `DotNetProjects.sln`
#endregion

#region 01-SolidPrinciples
- Project: `01-SolidPrinciples\SolidPrinciplesConsole`
  - `01-SolidPrinciples\SolidPrinciplesConsole\Program.cs`  // Console runner for SOLID demos

- Project: `01-SolidPrinciples\AfterDIP`
  - `01-SolidPrinciples\AfterDIP\NotificationManager.cs`
  - `01-SolidPrinciples\AfterDIP\INotificationService.cs`

Notes:
- The SOLID console calls several Before/After demo namespaces. Ensure the corresponding projects/files are present in the repo and included in the solution if any are missing.
#endregion

#region 02-DesignPatterns
- Project: `02-DesignPatterns\DesignPatternsConsole`
  - `02-DesignPatterns\DesignPatternsConsole\Program.cs`  // Main design patterns console runner
- Project: `02-DesignPatterns\FactoryDemo`
  - `02-DesignPatterns\FactoryDemo\INotification.cs`
  - `02-DesignPatterns\FactoryDemo\EmailNotification.cs`
  - `02-DesignPatterns\FactoryDemo\SMSNotification.cs`
  - `02-DesignPatterns\FactoryDemo\PushNotification.cs`
  - `02-DesignPatterns\FactoryDemo\NotificationFactory.cs`

Notes:
- `DesignPatternsConsole\Program.cs` contains explicit demo registration placeholders (DemoDecorator, DemoMediator, DemoObserver, DemoAdapter, DemoCqrs). These are designed to be explicit calls to `DemoRunner.Run()` in each demo project.
- Only projects/files discovered are listed above. Other pattern demo projects (DecoratorDemo, MediatorDemo, ObserverDemo, AdapterDemo, CqrsDemo) are referenced by the console runner as placeholders — implement them as separate class library projects under `02-DesignPatterns` following the `*Demo` + `DemoRunner.Run()` convention.
#endregion

#region Tests
- `/tests` (no files discovered in workspace; reserved for future tests)
#endregion

#region CI & Build
- Build: __dotnet build__
- Run console runner: __dotnet run --project 02-DesignPatterns/DesignPatternsConsole__
- CI suggestion: GitHub Actions (run restore, build, tests)
#endregion

#region How to make `Program.cs` editable by Copilot Web (quick)
1. Ensure repository access for Copilot Web (public repo or give app access).
2. Confirm `02-DesignPatterns/DesignPatternsConsole/Program.cs` is committed and pushed.
3. Add small markers inside `Program.cs` around demo registrations so Copilot Web can find them:
   - `// DemoRegistrationsStart`
   - `// DemoRegistrationsEnd`
4. Use explicit `DemoRunner.Run()` signatures in each demo project:
   - `public static class DemoRunner { public static void Run() { ... } }`
#endregion

#region Next steps I can do for you
- I can update this file to include a full repository scan output if you allow me to read all project files (I can fetch additional files you specify).
- Or I can insert the recommended `// DemoRegistrationsStart` / `// DemoRegistrationsEnd` snippet directly into `02-DesignPatterns/DesignPatternsConsole/Program.cs` for better Copilot Web compatibility (tell me to proceed).
#endregion

Apology: I removed previously suggested folders that were not confirmed present. If any legitimate project files are missing from this list, tell me which folders to scan or grant permission to enumerate repository files and I will add them with #region blocks so you can fold sections easily.