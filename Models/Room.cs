


/*
This is abstact class for room .
*/
public abstract class Room
{
    private decimal pricePerNight;
  
/*
Room class has properties like RoomType, RoomNumber, PricePerNight, IsAvailable and MaxGuests. It also has an abstract method DisplayRoomInfo() that must be implemented by derived classes to display room details.
*/
    public string RoomType { get; protected set; } = "";
    public string RoomNumber { get; protected set; } = "";

    public decimal PricePerNight
    {
        get { return pricePerNight; }
        protected set
        {
            if (value <= 0)
                throw new ArgumentException("Price per night must be positive.");
            pricePerNight = value;
        }
    }

    public bool IsAvailable { get;  set; }
    public int MaxGuests { get; protected set; }

    public abstract void DisplayRoomInfo();
}