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
            Console.WriteLine("----------------");
        }
    }

    public void DisplayCompleteTasks()
    {
        foreach (var task in _tasks)
        {
            if(task.GetCompleteStatus())
            {
                task.DisplayTaskDetails();
            }
        }
    }

    public void DisplayInCompleteTasks()
    {
        foreach (var task in _tasks)
        {
            if(!task.GetCompleteStatus())
            {
                task.DisplayTaskDetails();
            }
        }
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
}