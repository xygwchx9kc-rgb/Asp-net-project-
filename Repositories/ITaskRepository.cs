using TaskTrackerApi.Models;

namespace TaskTrackerApi.Repositories;

public interface ITaskRepository
{
    IReadOnlyCollection<BaseTask> GetAll();
    BugReportTask AddBugReport(string title, SeverityLevel severityLevel);
    BaseTask? GetById(Guid id);
    bool Complete(Guid id);
}
