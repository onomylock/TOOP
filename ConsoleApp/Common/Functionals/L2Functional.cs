using ConsoleApp.Interfaces;
using ConsoleApp.Types;
using MathVec = MathNet.Numerics.LinearAlgebra.Vector<double>;

namespace ConsoleApp.Common.Functionals
{
    public class L2Functional : ILeastSquaresFunctional
    {
        List<IVector> points;
        Vector funcPoints;

        public L2Functional(List<IVector> points, Vector funcPoints)
        {
            this.points = points;
            this.funcPoints = funcPoints;
        }

        public IMatrix Jacobian(IFunction function)
        {
            if (!(function is IDifferentiableFunction differentiableFunction))
                throw new InvalidDataException();

            var res = new Matrix();
            foreach (var point in points)
            {
                res.Add(differentiableFunction.Gradient(point).Doubles);
            }

            return res;
        }

        public IVector Residual(IFunction function)
        {
            var res = new Vector();
            int index = 0;
            points.ForEach(x =>
            {
                res.Doubles.Add(function.Value(x) - funcPoints.Doubles[index]);
                index++;
            });

            return res;
        }

        public double Value(IFunction function)
        {
            var funVal = new Vector();
            foreach (var point in points)
            {
                funVal.Doubles.Add(function.Value(point));
            }            

            return Vector.NormL2(funcPoints, funVal);
        }
    }
}