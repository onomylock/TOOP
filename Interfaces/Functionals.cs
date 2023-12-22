namespace TOOP.Interfaces
{
    public interface IFunctional
    {
        double Value(IFunction function);
    }

    public interface IDifferentiableFunctional : IFunctional
    {
        IVector Gradient(IFunction function);
    }
    public interface IMatrix : IList<IList<double>>
    {

    }
    public interface ILeastSquaresFunctional : IFunctional
    {
        IVector Residual(IFunction function);
        IMatrix Jacobian(IFunction function);
    }

    public interface ISetPoints
    {
        void SetPoints(List<(double x, double y)> points);
    }
}