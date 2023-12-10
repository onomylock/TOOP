using TOOP.Interfaces;

namespace TOOP.Common.Functions
{
    public class SplineFunction : IParametricFunction
    {
        class InternalFunction : IFunction
        {
            public List<Point> _points;
            private SplineTuple[] _splines;

            private struct SplineTuple
            {
                public double a, b, c, d, x;
            }

            public InternalFunction(IVector parameters)
            {
                if(!VectorConverter.TryConvertToPointList((Vector)parameters, out _points))
                    throw new Exception("Invalid input data");                
            }

            private void BuildSpline()
            {
                int n = _points.Count();


                _splines = new SplineTuple[n];
                for (int i = 0; i < n; ++i)
                {
                    _splines[i].x = _points[i].X;
                    _splines[i].a = _points[i].Y;
                }
                _splines[0].c = _splines[n - 1].c = 0.0;
                
                double[] alpha = new double[n - 1];
                double[] beta  = new double[n - 1];
                alpha[0] = beta[0] = 0.0;
                for (int i = 1; i < n - 1; ++i)
                {
                    double hi  = _points[i].X - _points[i - 1].X;
                    double hi1 = _points[i + 1].X - _points[i].X;
                    double A = hi;
                    double C = 2.0 * (hi + hi1);
                    double B = hi1;
                    double F = 6.0 * ((_points[i + 1].Y - _points[i].Y) / hi1 - (_points[i].Y - _points[i - 1].Y) / hi);
                    double z = (A * alpha[i - 1] + C);
                    alpha[i] = -B / z;
                    beta[i] = (F - A * beta[i - 1]) / z;
                }

                // Нахождение решения - обратный ход метода прогонки
                for (int i = n - 2; i > 0; --i)
                {
                    _splines[i].c = alpha[i] * _splines[i + 1].c + beta[i];
                }

                // По известным коэффициентам c[i] находим значения b[i] и d[i]
                for (int i = n - 1; i > 0; --i)
                {
                    double hi = _points[i].X - _points[i - 1].X;
                    _splines[i].d = (_splines[i].c - _splines[i - 1].c) / hi;
                    _splines[i].b = hi * (2.0 * _splines[i].c + _splines[i - 1].c) / 6.0 + (_points[i].Y - _points[i - 1].Y) / hi;
                }
            }


            public double Value(IVector point)
            {
                var x = point[0];

                if (_splines == null)
                    throw new Exception("spline not build");

                int n = _splines.Length;
                SplineTuple s;

                if (x <= _splines[0].x)
                {
                    s = _splines[0];
                }
                else if (x >= _splines[n - 1].x)
                {
                    s = _splines[n - 1];
                }
                else
                {
                    int i = 0;
                    int j = n - 1;
                    while (i + 1 < j)
                    {
                        int k = i + (j - i) / 2;
                        if (x <= _splines[k].x)
                        {
                            j = k;
                        }
                        else
                        {
                            i = k;
                        }
                    }
                    s = _splines[j];
                }

                double dx = x - s.x;            
                return s.a + (s.b + (s.c / 2.0 + s.d * dx / 6.0) * dx) * dx;
            }
        }

        IFunction IParametricFunction.Bind(IVector parameters) => new InternalFunction(parameters);
    }
}