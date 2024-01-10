using ConsoleApp.Common.Functions;
using ConsoleApp.Types;

namespace ConsoleApp.Test
{
    [TestFixture]
    public class SplineFunctionTest
    {
        private SplineFunction _splineFunction;
        private static readonly object[] _sourceParameters =
        {
            new object[]
            {
                new object[] {new Vector( [1, 2]  ) },
                new object[] {new Vector( [4, -7] ) },
                new object[] {new Vector( [9, 42] ) }
            }            
        };

        [SetUp]
        public void SetUp()
        {
            _splineFunction = new SplineFunction();
        }

        [TestCaseSource("_sourceParameters")]
        public void Test(List<List<Vector>> parameters)
        {
            var fun = _splineFunction.Bind(new Vector(parameters.SelectMany(x => x.SelectMany(y => y.Doubles))));
            var rand = new Random();
            var points = Enumerable.Repeat(0.0, 100).Select(x => (double)(50 / rand.Next(1, 50))).ToList();
            points.Sort();
            foreach (var point in points) 
            {
                Console.WriteLine(fun.Value(new Vector([point])));
            }
        }

    }
}
