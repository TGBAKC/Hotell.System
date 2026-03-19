


/*
this is the CardPayment class which implements the IPayable interface. It has properties for the card number and card type. The constructor initializes these properties. The ProcessPayment method processes the payment and returns true if the payment is successful. The GetPaymentInfo method returns a string with the card type and masked card number for display purposes.

*/
public class CardPayment : IPayable
{
    public string CardNumber { get; set; }
    public string CardType { get; set; }
    public CardPayment(string cardNumber, string cardType)
    {
        CardNumber = cardNumber;
        CardType = cardType;
    }
    public bool ProcessPayment(decimal amount)
    {
        string last4 = CardNumber.Length >= 4
            ? CardNumber.Substring(CardNumber.Length - 4)
            : CardNumber;

        Console.WriteLine($"Processing card payment of {amount:C} using {CardType} card ending with {last4}.");
        return true;
    }
/*
this is method for getting the payment information which returns a string with the card type and masked card number for display purposes.


*/

    public string GetPaymentInfo()
    {  string last4= CardNumber.Length >= 4 ? CardNumber.Substring(CardNumber.Length - 4) : CardNumber;
        return $"Card Type: {CardType}, Card Number: **** **** **** {last4}";
    }
}
