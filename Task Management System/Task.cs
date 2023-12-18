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

    public string GetName()
    {
        return TaskName;
    }

    public void EditName()
    {
        Console.WriteLine("Enter a new name for task: " + TaskName);
        var enteredName = Console.ReadLine();

        if(enteredName?.Length <= 0)
            Program.Run();

        TaskName = enteredName!;
        StringUtils.PrintSeperator(true);
        Program.Run();
    }

    public void EditDescription()
    {
        Console.WriteLine("Enter a new description for task: " + TaskName);
        var enteredDesc = Console.ReadLine();

        if(enteredDesc?.Length <= 0)
            Program.Run();

        Description = enteredDesc!;
        StringUtils.PrintSeperator(true);
        Program.Run();
    }

    public void SetCompleted(bool state)
    {
        IsComplete = state;
        StringUtils.PrintSeperator(true);
        Program.Run();
    }
}