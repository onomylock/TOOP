using TOOP.Interfaces;

namespace TOOP.Common.Functions
{
    public class PiecewiseLinearFunction : IParametricFunction
    {
        
        class InternalFunction : IDifferentiableFunction
        {

            private List<(Point, Point)> lines;

            public InternalFunction(IVector parameters)
            {
                if(!VectorConverter.TryConvertToLinesList((Vector)parameters, out lines))
                    throw new Exception("Invalid points");            
            }

            public IVector Parameters {get; set;}

            public IVector Gradient(IVector point)
            {
                var px = point.First();
                var resLine = lines.First(line => line.Item1.X >= px && line.Item2.X <= px);

                return new Vector(){(resLine.Item2.Y - resLine.Item1.Y) / (resLine.Item2.X - resLine.Item1.X), 1};
            }

            public double Value(IVector point)
            {
                var px = point.First();
                var resLine = lines.First(line => line.Item1.X >= px && line.Item2.X <= px);
                return (px - resLine.Item1.X) * (resLine.Item2.Y - resLine.Item1.Y) / (resLine.Item2.X - resLine.Item1.X) + resLine.Item1.Y;
            }
        }

        public IFunction Bind(IVector parameters) => new InternalFunction(parameters);
    }
}