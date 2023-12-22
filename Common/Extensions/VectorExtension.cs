using TOOP.Interfaces;

namespace TOOP.Common.Extensions
{
    public static class VectorExtension
    {
        public static IVector AddRange(this IVector vector, List<double> list)
        {
            list.ForEach(vector.Add);
            return vector;
        }

        public static void Swap(this IVector vector, int v1, int v2)
        {
            (vector[v1], vector[v2]) = (vector[v2], vector[v1]);
        }
    }
}
