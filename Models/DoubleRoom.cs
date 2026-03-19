

/*
this is the DoubleRoom class which inherits from the Room class. It has a HasExtraBed property which indicates whether the double room has an extra bed or not. The constructor initializes the properties of the double room and the DisplayRoomInfo method displays the information of the double room.


*/
public class DoubleRoom :Room
{
    

public DoubleRoom( string roomNumber , bool hasExtraBed)
    {
        RoomType = "DoubleRoom";
        HasExtraBed = hasExtraBed;
        RoomNumber = roomNumber;
        IsAvailable = true;
        MaxGuests = 2;
        PricePerNight = 1200m;



    }
/*
this is the property for indicating whether the double room .
*/
  public bool HasExtraBed { get; set; }

    public override void DisplayRoomInfo()
    {
        Console.WriteLine($"[{RoomNumber}] {RoomType} - {PricePerNight} kr/night - Max {MaxGuests} guests - HasExtraBed: {(HasExtraBed ? "Yes" : "No")}");
        



}}