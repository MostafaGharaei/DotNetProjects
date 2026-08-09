# 🎯 Design Patterns Learning Project

## 📋 Project Overview
This project demonstrates a set of important Design Patterns with practical examples. Each pattern implementation should target **.NET 10** and modern C#.

---

## 📚 Table of Contents
1. [Design Patterns Covered](#-design-patterns-covered)
2. [Project Structure](#-project-structure)
3. [Technologies Used](#-technologies-used)
4. [Getting Started](#-getting-started)
5. [How to Run in Visual Studio](#-how-to-run-in-visual-studio)
6. [How to Run via Command Line](#-how-to-run-via-command-line)
7. [Pattern Details](#-pattern-details)
8. [Code Examples](#-code-examples)
9. [Troubleshooting](#-troubleshooting)
10. [Contributing](#-contributing)
11. [License](#-license)

---

## 🎯 Design Patterns Covered

The repository is intended to include demonstrations for these patterns (requested):
- Decorator (Structural/Behavioral)
- Mediator (Behavioral)
- Observer (Behavioral)
- Adapter (Structural)
- CQRS (Architectural pattern: Command/Query segregation)

Each pattern should include:
- Small runnable example project or namespace (e.g. `DecoratorDemo`, `MediatorDemo`, etc.)
- Short English comments in code explaining intent and key lines
- Unit tests where appropriate

---

## 🏗️ Project Structure
- `02-DesignPatterns/DesignPatternsConsole` — console runner that calls each demo
- `02-DesignPatterns/DecoratorDemo` — (implement) Decorator example
- `02-DesignPatterns/MediatorDemo` — (implement) Mediator example
- `02-DesignPatterns/ObserverDemo` — (implement) Observer example
- `02-DesignPatterns/AdapterDemo` — (implement) Adapter example
- `02-DesignPatterns/CqrsDemo` — (implement) CQRS example

## 🛠️ Getting Started
- In Visual Studio: set `DesignPatternsConsole` as startup project using __Solution Explorer__ → right-click project → __Set as Startup Project__.
- From command line:
  - Build: `dotnet build`
  - Run console runner: `dotnet run --project 02-DesignPatterns/DesignPatternsConsole`

## 📡 Make this repository available to Copilot Web
1. Commit and push your changes to the remote (GitHub).
2. Open the repository in the browser (GitHub).
3. In Copilot Web (or Codespaces) open the repository — Copilot will index repository files (including this README and `Program.cs`) and can be asked to implement the demo namespaces.
4. Alternatively, you can paste the repository URL into any Copilot Web upload/context field if the product supports it.

---

## 📝 Notes for implementers
- Use English comments in code to explain purpose of classes and key methods.
- Keep demos small and self-contained (in-memory data is fine).
- Target .NET 10 in project files.
