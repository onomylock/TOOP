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
                xVal = parameters.Where(x => parameters.IndexOf(x) % 2 == 0).ToArray();
                yVal = parameters.Where(x => parameters.IndexOf(x) % 2 == 1).ToArray();
                cubicSpline = CubicSpline.InterpolateAkimaSorted(xVal, yVal);
            }
            
            public double Value(IVector point)
            {
                return cubicSpline.Interpolate(point.First());
            }
        }

        public IFunction Bind(IVector parameters) => new InternalFunction(parameters);
    }
}