using System.Runtime.CompilerServices;
using TOOP.Interfaces;

namespace TOOP.Common.Functionals
{
    class L1Functional : IDifferentiableFunctional
    {
        public List<(double x, double y)> points;

        public L1Functional(List<(double x, double y)> points)
        {
            this.points = points;
        }

        public IVector Gradient(IFunction function)
        {
            if(!(function is IDifferentiableFunction func))
                throw new Exception("Invalid function type");

            var res = new Vector();
            foreach(var point in points)
            {
                res.Add(func.Value(new Vector(){point.x}));
            }
            return res;
        }

        public double Value(IFunction function)
        {
            double sum = 0;
            foreach (var point in points)
            {
                var param = new Vector();
                param.Add(point.x);
                var s = function.Value(param) - point.y;
                sum += s * s;
            }
            return sum;
        }


    }
}