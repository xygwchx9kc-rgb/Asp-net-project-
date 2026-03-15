using System.ComponentModel.DataAnnotations;
using TaskTrackerApi.Models;

namespace TaskTrackerApi.Contracts;

public sealed record CreateBugReportTaskRequest(
    [property: Required, MinLength(3)] string Title,
    [property: Required] SeverityLevel SeverityLevel);
