
/*1.When to use String vs. StringBuilder in C# ?
    String: Use String when you are working with fixed or small amounts of text data, or when you do not expect the text to change frequently. 
    StringBuilder: Use StringBuilder when you need to perform frequent modifications to a string, such as appending, inserting, or removing characters.
2. What is the base class for all arrays in C#?
    The base class for all arrays in C# is System.Array
3.How do you sort an array in C#?
    You can sort an array in C# using the Array.Sort method.
4. What property of an array object can be used to get the total number of elements in
an array?
    You can use the Length property to get the total number of elements in an array.
5. Can you store multiple data types in System.Array?
    No, System.Array is a strongly-typed collection, meaning that it can only store elements of a single data type. 
6. What’s the difference between the System.Array.CopyTo() and System.Array.Clone()
    CopyTo(): The CopyTo method copies the elements of the array to another existing array starting at a particular index.
    Clone(): The Clone method creates a shallow copy of the array, returning a new array object containing the same elements.*/

//1. Copying an Array

using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
int[] originalArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

int[] copiedArray = new int[originalArray.Length];

for (int i = 0; i < originalArray.Length; i++)
{
    copiedArray[i] = originalArray[i];
}

Console.WriteLine("Original Array:");
foreach (int item in originalArray)
{
    Console.Write(item + " ");
}

Console.WriteLine("\nCopied Array:");
foreach (int item in copiedArray)
{
    Console.Write(item + " ");
}

//2. Write a simple program that lets the user manage a list of elements. It can be a grocery list,
//"to do" list, etc

List<string> itemList = new List<string>();

while (true)
{
    Console.WriteLine("Enter command (+ item, - item, or -- to clear, exit to exit):");
    string input2 = Console.ReadLine();

    if (input2.StartsWith("+"))
    {
        string itemToAdd = input2.Substring(2);
        itemList.Add(itemToAdd);
    }
    else if (input2.StartsWith("-") && input2 != "--")
    {
        string itemToRemove = input2.Substring(2);
        itemList.Remove(itemToRemove);
    }
    else if (input2 == "--")
    {
        itemList.Clear();
    }
    else if (input2 == "exit")
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid command. Please try again.");
    }

    Console.WriteLine("Current list:");
    foreach (string item in itemList)
    {
        Console.WriteLine(item);
    }
}


//Write a method that calculates all prime numbers in given range and returns them as array of integer
static int[] FindPrimesInRange(int startNum, int endNum)
{
    List<int> primes = new List<int>();

    for (int i = startNum; i <= endNum; i++)
    {
        if (IsPrime(i))
        {
            primes.Add(i);
        }

    }
    return primes.ToArray();
}

static bool IsPrime(int number)
{
    if (number <= 1)
        return false;

    for (int i = 2; i <= Math.Sqrt(number); i++)
    {
        if (number % i == 0)
            return false;
    }

    return true;
}

int startNum = 2;
int endNum = 10;
int[] primes = FindPrimesInRange(startNum, endNum);
foreach (int prime in primes)
{
    Console.Write(prime + " ");
}

//Write a program to read an array of n integers (space separated on a single line) and an
//integer k, rotate the array right k times and sum the obtained arrays after each rotation as
//shown below
Console.WriteLine("Enter the array of integers (space separated):");
int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

Console.WriteLine("Enter the number of rotations:");
int k = int.Parse(Console.ReadLine());

int n = array.Length;
int[] sumArray = new int[n];

for (int r = 1; r <= k; r++)
{
    for (int i = 0; i < n; i++)
    {
        sumArray[(i + r) % n] += array[i];
    }
}

Console.WriteLine("Sum array: " + string.Join(" ", sumArray));

//Write a program that finds the longest sequence of equal elements in an array of integers.
//If several longest sequences exist, print the leftmost one
Console.WriteLine("Enter the array of integers (space separated):");
int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

int maxLength = 1;
int currentLength = 1;
int longestElement = nums[0];
int currentElement = nums[0];

for (int i = 1; i < nums.Length; i++)
{
    if (nums[i] == currentElement)
    {
        currentLength++;
    }
    else
    {
        currentElement = nums[i];
        currentLength = 1;
    }

    if (currentLength > maxLength)
    {
        maxLength = currentLength;
        longestElement = currentElement;
    }
}
Console.WriteLine("Longest sequence:");
for (int i = 0; i < maxLength; i++)
{
    Console.Write(longestElement + " ");
}

//Write a program that finds the most frequent number in a given sequence of numbers. In
//case of multiple numbers with the same maximal frequency, print the leftmost of the
Console.WriteLine("Enter the sequence of numbers (space separated):");
int[] array7 = Console.ReadLine().Split().Select(int.Parse).ToArray();

