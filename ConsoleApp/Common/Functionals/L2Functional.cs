using ConsoleApp.Interfaces;

namespace ConsoleApp.Common.Functionals
{
    public class L2Functional : ILeastSquaresFunctional
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
}