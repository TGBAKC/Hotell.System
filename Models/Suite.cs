
 public class Suite : Room
{
    


    public Suite (string roomNumber, bool hasJacuzzi, bool hasLounge)
    {
        
        RoomType = "Suite";
        HasJacuzzi = hasJacuzzi;
        HasLounge = hasLounge;
        RoomNumber = roomNumber;
        IsAvailable = true;
        MaxGuests = 4;
        PricePerNight = 3500m;




    }



    public bool HasJacuzzi { get; set; }
    public bool HasLounge { get; set; }

    public override void DisplayRoomInfo()
    {
        Console.WriteLine($"Room Type: {RoomType}");
        Console.WriteLine($"Price per Night: {PricePerNight:C}");
        Console.WriteLine($"Max Guests: {MaxGuests}");
        Console.WriteLine($"Has Jacuzzi: {(HasJacuzzi ? "Yes" : "No")}");
        Console.WriteLine($"Has Lounge: {(HasLounge ? "Yes" : "No")}");
        Console.WriteLine($"Availability: {(IsAvailable ? "Available" : "Not Available")}");
    }
}