using TOOP.Interfaces;

namespace TOOP.Common
{
    public class Vector : List<double>, IVector
    {
        //IVector IVector.GetRande(int v1, int v2)
        //{
        //    return (IVector)GetRange(v1, v2);
        //}
        IVector IVector.GetRange(int v1, int v2)
        {
            return (IVector)this.GetRange(v1, v2);
        }
    }
}