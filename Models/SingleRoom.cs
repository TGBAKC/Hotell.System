


public class SingleRoom: Room
{ public SingleRoom(string roomNumber ,bool hasDesk)
    {
        RoomType = "SingleRoom";
        HasDesk =  hasDesk;
        RoomNumber = roomNumber;
      
        IsAvailable = true;
        MaxGuests =1;
        PricePerNight = 800m;

    }

    public bool HasDesk { get; set; }

    public override void DisplayRoomInfo()
    {
     
        Console.WriteLine($"Room Type: {RoomType}");
        Console.WriteLine($"Price per Night: {PricePerNight:C}");
        Console.WriteLine($"Max Guests: {MaxGuests}");
        Console.WriteLine($"Has Desk: {(HasDesk ? "Yes" : "No")}");
        Console.WriteLine($"Availability: {(IsAvailable ? "Available" : "Not Available")}")  ; 
    }

}
    
