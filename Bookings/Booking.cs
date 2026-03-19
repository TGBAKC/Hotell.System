

/*
this is class Booking which has properties like BookingId, Guest, Room, CheckInDate, CheckOutDate, PaymentMethod, IsPaid, TotalPrice and IsActive. It also has methods to calculate total price based on the room price and guest discount, confirm payment using the provided payment method, check-in by marking the room as unavailable, and check-out by marking the room as available and deactivating the booking.
*/

public class Booking
{
  public string   BookingId { get; private set; }
    
    private static int counter = 1;
    public Booking()
    {
        BookingId = $"BK{counter:D3}";
        counter++;
        IsActive = true;
        IsPaid = false;
    }
    public Guest Guest { get; set; }
    public Room Room { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public IPayable PaymentMethod  { get; set; }
    public bool IsPaid { get; set; }
    public decimal TotalPrice { get; set; }
  public bool IsActive { get; set; }
/*
this method calculates the tot;a price of the booking .
*/
    public decimal CalculateTotalPrice()
    {
        
   int nights = (CheckOutDate - CheckInDate).Days;
        decimal basePrice = Room.PricePerNight * nights;
        return  Guest.GetDiscount(basePrice);



    }
    /*
    its for confriming the payment of teh booking.
    */
    public bool ConfirmPayment()
    {
        decimal amount = CalculateTotalPrice();
      
            IsPaid = PaymentMethod.ProcessPayment(amount);
            return IsPaid;
        }
    /*
    this method is for checking in the guest by marking the room as unavailable.
    */

    public void  CheckIn() 
    {
        
    Room.IsAvailable = false;




    }
    /*
    this method helps the check-out process by marking the room as available and deactivating the booking.
    */
    public void CheckOut()
    {
        Room.IsAvailable = true;
        IsActive = false;
        Guest.ActiveBookings.Remove(this);
        Console.WriteLine("Checked out successfully.");
    }
        










}
    