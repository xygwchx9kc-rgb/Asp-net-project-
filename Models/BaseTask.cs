namespace TaskTrackerApi.Models;

public abstract class BaseTask
{
    public delegate void TaskCompletedHandler(BaseTask completedTask);

    public event TaskCompletedHandler? OnTaskCompleted;

    protected BaseTask(string title)
    {
        Id = Guid.NewGuid();
        Title = title;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private init; }

    public string Title { get; protected set; }

    public DateTime CreatedAt { get; private init; }

    public bool IsCompleted { get; private set; }

    public virtual void CompleteTask()
    {
        if (IsCompleted)
        {
            return;
        }

        IsCompleted = true;
        OnTaskCompleted?.Invoke(this);
    }
}
