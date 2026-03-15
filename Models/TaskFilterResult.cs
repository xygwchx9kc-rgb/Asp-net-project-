namespace TaskTrackerApi.Models;

public sealed record TaskFilterResult(
    IReadOnlyList<BugReportTask> HighSeverityIncompleteBugs,
    decimal TotalEstimatedHoursForIncompleteFeatures);
