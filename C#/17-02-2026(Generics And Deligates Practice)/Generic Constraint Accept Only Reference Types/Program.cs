using System;

public class Program
{
    public static void Main()
    {
        var cache = new RefCache<string>(); 
        cache.Set(null);
        Console.WriteLine(cache.GetOrDefault("NA")); // NA

        cache.Set("Hello");
        Console.WriteLine(cache.GetOrDefault("NA")); // Hello

       
    }
}

public class RefCache<T> where T : class
{
    private T? _value;

    public void Set(T? value)
    {
        _value = value;
    }

    public T GetOrDefault(T defaultValue)
    {
        return _value ?? defaultValue;
    }
}
