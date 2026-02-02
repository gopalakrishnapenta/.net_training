using System;

/// <summary>
/// Custom exception class for robot safety-related errors.
/// This exception is thrown when safety validation fails or unsafe conditions are detected.
/// </summary>
public class RobotSafetyException : Exception
{
    /// <summary>
    /// Initializes a new instance of the RobotSafetyException class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that describes the safety issue.</param>
    public RobotSafetyException(string message) : base(message)
    {
    }
}

/// <summary>
/// RobotHazardAuditor class responsible for analyzing and calculating workplace hazard risks
/// associated with industrial robot operations.
/// 
/// This class evaluates three key factors:
/// 1. Arm Precision: The accuracy and reliability of robot arm movements (0.0-1.0)
/// 2. Worker Density: The number of workers in the robot's operational area (1-20)
/// 3. Machinery State: The operational condition of machinery (Worn/Faulty/Critical)
/// </summary>
public class RobotHazardAuditor
{
    /// <summary>
    /// Calculates the overall hazard risk score based on robot precision, worker proximity, and machinery condition.
    /// </summary>
    /// <param name="armPrecision">The precision level of the robot arm (0.0 = lowest, 1.0 = highest accuracy)</param>
    /// <param name="workerDensity">The number of workers in proximity to the robot (1-20 workers)</param>
    /// <param name="machineryState">The operational state of the machinery: "Worn", "Faulty", or "Critical"</param>
    /// <returns>A calculated hazard risk score. Higher values indicate greater risk.</returns>
    /// <exception cref="RobotSafetyException">Thrown when input parameters are outside acceptable ranges or invalid.</exception>
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
        // Validate arm precision parameter is within acceptable range (0.0 to 1.0)
        if (armPrecision < 0.0 || armPrecision > 1.0)
        {
            throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");
        }

        // Validate worker density parameter is within acceptable range (1 to 20 workers)
        if (workerDensity < 1 || workerDensity > 20)
        {
            throw new RobotSafetyException("Error: Worker density must be 1-20");
        }

        // Determine machinery risk multiplier based on operational state
        // Risk factors escalate with machinery degradation: Worn (1.3) → Faulty (2.0) → Critical (3.0)
        double machineRiskFactor;

        if (machineryState == "Worn")
        {
            // Minor wear: 1.3x risk multiplier
            machineRiskFactor = 1.3;
        }
        else if (machineryState == "Faulty")
        {
            // Significant fault: 2.0x risk multiplier
            machineRiskFactor = 2.0;
        }
        else if (machineryState == "Critical")
        {
            // Critical condition: 3.0x risk multiplier
            machineRiskFactor = 3.0;
        }
        else
        {
            throw new RobotSafetyException("Error: Unsupported machinery state");
        }

        // Calculate total hazard risk using weighted formula:
        // Imprecision Risk = (1 - armPrecision) × 15.0 points
        // Worker Proximity Risk = workerDensity × machinery risk multiplier
        // Total Risk = Imprecision Risk + Worker Proximity Risk
        double hazardRisk =
            ((1.0 - armPrecision) * 15.0) +
            (workerDensity * machineRiskFactor);

        return hazardRisk;
    }
}

/// <summary>
/// Program class containing the entry point for the Factory Robot Hazard Analyzer application.
/// 
/// This application provides an interactive command-line interface for analyzing workplace
/// hazard risks in factory environments with industrial robot operations.
/// </summary>
public class Program
{
    /// <summary>
    /// Main entry point of the application.
    /// Collects user input for robot safety parameters and calculates the hazard risk score.
    /// </summary>
    /// <param name="args">Command-line arguments (not utilized in this application)</param>
    public static void Main(string[] args)
    {
        try
        {
            // Prompt user to input robot arm precision value
            Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
            double armPrecision = Convert.ToDouble(Console.ReadLine());

            // Prompt user to input worker density value
            Console.WriteLine("Enter Worker Density (1 - 20):");
            int workerDensity = Convert.ToInt32(Console.ReadLine());

            // Prompt user to input machinery operational state
            Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical):");
            string machineryState = Console.ReadLine();

            // Create auditor instance and perform hazard risk calculation
            RobotHazardAuditor auditor = new RobotHazardAuditor();
            double risk = auditor.CalculateHazardRisk(
                armPrecision,
                workerDensity,
                machineryState);

            // Display the calculated hazard risk score to the user
            Console.WriteLine("Robot Hazard Risk Score: " + risk);
        }
        catch (RobotSafetyException ex)
        {
            // Catch and display robot safety-specific exceptions with detailed error information
            Console.WriteLine(ex.Message);
        }
    }
}
