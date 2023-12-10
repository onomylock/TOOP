using TOOP.Interfaces;

namespace TOOP.Common.Functionals
{
    public class L2Functional : ILeastSquaresFunctional
    {
        public List<(double x, double y)> points;

        IMatrix ILeastSquaresFunctional.Jacobian(IFunction function)
        {
            throw new NotImplementedException();
        }

        IVector ILeastSquaresFunctional.Residual(IFunction function)
        {
            throw new NotImplementedException();
        }

        double IFunctional.Value(IFunction function)
        {
            throw new NotImplementedException();
        }
    }
}