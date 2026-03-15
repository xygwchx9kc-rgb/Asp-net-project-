# Task Tracker API

## Overview

Task Tracker API is a microservice built with **C#** and **ASP.NET Core Web API** for managing tasks in a distributed project management system.  
This project was developed as a **midterm assignment** and demonstrates object-oriented programming, event handling, LINQ, dependency injection, repository pattern, and containerization with Docker. :contentReference[oaicite:1]{index=1}

The main purpose of the service is to manage different types of tasks, such as bug reports and feature requests, provide API endpoints for working with them, and support future extensibility for integrations such as notifications.

---

## Project Goal

The goal of this project is to design and implement the core functionality of a **Task Service microservice**.  
The system allows users to:

- retrieve all tasks
- create bug report tasks
- mark tasks as completed
- filter and analyze tasks using LINQ
- prepare the service for deployment using Docker

This project follows a clean structure with separation between:

- **Models**
- **Repository / Service Layer**
- **Controller Layer**
- **Containerization files**

---

## Assignment Requirements Implemented

According to the assignment, the project includes the following features: :contentReference[oaicite:2]{index=2}

### Block 1 — Domain Model and Business Logic

- An abstract base class `BaseTask`
- Encapsulated properties:
  - `Id : Guid`
  - `Title : string`
  - `CreatedAt : DateTime`
  - `IsCompleted : bool`
- Derived classes:
  - `BugReportTask` with `SeverityLevel`
  - `FeatureRequestTask` with `EstimatedHours`
- Delegate and event:
  - `OnTaskCompleted`
- Method:
  - `CompleteTask()` triggers the completion event
- Static filtering service:
  - returns incomplete high-severity bug reports sorted by newest first
  - calculates total estimated hours for incomplete feature requests

### Block 2 — Web API

Implemented `TasksController` with endpoints:

- `GET /api/tasks` — get all tasks
- `POST /api/tasks/bug` — create a new bug report
- `PUT /api/tasks/{id}/complete` — complete a task and trigger the event

### Architecture

- Dependency Injection
- Repository pattern with `ITaskRepository`
- Controller layer separated from business/repository layer

### Block 3 — Integration Design

The project also discusses future integration with a `NotificationService` for sending email when a task is completed.

### Containerization

- `Dockerfile` with multi-stage build
- `docker-compose.yml` for running the service

---

## Technologies Used

- **C#**
- **ASP.NET Core Web API**
- **LINQ**
- **Dependency Injection**
- **Repository Pattern**
- **Events and Delegates**
- **Docker**
- **Docker Compose**

---

## Project Structure

```bash
TaskTrackerApi/
│
├── Controllers/
│   └── TasksController.cs
│
├── Models/
│   ├── BaseTask.cs
│   ├── BugReportTask.cs
│   └── FeatureRequestTask.cs
│
├── Repositories/
│   ├── ITaskRepository.cs
│   └── InMemoryTaskRepository.cs
│
├── Services/
│   └── TaskFilterService.cs
│
├── Program.cs
├── Dockerfile
├── docker-compose.yml
└── README.md
