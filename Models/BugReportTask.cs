namespace TaskTrackerApi.Models;

public sealed class BugReportTask : BaseTask
{
    public BugReportTask(string title, SeverityLevel severityLevel) : base(title)
    {
        SeverityLevel = severityLevel;
    }

    public SeverityLevel SeverityLevel { get; }
}
