using TaskTrackerApi.Models;

namespace TaskTrackerApi.Repositories;

public sealed class InMemoryTaskRepository : ITaskRepository
{
    private readonly List<BaseTask> _tasks =
    [
        new BugReportTask("Fix login redirect loop", SeverityLevel.Critical),
        new BugReportTask("Resolve navbar overlap on mobile", SeverityLevel.High),
        new FeatureRequestTask("Add kanban board view", 16),
        new FeatureRequestTask("Export sprint report to CSV", 6)
    ];

    private readonly object _lock = new();

    public InMemoryTaskRepository()
    {
        foreach (var task in _tasks)
        {
            task.OnTaskCompleted += HandleTaskCompleted;
        }
    }

    public IReadOnlyCollection<BaseTask> GetAll()
    {
        lock (_lock)
        {
            return _tasks.ToList().AsReadOnly();
        }
    }

    public BugReportTask AddBugReport(string title, SeverityLevel severityLevel)
    {
        var bugReport = new BugReportTask(title, severityLevel);

        bugReport.OnTaskCompleted += HandleTaskCompleted;

        lock (_lock)
        {
            _tasks.Add(bugReport);
        }

        return bugReport;
    }

    public BaseTask? GetById(Guid id)
    {
        lock (_lock)
        {
            return _tasks.FirstOrDefault(task => task.Id == id);
        }
    }

    public bool Complete(Guid id)
    {
        lock (_lock)
        {
            var task = _tasks.FirstOrDefault(item => item.Id == id);

            if (task is null)
            {
                return false;
            }

            task.CompleteTask();
            return true;
        }
    }

    private static void HandleTaskCompleted(BaseTask completedTask)
    {
        Console.WriteLine(
            "Task completed: {0} ({1}) at {2:O}",
            completedTask.Title,
            completedTask.Id,
            DateTime.UtcNow);
    }
}
