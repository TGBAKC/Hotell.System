



public class CardPayment : IPayable
{
    public string CardNumber { get; set; }
    public string CardType { get; set; }
    public CardPayment(string cardNumber, string cardType)
    {
        CardNumber = cardNumber;
        CardType = cardType;
    }
    public  bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing card payment of {amount:C} using {CardType} card ending with {CardNumber.Substring(CardNumber.Length - 4)}.");
        return true; 
    }

    public string GetPaymentInfo()
    {  string last4= CardNumber.Length >= 4 ? CardNumber.Substring(CardNumber.Length - 4) : CardNumber;
        return $"Card Type: {CardType}, Card Number: **** **** **** {last4}";
    }
}
