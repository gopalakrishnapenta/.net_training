using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var intRepo = new SimpleRepo<int>();
        intRepo.Add(10);
        intRepo.Add(20);

        Console.WriteLine(string.Join(",", intRepo.GetAll())); // 10,20

        var nameRepo = new SimpleRepo<string>();
        nameRepo.Add("Asha");
        nameRepo.Add("Vikram");

        Console.WriteLine(string.Join(",", nameRepo.GetAll())); // Asha,Vikram
    }
}

public class SimpleRepo<T>
{
    private readonly List<T> _items = new();

    // Add item into repository
    public void Add(T item)
    {
        _items.Add(item);
    }

    // Return read-only view of items
    public IReadOnlyList<T> GetAll()
    {
        return _items.AsReadOnly();
    }
}
