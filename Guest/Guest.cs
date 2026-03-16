




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
   
     
 public List <Booking> ActiveBookings { get; set; } = new List<Booking>();

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
  public abstract decimal GetDiscount(decimal basePrice);

    
}