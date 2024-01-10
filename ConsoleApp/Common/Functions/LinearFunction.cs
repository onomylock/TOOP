using ConsoleApp.Interfaces;
using ConsoleApp.Types;

namespace ConsoleApp.Common.Functions
{
    public class LinearFunction : IParametricFunction
    {
        internal class InternalFunction(IVector parameters) : IFunction, IDifferentiableFunction
        {
            IVector parameters { get; set; } = parameters;
            
            public IVector Gradient(IVector point)
            {
                var res = parameters.Doubles.Take(parameters.Doubles.Count() - 1).ToList();
                var grad = Math.Sqrt(res.Select(x => Math.Pow(x, 2)).Sum());
                
                return new Vector(res) / grad;
            }

            public double Value(IVector point)
            {
                if ((parameters.Doubles.Count() - 1) != point.Doubles.Count())
                    throw new InvalidDataException();
                double res = 0;
                for(int i = 0; i < point.Doubles.Count(); i++)
                {
                    res += parameters.Doubles[i] * point.Doubles[i];
                }                

                return res + parameters.Doubles.Last();
            }
        }

        public IFunction Bind(IVector parameters) => new InternalFunction(parameters);
    }
}