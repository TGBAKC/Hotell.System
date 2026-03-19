


/*

this is the Suite class which inherits from the Room class. It has a HasJacuzzi property which indicates whether the suite has a jacuzzi or not and a HasLounge property which indicates whether the suite has a lounge area or not. The constructor initializes the properties of the suite and the DisplayRoomInfo method displays the information of the suite.

*/
 public class Suite : Room
{
    

/*

this is the constructor for the Suite class which initializes the properties of the suite.


*/
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


/*
this is the property for indicating whether the suite has a jacuzzi or not.

*/
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