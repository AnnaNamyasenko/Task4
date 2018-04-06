using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    interface IFunction: ICloneable, IComparable, IInputOutput
    {
        double FindFunctionValue(double x);

        double FindDerivativeValue(uint derivativeOrder, double x);
    }
}
