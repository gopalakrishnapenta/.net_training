using System;
using System.Collections.Generic;

namespace HotelRoomBookingSystem
{
    public class HotelManager
    {
        private readonly List<Room> rooms = new List<Room>();

        public void AddRoom(int roomNumber, string type, double price)
        {
            bool exists = false;
            foreach (var r in rooms)
            {
                if (r.RoomNumber == roomNumber)
                {
                    exists = true;
                    break;
                }
            }
            
            if (exists)
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
            Dictionary<string, List<Room>> grouped = new Dictionary<string, List<Room>>();
            
            foreach (var room in rooms)
            {
                if (room.IsAvailable)
                {
                    if (!grouped.ContainsKey(room.RoomType))
                    {
                        grouped[room.RoomType] = new List<Room>();
                    }
                    grouped[room.RoomType].Add(room);
                }
            }
            
            return grouped;
        }

        public bool BookRoom(int roomNumber, int nights)
        {
            Room room = null;
            foreach (var r in rooms)
            {
                if (r.RoomNumber == roomNumber && r.IsAvailable)
                {
                    room = r;
                    break;
                }
            }
            
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
            List<Room> result = new List<Room>();
            foreach (var room in rooms)
            {
                if (room.IsAvailable && room.PricePerNight >= min && room.PricePerNight <= max)
                {
                    result.Add(room);
                }
            }
            return result;
        }
    }
}
