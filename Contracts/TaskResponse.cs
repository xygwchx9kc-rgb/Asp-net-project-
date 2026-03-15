using TaskTrackerApi.Models;

namespace TaskTrackerApi.Contracts;

public sealed record TaskResponse(
    Guid Id,
    string Type,
    string Title,
    DateTime CreatedAt,
    bool IsCompleted,
    SeverityLevel? SeverityLevel,
    decimal? EstimatedHours)
{
    public static TaskResponse FromModel(BaseTask task) =>
        task switch
        {
            BugReportTask bugReport => new TaskResponse(
                bugReport.Id,
                nameof(BugReportTask),
                bugReport.Title,
                bugReport.CreatedAt,
                bugReport.IsCompleted,
                bugReport.SeverityLevel,
                null),
            FeatureRequestTask featureRequest => new TaskResponse(
                featureRequest.Id,
                nameof(FeatureRequestTask),
                featureRequest.Title,
                featureRequest.CreatedAt,
                featureRequest.IsCompleted,
                null,
                featureRequest.EstimatedHours),
            _ => new TaskResponse(
                task.Id,
                task.GetType().Name,
                task.Title,
                task.CreatedAt,
                task.IsCompleted,
                null,
                null)
        };
}
