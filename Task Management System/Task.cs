namespace Task_Management_System;

public class Task
{
    private static int _counter;
    public int TaskId { get; set; }
    private string TaskName { get; set; }
    private string Description { get; set; }
    private DateTime DueDate { get; set; }
    private bool IsComplete { get; set; }

    public Task(string taskName, string description)
    {
        TaskId = ++_counter;
        TaskName = taskName;
        Description = description;
        DueDate = DateTime.Now;
        IsComplete = false;
    }

    public void MarkAsComplete()
    {
        IsComplete = true;
    }

    public void DisplayTaskDetails()
    {
        Console.WriteLine("Task ID: " + TaskId);
        Console.WriteLine("Task Name: " + TaskName);
        Console.WriteLine("Task Description: " + Description);
        Console.WriteLine("Task Due Date: " + DueDate);
        Console.WriteLine("Is Task Completed?: " + (IsComplete ? "true" : "false"));
    }

    public bool GetCompleteStatus()
    {
        return IsComplete;
    }
}