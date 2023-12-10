using TOOP.Interfaces;

namespace TOOP.Common.Optimization
{
    public class GaussNewtonAlgorithm : IOptimizator
    {
        class InternalFunctional : ILeastSquaresFunctional
        {            

            public IMatrix Jacobian(IFunction function)
            {
                throw new NotImplementedException();
            }

            public IVector Residual(IFunction function)
            {
                throw new NotImplementedException();
            }

            public double Value(IFunction function)
            {
                throw new NotImplementedException();
            }
        }

        IVector IOptimizator.Minimize(IFunctional objective, IParametricFunction function, IVector initialParameters, IVector minimumParameters, IVector maximumParameters)
        {
            throw new NotImplementedException();
        }
    }
}