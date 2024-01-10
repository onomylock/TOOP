using ConsoleApp.Interfaces;
using ConsoleApp.Types;
using MathVec = MathNet.Numerics.LinearAlgebra.Vector<double>;

namespace ConsoleApp.Common.Functionals
{
    public class LInf : IFunctional
    {
        List<IVector> points;
        IVector funcPoints;

        public LInf(List<IVector> points, IVector funcPoints)
        {
            this.points = points;
            this.funcPoints = funcPoints;
        }
        public double Value(IFunction function)
        {
            var funVal = new Vector();
            foreach(var point in points)
            {
                funVal.Add(function.Value(point));
            }
            var res = MathVec.Build.Dense([.. (funVal - (Vector)funcPoints)]);
            
            return res.InfinityNorm();
        }
    }
}