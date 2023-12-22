using TOOP.Common.Functionals;
using TOOP.Common.Menu;
using TOOP.Interfaces;

namespace TOOP.Common.Factory
{
    public class FunctionalFactory : IFunctionalFactory
    {
        public IFunctional CreateFunctional(FuctionalType functionalType)
        {
            IFunctional functional = null;

            switch (functionalType) 
            {
                case FuctionalType.L1:
                    functional = new L1Functional();
                    break;
                case FuctionalType.L2:
                    functional = new L2Functional();
                    break;
                case FuctionalType.Linf:
                    functional = new LInfFunctional();
                    break;
                case FuctionalType.Integral:
                    functional = new Integral();
                    break;
            }

            return functional;
        }
    }
}
