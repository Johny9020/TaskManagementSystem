namespace Task_Management_System;

class Program
{
    private static readonly TaskManager TaskManager = new ();
    
    private static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            TaskManager.AddTask(new Task("Hey " + i, "Description: " + i));
        }

        Console.WriteLine("Task Management System. By Johny9020");
        Console.WriteLine("Please follow the instructions bellow. Press a number according to the wished command.");
        Run();
    }

    public static void Run()
    {
        Console.WriteLine("1. Create a new task");
        Console.WriteLine("2. Display a desired tasks details");
        Console.WriteLine("3. Display all tasks");
        Console.WriteLine("4. Display all completed tasks");
        Console.WriteLine("5. Display all uncompleted tasks");
        Console.WriteLine("6. Edit task");
        Console.WriteLine("7.. To exit");
        var pressedKey = Console.ReadLine();

        switch (pressedKey)
        {
            case "1":
                CreateTask();
                break;
            case "2":
                DisplayTask();
                break;
            case "3":
                DisplayAllTasks();
                break;
            case "4":
                DisplayCompleted();
                break;
            case "5":
                DisplayInComplete();
                break;
            case "6":
                EditTask();
                break;
            case "7.":
                Exit();
                break;
            default:
                Exit();
                break;
        }
    }

    public static void PrintContinue()
    {
        Console.WriteLine("Enter any key to continue...");
        Console.ReadLine();
        Run();
    }

    private static void EditTask()
    {
        Console.WriteLine("Enter a task id to edit task or 0 to exit to Main Menu...");
        var pressedKey = Console.ReadLine();

        if(pressedKey == "0")
        {
            Run();
        }

        if(!TaskManager.DoesTaskExist(int.Parse(pressedKey!)))
        {
            Console.WriteLine("Task with id '" + pressedKey + "' Doesn't exist...");
            EditTask();
        }

        var task = TaskManager.GetTaskById(int.Parse(pressedKey!));
        Console.WriteLine("Editing task: " + task?.GetName());
        Console.WriteLine("1. Edit name");
        Console.WriteLine("2. Edit Description");
        Console.WriteLine("3. Toggle complete state");
        Console.WriteLine("0. Exit to main menu");
        var selectedOption = Console.ReadLine();

        if(selectedOption == "0")
        {
            Run();
        }

        switch (selectedOption)
        {
            case "1":
                task!.EditName();
                break;
            case "2":
                task!.EditDescription();
                break;
            case "3":
                task!.SetCompleted(!task.GetCompleteStatus());
                Run();
                break;
            case "6":
                Run();
                break;
            default:
                Run();
                break;
        }

    }

    private static void DisplayAllTasks()
    {
        StringUtils.PrintSeperator();
        TaskManager.DisplayAllTasks();
        PrintContinue();
    }

    private static void DisplayInComplete()
    {
        StringUtils.PrintSeperator();
        TaskManager.DisplayInCompleteTasks();
        PrintContinue();
    }

    private static void DisplayCompleted()
    {
        StringUtils.PrintSeperator();
        TaskManager.DisplayCompleteTasks();
        PrintContinue();
    }

    private static void CreateTask()
    {
        Console.WriteLine("Please specify a new for a new task.");
        var taskName = Console.ReadLine();
        
        if(taskName!.Length <= 0)
        {
            CreateTask();
        }

        Console.WriteLine("Please specify a description for the task");
        var description = Console.ReadLine();
        
        if(description!.Length <= 0)
        {
            CreateTask();
        }

        TaskManager.AddTask(new Task(taskName!, description!));
        Run();
    }

    private static void DisplayTask()
    {
        try
        {
            Console.WriteLine("Please enter a task id or 0 to exit to main menu...");
            var pressedKey = Console.ReadLine();
            
            if(pressedKey == "0")
            {
                Run();
            }
            
            var displayTask = TaskManager.GetTaskById(int.Parse(pressedKey!));
            
            if (displayTask == null)
            {
                Console.WriteLine("Invalid task id!");
                DisplayTask();
            }

            displayTask!.DisplayTaskDetails();
            PrintContinue();
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