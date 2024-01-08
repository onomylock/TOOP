namespace ConsoleApp.Interfaces
{
    public interface IVector : IList<double>
    {
        IVector GetRange(int v1, int v2);
        void AddRange(double[] arr);        
        //Range operator ..(Index start, Index end);
    }
}