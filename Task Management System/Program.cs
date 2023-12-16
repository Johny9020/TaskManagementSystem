﻿namespace Task_Management_System;

class Program
{
    private static TaskManager _taskManager;
    
    private static void Main()
    {
        _taskManager = new TaskManager();
        
        Console.WriteLine("Task Management System. By Johny9020");
        Console.WriteLine("Please follow the instructions bellow. Press a number according to the wished command.");
        Run();
    }

    private static void Run()
    {
        Console.WriteLine("1. Create a new task");
        Console.WriteLine("2. Display a desired tasks details");
        Console.WriteLine("3. Display all tasks");
        Console.WriteLine("4. Display all completed tasks");
        Console.WriteLine("5. Display all uncompleted tasks");
        Console.WriteLine("6. To exit");
        var pressedKey = Console.ReadLine();

        switch (pressedKey)
        {
            case "1":
                CreateTask();
                break;
            case "2":
                DisplayTask();
                break;
            default:
                Exit();
                break;
        }
    }

    private static void CreateTask()
    {
        Console.WriteLine("Please specify a new for a new task.");
        var taskName = Console.ReadLine();
        
        Console.WriteLine("Please specify a description for the task");
        var description = Console.ReadLine();
        
        _taskManager.AddTask(new Task(taskName, description));
        Run();
    }

    private static void DisplayTask()
    {
        try
        {
            Console.WriteLine("Please enter a task id or 0 to exit to main menu...");
            var pressedKey = Console.ReadLine();
            
            if(pressedKey == "0")
                Run();
            
            var displayTask = _taskManager.GetTaskById(int.Parse(pressedKey));
            
            if (displayTask == null)
            {
                Console.WriteLine("Invalid task id!");
                DisplayTask();
            }
            Console.WriteLine("Enter any key to continue...");
            Console.ReadLine();
            Run();
        }
        catch (FormatException e)
        {
            Console.WriteLine("Invalid task id!");
            DisplayTask();
        }
    }

    private static void Exit()
    {
        Console.WriteLine("Thank you for using Johny9020's Task Management system!");
        Environment.Exit(1);
    }
}