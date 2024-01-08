using ConsoleApp.Interfaces;

namespace ConsoleApp.Common.Functions
{
    public class LinearFunction : IParametricFunction
    {
        internal class InternalFunction(IVector parameters) : IFunction, IDifferentiableFunction
        {
            IVector parameters { get; set; } = parameters;

            public IVector Gradient(IVector point) => parameters.GetRange(0, parameters.Count() - 2);

            public double Value(IVector point)
            {
                double res = 0;
                for(int i = 0; i < point.Count(); i++)
                {
                    res += parameters[i] * point[i];
                }

                return res + parameters.Last();
            }
        }

        public IFunction Bind(IVector parameters) => new InternalFunction(parameters);
    }
}