using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLib.Math
{
    public class BasicCalc
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
        public double Divide(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException();
            return a / b;
        }

        public long Factorial(int n)
        {
            if (n < 0) throw new ArgumentOutOfRangeException();
            if (n == 0) return 1;
            return Enumerable.Range(1, n).Aggregate(1, (x, y) => x * y);
        }

        public int GCD(int a, int b)
        {
            if (a < 0 || b < 0) throw new ArgumentOutOfRangeException();
            if (a == 0 || b == 0) return 0;
            return Enumerable.Range(1, System.Math.Min(a, b)).Last(x => a % x == 0 && b % x == 0);
        }

        public int LCM(int a, int b)
        {
            if (a < 0 || b < 0) throw new ArgumentOutOfRangeException();
            return a * b / GCD(a, b);
        }

        public double Sqrt(double n)
        {
            if (n < 0) throw new ArgumentOutOfRangeException();
            return System.Math.Sqrt(n);
        }

        public double Log(double n, double baseN)
        {
            if (n <= 0) throw new ArgumentOutOfRangeException();
            return System.Math.Log(n, baseN);
        }

        public (double?, double?) SolveQuadraticEquation(double a, double b, double c)
        {
            if (a == 0)
                throw new ArgumentOutOfRangeException();

            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
                return (null, null);

            double sqrtDiscriminant = Sqrt(discriminant);
            double root1 = (-b + sqrtDiscriminant) / (2 * a);
            double root2 = (-b - sqrtDiscriminant) / (2 * a);

            return (root1, root2);
        }

        //Проверяет, является ли число совершенным (число, которое равно сумме всех своих собственных делителей, кроме себя)
        public bool IsPerfectNumber(int n)
        {
            if (n < 1)
                throw new ArgumentOutOfRangeException();

            int sum = 0;
            for (int i = 1; i <= n / 2; i++)
            {
                if (n % i == 0)
                    sum += i;
            }

            return sum == n;
        }

        public bool IsPrime(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException();
            if (n <= 1)
                return false;
            for (int i = 2; i <= Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
    }
}
