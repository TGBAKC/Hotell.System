


/*
this is the VippsPayment class which implements the IPayable interface. It has a property for the phone number used for the Vipps payment. The constructor initializes this property. The ProcessPayment method processes the payment and returns true if the payment is successful. The GetPaymentInfo method returns a string with the phone number used for the Vipps payment for display purposes.
*/

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

    /*
    this is method for getting the payment information which returns a string with the phone number used for the Vipps payment for display purposes.
    */
    public string GetPaymentInfo()
    {
        return $"Vipps Payment - Phone Number: {PhoneNumber}";
    }
}