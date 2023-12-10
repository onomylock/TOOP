using TOOP.Interfaces;

namespace TOOP.Common
{
    public class Vector : List<double>, IVector
    {
        IVector IVector.GetRande(int v1, int v2)
        {
            return (IVector)GetRange(v1, v2);
        }
    }
}