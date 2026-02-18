public class Mini : Cab
{
    public override double CalculateFare(int km)
    {
        return km * 12;
    }
}

public class Sedan : Cab
{
    public override double CalculateFare(int km)
    {
        return (km * 15) + 50;
    }
}

public class Suv : Cab
{
    public override double CalculateFare(int km)
    {
        return (km * 18) + 100;
    }
}
