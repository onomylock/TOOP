using ConsoleApp.Interfaces;
using ConsoleApp.Types;

namespace ConsoleApp.Common.Functionals
{
    public class L1Functional : IDifferentiableFunctional
    {
        List<IVector> points;
        Vector funcPoints;

        public L1Functional(List<IVector> points, Vector funcPoints)
        {
            this.points = points;
            this.funcPoints = funcPoints;
        }

        public IVector Gradient(IFunction function)
        {
            if (!(function is IDifferentiableFunction differentiableFunction))
                throw new InvalidDataException();

            var res = new Vector();
            foreach (var point in points)
            {
                res.Doubles.AddRange(differentiableFunction.Gradient(point).Doubles);
            }

            return res;
        }

        public double Value(IFunction function)
        {
            var funVal = new Vector();
            foreach (var point in points)
            {
                funVal.Doubles.Add(function.Value(point));
            }            

            return Vector.NormL1(funVal, funcPoints);
        }
    }
}