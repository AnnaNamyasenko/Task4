using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public enum TrigonometricFuncName { Cos, Sin, Tg, Ctg};

    public class TrigonometricFunction: IFunction
    {
        private double a;
        private double b;
        private const uint INITIALCOEFFICIENTVALUE = 1;


        public TrigonometricFuncName TrigonometricFuncName { get; set; }

        public TrigonometricFunction()
        {
            a = INITIALCOEFFICIENTVALUE;
            b = INITIALCOEFFICIENTVALUE;
            TrigonometricFuncName = TrigonometricFuncName.Cos;
        }

        public TrigonometricFunction(double _a)
        {
            a = _a;
            b = INITIALCOEFFICIENTVALUE;
            TrigonometricFuncName = TrigonometricFuncName.Cos;
        }

        public TrigonometricFunction(double _a, double _b)
        {
            a = _a;
            b = _b;
            TrigonometricFuncName = TrigonometricFuncName.Cos;
        }

        public TrigonometricFunction(double _a, double _b, TrigonometricFuncName name)
        {
            a = _a;
            b = _b;
            TrigonometricFuncName = name;
        }

        public double FindFunctionValue(double x)
        {
            double functionResult = 0;
            switch(TrigonometricFuncName)
            {
                case TrigonometricFuncName.Cos:
                    functionResult = a * Math.Cos(b * x);
                    break;
                case TrigonometricFuncName.Sin:
                    functionResult = a * Math.Sin(b * x);
                    break;
                case TrigonometricFuncName.Tg:
                    functionResult = a * Math.Tan(b * x);
                    break;
                case TrigonometricFuncName.Ctg:
                    functionResult = a / Math.Tan(b * x);
                    break;
                default:
                    throw new ArgumentException("Incorrect function type");

            }
            return functionResult;
        }
        
        public double FindDerivativeValue(double derivativeOrder, double x)
        {
            double result = 0;
            switch (TrigonometricFuncName)
            {
                case TrigonometricFuncName.Cos:
                    result = Math.Cos(x +(Math.PI/2)*derivativeOrder);
                    break;
                case TrigonometricFuncName.Sin:
                    result = Math.Sin(x + (Math.PI / 2) * derivativeOrder);
                    break;
                /*case TrigonometricFuncName.Tg:
                    result = ;
                    break;
                case TrigonometricFuncName.Ctg:
                    result = ;
                    break;*/
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
                throw new ArgumentException("Object is not a Trigonometric function");
        }

        public Object Clone()
        {
            TrigonometricFunction clone = new TrigonometricFunction(this.a, this.b, this.TrigonometricFuncName);
            return clone;
        }

        //public override string ToString()

        //public override bool Equals(Object obj)

        //public static bool operator ==(TrigonometricFunction firstFunction, TrigonometricFunction secondFunction)
        //public static bool operator !=(TrigonometricFunction firstFunction, TrigonometricFunction secondFunction)
    }
}
