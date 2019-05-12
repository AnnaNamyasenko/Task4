using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class PowerFunction : IFunction
    {
        private double a;
        private uint n;
        private const uint INITIALVALUE = 1;

        public PowerFunction(): this(a: INITIALVALUE, n: INITIALVALUE){ }

        public PowerFunction(double a)
        {
            this.a = a;
            this.n = INITIALVALUE;
        }
<<<<<<< HEAD

        public PowerFunction(double a, uint n)
=======
       
        public PowerFunction(double _a, uint _n)
>>>>>>> 9b8ced08ae7d91eb2fabac32dcd4b857423390a9
        {
            this.a = a;
            this.n = n;
        }
        //tested
        public double FindFunctionValue(double x)
        {
            double functionResult = a * Math.Pow(x, n);
            return functionResult;
        }
        //tested
        public double FindDerivativeValue(uint derivativeOrder, double x)
        {
            double result = 1;
            while(derivativeOrder != 0)
            {
                result *= n;
                n -= 1;
                derivativeOrder--;
            }

            result *= (a * Math.Pow(x, n));
            return result;
        }
        //tested
        public int CompareTo(Object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            PowerFunction otherFunction = obj as PowerFunction;
            if (otherFunction != null)
            {
                return this.n.CompareTo(otherFunction.n);
            }
            else
            {
                throw new ArgumentException("Object is not a Power function");
            }
        }

        //tested
        public Object Clone()
        {
            PowerFunction clone = new PowerFunction(this.a, this.n);
            return clone;
        }

        public void Input()
        {
            Console.WriteLine("Enter coefficient of function: ");
            this.a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter power of function: ");
            this.n = Convert.ToUInt32(Console.ReadLine());
        }

        public void Output()
        {
            Console.WriteLine($"{this.a}*x^{this.n}".ToLower());
        }
        //tested
        public static bool operator ==(PowerFunction f1, PowerFunction f2)
        {
            return (f1.a == f2.a) && (f1.n == f2.n);
        }
        //tested
        public static bool operator !=(PowerFunction f1, PowerFunction f2)
        {
            return (f1.a != f2.a) || (f1.n != f2.n);
        }
    }
}
//
