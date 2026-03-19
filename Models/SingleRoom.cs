

/*
this is class for the single room which inherits from the Room class. It has a HasDesk property which indicates whether the single room has a desk or not. The constructor initializes the properties of the single room and the DisplayRoomInfo method displays the information of the single room.


*/
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
/*
this is the property for indicating whether the single room has a desk or not.


*/
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
    
