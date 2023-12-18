using System.Security.Cryptography.X509Certificates;

namespace Task_Management_System;

public class TaskManager
{
    private List<Task> _tasks = new();

    public void AddTask(Task task)
    {
        if (_tasks.Contains(task))
            return;
        _tasks.Add(task);
        Console.WriteLine("Creating a new task with ID: " + task.TaskId);
    }

    public void DisplayAllTasks()
    {
        foreach (var task in _tasks)
        {
            task.DisplayTaskDetails();
            StringUtils.PrintSeperator();
        }
    }

    public void DisplayCompleteTasks()
    {
        if(GetCompletedTasksInt() <= 0)
        {
            Console.WriteLine("No completed tasks!");
            StringUtils.PrintSeperator(true);
            Program.Run();
        }

        foreach (var task in _tasks)
        {
            if(task.GetCompleteStatus())
            {
                task.DisplayTaskDetails();
                StringUtils.PrintSeperator();
            }
        }
    }

    public void DisplayInCompleteTasks()
    {
        if(GetInCompleteTasksInt() <= 0)
        {
            Console.WriteLine("No completed tasks!");
            StringUtils.PrintSeperator(true);
            Program.Run();
        }

        foreach (var task in _tasks)
        {
            if(!task.GetCompleteStatus())
            {
                task.DisplayTaskDetails();
                StringUtils.PrintSeperator();
            }
        }
    }

    private int GetCompletedTasksInt()
    {
        int count = 0;
        foreach (var task in _tasks)
        {
            if(task.GetCompleteStatus())
                count++;
        }
        return count;
    }

    private int GetInCompleteTasksInt()
    {
        int count = 0;
        foreach (var task in _tasks)
        {
            if(!task.GetCompleteStatus())
                count++;
        }
        return count;
    }

    public List<Task> GetTasks()
    {
        return _tasks;
    }

    public Task? GetTaskById(int id)
    {
        foreach (var task in _tasks)
        {
            if (task.TaskId == id)
                return task;
        }

        return null;
    }

    public bool DoesTaskExist(int id)
    {
        foreach (var task in _tasks)
        {
            if(task.TaskId == id)
            {
                return true;
            }
        }
        return false;
    }
}