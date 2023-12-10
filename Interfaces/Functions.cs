namespace TOOP.Interfaces
{
    interface IParametricFunction
    {
        IFunction Bind(IVector parameters);
    }

    interface IFunction
    {
        double Value(IVector point);
    }

    interface IDifferentiableFunction : IFunction
    {
        // По параметрам исходной IParametricFunction
        IVector Gradient(IVector point);
    }
}