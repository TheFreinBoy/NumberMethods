class Program
{
    static void Main()
    {
        double x = -1.2;
        double result = (Math.Pow(Math.E , x)) - Math.Sin(2*x)-1;
        Console.WriteLine(x + "=" + result);
    }
    static double TruncateToTwoDecimalPlaces(double value)
    {
        return Math.Truncate(value * 100) / 100;
    }
}