int n7 = array7.Length;
int[] uniqueNumbers = array7.Distinct().ToArray();
int[] frequencies = new int[uniqueNumbers.Length];

for (int i = 0; i < n7; i++)
{
    for (int j = 0; j < uniqueNumbers.Length; j++)
    {
        if (array7[i] == uniqueNumbers[j])
        {
            frequencies[j]++;
        }
    }
}

int maxFrequency = frequencies.Max();
int mostFrequentIndex = -1;
for (int i = 0; i < frequencies.Length; i++)
{
    if (frequencies[i] == maxFrequency)
    {
        mostFrequentIndex = i;
        break;
    }
}

int mostFrequentNumber = uniqueNumbers[mostFrequentIndex];


Console.WriteLine($"The number {mostFrequentNumber} is the most frequent (occurs {maxFrequency} times).");

//Write a program that reads a string from the console, reverses its letters and prints the
//result back at the console
Console.WriteLine("Enter a string:");
string input = Console.ReadLine();

char[] charArray = input.ToCharArray();
Array.Reverse(charArray);
string reversedString = new string(charArray);

Console.WriteLine("Reversed string: " + reversedString);

Console.Write("Reversed string: ");
for (int i = input.Length - 1; i >= 0; i--)
{
    Console.Write(input[i]);
}
Console.WriteLine();

//Write a program that reverses the words in a given sentence without changing the
//punctuation and space
Console.WriteLine("Enter a sentence:");
string input22 = Console.ReadLine();

char[] separators = new char[] { '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };

List<string> wordsAndSeparators = new List<string>();
int lastIndex = 0;

for (int i = 0; i < input22.Length; i++)
{
    if (Array.Exists(separators, element => element == input22[i]))
    {
        if (i > lastIndex)
        {
            wordsAndSeparators.Add(input22.Substring(lastIndex, i - lastIndex));
        }
        wordsAndSeparators.Add(input22[i].ToString());
        lastIndex = i + 1;
    }
}

if (lastIndex < input22.Length)
{
    wordsAndSeparators.Add(input22.Substring(lastIndex));
}

string[] words = new string[wordsAndSeparators.Count];
int wordIndex = 0;

for (int i = 0; i < wordsAndSeparators.Count; i++)
{
    if (!Array.Exists(separators, element => element == wordsAndSeparators[i][0]))
    {
        words[wordIndex++] = wordsAndSeparators[i];
    }
}

StringBuilder result = new StringBuilder();
wordIndex--;

for (int i = 0; i < wordsAndSeparators.Count; i++)
{
    if (Array.Exists(separators, element => element == wordsAndSeparators[i][0]))
    {
        result.Append(wordsAndSeparators[i]);
    }
    else
    {
        result.Append(words[wordIndex--]);
    }
}

Console.WriteLine(result.ToString());


//Write a program that extracts from a given text all palindromes, e.g. “ABBA”, “lamal”, “exe”
//and prints them on the console on a single line, separated by comma and space.Print all
//unique palindromes (no duplicates), sorted
Console.WriteLine("Enter the text:");
string input33 = Console.ReadLine();

// 定义分隔符
char[] separators33 = new char[] { '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };

// 提取单词
string[] words33 = input33.Split(separators33, StringSplitOptions.RemoveEmptyEntries);

// 查找回文字符串
List<string> palindromes = new List<string>();

foreach (string word in words33)
{
    if (IsPalindrome(word) && !palindromes.Contains(word))
    {
        palindromes.Add(word);
    }
}

// 排序回文字符串
palindromes.Sort();

// 打印结果
Console.WriteLine("Palindromes: " + string.Join(", ", palindromes));

static bool IsPalindrome(string word)
{
    if (string.IsNullOrEmpty(word))
        return false;

    int length = word.Length;
    for (int i = 0; i < length / 2; i++)
    {
        if (char.ToLower(word[i]) != char.ToLower(word[length - i - 1]))
        {
            return false;
        }
    }
    return true;
}

//Write a program that parses an URL given in the following format
Console.WriteLine("Enter the URL:");
string url = Console.ReadLine();

string protocol = null;
string server = null;
string resource = null;

// 查找协议部分
int protocolEndIndex = url.IndexOf("://");
if (protocolEndIndex != -1)
{
    protocol = url.Substring(0, protocolEndIndex);
    url = url.Substring(protocolEndIndex + 3);
}

// 查找服务器和资源部分
int serverEndIndex = url.IndexOf("/");
if (serverEndIndex != -1)
{
    server = url.Substring(0, serverEndIndex);
    resource = url.Substring(serverEndIndex + 1);
}
else
{
    server = url;
}

// 打印结果
Console.WriteLine("[protocol] = \"" + (protocol ?? "") + "\"");
Console.WriteLine("[server] = \"" + server + "\"");
Console.WriteLine("[resource] = \"" + (resource ?? "") + "\"");