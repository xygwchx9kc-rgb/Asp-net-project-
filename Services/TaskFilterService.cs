using TaskTrackerApi.Models;

namespace TaskTrackerApi.Services;

public static class TaskFilterService
{
    public static TaskFilterResult FilterTasks(IEnumerable<BaseTask> tasks)
    {
        var taskList = tasks.ToList();

        var highSeverityIncompleteBugs = taskList
            .OfType<BugReportTask>()
            .Where(task => !task.IsCompleted && task.SeverityLevel >= SeverityLevel.High)
            .OrderByDescending(task => task.CreatedAt)
            .ToList();

        var totalEstimatedHours = taskList
            .OfType<FeatureRequestTask>()
            .Where(task => !task.IsCompleted)
            .Sum(task => task.EstimatedHours);

        return new TaskFilterResult(highSeverityIncompleteBugs, totalEstimatedHours);
    }
}
