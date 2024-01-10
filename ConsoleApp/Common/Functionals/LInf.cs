using ConsoleApp.Interfaces;
using ConsoleApp.Types;
using MathVec = MathNet.Numerics.LinearAlgebra.Vector<double>;

namespace ConsoleApp.Common.Functionals
{
    public class LInf : IFunctional
    {
        List<IVector> points;
        Vector funcPoints;

        public LInf(List<IVector> points, Vector funcPoints)
        {
            this.points = points;
            this.funcPoints = funcPoints;
        }
        public double Value(IFunction function)
        {
            var funVal = new Vector();
            foreach (var point in points)
            {
                funVal.Doubles.Add(function.Value(point));
            }
            return Vector.NormLInf(funVal, funcPoints);
        }
    }
}