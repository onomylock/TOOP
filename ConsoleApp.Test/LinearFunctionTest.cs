using ConsoleApp.Common.Functions;
using ConsoleApp.Interfaces;
using ConsoleApp.Types;

namespace ConsoleApp.Test
{
    [TestFixture]
    public class LinearFunctionTest
    {
        private LinearFunction _linearFunction;

        private static readonly object[] _sourceParameters = 
        {
            new object[] {new Vector( [1, 2] ), new Vector([1]) },
            new object[] {new Vector( [1, 2, 0]), new Vector([1, 2]) },
            new object[] {new Vector( [1, 2, 3, 0]), new Vector([1, 2, 3]) }
        };      

        [SetUp]
        public void SetUp()
        {
            _linearFunction = new LinearFunction();
        }
        
        [TestCaseSource("_sourceParameters")]        
        public void Test1(Vector parameters, Vector points) 
        {
            var funLine = _linearFunction.Bind(parameters) as IDifferentiableFunction;

            Console.WriteLine("Parameters: [{0}]", string.Join(", ", parameters.Doubles));

            Console.WriteLine("Point: [{0}]", string.Join(", ", points.Doubles));

            Console.WriteLine("Fun val: {0}", funLine.Value(points));

            Console.WriteLine("Gradient: [{0}]", string.Join(", ", funLine.Gradient(points).Doubles));
        }

    }
}
