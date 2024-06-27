using ConsoleApp1;

internal class Program
{
     static void Main(string[] args)
    {
        int[] numbers = GenerateNumbers(10);
        Reverse(numbers);
        PrintNumbers(numbers);
        Console.WriteLine(Fibonacci(11));

        Dog dog1 = new Dog();
        dog1.Behavior();
        Cat cat1 = new Cat();
        cat1.Behavior();


        Color redColor = new Color(255, 0, 0);
        Ball ball1 = new Ball(10, redColor);

        Color greenColor = new Color(0, 255, 0);
        Ball ball2 = new Ball(15, greenColor);

        Color blueColor = new Color(0, 0, 255);
        Ball ball3 = new Ball(20, blueColor);

        ball1.Throw();
        ball1.Throw();
        ball2.Throw();
        ball3.Throw();
        ball3.Throw();
        ball3.Throw();

        ball1.Pop();
        ball3.Pop();

        ball1.Throw();
        ball3.Throw();

        Console.WriteLine($"Ball 1 was thrown {ball1.GetThrowCount()} times.");
        Console.WriteLine($"Ball 2 was thrown {ball2.GetThrowCount()} times.");
        Console.WriteLine($"Ball 3 was thrown {ball3.GetThrowCount()} times.");
    }

    private static int[] GenerateNumbers(int L)
    {
        int[] numbers = new int[L];
        for (int i = 0; i < L; i++)
        {
            numbers[i] = i+1;
        }
        return numbers;
    }

    private static void Reverse(int[] numbers)
    {
        //Array.Reverse(numbers);
        for (int i = 0; i < numbers.Length/2; i++)
        {
            int temp = numbers[i];
            numbers[i] = numbers[numbers.Length-1-i];
            numbers[numbers.Length - 1 - i] = temp;
        }
    }

    private static void PrintNumbers(int[] numbers)
    {
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    private static int Fibonacci(int num)
    {   
        if (num == 1 || num == 2)
        {
            return 1;
        }
        else
        {
            return Fibonacci(num-1) + Fibonacci(num-2);
        }
    }
}