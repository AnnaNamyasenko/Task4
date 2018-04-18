using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public enum TrigonometricFuncNames { cos, sin, tg, ctg};

    public class TrigonometricFunction: IFunction
    {
        private double a;
        private double b;
        private const uint INITIALVALUE = 1;


        public TrigonometricFuncNames TrigonometricFuncName { get; set; }

        public TrigonometricFunction(): this(a: INITIALVALUE, b: INITIALVALUE, TrigonometricFuncName: TrigonometricFuncNames.cos){}

        public TrigonometricFunction(double a)
        {
            this.a = a;
            b = INITIALVALUE;
            TrigonometricFuncName = TrigonometricFuncNames.cos;
        }

        public TrigonometricFunction(double a, double b)
        {
            this.a = a;
            this.b = b;
            TrigonometricFuncName = TrigonometricFuncNames.cos;
        }

        public TrigonometricFunction(double a, double b, TrigonometricFuncNames TrigonometricFuncName)
        {
            this.a = a;
            this.b = b;
            this.TrigonometricFuncName = TrigonometricFuncName;
        }

        public double FindFunctionValue(double x)
        {
            double functionResult = 0;
            switch(TrigonometricFuncName)
            {
                case TrigonometricFuncNames.cos:
                    functionResult = a * Math.Cos(b * x);
                    break;
                case TrigonometricFuncNames.sin:
                    functionResult = a * Math.Sin(b * x);
                    break;
                case TrigonometricFuncNames.tg:
                    functionResult = a * Math.Tan(b * x);
                    break;
                case TrigonometricFuncNames.ctg:
                    functionResult = a / Math.Tan(b * x);
                    break;
                default:
                    throw new ArgumentException("Incorrect function type");

            }
            return functionResult;
        }


        public double FindDerivativeValue(uint derivativeOrder, double x)
        {
            double result = 0;
            switch (TrigonometricFuncName)
            {
                case TrigonometricFuncNames.cos:
                    result = Math.Cos(x +(Math.PI/2)*derivativeOrder);
                    break;
                case TrigonometricFuncNames.sin:
                    result = Math.Sin(x + (Math.PI / 2) * derivativeOrder);
                    break;
                case TrigonometricFuncNames.tg:
                    result = 1/Math.Pow(Math.Cos(x), 2);
                    break;
                case TrigonometricFuncNames.ctg:
                    result = 1/ Math.Pow(Math.Sin(x), 2);
                    break;
                default:
                    throw new ArgumentException("Incorrect function type");

            }
            return result;
        }
        
        public int CompareTo(Object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            TrigonometricFunction otherFunction = obj as TrigonometricFunction;
            if (otherFunction != null)
            {
                return this.TrigonometricFuncName.CompareTo(otherFunction.TrigonometricFuncName);
            }
            else
            {
                throw new ArgumentException("Object is not a Trigonometric function");
            }
        }

        public Object Clone()
        {
            TrigonometricFunction clone = new TrigonometricFunction(this.a, this.b, this.TrigonometricFuncName);
            return clone;
        }

        public void Input()
        {
            Console.WriteLine("Enter trigonometric function type: ");
            this.TrigonometricFuncName = (TrigonometricFuncNames)Enum.Parse(typeof(TrigonometricFuncNames), Console.ReadLine());
            Console.WriteLine("Enter first coefficient: ");
            this.a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter second coefficient: ");
            this.b = Convert.ToDouble(Console.ReadLine());
        }

        public void Output()
        {
            Console.WriteLine($"{this.a}*{TrigonometricFuncName}({this.b}*x)".ToLower());
        }
    }
}
//