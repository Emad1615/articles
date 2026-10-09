📚 Article Publishing Platform Microservices
An enterprise-grade, distributed Microservices platform built with .NET 9, adopting Domain-Driven Design (DDD) and Vertical Slice Architecture. The platform streamlines the complete academic publishing lifecycle—from submission and review to production and public indexing.

🏛️ Architecture Overview
The system transitions away from traditional layered architecture in favor of Vertical Slice Architecture within each Bounded Context, ensuring high cohesion, maintainability, and loose coupling.

[ Clients / Frontends ]
         │
         ▼
 ┌───────────────┐
 │  API Gateway  │
 └───────┬───────┘
         │
  ┌──────┴─────────────────────────────────────────┐
  │                                                │
  ▼                                                ▼
┌───────────────────────────┐            ┌───────────────────────────┐
│       Auth Service        │            │     Journals Service      │
│  (SQL Server / JWT RBAC)  │            │      (Redis Stack)        │
└───────────────────────────┘            └───────────────────────────┘
          │                                        │
          ▼                                        ▼
┌───────────────────────────┐            ┌───────────────────────────┐
│    Submission Service     │ ──Event──► │      Review Service       │
│   (SQL Server + GridFS)   │ (RabbitMQ) │       (SQL Server)        │
└───────────────────────────┘            └───────────────────────────┘
          │                                        │
          ▼                                        ▼
┌───────────────────────────┐            ┌───────────────────────────┐
│     ArticleHub Service    │ ◄──Sync─── │    Hasura GraphQL Engine  │
│   (PostgreSQL / MediatR)  │            │    (Real-time Queries)    │
└───────────────────────────┘            └───────────────────────────┘

🛠️ Tech Stack & Infrastructure
Framework: .NET 9 Web API (Minimal APIs)

Architecture: Domain-Driven Design (DDD), Vertical Slice Architecture, CQRS (MediatR)

Databases:

PostgreSQL: Primary storage for ArticleHub (Npgsql EF Core Provider)

Microsoft SQL Server: Core relational DB for Auth, Submission, & Review services

MongoDB (GridFS): Document & Binary storage for manuscripts & attachments

Redis Stack: Caching layer for Journals & Fast Lookups

Event-Driven Messaging: RabbitMQ with MassTransit

GraphQL & Data API: Hasura GraphQL Engine (Connected to PostgreSQL)

Containerization & Orchestration: Docker & Docker Compose

🛠️ Tech Stack & Infrastructure
Framework: .NET 9 Web API (Minimal APIs)

Architecture: Domain-Driven Design (DDD), Vertical Slice Architecture, CQRS (MediatR)

Databases:

PostgreSQL: Primary storage for ArticleHub (Npgsql EF Core Provider)

Microsoft SQL Server: Core relational DB for Auth, Submission, & Review services

MongoDB (GridFS): Document & Binary storage for manuscripts & attachments

Redis Stack: Caching layer for Journals & Fast Lookups

Event-Driven Messaging: RabbitMQ with MassTransit

GraphQL & Data API: Hasura GraphQL Engine (Connected to PostgreSQL)

Containerization & Orchestration: Docker & Docker Compose
