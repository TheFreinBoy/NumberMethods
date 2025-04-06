using System;
using System.Text;

public class Program 
{
    public const double eps = 0.01;
    public delegate double Function(double x);
    public static double dfx(Function func, double x) => (func(x + 0.01) - func(x)) / 0.01;
    public static List<double> roots = new List<double>();

    public static void Main() 
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Function func = x => Math.Exp(x) - Math.Sin(2*x) - 1;
        checkFunc(func, -6, 6, 1.2);

        Console.WriteLine($"\nЗнайдено {roots.Count} унікальні корені:");
        foreach (var root in roots)
        {
            Console.WriteLine($"x = {root:0.00}");
        }
    }

    public static void checkFunc(Function func, double left, double right, double interval) 
    {
        if (interval > 2) { FindRoot((left, right), func); return; }

        int count = 10;
        double h = Math.Abs(right - left) / count;

        for (int i = 0; i < count; i++) 
        {
            double a = left + i * h;
            double b = left + (i + 1) * h;

            if (Math.Sign(func(a)) != Math.Sign(func(b))) 
            {
                checkDerivative(func, a, b, interval, true);
            } else 
            {
                checkDerivative(func, a, b, interval, false);
            }
        }
    }

    public static void checkDerivative(Function func, double left, double right, double interval, bool signChanged) 
    {
        double h = Math.Abs(right - left) / 10;
        bool sameSign = true;
        double prevDeriv = dfx(func, left);

        for (int i = 1; i <= 6; i++) 
        {
            double x = left + i * h;
            double derivative = dfx(func, x);

            if (Math.Sign(prevDeriv) != Math.Sign(derivative)) 
            {
                sameSign = false;
                checkFunc(func, left, right, interval + 1);
            }

            prevDeriv = derivative;
        }

        if (sameSign && signChanged) 
        {
            FindRoot((left, right), func);
        }
    }

    public static void FindRoot((double, double) interval, Function func) 
    {
        double x0 = interval.Item1;
        double x1 = interval.Item2;
        double f0 = func(x0);
        double f1 = func(x1);

        if (Math.Abs(f0) < eps) 
        {
            AddRoot(x0, f0);
            return;
        }
        if (Math.Abs(f1) < eps) 
        {
            AddRoot(x1, f1);
            return;
        }

        int count = 0;
        int maxCount = 100; 

        while (count++ < maxCount) 
        {
            if (Math.Abs(f1 - f0) < 1e-12) break;

            double x2 = x1 - f1 * (x1 - x0) / (f1 - f0);
            double f2 = func(x2);

            if (Math.Abs(f2) < eps || Math.Abs(x2 - x1) < eps) 
            {
                AddRoot(x2, f2);
                return;
            }

            x0 = x1;
            f0 = f1;
            x1 = x2;
            f1 = f2;
        }
    }


    private static void AddRoot(double root, double funcValue) 
    {
        if (!roots.Any(existingRoot => Math.Abs(existingRoot - root) < eps)) 
        {
            roots.Add(root);
            Console.WriteLine($"Розв'язок: x = {root:0.0000}, f(x) = {funcValue:0.0000}");
        }
    }
}