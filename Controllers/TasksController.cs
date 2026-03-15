using Microsoft.AspNetCore.Mvc;
using TaskTrackerApi.Contracts;
using TaskTrackerApi.Repositories;
using TaskTrackerApi.Services;

namespace TaskTrackerApi.Controllers;

[ApiController]
[Route("api/tasks")]
public sealed class TasksController(ITaskRepository taskRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var tasks = taskRepository.GetAll();
        var filters = TaskFilterService.FilterTasks(tasks);

        return Ok(new
        {
            Tasks = tasks.Select(TaskResponse.FromModel),
            HighSeverityIncompleteBugs = filters.HighSeverityIncompleteBugs.Select(TaskResponse.FromModel),
            TotalEstimatedHoursForIncompleteFeatures = filters.TotalEstimatedHoursForIncompleteFeatures
        });
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var task = taskRepository.GetById(id);

        return task is null ? NotFound() : Ok(TaskResponse.FromModel(task));
    }

    [HttpPost("bug")]
    public IActionResult CreateBug([FromBody] CreateBugReportTaskRequest request)
    {
        var task = taskRepository.AddBugReport(request.Title, request.SeverityLevel);

        return CreatedAtAction(nameof(GetById), new { id = task.Id }, TaskResponse.FromModel(task));
    }

    [HttpPut("{id:guid}/complete")]
    public IActionResult Complete(Guid id)
    {
        var wasCompleted = taskRepository.Complete(id);

        return wasCompleted ? NoContent() : NotFound();
    }
}
