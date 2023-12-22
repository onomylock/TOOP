using TOOP.Common.Extensions;
using TOOP.Interfaces;

namespace TOOP.Common.Optimization
{
    public class MinimizerMonteCarlo : IOptimizator
    {
        int maxIter = 10000;

        IVector IOptimizator.Minimize(IFunctional objective, IParametricFunction function, IVector initialParameters, IVector minimumParameters, IVector maximumParameters)
        {
            var result = new Vector();
            var rand = new Random();
            var func = function.Bind(initialParameters);
            var ans = func.Value(new Vector() { initialParameters.First() });

            double t = 1;
            for(int i = 0; i < maxIter; i++)
            {
                t *= 0.99;
                var vec = result;
                vec.Swap(rand.Next() % vec.Count(), rand.Next() % vec.Count());


            }

            return result;
        }
    }
}