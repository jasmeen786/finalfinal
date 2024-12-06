// TaskItem class to represent each task
using System;

public class TaskItem
{
    public int TaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
}

public class Task
{
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public bool IsCompleted { get; set; }
}
