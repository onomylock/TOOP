using TOOP.Common.Functions;
using TOOP.Common.Menu;
using TOOP.Interfaces;

namespace TOOP.Common.Factory
{
    public interface IFunctionFactory
    {
        IParametricFunction CreateParametricFunction(FunctionType functionType);
    }
}
