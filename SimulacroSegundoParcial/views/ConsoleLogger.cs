namespace views;

public static class ConsoleLogger
{
    public static void Print(string s, bool newLine, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        if (newLine)
        {
            Console.WriteLine(s);
        }
        else
        {
            Console.Write(s);
        }
        Console.ResetColor();
    }

    public static void PrintError(string s, bool newLine)
    {
        Print(s, newLine, ConsoleColor.Red);
    }

    public static int IntInput()
    {
        if (int.TryParse(Console.ReadLine(), out int input))
        {
            return input;
        }
        throw new ArgumentException("Input no valido");
    }
    public static decimal DecimalInput()
    {
        if (decimal.TryParse(Console.ReadLine(), out decimal input))
        {
            return input;
        }
        throw new ArgumentException("Input no valido");
    }
    
}