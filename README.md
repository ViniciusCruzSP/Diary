# WebDiary

WebDiary is a portfolio project built to demonstrate professional backend and frontend architecture using ASP.NET Core.  
The domain itself (a diary application) is intentionally simple — the focus is on **architecture, separation of concerns, security, and real-world practices**, not on feature complexity.

## Project Goals

This project was created to study and showcase:

- Clear separation between Frontend and Backend
- API-first architecture
- ASP.NET Core MVC consuming a REST API via HTTP
- Business rules enforced exclusively on the backend
- ASP.NET Core Identity with JWT authentication
- Secure multi-user data isolation
- Clean Git history with feature branches and semantic commits
- Preparation for CI/CD and containerized environments

## Architecture Overview

The solution is split into two independent applications running as separate processes.

### Backend — Web API

**Project:** `WebDiaryAPI`

Responsibilities:
- Data persistence (Entity Framework Core)
- Business rules and validation
- Authentication and authorization
- Security and data ownership
- Database migrations

Key characteristics:
- ASP.NET Core Web API
- Entity Framework Core with SQL Server
- ASP.NET Core Identity
- JWT-based authentication
- ProblemDetails for standardized API errors
- Each diary entry is scoped to the authenticated user

The API is the **single source of truth** for:
- Business rules
- Security
- Data integrity

### Frontend — MVC Application

**Project:** `DiaryApp`

Responsibilities:
- User interface and user experience
- Form handling and basic UX validation
- Authentication flow (login/logout)
- Consuming the API via HttpClient

Key characteristics:
- ASP.NET Core MVC
- No direct database access
- No DbContext or migrations
- Communication with the backend exclusively via HTTP
- JWT stored in an HTTP-only cookie
- Custom HttpClient handler to inject the Bearer token per request

The frontend **does not enforce security rules** — it delegates all authorization decisions to the API.

## Authentication Flow

1. User logs in through the MVC application
2. MVC sends credentials to the API
3. API validates credentials using Identity
4. API issues a JWT
5. MVC stores the token in an HTTP-only cookie
6. All subsequent API requests automatically include the Bearer token
7. API authorizes access using `[Authorize]`

If the user is not authenticated:
- Protected pages redirect to the login page
- Navigation elements are hidden

## Business Rules (Backend)

All business rules are enforced **only** in the API:

- Title is required and must have at least 3 characters
- Content is required and must have at least 10 characters
- Creation date cannot be in the future
- A user can only access their own diary entries

The frontend never duplicates these rules.

## Error Handling

- API uses `ProblemDetails` for standardized error responses
- MVC uses a global exception filter to handle API errors gracefully
- Unauthorized access results in redirects instead of unhandled exceptions

## Repository Structure

/BackEnd
└── WebDiaryAPI

/FrontEnd
└── DiaryApp


Both applications live in the same repository but are fully decoupled.

## Running the Project Locally

1. Start the API
2. Apply database migrations
3. Start the MVC application
4. Access the MVC app in the browser
5. Log in and use the diary

Both applications must be running simultaneously.

## Why This Project Exists

This project is not about building a feature-rich diary application.

It exists to demonstrate:
- Architectural decisions
- Security-conscious design
- Clean separation of responsibilities
- Realistic development workflow

It is intentionally designed to resemble how internal or enterprise applications are structured.

## Next Steps

Planned or possible next steps include:
- CI pipeline (build and validation)
- Dockerization (API and database)
- Deployment to staging and production environments
- Role-based authorization
- Automated tests

---

**Author:** Vinicius Cruz  
**Purpose:** Portfolio / Learning Project
