using ConsoleApp.Interfaces;
using ConsoleApp.Types;

namespace ConsoleApp.Common.Functions
{
    public class PiecewiseLinearFunction : IParametricFunction
    {
        internal class InternalFunction : IFunction, IDifferentiableFunction
        {
            
            public InternalFunction(IVector parameters)
            {
                this.parameters = parameters;
                intersactionPoints = new Matrix();
                SetIntersactionPoints();
            }

            IVector parameters { get; set; }
            IMatrix intersactionPoints {get; set;}
            public IVector Gradient(IVector point) 
            {
                var res = new Vector();
                var current = GetCurrentLineIndex(point);

                res.Add(parameters[current]);                
                res.Add(1);
                return res;
            }

            public double Value(IVector point)
            {
                var current = GetCurrentLineIndex(point);

                return parameters[current] * point.First() + parameters[current + 1];
            }

            int GetCurrentLineIndex(IVector point)
            {                
                var px = point.First();
                int current = 0;
                for(int i = 0; i < intersactionPoints.Count() - 1; i++)
                {
                    if(px > intersactionPoints[i][0] && px < intersactionPoints[i + 1][0])
                    {
                        current = i;
                        break;
                    }
                }

                return current * 2;
            }

            void SetIntersactionPoints()
            {
                for(int i = 0; i < parameters.Count() - 3; i+=4)
                {
                    var px = (parameters[i + 1] - parameters[i + 3]) / (parameters[i] - parameters[i + 2]);
                    var py = parameters[i] * px + parameters[i + 1];
                    if(intersactionPoints.Last() != null && intersactionPoints.Last()[0] < px)
                        intersactionPoints.Add([px, py]);
                    else if(intersactionPoints.Last()[0] < px)
                        throw new InvalidDataException();
                }
            }
        }

        public IFunction Bind(IVector parameters) => new InternalFunction(parameters);
    }
}