using TOOP.Interfaces;

namespace TOOP.Common.Functions
{
    public class PolynomialFunction : IParametricFunction
    {
        class InternalFunction : IFunction
        {
            public IVector Parameters {get; set;}

            double IFunction.Value(IVector point)
            {
                double res = 0;
                for(int i = 1; i < Parameters.Count(); i++)
                {
                    res += point[i - 1] * Parameters[i];
                }

                return res + Parameters.First();
            }
        }

        public IFunction Bind(IVector parameters) => new InternalFunction(){Parameters = parameters};
    }
}