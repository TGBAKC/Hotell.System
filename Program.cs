using System;

class Program
{
    static void Main(string[] args)
    {
        Hotel hotel = new Hotel("Hotel Besdil");
        SeedData(hotel);
        RunTests();

        bool running = true;

        while (running)
        {
            Console.WriteLine("--Hotell--");
            Console.WriteLine("Welcome to our hotel!");
            Console.WriteLine("1. Show available rooms");
            Console.WriteLine("2. Create booking");
            Console.WriteLine("3. Check in");
            Console.WriteLine("4. Check out");
            Console.WriteLine("5. Show my bookings");
            Console.WriteLine("6. Register new guest");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Please choose an option:");

            string choice = Console.ReadLine()?.Trim() ?? "";

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
                    Console.WriteLine("Exiting program...");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
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
    }

    static void CheckInMenu(Hotel hotel)
    {
        Console.WriteLine("Enter BookingId:");
        string bookingId = Console.ReadLine() ?? "";

        foreach (var booking in hotel.BookingHistory)
        {
            if (booking.BookingId == bookingId)
            {
                booking.CheckIn();
                Console.WriteLine("Checked in successfully.");
                return;
            }
        }

        Console.WriteLine("Booking not found.");
    }

    static void CheckOutMenu(Hotel hotel)
    {
        Console.WriteLine("Enter BookingId:");
        string bookingId = Console.ReadLine() ?? "";

        foreach (var booking in hotel.BookingHistory)
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
        string guestId = Console.ReadLine() ?? "";
        hotel.GetGuestBookings(guestId);
    }

    static void RegisterGuestMenu(Hotel hotel)
    {
        Console.WriteLine("Enter name:");
        string name = Console.ReadLine() ?? "";

        Console.WriteLine("Enter email:");
        string email = Console.ReadLine() ?? "";

        Console.WriteLine("Guest type (1=Regular, 2=VIP):");
        string guestType = Console.ReadLine() ?? "";

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

    static void RunTests()
    {
        Console.WriteLine("=== Running Tests ===");

        TestVipGuestDiscount();
        TestBookingCalculateTotalPrice();
        TestCreateBookingFailsWhenRoomIsOccupied();
        TestCheckOutMakesRoomAvailable();

        Console.WriteLine("=== Tests Finished ===");
        Console.WriteLine();
    }

    static void TestVipGuestDiscount()
    {
        VipGuest vip = new VipGuest("Test VIP", "vip@test.com");
        decimal result = vip.GetDiscount(1000m);

        if (result == 850m)
            Console.WriteLine("Test 1 PASSED: VipGuest.GetDiscount()");
        else
            Console.WriteLine("Test 1 FAILED: VipGuest.GetDiscount()");
    }

    static void TestBookingCalculateTotalPrice()
    {
        Guest guest = new RegularGuest("Test Guest", "guest@test.com");
        Room room = new DoubleRoom("202", false);

        Booking booking = new Booking
        {
            Guest = guest,
            Room = room,
            CheckInDate = new DateTime(2026, 3, 10),
            CheckOutDate = new DateTime(2026, 3, 13)
        };

        decimal total = booking.CalculateTotalPrice();

        if (total == 3600m)
            Console.WriteLine("Test 2 PASSED: Booking.CalculateTotalPrice()");
        else
            Console.WriteLine("Test 2 FAILED: Booking.CalculateTotalPrice()");
    }

    static void TestCreateBookingFailsWhenRoomIsOccupied()
    {
        Hotel hotel = new Hotel("Test Hotel");

        Guest guest1 = new RegularGuest("Guest One", "guest1@test.com");
        Guest guest2 = new RegularGuest("Guest Two", "guest2@test.com");
        Room room = new SingleRoom("101", true);

        hotel.RegisterGuest(guest1);
        hotel.RegisterGuest(guest2);
        hotel.Rooms.Add(room);

        IPayable payment = new CardPayment("4242", "Visa");

        hotel.CreateBooking(guest1.GuestId, "101", new DateTime(2026, 3, 10), new DateTime(2026, 3, 12), payment);
        room.IsAvailable = false;

        int beforeCount = hotel.BookingHistory.Count;

        hotel.CreateBooking(guest2.GuestId, "101", new DateTime(2026, 3, 10), new DateTime(2026, 3, 12), payment);

        int afterCount = hotel.BookingHistory.Count;

        if (beforeCount == afterCount)
            Console.WriteLine("Test 3 PASSED: Hotel.CreateBooking() fails when room is occupied");
        else
            Console.WriteLine("Test 3 FAILED: Hotel.CreateBooking() fails when room is occupied");
    }

    static void TestCheckOutMakesRoomAvailable()
    {
        Guest guest = new RegularGuest("Guest Test", "checkout@test.com");
        Room room = new SingleRoom("103", true);

        Booking booking = new Booking
        {
            Guest = guest,
            Room = room,
            CheckInDate = new DateTime(2026, 3, 10),
            CheckOutDate = new DateTime(2026, 3, 12)
        };

        booking.CheckIn();
        booking.CheckOut();

        if (room.IsAvailable == true)
            Console.WriteLine("Test 4 PASSED: CheckOut() makes room available");
        else
            Console.WriteLine("Test 4 FAILED: CheckOut() makes room available");
    }
}