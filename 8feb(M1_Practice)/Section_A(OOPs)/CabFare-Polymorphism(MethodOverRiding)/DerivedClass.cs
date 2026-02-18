public class Mini : Cab
{
    public override double CalculateFare(int km)
    {
        return km * 30;
    }
}

public class Sedan : Cab
{
    public override double CalculateFare(int km)
    {
        return (km * 50) + 50;
    }
}

public class Suv : Cab
{
    public override double CalculateFare(int km)
    {
        return (km * 70) + 100;
    }
}
