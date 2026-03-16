using System;
using System.Collections.Generic;
using System.Linq;

public class Hotel
{
    public string Name { get; set; }
    public List<Room> Rooms { get; set; } = new List<Room>();
    public List<Booking> BookingHistory { get; set; } = new List<Booking>();
    public List<Guest> Guests { get; set; } = new List<Guest>();

    public Hotel(string name)
    {
        Name = name;
    }

    public void RegisterGuest(Guest guest)
    {
        if (Guests.Any(g => g.Email == guest.Email))
        {
            Console.WriteLine("Email is already registered.");
            return;
        }

        Guests.Add(guest);
        Console.WriteLine($"Guest {guest.Name} registered successfully.");
    }

    public void GetAvailableRooms(DateTime checkIn, DateTime checkOut)
    {
        if (checkIn >= checkOut)
        {
            Console.WriteLine("Check-out date must be after check-in date.");
            return;
        }

        foreach (var room in Rooms.Where(r => r.IsAvailable))
        {
            Console.WriteLine($"Room {room.RoomNumber} - {room.RoomType} - {room.PricePerNight:C} per night");
        }
    }

    public void CreateBooking(string guestId, string roomNumber, DateTime checkIn, DateTime checkOut, IPayable payment)
    {
        if (checkIn >= checkOut)
        {
            Console.WriteLine("Check-out date must be after check-in date.");
            return;
        }

        foreach (var guest in Guests)
        {
            if (guest.GuestId == guestId)
            {
                if (guest.ActiveBookings.Count >= guest.MaxActiveBookings)
                {
                    Console.WriteLine($"Guest {guest.Name} already has an active booking.");
                    return;
                }

                foreach (var room in Rooms.Where(r => r.RoomNumber == roomNumber && r.IsAvailable))
                {
                    Booking newBooking = new Booking
                    {
                        Guest = guest,
                        Room = room,
                        CheckInDate = checkIn,
                        CheckOutDate = checkOut,
                        PaymentMethod = payment
                    };

                    newBooking.TotalPrice = newBooking.CalculateTotalPrice();

                    if (!newBooking.ConfirmPayment())
                    {
                        Console.WriteLine("Payment failed.");
                        return;
                    }

                    BookingHistory.Add(newBooking);
                    guest.ActiveBookings.Add(newBooking);

                    if (guest is VipGuest vipGuest)
                    {
                        vipGuest.AddLoyaltyPoints();
                    }

                    Console.WriteLine($"Booking created successfully for guest {guest.Name} in room {room.RoomNumber}.");
                    return;
                }

                Console.WriteLine("Room not found or not available.");
                return;
            }
        }

        Console.WriteLine("Guest not found.");
    }

    public void CancelBooking(string bookingId)
    {
        foreach (var booking in BookingHistory)
        {
            if (booking.BookingId == bookingId && booking.IsActive)
            {
                booking.IsActive = false;
                booking.Room.IsAvailable = true;
                booking.Guest.ActiveBookings.Remove(booking);
                Console.WriteLine($"Booking {bookingId} cancelled successfully.");
                return;
            }
        }

        Console.WriteLine("Booking not found or already cancelled.");
    }

    public void GetGuestBookings(string guestId)
    {
        foreach (var booking in BookingHistory)
        {
            if (booking.Guest.GuestId == guestId && booking.IsActive)
            {
                Console.WriteLine(
                    $"Booking ID: {booking.BookingId}, Room: {booking.Room.RoomNumber}, Check-in: {booking.CheckInDate.ToShortDateString()}, Check-out: {booking.CheckOutDate.ToShortDateString()}, Total Price: {booking.TotalPrice:C}");
            }
        }
    }
}