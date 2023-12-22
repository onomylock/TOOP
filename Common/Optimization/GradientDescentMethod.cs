using TOOP.Interfaces;

namespace TOOP.Common.Optimization
{
    public class GradientDescentMethod : IOptimizator
    {
        int maxIter = 10000;
        IVector IOptimizator.Minimize(IFunctional objective, IParametricFunction function, IVector initialParameters, IVector minimumParameters, IVector maximumParameters)
        {
            
        }
    }
}