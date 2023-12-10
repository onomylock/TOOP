namespace TOOP.Common
{
    public static class VectorConverter
    {
        public static bool TryConvertToLinesList(Vector parameters, out List<(Point, Point)> lines)
        {
            lines = new List<(Point, Point)>();

            if(parameters.Count() % 4 != 0)            
                return false;
                    
            for(int i = 0; i < parameters.Count() - 3; i+=4)
            {
                lines.Add((new Point(){X = parameters[i], Y = parameters[i + 1]}, new Point(){X = parameters[i + 2], Y = parameters[i + 3]}));
            }            

            return true;
        }

        public static bool TryConvertToPointList(Vector parameters, out List<Point> points)
        {
            points = new List<Point>();

            if(parameters.Count() % 2 != 0)
                return false;

            for(int i = 0; i < parameters.Count() - 1; i+= 2)
            {
                points.Add(new Point(){X = parameters[i], Y = parameters[i + 1]});
            }

            return true;
        }
    }
}