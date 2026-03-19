








/*

this is the RegularGuest class which inherits from the Guest class. It has a MaxActiveBookings property which is set to 3 and a GetDiscount method which returns the base price without any discount.

*/
public class RegularGuest : Guest
{
    
     public override int MaxActiveBookings => 3;

  public RegularGuest( string name, string email) : base(name, email)
    {
        
     

    }

  



/* this method returns the base price without any discount for regular guests */
   public override decimal GetDiscount(decimal basePrice)
    {
        
   return basePrice;  

    }

    
      
    
}