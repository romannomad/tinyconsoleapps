// Collect the bill amount and tip percentage
Console.WriteLine("Enter your bill details: ");
Console.Write("Bill amount: ");
decimal billAmount = Convert.ToDecimal(Console.ReadLine());
Console.Write("Tip percentage: ");
decimal tipPercentage = Convert.ToDecimal(Console.ReadLine());


// Display the entered values
Console.WriteLine($"Bill details: ");
Console.WriteLine($"Bill amount: {billAmount}");
Console.WriteLine($"Tip percentage: {tipPercentage}%");

// Calculate the tip and total
decimal tipAmount = billAmount * (tipPercentage / 100);
decimal totalAmount = billAmount + tipAmount;

// Display the results
Console.WriteLine($"Tip amount: {tipAmount}");
Console.WriteLine($"Total amount: {totalAmount}");