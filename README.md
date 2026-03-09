# ZenBudget — Backend API
![.NET 8](https://img.shields.io/badge/.NET_8.0-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![C# 12](https://img.shields.io/badge/C%23_12-239120?style=flat-square&logo=c-sharp&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/EF_Core_8-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL_16-336791?style=flat-square&logo=postgresql&logoColor=white)
![Redis](https://img.shields.io/badge/Redis_7-DC382D?style=flat-square&logo=redis&logoColor=white)

![JWT](https://img.shields.io/badge/JWT-000000?style=flat-square&logo=JSON%20web%20tokens&logoColor=white)
![Firebase](https://img.shields.io/badge/Firebase_Auth-FFCA28?style=flat-square&logo=firebase&logoColor=black)
![Azure Blob Storage](https://img.shields.io/badge/Azure_Blob-0089D6?style=flat-square&logo=microsoft-azure&logoColor=white)
![Google Gemini](https://img.shields.io/badge/Gemini_API-8E75B2?style=flat-square&logo=google&logoColor=white)
![SendGrid](https://img.shields.io/badge/SendGrid-00B2F2?style=flat-square&logo=twilio&logoColor=white)

![Hangfire](https://img.shields.io/badge/Hangfire-0071CE?style=flat-square)
![Serilog](https://img.shields.io/badge/Serilog-E71522?style=flat-square)
![Sentry](https://img.shields.io/badge/Sentry-362D59?style=flat-square&logo=sentry&logoColor=white)
![QuestPDF](https://img.shields.io/badge/QuestPDF-8C52FF?style=flat-square)
![Clean Architecture](https://img.shields.io/badge/Clean_Architecture-success?style=flat-square)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat-square&logo=docker&logoColor=white)

> RESTful API layer of the personal budget management application, built on **ASP.NET Core 8.0** following Clean Architecture principles.

---
> 💡 **Note:** This repository contains the backend API for the **ZenBudget** application. If you are looking for the cross-platform Flutter mobile client source code, please visit the [ZenBudget Mobile App Repository](https://github.com/yucezis/fintech-flutter-app).

---

## Table of Contents

- [About](#about)
- [Tech Stack](#tech-stack)
- [Architecture](#architecture)
- [Getting Started](#getting-started)
- [Environment Variables](#environment-variables)
- [Database](#database)
- [API Documentation](#api-documentation)
- [Testing](#testing)
- [Deployment](#deployment)

---

## About

ZenBudget Backend is the server-side of a personal finance application that provides income/expense tracking, spending analysis, savings goals, and AI-powered financial insights. It supports OCR-based receipt/invoice scanning, voice recognition, and Google Gemini API integration.

**Key Features:**
- JWT-based authentication (Google, Apple, Email/Password)
- Income/expense management with category-based analytics
- OCR-powered receipt and invoice processing
- AI-driven spending insights (Gemini API + ML.NET)
- Background job queue (Hangfire)
- High performance with Redis caching
- Real-time push notification support (FCM)
- PDF report generation
- 10 language support

---

## Tech Stack

| Layer | Technology |
|---|---|
| **Framework** | ASP.NET Core 8.0 / C# 12 |
| **Database** | PostgreSQL 16 |
| **ORM** | Entity Framework Core 8 |
| **Cache** | Redis 7 (StackExchange.Redis) |
| **Authentication** | JWT Bearer + Firebase Auth |
| **Background Jobs** | Hangfire + PostgreSQL |
| **Logging** | Serilog (Console, File, Seq) |
| **File Storage** | Azure Blob Storage |
| **AI / ML** | Google Gemini API + ML.NET 3.0 |
| **Email** | SendGrid / MailKit |
| **PDF** | QuestPDF / iText7 |
| **Error Tracking** | Sentry |

**Core NuGet Packages:**

```
Microsoft.AspNetCore.Authentication.JwtBearer 8.0.0
Npgsql.EntityFrameworkCore.PostgreSQL 8.0.0
StackExchange.Redis 2.7.10
Hangfire.Core 1.8.6
Serilog.AspNetCore 8.0.0
AutoMapper 12.0.0
FluentValidation.AspNetCore 11.3.0
Polly 8.2.0
QuestPDF 2023.12.0
Sentry.AspNetCore 4.0.0
```

---

## Architecture

The project follows **Clean Architecture** principles with 4 distinct layers:

```
src/
├── ZenBudget.API/              # Presentation Layer (Controllers, Middleware)
├── ZenBudget.Application/     # Application Layer (CQRS, Use Cases, DTOs)
├── ZenBudget.Domain/           # Domain Layer (Entities, Interfaces, Business Rules)
└── ZenBudget.Infrastructure/  # Infrastructure Layer (EF Core, Redis, External APIs)

tests/
├── ZenBudget.UnitTests/
└── ZenBudget.IntegrationTests/
```

**Applied Patterns:** Clean Architecture · CQRS · Repository Pattern · Unit of Work

---

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker & Docker Compose](https://www.docker.com/)
- [PostgreSQL 16](https://www.postgresql.org/) *(auto-installed via Docker)*
- [Redis 7](https://redis.io/) *(auto-installed via Docker)*

### Installation

```bash
# 1. Clone the repository
git clone https://github.com/your-username/zenbudget-backend.git
cd zenbudget-backend

# 2. Restore dependencies
dotnet restore

# 3. Start the database and Redis with Docker
docker-compose up -d postgres redis

# 4. Set up environment variables
cp .env.example .env
# Edit the .env file

# 5. Apply database migrations
dotnet ef database update --project src/ZenBudget.Infrastructure

# 6. Run the application
dotnet run --project src/ZenBudget.API
```

The application will be available at `https://localhost:7001`.  
Swagger UI: `https://localhost:7001/swagger`

### Full Environment with Docker

```bash
docker-compose up --build
```

---

## Environment Variables

```env
# Application
ASPNETCORE_ENVIRONMENT=Development
ASPNETCORE_URLS=https://+:7001;http://+:7000

# Database
DATABASE_URL=Host=localhost;Port=5432;Database=zenbudget;Username=postgres;Password=yourpassword

# Redis
REDIS_CONNECTION_STRING=localhost:6379

# JWT
JWT_SECRET=your-super-secret-key-min-32-chars
JWT_ISSUER=zenbudget-api
JWT_AUDIENCE=zenbudget-app
JWT_EXPIRY_MINUTES=60

# Firebase
FIREBASE_PROJECT_ID=your-firebase-project-id
FIREBASE_CREDENTIALS_PATH=firebase-adminsdk.json

# Google Gemini AI
GEMINI_API_KEY=your-gemini-api-key

# SendGrid
SENDGRID_API_KEY=your-sendgrid-key
SENDGRID_FROM_EMAIL=noreply@zenbudget.app

# Azure Blob Storage
AZURE_BLOB_CONNECTION_STRING=DefaultEndpointsProtocol=https;...
AZURE_BLOB_CONTAINER_NAME=zenbudget-files

# Sentry
SENTRY_DSN=https://your-sentry-dsn
```

---

## Database

**PostgreSQL 16** is used as the primary database. Active extensions:

- `uuid-ossp` — UUID generation
- `pg_trgm` — Fuzzy text search

### Migration Commands

```bash
# Create a new migration
dotnet ef migrations add MigrationName --project src/ZenBudget.Infrastructure --startup-project src/ZenBudget.API

# Apply migrations
dotnet ef database update --project src/ZenBudget.Infrastructure --startup-project src/ZenBudget.API

# Revert the last migration
dotnet ef migrations remove --project src/ZenBudget.Infrastructure
```

---

## API Documentation

Swagger UI is automatically available in the development environment:

```
https://localhost:7001/swagger
```

API versioning is supported:

```
/api/v1/auth
/api/v1/transactions
/api/v1/categories
/api/v1/budgets
/api/v1/reports
/api/v1/ai/insights
```

Postman collection: `docs/ZenBudget.postman_collection.json`

---

## Testing

```bash
# Run all tests
dotnet test

# Unit tests only
dotnet test tests/ZenBudget.UnitTests

# With coverage report
dotnet test --collect:"XPlat Code Coverage"
```

**Testing Tools:** xUnit · Moq · FluentAssertions · Testcontainers (integration tests)

---

## Deployment

### Railway (MVP / Development)

```bash
railway login
railway up
```

### Docker (Production)

```bash
docker build -t zenbudget-api .
docker push your-registry/zenbudget-api:latest
```

### GitHub Actions

CI/CD pipeline definitions are located in `.github/workflows/`:
- `ci.yml` — Build, test, lint
- `deploy.yml` — Production deployment

---

## Health Checks

```
GET /health          # General status
GET /health/ready    # Readiness (DB + Redis connectivity)
GET /health/live     # Liveness
GET /health/ui       # Dashboard
```

---


## License

This project is licensed under the [MIT License](LICENSE).

---

⭐ **If you like this project, don't forget to give it a star!**

---

<p align="center">
  ZenBudget Backend — The API layer of financial peace 💙
</p>

