/*Controlling Flow and Converting Types
Test your Knowledge
1. What happens when you divide an int variable by 0?
     A System.DivideByZeroException is thrown at runtime
2. What happens when you divide a double variable by 0?
    The result is Infinity or -Infinity, depending on the sign of the numerator. 
3. What happens when you overflow an int variable, that is, set it to a value beyond its
range?
    It wraps around to the minimum or maximum value within the int range
4. What is the difference between x = y++; and x = ++y;?
    x = y++ : The value of y is assigned to x first, then y is incremented by 1.
    x = ++y : y is incremented by 1 first, then the new value of y is assigned to x.
5. What is the difference between break, continue, and return when used inside a loop
statement?
    break: Exits the nearest enclosing loop or switch statement.
    continue: Skips the remaining statements in the current iteration and moves to the next iteration of the loop.
    return: Exits the current method and optionally returns a value to the calling method.
6. What are the three parts of a for statement and which of them are required?
    Initialization (optional): for (int i = 0; ...
    Condition (required): ... i < 10; ...
    Iterator (optional): ... i++)
7. What is the difference between the = and == operators?
    = : Assigns the value on the right-hand side to the variable on the left-hand side.
    == : Compares the values on both sides and returns true if they are equal and false otherwise.
8. Does the following statement compile? for ( ; true; ) ;
    Yes, the statement compiles. It creates an infinite loop
9.What does the underscore _ represent in a switch expression?
    In a switch expression, the underscore _ represents the default case
10. What interface must an object implement to be enumerated over by using the foreach
statement
    An object must implement the IEnumerable interface to be enumerated over by using the foreach statement.*/

//FizzBuzz
for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("fizzbuzz");
    }
    else if (i % 3 == 0)
    {
        Console.WriteLine("fizz");
    }
    else if (i % 5 == 0)
    {
        Console.WriteLine("buzz");
    }
    else
    {
        Console.WriteLine(i);
    }
}

//int max = 500;
//for (byte i = 0; i < max; i++)
//{
//    Console.WriteLine(i);
//}

//Since the range of the byte type is 0 to 255, when the loop count reaches 255, it will overflow and change back to 0, resulting in an infinite loop.

//Solution
int max = 500;
for (byte i = 0; i < max; i++)
{
    if (i == 255)
    {
        Console.WriteLine("byte overflow occured.");
        break;
    }
    Console.WriteLine(i);
}

//Write a program that generates a random number between 1 and 3 and asks the user to
//guess what the number i

int correctNumber1 = new Random().Next(3) + 1;
Console.WriteLine("Your guess: ");
int guessedNumber1 = int.Parse(Console.ReadLine());

if (guessedNumber1 < 1 || guessedNumber1 > 3)
{
    Console.WriteLine("Your guess is outside the valid range. Please guess a number between 1 and 3.");
}
else if (guessedNumber1 < correctNumber1)
{
    Console.WriteLine("Your guess is too low.");
}
else if (guessedNumber1 > correctNumber1)
{
    Console.WriteLine("Your guess is too high.");
}
else
{
    Console.WriteLine("Congratulations!");
}


//Print-a-Pyramid
int pyramidHeight = 5;
for (int i = 1; i <= pyramidHeight; i++)
{

    for (int j = 1; j <= pyramidHeight - i; j++)
    {
        Console.Write(" ");
    }

    for (int k = 1; k <= (2 * i - 1); k++)
    {
        Console.Write("*");
    }

    Console.WriteLine();
}

// Write a program that generates a random number between 1 and 3 and asks the user to
//guess what the number i
int correctNumber = new Random().Next(3) + 1;
while (true)
{
    Console.WriteLine("Your guess: ");
    int guessedNumber = int.Parse(Console.ReadLine());
    if (guessedNumber < 1 || guessedNumber > 3)
    {
        Console.WriteLine("Your guess is outside the valid range. Please guess a number between 1 and 3.");
    }
    else if (guessedNumber < correctNumber)
    {
        Console.WriteLine("Your guess is too low.");
        continue;
    }
    else if (guessedNumber > correctNumber)
    {
        Console.WriteLine("Your guess is too high.");
        continue;
    }
    else
    {
        Console.WriteLine("Congratulations!");
        break;
    }
}


//Write a simple program that defines a variable representing a birth date and calculates
//how many days old the person with that birth date is current

DateTime birthDate = new DateTime(2000, 1, 1);

DateTime currentDate = DateTime.Now;

TimeSpan ageSpan = currentDate - birthDate;
int daysOld = (int)ageSpan.TotalDays;


Console.WriteLine($"You are {daysOld} days old.");

int daysToNextAnniversary = 10000 - (daysOld % 10000);

DateTime nextAnniversary = currentDate.AddDays(daysToNextAnniversary);

Console.WriteLine($"Your next 10,000 day anniversary is on: {nextAnniversary.ToShortDateString()}");


//Write a program that greets the user using the appropriate greeting for the time of 

DateTime currentTime = DateTime.Now;

int hour = currentTime.Hour;

if (hour >= 6 && hour < 12)
{
    Console.WriteLine("Good Morning");
}
if (hour >= 12 && hour < 18)
{
    Console.WriteLine("Good Afternoon");
}
if (hour >= 18 && hour < 23)
{
    Console.WriteLine("Good Evening");
}
if (hour >= 0 && hour < 6)
{
    Console.WriteLine("Good Night");
}

//Write a program that prints the result of counting up to 24 using four different increme
for (int increment = 1; increment <= 4; increment++)
{
    for (int i = 0; i <= 24; i += increment)
    {
        if (i != 0)
        {
            Console.Write(",");
        }
        Console.Write(i);
    }
    Console.WriteLine();
}