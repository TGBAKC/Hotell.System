class Program
{
    static void Main(string[] args)
    {
        Hotel hotel = new Hotel("Hotel Besdil");
        SeedData(hotel);

        bool running = true;

        while (running)
        {
            Console.WriteLine("--Hotell--");
            Console.WriteLine("Välkommen till vårt hotell!");
            Console.WriteLine("1. Show available rooms");
            Console.WriteLine("2. Create booking");
            Console.WriteLine("3. Check in");
            Console.WriteLine("4. Check out");
            Console.WriteLine("5. Show my bookings");
            Console.WriteLine("6. Register new guest");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Vänligen välj ett alternativ:");

            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    ShowAvailableRooms(hotel);
                    break;
                case "2":
                    CreateBookingMenu(hotel);
                    break;
                case "3":
                    CheckInMenu(hotel);
                    break;
                case "4":
                    CheckOutMenu(hotel);
                    break;
                case "5":
                    ShowGuestBookingsMenu(hotel);
                    break;
                case "6":
                    RegisterGuestMenu(hotel);
                    break;
                case "0":
                    Console.WriteLine("Avslutar programmet...");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void SeedData(Hotel hotel)
    {
        hotel.Rooms.Add(new SingleRoom("101", true));
        hotel.Rooms.Add(new DoubleRoom("201", false));
        hotel.Rooms.Add(new Suite("301", true, true));

        hotel.RegisterGuest(new RegularGuest("Kari Nordmann", "kari@mail.com"));
        hotel.RegisterGuest(new VipGuest("Ola Nordmann", "ola@mail.com"));
    }

    static void ShowAvailableRooms(Hotel hotel)
    {
        Console.WriteLine("Enter check-in date (dd.MM.yyyy):");
        DateTime checkIn = DateTime.Parse(Console.ReadLine() ?? "");

        Console.WriteLine("Enter check-out date (dd.MM.yyyy):");
        DateTime checkOut = DateTime.Parse(Console.ReadLine() ?? "");

        Console.WriteLine($"\n=== Available rooms ({checkIn:dd.MM} - {checkOut:dd.MM}) ===\n");
        hotel.GetAvailableRooms(checkIn, checkOut);
    }

    static void CreateBookingMenu(Hotel hotel)
    {
        Console.WriteLine("Enter guest ID:");
        string guestId = Console.ReadLine() ?? "";

        Console.WriteLine("Enter room number:");
        string roomNumber = Console.ReadLine() ?? "";

        Console.WriteLine("Enter check-in date (dd.MM.yyyy):");
        DateTime checkIn = DateTime.Parse(Console.ReadLine() ?? "");

        Console.WriteLine("Enter check-out date (dd.MM.yyyy):");
        DateTime checkOut = DateTime.Parse(Console.ReadLine() ?? "");

        Console.WriteLine("Payment method (1=Card, 2=Vipps):");
        string paymentMethod = Console.ReadLine() ?? "";

        IPayable payment;

        if (paymentMethod == "1")
        {
            Console.WriteLine("Enter card number:");
            string cardNumber = Console.ReadLine() ?? "";

            Console.WriteLine("Enter card type:");
            string cardType = Console.ReadLine() ?? "";

            payment = new CardPayment(cardNumber, cardType);
        }
        else if (paymentMethod == "2")
        {
            Console.WriteLine("Enter phone number:");
            string phoneNumber = Console.ReadLine() ?? "";

            payment = new VippsPayment(phoneNumber);
        }
        else
        {
            Console.WriteLine("Invalid payment method.");
            return;
        }

        hotel.CreateBooking(guestId, roomNumber, checkIn, checkOut, payment);
        Console.WriteLine("Guest or room not found, or room is not available.");
    }

    static void CheckInMenu(Hotel hotel)
    {
        Console.WriteLine("Enter BookingId:");
        string bookingId = Console.ReadLine() ?? "";

        foreach (var booking in hotel.bookings)
        {
            if (booking.BookingId == bookingId)
            {
                booking.CheckIn();
                return;
            }
        }

        Console.WriteLine("Booking not found.");
    }

    static void CheckOutMenu(Hotel hotel)
    {
        Console.WriteLine("Enter BookingId:");
        string bookingId = Console.ReadLine()?? "";

        foreach (var booking in hotel.bookings)
        {
            if (booking.BookingId == bookingId)
            {
                booking.CheckOut();
                return;
            }
        }

        Console.WriteLine("Booking not found.");
    }

    static void ShowGuestBookingsMenu(Hotel hotel)
    {
        Console.WriteLine("Enter Guest ID:");
        string guestId = Console.ReadLine()?? "";
        hotel.GetGuestBookings(guestId);
    }

    static void RegisterGuestMenu(Hotel hotel)
    {
        Console.WriteLine("Enter name:");
        string name = Console.ReadLine()?? "";

        Console.WriteLine("Enter email:");
        string email = Console.ReadLine()?? "";

        Console.WriteLine("Guest type (1=Regular, 2=VIP):");
        string guestType = Console.ReadLine()?? "";

        if (guestType == "1")
        {
            hotel.RegisterGuest(new RegularGuest(name, email));
        }
        else if (guestType == "2")
        {
            hotel.RegisterGuest(new VipGuest(name, email));
        }
        else
        {
            Console.WriteLine("Invalid guest type.");
        }
    }
}