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
                _parameters = parameters;
                _intersactionPoints = new Vector([double.MinValue]);
                SetIntersactionPoints();
            }

            IVector _parameters { get; set; }
            IVector _intersactionPoints { get; set; }
            public IVector Gradient(IVector point)
            {
                var res = new Vector();
                var current = GetCurrentLineIndex(point);

                res.Doubles.Add(_parameters.Doubles[current]);                
                return res;
            }

            public double Value(IVector point)
            {
                var current = GetCurrentLineIndex(point);

                return _parameters.Doubles[current] * point.Doubles.First() + _parameters.Doubles[current + 1];
            }

            int GetCurrentLineIndex(IVector point)
            {
                var px = point.Doubles.First();
                int current = 0;
                for (int i = 0; i < _intersactionPoints.Doubles.Count() - 1; i++)
                {
                    if (px >= _intersactionPoints.Doubles[i] && px <= _intersactionPoints.Doubles[i + 1])
                    {
                        current = i;
                        break;
                    }
                }

                return current * 2;
            }

            void SetIntersactionPoints()
            {
                for (int i = 0; i < _parameters.Doubles.Count() - 2; i += 2)
                {
                    var px = (_parameters.Doubles[i + 3] - _parameters.Doubles[i + 1]) / (_parameters.Doubles[i] - _parameters.Doubles[i + 2]);
                    if (px != double.NaN && _intersactionPoints.Doubles.Last() < px)
                        _intersactionPoints.Doubles.Add(px);
                    else
                        throw new InvalidDataException();
                }
                _intersactionPoints.Doubles.Add(double.MaxValue);
            }
        }

        public IFunction Bind(IVector parameters) => new InternalFunction(parameters);
    }
}