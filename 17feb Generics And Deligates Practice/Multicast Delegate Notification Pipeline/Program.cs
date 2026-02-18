using System;

public class Program
{
    public delegate void Notifier(string message);

    public static void Main()
    {
        Notifier pipeline = BuildPipeline();
        pipeline("Order Created");
    }

    public static Notifier BuildPipeline()
    {
        Notifier notifier = null!;

        notifier += SendEmail;
        notifier += SendSms;
        notifier += WriteLog;

        return notifier;
    }

    private static void SendEmail(string message)
    {
        Console.WriteLine($"Email: {message}");
    }

    private static void SendSms(string message)
    {
        Console.WriteLine($"SMS: {message}");
    }

    private static void WriteLog(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}
