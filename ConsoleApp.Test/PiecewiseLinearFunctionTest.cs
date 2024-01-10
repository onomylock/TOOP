using ConsoleApp.Common.Functions;
using ConsoleApp.Interfaces;
using ConsoleApp.Types;

namespace ConsoleApp.Test
{
    [TestFixture]
    public class PiecewiseLinearFunctionTest
    {
        private PiecewiseLinearFunction _piecewiseLinearFunction;

        private static readonly object[] _sourceParameters =
        {
            new object[] 
            { 
                new List<List<double>> 
                {
                    new List<double>() { 1, 0 },
                    new List<double>() { -1, 1 },
                    new List<double>() { 1, -2 },
                    new List<double>() { -1, 3}
                },
                new List<Vector>
                { 
                    new Vector([-1]),
                    new Vector([2]),
                    new Vector([4])
                }
            },            
        };

        [SetUp] public void SetUp() 
        {
            _piecewiseLinearFunction = new PiecewiseLinearFunction();
        }

        [TestCaseSource("_sourceParameters")]
        public void Test(List<List<double>> parameters, List<Vector> points)
        {
            var fun = _piecewiseLinearFunction.Bind(new Vector(parameters.SelectMany(x => x))) as IDifferentiableFunction;

            foreach(var point in points) 
            {
                Console.WriteLine("Fun val: {0}", fun.Value(point));
                Console.WriteLine("Gradient: [{0}]", string.Join(", ", fun.Gradient(point).Doubles));
            }
        }
    }
}
