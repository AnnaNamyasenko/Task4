using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Task.Execute();
            }

            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch(Exception _exception)
            {
                Console.WriteLine(_exception.Message);
            }
            Console.ReadLine();
        }
    }
}
