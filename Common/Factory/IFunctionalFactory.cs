using TOOP.Common.Menu;
using TOOP.Interfaces;

namespace TOOP.Common.Factory
{
    public interface IFunctionalFactory
    {
        IFunctional CreateFunctional(FuctionalType functionalType);
    }
}
