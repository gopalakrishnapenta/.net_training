using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelRoomBookingSystem
{
    public class HotelManager
    {
        private readonly List<Room> rooms = new List<Room>();

        public void AddRoom(int roomNumber, string type, double price)
        {
            if (rooms.Any(r => r.RoomNumber == roomNumber))
                return;

            rooms.Add(new Room
            {
                RoomNumber = roomNumber,
                RoomType = type,
                PricePerNight = price,
                IsAvailable = true
            });
        }

        public Dictionary<string, List<Room>> GroupRoomsByType()
        {
            return rooms
                .Where(r => r.IsAvailable)
                .GroupBy(r => r.RoomType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public bool BookRoom(int roomNumber, int nights)
        {
            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber && r.IsAvailable);
            if (room == null)
                return false;

            double totalCost = room.PricePerNight * nights;
            room.IsAvailable = false;

            Console.WriteLine($"Room {room.RoomNumber} booked for {nights} nights.");
            Console.WriteLine($"Total Cost: {totalCost}");

            return true;
        }

        public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
        {
            return rooms
                .Where(r => r.IsAvailable && r.PricePerNight >= min && r.PricePerNight <= max)
                .ToList();
        }
    }
}
