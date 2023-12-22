namespace TOOP.Interfaces
{
    public interface IOptimizator
    {
        IVector Minimize(IFunctional objective, IParametricFunction function,
            IVector initialParameters, IVector minimumParameters = default, IVector maximumParameters = default);
    }
}