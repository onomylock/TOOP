using TOOP.Interfaces;

namespace TOOP.Common.Functions
{
    public class LineFunction : IParametricFunction
    {        
        class InternalLineFunction : IFunction, IDifferentiableFunction
        {
            public IVector Parameters {get; set;}

            public IVector Gradient(IVector point)
            {
                return Parameters.GetRange(0, Parameters.Count() - 2);
            }

            public double Value(IVector point)
            {
                double res = 0;
                for(int i = 0; i < Parameters.Count(); i++)
                {
                    res += point[i] * Parameters[i];
                }

                return res + Parameters.Last();
            }
        }

        public IFunction Bind(IVector parameters) => new InternalLineFunction() { Parameters = parameters };       
    }
}