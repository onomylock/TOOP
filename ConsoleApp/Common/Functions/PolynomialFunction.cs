using ConsoleApp.Interfaces;

namespace ConsoleApp.Common.Functions
{
    public class PolynomialFunction : IParametricFunction
    {
        internal class InternalFunction(IVector parameters) : IFunction
        {
            IVector parameters { get; set; } = parameters;
            public double Value(IVector point)
            {
                var p = point.Doubles.First();
                int n = parameters.Doubles.Count();
                double res = 0;        
                for (int i = 0; i < n; i++)
                {
                    res += parameters.Doubles[n - i - 1] * Math.Pow(p, i);
                }
                return res;
            }
        }

        public IFunction Bind(IVector parameters) => new InternalFunction(parameters);
    }
}