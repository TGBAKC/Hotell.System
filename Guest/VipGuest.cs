

/*
This is the VipGuest class which inherits from the Guest class. It has a MaxActiveBookings property which is set to 10 and a GetDiscount method which returns the base price with a 15% discount. It also has a LoyaltyPoints property which keeps track of the loyalty points of the VIP guests and an AddLoyaltyPoints method which adds 10 loyalty points to the VIP guest.
*/
public class VipGuest : Guest

{
/*
this is method for keeping track of the loyalty points of the VIP guests.

*/
public int LoyaltyPoints { get; private set; }

public override int MaxActiveBookings=> 10;
    public VipGuest(string name, string email) : base(name, email)
        {
            
            LoyaltyPoints = 0;

        }
      
        public override decimal GetDiscount(decimal basePrice)
        {
            return basePrice * 0.85m; // VIP guests get a 15% discount
        }
/*
this is method for adding loyalty points to the VIP guest.



*/
      public void AddLoyaltyPoints()
        {
            LoyaltyPoints += 10;
        }


}