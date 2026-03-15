# Task Tracker API

ASP.NET Core Web API implementation of the midterm assignment for a task management microservice.

## Endpoints

- `GET /api/tasks`
- `POST /api/tasks/bug`
- `PUT /api/tasks/{id}/complete`

## Run locally

```bash
dotnet restore
dotnet run
```

## Run with Docker

```bash
docker compose up --build
```

The API will be available at `http://localhost:8080/api/tasks`.
