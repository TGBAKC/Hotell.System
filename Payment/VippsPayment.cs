




public class VippsPayment : IPayable
{
    public VippsPayment(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

    public string PhoneNumber { get; set; }
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing Vipps payment of {amount:C} using phone number {PhoneNumber}.");
        return true; 
    }
    public string GetPaymentInfo()
    {
        return $"Vipps Payment - Phone Number: {PhoneNumber}";
    }
}