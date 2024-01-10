using ConsoleApp.Interfaces;
using ConsoleApp.Common.Functions;
using ConsoleApp.Types;

namespace ConsoleApp
{
    class Program
    {
        const string INPUT_PATH = "../../../Input/";
        const string OUTPUT_PATH = "../../../Output/";

        static void Main(string[] args)
        {
            try
            {
                //#region Line test

                //ReadVector(out IVector parametersLine, INPUT_PATH + "paramsLine.txt");
                //var funcLine = new LinearFunction();
                //var funLine = funcLine.Bind(parametersLine) as IDifferentiableFunction;

                //if (fun == null)
                //    throw new InvalidDataException();

                //Console.WriteLine(funLine.Value(new Vector([1.0])));

                //Console.WriteLine("[{0}]", string.Join(", ", funLine.Gradient(new Vector([1.0])).Doubles));
                //#endregion

                #region Piecewise test

                var parameters = new List<List<double>>
                {
                    new List<double>() { 1, 0 },
                    new List<double>() { -1, 1 },
                    new List<double>() { 1, -2 },
                    new List<double>() { -1, 3}
                };
                var points = new List<Vector>
                {
                    new Vector([1]),
                    new Vector([2]),
                    new Vector([3])
                };

                //ReadVector(out IVector parametersPiecewise, INPUT_PATH + "paramsLine.txt");
                var func = new PiecewiseLinearFunction();
                var fun = func.Bind(new Vector(parameters.SelectMany(x => x))) as IDifferentiableFunction;

                if (fun == null)
                    throw new InvalidDataException();

                Console.WriteLine(fun.Value(new Vector([1.0])));

                Console.WriteLine("[{0}]", string.Join(", ", fun.Gradient(new Vector([1.0])).Doubles));
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        static void ReadVector(out IVector vector, string path)
        {            
            var input = new List<double>();
            string line;
            using(var sr = new StreamReader(path))
            {
                while((line = sr.ReadLine()) != null)
                {                    
                    input.AddRange(Array.ConvertAll(line.Trim().Split(' '), Convert.ToDouble).ToList());
                }
            }
            vector = new Vector(input);            
        }
    }
}


