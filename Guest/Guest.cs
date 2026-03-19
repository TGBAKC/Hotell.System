




/* this is abstract class for Guest */
public abstract class Guest 


{
private static int guestcounter = 1;

public abstract int MaxActiveBookings { get;  }
 public string GuestId{get; private set;}  
public string Name { get; set; } = "";

  private string email = "";
  public string Email
   {
         get { return email; }
         set
         {
               if (IsValidEmail(value))
               {
                  email = value;
               }
               else
               {
                  throw new ArgumentException("Invalid email format.");
               }
         }
      }
   
     /*
     this is for keeping  track of the active bookings of the guests.
     */
 public List <Booking> ActiveBookings { get; set; } = new List<Booking>();
/*
this is the constructor for the Guest class.

*/
 public Guest (string name ,string email)
   {
      GuestId = $"G{guestcounter:D3}";
      guestcounter++;
      Name = name;
      Email= email;


   }
   private bool IsValidEmail(string value)
   {
     return value.Contains("@") && value.Contains(".");
   }
/*
this is an abstarct method for calcualting the discount.


*/
 
   public abstract decimal GetDiscount(decimal basePrice);

    
}