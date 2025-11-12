using LinearAlgebra;
using System.Collections.Generic;

namespace VectorDemo
{
    class Program
    {
        static void Main()
        {
            double[] array = { 1, 2, 3 };
            List<double> list = new List<double> { 4, 5, 6 };

            IMathVector vectorFromArray = new MathVector(array);
            IMathVector vectorFromList = new MathVector(list);
            IMathVector vectorFromVector = new MathVector(vectorFromArray);

            Console.WriteLine($"Vector from array: {vectorFromArray}");
            Console.WriteLine($"Vector from list: {vectorFromList}");
            Console.WriteLine($"Vector from vector: {vectorFromVector}");
        }
    }
}