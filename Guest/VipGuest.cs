


public class VipGuest : Guest

{

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

      public void AddLoyaltyPoints()
        {
            LoyaltyPoints += 10;
        }


}