using TOOP.Interfaces;

namespace TOOP.Common.Functionals
{
    public class Integral : IFunctional
    {       
        public List<Point> points {get; set; }

        public Integral(List<Point> points)
        {
            this.points = points;
        }

        public Integral(){ }

        double IFunctional.Value(IFunction function)
        {
            double a = points.First().X;
            double b = points.Last().X;
            int n = points.Count();

            var h = (b - a) / n;
            double sum1 = 0, sum2 = 0;
            

            for(int i = 1; i <= n; i++)
            {
                var xi = a + i * h;
                if(i <= n - 1)
                {
                    sum1 += function.Value(new Vector(){points[i].X});
                }

                var xi_1 =  a + (i - 1) * h;
                sum2 += function.Value(new Vector(){(xi + xi_1) / 2});
            }

            var result = h / 3d * (1d / 2d * function.Value(new Vector(){a}) + sum1 + 2 * sum2 + 1d / 2d * function.Value(new Vector(){b}));
            return result;
        }
    }
}