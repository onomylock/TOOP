namespace ConsoleApp.Interfaces
{
    public interface IFunctional
    {
        double Value(IFunction function);
    }
    public interface IDifferentiableFunctional : IFunctional
    {
        IVector Gradient(IFunction function);
    }
    
    public interface ILeastSquaresFunctional : IFunctional
    {
        IVector Residual(IFunction function);
        IMatrix Jacobian(IFunction function);
    }
}