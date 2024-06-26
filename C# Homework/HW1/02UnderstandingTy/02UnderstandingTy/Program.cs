
//Create a console application project named /02UnderstandingTypes/ that outputs the
//number of bytes in memory that each of the following number types u
using System.Numerics;

Console.WriteLine("Type: sbyte");
Console.WriteLine($"Size: {sizeof(sbyte)} bytes");
Console.WriteLine($"Min: {sbyte.MinValue}");
Console.WriteLine($"Max: {sbyte.MaxValue}\n");

Console.WriteLine("Type: byte");
Console.WriteLine($"Size: {sizeof(byte)} bytes");
Console.WriteLine($"Min: {byte.MinValue}");
Console.WriteLine($"Max: {byte.MaxValue}\n");

Console.WriteLine("Type: short");
Console.WriteLine($"Size: {sizeof(short)} bytes");
Console.WriteLine($"Min: {short.MinValue}");
Console.WriteLine($"Max: {short.MaxValue}\n");

Console.WriteLine("Type: ushort");
Console.WriteLine($"Size: {sizeof(ushort)} bytes");
Console.WriteLine($"Min: {ushort.MinValue}");
Console.WriteLine($"Max: {ushort.MaxValue}\n");

Console.WriteLine("Type: int");
Console.WriteLine($"Size: {sizeof(int)} bytes");
Console.WriteLine($"Min: {int.MinValue}");
Console.WriteLine($"Max: {int.MaxValue}\n");

Console.WriteLine("Type: uint");
Console.WriteLine($"Size: {sizeof(uint)} bytes");
Console.WriteLine($"Min: {uint.MinValue}");
Console.WriteLine($"Max: {uint.MaxValue}\n");

Console.WriteLine("Type: long");
Console.WriteLine($"Size: {sizeof(long)} bytes");
Console.WriteLine($"Min: {long.MinValue}");
Console.WriteLine($"Max: {long.MaxValue}\n");

Console.WriteLine("Type: ulong");
Console.WriteLine($"Size: {sizeof(ulong)} bytes");
Console.WriteLine($"Min: {ulong.MinValue}");
Console.WriteLine($"Max: {ulong.MaxValue}\n");

Console.WriteLine("Type: float");
Console.WriteLine($"Size: {sizeof(float)} bytes");
Console.WriteLine($"Min: {float.MinValue}");
Console.WriteLine($"Max: {float.MaxValue}\n");

Console.WriteLine("Type: double");
Console.WriteLine($"Size: {sizeof(double)} bytes");
Console.WriteLine($"Min: {double.MinValue}");
Console.WriteLine($"Max: {double.MaxValue}\n");

Console.WriteLine("Type: decimal");
Console.WriteLine($"Size: {sizeof(decimal)} bytes");
Console.WriteLine($"Min: {decimal.MinValue}");
Console.WriteLine($"Max: {decimal.MaxValue}\n");


//Write program to enter an integer number of centuries and convert it to years, days, hours,
//minutes, seconds, milliseconds, microseconds, nanoseconds

Console.Write("Enter the number of centuries: ");
int centuries = int.Parse(Console.ReadLine());

int years = centuries * 100;

int days = years * 365;

long hours = days * 24;
long minutes = hours * 60;
long seconds = minutes * 60;
long milliseconds = seconds * 1000;
BigInteger microseconds = milliseconds * 1000;
BigInteger nanoseconds = microseconds * 1000;

Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");