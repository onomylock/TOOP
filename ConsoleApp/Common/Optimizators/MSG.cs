using ConsoleApp.Interfaces;

namespace ConsoleApp.Common.Optimizators
{
    public class MSG : IOptimizator
    {
        public IVector Minimize(IFunctional objective, IParametricFunction function, IVector initialParameters,
                                IVector minimumParameters = null, IVector maximumParameters = null)
        {
            throw new NotImplementedException();
        }
    }
}