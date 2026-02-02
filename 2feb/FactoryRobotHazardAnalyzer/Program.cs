using System;

// Custom exception for robot safety errors
public class RobotSafetyException : Exception
{
    public RobotSafetyException(string message) : base(message)
    {
    }
}


// Robot hazard auditor class
public class RobotHazardAuditor
{
    // Calculate hazard risk score
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
        // Validate arm precision
        if (armPrecision < 0.0 || armPrecision > 1.0)
        {
            throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");
        }

        // Validate worker density
        if (workerDensity < 1 || workerDensity > 20)
        {
            throw new RobotSafetyException("Error: Worker density must be 1-20");
        }

        // Get machinery risk factor
        double machineRiskFactor;

        if (machineryState == "Worn")
        {
            machineRiskFactor = 1.3;
        }
        else if (machineryState == "Faulty")
        {
            machineRiskFactor = 2.0;
        }
        else if (machineryState == "Critical")
        {
            machineRiskFactor = 3.0;
        }
        else
        {
            throw new RobotSafetyException("Error: Unsupported machinery state");
        }

        // Calculate hazard risk
        double hazardRisk =
            ((1.0 - armPrecision) * 15.0) +
            (workerDensity * machineRiskFactor);

        return hazardRisk;
    }
}

// Main program class
public class Program
{
    // Entry point
    public static void Main(string[] args)
    {
        try
        {
            // Get arm precision input
            Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
            double armPrecision = Convert.ToDouble(Console.ReadLine());

            // Get worker density input
            Console.WriteLine("Enter Worker Density (1 - 20):");
            int workerDensity = Convert.ToInt32(Console.ReadLine());

            // Get machinery state input
            Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical):");
            string machineryState = Console.ReadLine();

            // Calculate hazard risk
            RobotHazardAuditor auditor = new RobotHazardAuditor();
            double risk = auditor.CalculateHazardRisk(
                armPrecision,
                workerDensity,
                machineryState);

            // Display result
            Console.WriteLine("Robot Hazard Risk Score: " + risk);
        }
        catch (RobotSafetyException ex)
        {
            // Display error
            Console.WriteLine(ex.Message);
        }
    }
}
        }
    }
}
