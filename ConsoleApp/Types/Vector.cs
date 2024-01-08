using System.Collections;
using System.Dynamic;
using ConsoleApp.Interfaces;

namespace ConsoleApp.Types
{
    public class Vector : IVector
    {
        public Vector(double[] vector) => this.vector = vector;
        public Vector() {}

        double[] vector {get; set;} = Array.Empty<double>();

        public double this[int index] { get => vector[index]; set => vector[index] = value; }        

        public int Count => vector.Length;

        public bool IsReadOnly => false;

        public void Add(double item) => vector.Append(item);

        public void Clear() => Array.Clear(vector);

        public bool Contains(double item) => vector.Contains(item);

        public void CopyTo(double[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<double> GetEnumerator() => GetEnumerator();

        public int IndexOf(double item)
        {
            return Array.IndexOf(vector, item);
        }

        public void Insert(int index, double item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(double item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }        

        IEnumerator IEnumerable.GetEnumerator() => vector.GetEnumerator();

        public IVector GetRange(int v1, int v2)
        {
            IVector result = new Vector();
            
            for (int i = v1; i < v2; i++)
                result.Add(vector[i]);            
            return result;
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            var res = new Vector();
            for(int i = 0; i < v1.Count(); i++)
            {
                res.Add(v1[i] - v2[i]);
            }
            return res;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            var res = new Vector();
            for(int i = 0; i < v1.Count(); i++)
            {
                res.Add(v1[i] + v2[i]);
            }
            return res;
        }

        public void AddRange(double[] arr)
        {                                            
            var result = new double[vector.Length + arr.Length];
            vector.CopyTo(result, 0);
            arr.CopyTo(result, vector.Length);
            vector = result;
        }        
    }
}