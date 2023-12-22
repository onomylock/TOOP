using TOOP.Common.Functions;
using TOOP.Common.Menu;
using TOOP.Interfaces;

namespace TOOP.Common.Factory
{
    public class FunctionFactory : IFunctionFactory
    {        
        public IParametricFunction CreateParametricFunction(FunctionType functionType)
        {
            IParametricFunction function = null;

            switch (functionType)
            {
                case FunctionType.LineFunction:             
                    function =  new LineFunction();
                    break;
                case FunctionType.PiecewiseLinearFunction:  
                    function =  new PiecewiseLinearFunction();
                    break;
                case FunctionType.PolynomialFunction:       
                    function =  new PolynomialFunction();
                    break;
                case FunctionType.SplineFunction:           
                    function =  new SplineFunction();
                    break;
            }

            return function;
        }
    }    
}
