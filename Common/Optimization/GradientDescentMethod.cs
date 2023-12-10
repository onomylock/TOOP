using TOOP.Interfaces;

namespace TOOP.Common.Optimization
{
    public class GradientDescentMethod : IOptimizator
    {
        IVector IOptimizator.Minimize(IFunctional objective, IParametricFunction function, IVector initialParameters, IVector minimumParameters, IVector maximumParameters)
        {
            throw new NotImplementedException();
        }
    }
}