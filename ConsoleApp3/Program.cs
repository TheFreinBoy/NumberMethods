class Program
{
    static void Main()
    {
        double x = -1.08;
        double x1 = -1.2;        
        double X = TruncateToTwoDecimalPlaces( x - ((F(x) * (x -x1))/(F(x) - F(x1))));
        Console.WriteLine(X);
    }
    static double F(double x1)
    {
        double result = (Math.Pow(Math.E , x1)) - Math.Sin(2*x1)-1;
        return result;
    }
    static double TruncateToTwoDecimalPlaces(double value)
    {
        return Math.Truncate(value * 10000) / 10000;
    }
}