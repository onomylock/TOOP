using ConsoleApp.Interfaces;
using ConsoleApp.Types;
using MathVec = MathNet.Numerics.LinearAlgebra.Vector<double>;

namespace ConsoleApp.Common.Functionals
{
    public class L1Functional : IDifferentiableFunctional
    {
        List<IVector> points;
        IVector funcPoints;

        public L1Functional(List<IVector> points, IVector funcPoints)
        {
            this.points = points;
            this.funcPoints = funcPoints;
        }

        public IVector Gradient(IFunction function)
        {
            if(!(function is IDifferentiableFunction differentiableFunction))
                throw new InvalidDataException();

            var res = new Vector();
            foreach(var point in points)
            {
                res.AddRange(differentiableFunction.Gradient(point));
            }

            return res;
        }

        public double Value(IFunction function)
        {
            var funVal = new Vector();
            foreach(var point in points)
            {
                funVal.Add(function.Value(point));
            }
            var res = MathVec.Build.Dense([.. (funVal - (Vector)funcPoints)]);
            
            return res.L1Norm();
        }
    }
}