using BankSolutions;

var banck = new BanckAccount("<Name>", 10000);

banck.MakeWhithdrawall(5500, DateTime.Now, "Extraccion de 5500");
Console.WriteLine($"Su cuenta tiene: {banck.Number}: {banck.Balance}");
banck.MakeDeposit(50, DateTime.Now, "Deposito de 50");
Console.WriteLine($"Su cuenta tiene: {banck.Number}: {banck.Balance}");
Console.WriteLine($"Saldo principal de la cuenta: {banck.GetAccountHistory()}");
try
{
    banck.MakeWhithdrawall(5000, DateTime.Now, "Extraccion de 5000");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine("Operacion no valida: " + ex.Message);
}

var giftCard = new GiftCardAccount("<Name>", 100, 50);
giftCard.MakeWhithdrawall(20, DateTime.Now, "get expensive coffee");
giftCard.MakeWhithdrawall(50, DateTime.Now, "buy groceries");
giftCard.PerformMonthEndTransactions();
giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional money");
Console.WriteLine($"Account states: {giftCard.GetAccountHistory()}");

var savings = new InterestEarningAccount("savings account", 10000);
savings.MakeDeposit(750, DateTime.Now, "save some money");
savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
savings.MakeWhithdrawall(250, DateTime.Now, "Needed to pay monthly bills");
savings.PerformMonthEndTransactions();
Console.WriteLine($"_____________________________________________________________________________________");
Console.WriteLine(savings.GetAccountHistory());

var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
// How much is too much to borrow?
lineOfCredit.MakeWhithdrawall(1000m, DateTime.Now, "Take out monthly advance");
lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
lineOfCredit.MakeWhithdrawall(5000m, DateTime.Now, "Emergency funds for repairs");
lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
lineOfCredit.PerformMonthEndTransactions();
Console.WriteLine($"_____________________________________________________________________________________");
Console.WriteLine(lineOfCredit.GetAccountHistory());


var objD = new C();
objD.Element();

string a = "Hello";
string b = new string("Hello".ToCharArray());
Console.WriteLine($"a == b: {a == b}");
Console.WriteLine($"Reference equals: a == b: {object.ReferenceEquals(a, b)}");

var person1 = new Person("John", 42);
var person2 = new Person("John", 42);

Console.WriteLine($"person1 == person2: {person1.Equals(person2)}");
Console.WriteLine($"person1==perosn2 for reference: {object.ReferenceEquals(person2, person1)}");

var auto = new Automobile("Listo", "Mercedez", 1958);
Console.WriteLine($"auto: {auto.ToString()}");

var book = new Book("The Great Gatsby", "978-3-16-1", "F. Scott Fitzgerald", "Scribner");
book.SetPrice(10.99m, "USD");
book.Publish(DateTime.Now);
Console.WriteLine($"Book: {book.ToString()}, Price: {book.Price} {book.Currency}, Published on: {book.GetPublicationDate()}");