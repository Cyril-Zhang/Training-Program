//See https://aka.ms/new-console-template for more information

/*1.What type would you choose for the following “numbers”?
A person’s telephone number: string
A person’s height: double
A person’s age: int
A person’s gender (Male, Female, Prefer Not To Answer): enum
A person’s salary: decimal
A book’s ISBN: string
A book’s price: decimal
A book’s shipping weight: double
A country’s population: long
The number of stars in the universe: BigInterger
The number of employees in each of the small or medium businesses in the
United Kingdom (up to about 50,000 employees per business): int

2. What are the difference between value type and reference type variables? What is
boxing and unboxing?
    Value Type: Stores the actual data
    Reference Type: Stores a reference to the data's memory address.
    Boxing: Converting a value type to a reference type.
    Unboxing: Converting a reference type back to a value type.

3. What is meant by the terms managed resource and unmanaged resource in .NET
    Managed Resource: Resources managed by the .NET runtime (e.g., memory allocated for .NET objects).
    Unmanaged Resource: Resources not managed by the .NET runtime (e.g., file handles, database connections, COM objects).
4. Whats the purpose of Garbage Collector in .NET?
    The Garbage Collector (GC) automatically manages memory, freeing up unused objects and ensuring that applications efficiently 
    use memory by reclaiming memory occupied by objects that are no longer in use.*/

//Playing with Console App
Console.Write("Enter your favorite color: ");
string? color = Console.ReadLine();

Console.Write("Enter your astrology sign: ");
string? sign = Console.ReadLine();

Console.Write("Enter your street address number: ");
string? addressNumber = Console.ReadLine();

Console.WriteLine($"Your hacker name is {color}{sign}{addressNumber}.");