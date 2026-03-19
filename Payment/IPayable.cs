




/*
this is the IPayable interface which defines the contract for payment processing. It has two methods: ProcessPayment which takes a decimal amount and returns a boolean indicating whether the payment was successful, and GetPaymentInfo which returns a string with the payment information for display purposes.


*/
public interface IPayable
{
   
bool ProcessPayment(decimal amount);
string GetPaymentInfo();
   
    



}