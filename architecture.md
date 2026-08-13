# Task Management System – Architecture

This project follows Clean Architecture principles:

- Domain: Contains core entities.
- Application: Contains CQRS commands, queries, and Mediator handlers.
- Infrastructure: Contains repository implementations.
- API: Exposes REST endpoints.

Mediator Pattern is used to decouple controllers from business logic.
CQRS is used to separate read and write operations.
