using Banck_Operator;

var banck = new Banck("<Name>", 10000);

banck.Makewhithdrawall(5500, DateTime.Now, "Extraccion de 5500");
Console.WriteLine($"Su cuenta tiene: {banck.Number}: {banck.Balance}");
banck.MakeDeposit(50, DateTime.Now, "Deposito de 50");
Console.WriteLine($"Su cuenta tiene: {banck.Number}: {banck.Balance}");
Console.ReadLine();