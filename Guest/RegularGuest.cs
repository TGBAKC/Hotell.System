









public class RegularGuest : Guest
{
    
     public override int MaxActiveBookings => 3;

  public RegularGuest( string name, string email) : base(name, email)
    {
        
     

    }

  




   public override decimal GetDiscount(decimal basePrice)
    {
        
   return basePrice;  

    }

    
      
    
}