using ConsoleApp.Common.Functions;
using ConsoleApp.Types;
using System.Reflection.Metadata;

namespace ConsoleApp.Test
{
    [TestFixture]
    public class PolinomialFunctionTest
    {
        private PolynomialFunction _polynomialFunction;
        private static readonly object[] _sourceParameters =
        {
            new object[] { new List<double> { 1, 2, 3, 4 }, 1.0 },
            new object[] { new List<double> {  -1, 2, 3, -4 }, 13.0 },
            new object[] { new List<double> {  -1, 2, 3, -4, -5 }, 15.0 },
        };


        [SetUp]
        public void SetUp()
        {
            _polynomialFunction = new PolynomialFunction();
        }

        [TestCaseSource("_sourceParameters")]
        public void Test(List<double> parameters, double point)
        {
            var fun = _polynomialFunction.Bind(new Vector(parameters));

            Console.WriteLine("Parameters: [{0}]", string.Join(", ", parameters));

            Console.WriteLine("Point: [{0}]", point);

            Console.WriteLine("Fun val: {0}", fun.Value(new Vector([point])));
            
        }

    }
}
