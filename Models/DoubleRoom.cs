


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

  public bool HasExtraBed { get; set; }

    public override void DisplayRoomInfo()
    {
        Console.WriteLine($"[{RoomNumber}] {RoomType} - {PricePerNight} kr/night - Max {MaxGuests} guests - HasExtraBed: {(HasExtraBed ? "Yes" : "No")}");
        



}}