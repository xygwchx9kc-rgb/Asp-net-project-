namespace TaskTrackerApi.Models;

public sealed class FeatureRequestTask : BaseTask
{
    public FeatureRequestTask(string title, decimal estimatedHours) : base(title)
    {
        EstimatedHours = estimatedHours;
    }

    public decimal EstimatedHours { get; }
}
