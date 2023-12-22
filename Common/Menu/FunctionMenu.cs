using TOOP.Common.Extensions;
using TOOP.Common.Factory;
using TOOP.Interfaces;

namespace TOOP.Common.Menu
{
    public enum FunctionType
    {
        LineFunction, 
        PiecewiseLinearFunction, 
        PolynomialFunction, 
        SplineFunction
    }

    public class FunctionMenu : MenuBase
    {
        public IFunction function { get; set; }
        IParametricFunction parametricFunction { get; set; }
        static FunctionType functionType { get; set; } = FunctionType.LineFunction;
        IFunctionFactory functionFactory = new FunctionFactory();
        IDictionary<FunctionType, string> functionInputs = new Dictionary<FunctionType, string>() 
        {
            {FunctionType.LineFunction, "" },
            {FunctionType.PiecewiseLinearFunction, "" },
            {FunctionType.SplineFunction, "" },
            {FunctionType.PolynomialFunction, "" }
        };

        private Option[] funcTypeOptions = new Option[]
        {
            new Option("Line function", (i) => { functionType = FunctionType.LineFunction; return false; } ),
            new Option("Piecewise linear function", (i) => { functionType = FunctionType.PiecewiseLinearFunction; return false; }),
            new Option("Polynomial function", (i) => { functionType = FunctionType.PolynomialFunction; return false; }),
            new Option("Spline function", (i) => { functionType = FunctionType.SplineFunction; return false; }),
        };

        public FunctionMenu() 
        {
            options = new List<Option>()
            {
                new Option("Select function type", (i) => SelectFunctionTypeCommand()),
                new Option("Set function parameters from file", (i) => SelectFunctionParametersFromFileCommand()),
                new Option("Get value", (i) => GetValueCommand()),
                new Option("Insert function", (i) => InsertFunctionCommand()),
                new Option("Get function value in point", (i) => InsertFunctionValueCommand()),
                new Option("Get function gradient in point", (i) => GetFunctionGradientCommand()),
                new Option("Exit", (i) => false)
            };
        }

        private bool SelectFunctionTypeCommand()
        {
            StartMenu(funcTypeOptions);
            parametricFunction = functionFactory.CreateParametricFunction(functionType);
            return true;
        }

        private bool GetValueCommand()
        {
            Console.WriteLine("Write coordinate");
            function.Value(new Vector() { double.Parse(Console.ReadLine()) });
            return true;
        }
        
        private bool SelectFunctionParametersFromFileCommand()
        {
            IVector paramList = new Vector();
            using (var sr = new StreamReader(functionInputs[functionType]))
            {
                var N = int.Parse(Console.ReadLine());
                for(int i = 0; i < N; i++)
                {
                    paramList.AddRange(Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToDouble).ToList());
                }
            }
            function = parametricFunction.Bind(paramList);
            return true;
        }

        private bool InsertFunctionCommand()
        {
            return false;
        }

        private bool InsertFunctionValueCommand()
        {
            return false;
        }

        private bool GetFunctionGradientCommand()
        {
            return false;
        }
    }
}
