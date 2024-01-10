using ConsoleApp.Interfaces;

namespace ConsoleApp.Types
{
    public class Vector : IVector
    {                
        public List<double> Doubles { get; set; } = new List<double>();

        public Vector() { }

        public Vector(IEnumerable<double> doubles) => Doubles = doubles.ToList();

        public static Vector operator -(Vector v1, Vector v2) => 
            new(v1.Doubles.Zip(v2.Doubles, (elem1, elem2) => elem1 - elem2));

        public static Vector operator +(Vector v1, Vector v2) => 
            new(v1.Doubles.Zip(v2.Doubles, (elem1, elem2) => elem1 + elem2));

        public static Vector operator /(Vector v1, double val) =>
            new(v1.Doubles.Select(x => x / val));

        public static double NormL1(Vector v1, Vector v2) => (v1 - v2).Doubles.Select(Math.Abs).Sum();

        public static double NormL2(Vector v1, Vector v2) => Math.Sqrt((v1 - v2).Doubles.Select(x => Math.Pow(x, 2)).Sum());            

        public static double NormLInf(Vector v1, Vector v2) => (v1 - v2).Doubles.Select(Math.Abs).Max();        
    }
}