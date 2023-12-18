namespace Task_Management_System;

public class StringUtils {
    
    public static void PrintSeperator(bool newLine = false)
    {
        Console.WriteLine("----------------" + (newLine ? "\n" : ""));
    }
}