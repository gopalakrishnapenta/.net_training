using System;

namespace HotelRoomBookingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            HotelManager hotel = new HotelManager();

            hotel.AddRoom(101, "Single", 100);
            hotel.AddRoom(102, "Double", 150);
            hotel.AddRoom(201, "Suite", 300);
            hotel.AddRoom(202, "Double", 180);

            Console.WriteLine("Available Rooms Grouped by Type:");
            var groupedRooms = hotel.GroupRoomsByType();
            foreach (var type in groupedRooms)
            {
                Console.WriteLine($"\n{type.Key} Rooms:");
                foreach (var room in type.Value)
                {
                    Console.WriteLine($"Room {room.RoomNumber} - {room.PricePerNight}");
                }
            }

            Console.WriteLine("\nBooking Room 102 for 3 nights:");
            hotel.BookRoom(102, 3);

            Console.WriteLine("\nAvailable Rooms in Price Range 100 - 200:");
            var budgetRooms = hotel.GetAvailableRoomsByPriceRange(100, 200);
            foreach (var room in budgetRooms)
            {
                Console.WriteLine($"Room {room.RoomNumber} - {room.RoomType} - {room.PricePerNight}");
            }
        }
    }
}
