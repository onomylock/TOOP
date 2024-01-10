using ConsoleApp.Interfaces;
using MathNet.Numerics.Interpolation;

namespace ConsoleApp.Common.Functions
{
    public class SplineFunction: IParametricFunction
    {
        internal class InternalFunction : IFunction
        {               
            CubicSpline cubicSpline {get; set;}              
            double[] xVal;
            double[] yVal;
            public InternalFunction(IVector parameters)
            {            
                xVal = parameters.Doubles.Where(x => parameters.Doubles.IndexOf(x) % 2 == 0).ToArray();
                yVal = parameters.Doubles.Where(x => parameters.Doubles.IndexOf(x) % 2 == 1).ToArray();
                cubicSpline = CubicSpline.InterpolateAkimaSorted(xVal, yVal);
            }
            
            public double Value(IVector point)
            {
                return cubicSpline.Interpolate(point.Doubles.First());
            }
        }

        public IFunction Bind(IVector parameters) => new InternalFunction(parameters);
    }
}