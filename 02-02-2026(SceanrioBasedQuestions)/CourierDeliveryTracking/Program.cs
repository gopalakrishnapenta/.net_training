using System;
using System.Collections.Generic;
using System.Linq;

namespace CourierDeliveryTracking
{
    // Package class
    class Package
    {
        public string TrackingNumber { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string DestinationAddress { get; set; }
        public double Weight { get; set; }
        public string PackageType { get; set; } // Document / Parcel / Fragile
        public double ShippingCost { get; set; }
    }

    // DeliveryStatus class
    class DeliveryStatus
    {
        public string TrackingNumber { get; set; }
        public List<string> Checkpoints { get; set; }
        public string CurrentStatus { get; set; } // Dispatched / InTransit / Delivered
        public DateTime EstimatedDelivery { get; set; }
        public DateTime ActualDelivery { get; set; }

        public DeliveryStatus()
        {
            Checkpoints = new List<string>();
        }
    }

    // CourierManager class
    class CourierManager
    {
        private List<Package> packages = new List<Package>();
        private List<DeliveryStatus> statuses = new List<DeliveryStatus>();
        private int trackingCounter = 1001;

        // Add package
        public void AddPackage(string sender, string receiver, string address,
                               double weight, string type, double cost)
        {
            string trackingNo = "TRK" + trackingCounter++;

            Package package = new Package
            {
                TrackingNumber = trackingNo,
                SenderName = sender,
                ReceiverName = receiver,
                DestinationAddress = address,
                Weight = weight,
                PackageType = type,
                ShippingCost = cost
            };

            packages.Add(package);

            statuses.Add(new DeliveryStatus
            {
                TrackingNumber = trackingNo,
                CurrentStatus = "Dispatched",
                EstimatedDelivery = DateTime.Now.AddDays(3)
            });

            Console.WriteLine("Package registered with Tracking No: " + trackingNo);
        }

        // Update delivery status
        public bool UpdateStatus(string trackingNumber, string status,
                                 string checkpoint)
        {
            DeliveryStatus ds = statuses
                .FirstOrDefault(s => s.TrackingNumber == trackingNumber);

            if (ds == null)
                return false;

            ds.CurrentStatus = status;
            ds.Checkpoints.Add(checkpoint);

            if (status == "Delivered")
                ds.ActualDelivery = DateTime.Now;

            return true;
        }

        // Group packages by type
        public Dictionary<string, List<Package>> GroupPackagesByType()
        {
            return packages
                .GroupBy(p => p.PackageType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Get packages by destination city
        public List<Package> GetPackagesByDestination(string city)
        {
            return packages
                .Where(p => p.DestinationAddress.Contains(city))
                .ToList();
        }

        // Get delayed packages
        public List<Package> GetDelayedPackages()
        {
            DateTime today = DateTime.Now;

            var delayedTrackingNos = statuses
                .Where(s => s.CurrentStatus != "Delivered" &&
                            s.EstimatedDelivery < today)
                .Select(s => s.TrackingNumber)
                .ToList();

            return packages
                .Where(p => delayedTrackingNos.Contains(p.TrackingNumber))
                .ToList();
        }
    }

    // Program class
    class Program
    {
        static void Main()
        {
            CourierManager manager = new CourierManager();

            // Add packages
            manager.AddPackage("Ravi", "Anita", "Hyderabad",
                               2.5, "Parcel", 350);

            manager.AddPackage("Suresh", "Kiran", "Bangalore",
                               0.5, "Document", 150);

            // Update status
            manager.UpdateStatus("TRK1001", "InTransit", "Hyderabad Hub");
            manager.UpdateStatus("TRK1001", "Delivered", "Bangalore Hub");

            // Group packages by type
            Console.WriteLine("\nPackages Grouped By Type:");
            var grouped = manager.GroupPackagesByType();
            foreach (var g in grouped)
            {
                Console.WriteLine(g.Key);
                foreach (var p in g.Value)
                    Console.WriteLine(p.TrackingNumber + " - " + p.ReceiverName);
            }

            // Packages by destination
            Console.WriteLine("\nPackages To Hyderabad:");
            var hydPackages = manager.GetPackagesByDestination("Hyderabad");
            foreach (var p in hydPackages)
                Console.WriteLine(p.TrackingNumber + " - " + p.SenderName);

            // Delayed packages
            Console.WriteLine("\nDelayed Packages:");
            var delayed = manager.GetDelayedPackages();
            if (delayed.Count == 0)
                Console.WriteLine("No delayed packages");
            else
                foreach (var p in delayed)
                    Console.WriteLine(p.TrackingNumber);
        }
    }
}
