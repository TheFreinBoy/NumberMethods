using System;

class Program
{
    static void Main()
    {
        decimal x = -1.2m;
        decimal triangleX = x + 0.05m;
        decimal result = CalculateFunction(x);
        Console.WriteLine($"{x} = {result}");
        decimal fTriangleX = CalculateFunction(triangleX);
        decimal resultnumber2 = TruncateToTwoDecimalPlaces((fTriangleX - result) / 0.05m);     
        Console.WriteLine("ф штріх x = " + resultnumber2);
    }
    static decimal CalculateFunction(decimal x)
    {
        decimal result = (decimal)Math.Exp((double)x) - (decimal)Math.Sin((double)(2 * x)) - 1;       
        return TruncateToTwoDecimalPlaces(result);
    }
    static decimal TruncateToTwoDecimalPlaces(decimal value)
    {
        return Math.Truncate(value * 100) / 100;    
    }
}
