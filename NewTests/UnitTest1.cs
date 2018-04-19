using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContext;

        public TestContext TestContext { get => testContext; set => testContext = value; }


        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\PFdata1.csv",
                    "PFdata1#csv",
                     DataAccessMethod.Sequential),
                     DeploymentItem("PFdata1.csv")
        ]
        public void PowerFunctionFindValueTest()
        {
            // F(x) = a*x^n

            //Arrange
            double a = double.Parse(TestContext.DataRow["a"].ToString());
            double x = double.Parse(TestContext.DataRow["x"].ToString());
            uint n = uint.Parse(TestContext.DataRow["n"].ToString());

            PowerFunction function = new PowerFunction(a, n);

            //Act
            double actual = function.FindFunctionValue(x);
            double result = double.Parse(TestContext.DataRow["result"].ToString());

            //Assert
            Assert.AreEqual(actual, result);

        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\PFdata2.csv",
                    "PFdata2#csv",
                     DataAccessMethod.Sequential),
                     DeploymentItem("PFdata2.csv")
        ]
        public void PowerFunctionFindDerivativeValueTest()
        {
            //Arrange
            double a = double.Parse(TestContext.DataRow["a"].ToString());
            double x = double.Parse(TestContext.DataRow["x"].ToString());
            uint n = uint.Parse(TestContext.DataRow["n"].ToString());
            uint derivativeOrder = uint.Parse(TestContext.DataRow["derivativeOrder"].ToString());

            PowerFunction function = new PowerFunction(a, n);

            //Act
            double actual = function.FindDerivativeValue(derivativeOrder, x);
            double result = double.Parse(TestContext.DataRow["result"].ToString());

            //Assert
            Assert.AreEqual(actual, result);
        }

        [TestMethod]
        public void PowerFunctionCloneTest()
        {
            PowerFunction function = new PowerFunction(12, 2);
            PowerFunction cloneFunction = function.Clone() as PowerFunction;

            Assert.IsTrue(function == cloneFunction);
        }

        [TestMethod]
        public void PowerFunctionOperatorEqualTest()
        {
            PowerFunction function1 = new PowerFunction(2);
            PowerFunction function2 = new PowerFunction(2);

            bool result = (function1 == function2);

            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void PowerFunctionOperatorNotEqualTest()
        {
            PowerFunction function1 = new PowerFunction(2,1);
            PowerFunction function2 = new PowerFunction(6,21);

            bool result = (function1 != function2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PowerFunctionCompareToTest()
        {
            PowerFunction function1 = new PowerFunction(12, 2);
            PowerFunction function2 = new PowerFunction(12, 7);

            int actual = function1.FindFunctionValue(1).CompareTo(function2.FindFunctionValue(1));

            Assert.AreEqual(actual,0);
        }

        //******************** TrigonometricFunctions********************
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                  "|DataDirectory|\\TFdata1.csv",
                  "TFdata1#csv",
                   DataAccessMethod.Sequential),
                   DeploymentItem("TFdata1.csv")
         ]
        public void TrigonometricFunctionFindValueTest()
        {
            //Arrange
            double a = double.Parse(TestContext.DataRow["a"].ToString());
            double b = double.Parse(TestContext.DataRow["b"].ToString());
            double x = double.Parse(TestContext.DataRow["x"].ToString());
            TrigonometricFuncName funcName = (TrigonometricFuncName)Enum.Parse(typeof(TrigonometricFuncName), TestContext.DataRow["name"].ToString());

            TrigonometricFunction function = new TrigonometricFunction(a, b, funcName);

            //Act
            double actual = function.FindFunctionValue(x);
            double result = double.Parse(TestContext.DataRow["result"].ToString());

            //Assert
            Assert.AreEqual(actual, result);
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                  "|DataDirectory|\\TFdata2.csv",
                  "TFdata2#csv",
                   DataAccessMethod.Sequential),
                   DeploymentItem("TFdata2.csv")
         ]
        public void TrigonometricFunctionFindDerivativeValueTest()
        {
            //Arrange
            double a = double.Parse(TestContext.DataRow["a"].ToString());
            double b = double.Parse(TestContext.DataRow["b"].ToString());
            double x = double.Parse(TestContext.DataRow["x"].ToString());
            uint derivativeOrder = uint.Parse(TestContext.DataRow["derivativeOrder"].ToString());

            TrigonometricFuncName funcName = (TrigonometricFuncName)Enum.Parse(typeof(TrigonometricFuncName), TestContext.DataRow["name"].ToString());

            TrigonometricFunction function = new TrigonometricFunction(a, b, funcName);

            //Act
            double actual = a * b * function.FindDerivativeValue(derivativeOrder, x);
            double result = double.Parse(TestContext.DataRow["result"].ToString());

            //Assert
            Assert.AreEqual(actual, result);
        }
        [TestMethod]
        public void TrigonometricFunctionCloneTest()
        {
            TrigonometricFuncName funcName = (TrigonometricFuncName)Enum.Parse(typeof(TrigonometricFuncName), "cos");
            TrigonometricFunction function = new TrigonometricFunction(12, 2, funcName);
            TrigonometricFunction cloneFunction = function.Clone() as TrigonometricFunction;

            Assert.IsTrue(function == cloneFunction);
        }
        [TestMethod]
        public void TrigonometricFunctionOperatorEqualTest()
        {
            TrigonometricFuncName funcName1 = (TrigonometricFuncName)Enum.Parse(typeof(TrigonometricFuncName), "cos");
            TrigonometricFunction function1 = new TrigonometricFunction(12, 2, funcName1);
            TrigonometricFuncName funcName2 = (TrigonometricFuncName)Enum.Parse(typeof(TrigonometricFuncName), "cos");
            TrigonometricFunction function2 = new TrigonometricFunction(12, 2, funcName2);

            bool result = (function1 == function2);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TrigonometricFunctionOperatorNotEqualTest()
        {
            TrigonometricFuncName funcName1 = (TrigonometricFuncName)Enum.Parse(typeof(TrigonometricFuncName), "cos");
            TrigonometricFunction function1 = new TrigonometricFunction(12, 2, funcName1);
            TrigonometricFuncName funcName2 = (TrigonometricFuncName)Enum.Parse(typeof(TrigonometricFuncName), "cos");
            TrigonometricFunction function2 = new TrigonometricFunction(2, 12, funcName2);

            bool result = (function1 == function2);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TrigonometricFunctionCompareToTest()
        {
            TrigonometricFuncName funcName1 = (TrigonometricFuncName)Enum.Parse(typeof(TrigonometricFuncName), "cos");
            TrigonometricFunction function1 = new TrigonometricFunction(12, 2, funcName1);
            TrigonometricFuncName funcName2 = (TrigonometricFuncName)Enum.Parse(typeof(TrigonometricFuncName), "cos");
            TrigonometricFunction function2 = new TrigonometricFunction(2, 12, funcName2);

            int actual = function1.FindFunctionValue(1).CompareTo(function2.FindFunctionValue(1));

            Assert.AreEqual(actual, -1);
        }

        
    }
}
//