using System.Runtime.CompilerServices;
using TOOP.Common.Factory;
using TOOP.Interfaces;

namespace TOOP.Common.Menu
{
    public enum FuctionalType
    {
        L1, L2, Linf, Integral
    }

    public class FunctionalMenu : MenuBase
    {
        private static FuctionalType functionalType { get; set; } = FuctionalType.L1;
        IFunctional functional { get; set; }
        FunctionMenu functionMenu { get; }
        IFunctionalFactory functionalFactory { get; set; }

        private Option[] functionalTypeOptions = new Option[] 
        {
            new Option("L1", (i) => { functionalType = FuctionalType.L1; return false; }),
            new Option("L2", (i) => { functionalType = FuctionalType.L2; return false; }),
            new Option("Linf", (i) => { functionalType = FuctionalType.Linf; return false; }),
            new Option("Integral", (i) => { functionalType = FuctionalType.Integral; return false; }),
        };

        public FunctionalMenu()
        {
            functionMenu = new FunctionMenu();

            options = new List<Option>()
            {
                 new Option("Select functional type", (i) => SelectFunctionalTypeCommand()),
                 new Option("Set function", (i) => SetFunctionCommand()),
                 new Option("Set points"), (i) => SetPointsCommand()),
                 new Option("Get Value", (i) => GetValueCommand()),
                 new Option("Get Gradient", (i) => GetGradientCommand()),
                 new Option("Get Jacobian", (i) => GetJacobianCommand()),
                 new Option("Get Residual", (i) => GetResidualCommand()),
                 new Option("Exit", (i) => false)
            };            
        }

        private bool SelectFunctionalTypeCommand()
        {
            StartMenu(functionalTypeOptions);
            functional = functionalFactory.CreateFunctional(functionalType);
            
            return true;
        }

        private bool SetFunctionCommand()
        {
            functionMenu.StartMenu();            
            return true;
        }

        private bool SetPointsCommand()
        {
            Console.WriteLine("Set points count");
            int N = int.Parse(Console.ReadLine());
            var points = new List<(double x, double y)>();
            Console.WriteLine("Set values as x, y pair");
            for(int i = 0; i < N; i++)
            {
                var point = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToDouble);
                points.Add((point[0], point[1]));
            }
            ((ISetPoints)functional).SetPoints(points);

            return false;
        }

        private bool GetValueCommand()
        {
            Console.WriteLine($"Value: {functional.Value(functionMenu.function)}");
            return false;
        }

        private bool GetGradientCommand()
        {
            if(functional is IDifferentiableFunctional differentiableFunctional)            
                Console.WriteLine($"Gradient: {differentiableFunctional.Gradient(functionMenu.function)}");
            else
                Console.WriteLine("Not valid type of functional");

            return false;
        }

        private bool GetJacobianCommand() 
        {
            if(functional is ILeastSquaresFunctional leastSquaresFunctional)
                Console.WriteLine($"Jacobian: {leastSquaresFunctional.Jacobian(functionMenu.function)}");
            else
                Console.WriteLine("Not valid type of functional");

            return false;
        }

        private bool GetResidualCommand()
        {
            if (functional is ILeastSquaresFunctional leastSquaresFunctional)
                Console.WriteLine($"Residual: {leastSquaresFunctional.Residual(functionMenu.function)}");
            else
                Console.WriteLine("Not valid type of functional");

            return false;
        }
    }
}
