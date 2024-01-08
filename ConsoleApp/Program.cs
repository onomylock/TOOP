using ConsoleApp.Types;
using ConsoleApp.Interfaces;
using ConsoleApp.Common.Functions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ReadVector(out IVector parameters, "Input/params.txt");
                var func = new LinearFunction();
                var fun = func.Bind(parameters);
                Console.WriteLine(fun.Value(new Vector([1.0, 2.0])));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        static void ReadVector(out IVector vector, string path)
        {
            vector = new Vector();
            string line;
            using(var sr = new StreamReader(path))
            {
                while((line = sr.ReadLine()) != null)
                {
                    vector.AddRange(Array.ConvertAll(line.Trim().Split(' '), Convert.ToDouble));
                }
            }
        }
    }
}


