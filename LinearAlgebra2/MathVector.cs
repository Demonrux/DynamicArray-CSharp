using System.Collections;

namespace LinearAlgebra
{
    public class MathVector : IMathVector
    {
        private double[] arr;

        public MathVector(IEnumerable<double> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            arr = data.ToArray();
        }
        public IEnumerator<double> GetEnumerator()
        {
            return ((IEnumerable<double>)arr).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return arr.GetEnumerator();
        }

        public int Dimensions
        {
            get { return arr.Length; }
        }

        public double this[int i]
        {
            get
            {
                if (i < 0 || i >= Dimensions)
                    throw new ArgumentOutOfRangeException(nameof(i));
                return arr[i];
            }
            set
            {
                if ((i < 0) || (i >= Dimensions))
                    throw new ArgumentOutOfRangeException(nameof(i));
                arr[i] = value;
            }
        }

        public double Length
        {
            get
            {
                double sumSquare = 0;
                foreach (var item in arr)
                {
                    sumSquare += item * item;
                }
                return Math.Sqrt(sumSquare);
            }
        }

        public IMathVector SumNumber(double number)
        {
            var result = new MathVector(new double[Dimensions]);
            for (int i = 0; i < Dimensions; ++i)
            {
                result[i] = this[i] + number;
            }
            return result;
        }

        public IMathVector MultiplyNumber(double number)
        {
            var result = new MathVector(new double[Dimensions]);
            for (int i = 0; i < Dimensions; ++i)
            {
                result[i] = this[i] * number;
            }
            return result;
        }

        public IMathVector Sum(IMathVector vector)
        {
            if (vector.Dimensions != Dimensions)
                throw new ArgumentException("Vectors must have the same dimensions");

            var result = new MathVector(new double[Dimensions]);
            for (int i = 0; i < Dimensions; ++i)
            {
                result[i] = this[i] + vector[i];
            }
            return result;
        }

        public IMathVector Multiply(IMathVector vector)
        {
            if (vector.Dimensions != Dimensions)
                throw new ArgumentException("Vectors must have the same dimensions");

            var result = new MathVector(new double[Dimensions]);
            for (int i = 0; i < Dimensions; ++i)
            {
                result[i] = this[i] * vector[i];
            }
            return result;
        }

        public double ScalarMultiply(IMathVector vector)
        {
            if (vector.Dimensions != Dimensions)
                throw new ArgumentException("Vectors must have the same dimensions");

            double result = 0;
            for (int i = 0; i < Dimensions; ++i)
            {
                result += this[i] * vector[i];
            }
            return result;
        }

        public double CalcDistance(IMathVector vector)
        {
            if (vector.Dimensions != Dimensions)
                throw new ArgumentException("Vectors must have the same dimensions");

            double distance = 0;
            for (int i = 0; i < Dimensions; ++i)
            {
                distance += (this[i] - vector[i]) * (this[i] - vector[i]);
            }
            return Math.Sqrt(distance);
        }

        public static MathVector operator +(MathVector vector1, MathVector vector2)
        {
            if (vector1.Dimensions != vector2.Dimensions)
                throw new ArgumentException("Vectors must have the same dimensions");

            return (MathVector)vector1.Sum(vector2);
        }

        public static MathVector operator +(MathVector vector, double number)
        {
            return (MathVector)vector.SumNumber(number);
        }

        public static MathVector operator -(MathVector vector1, MathVector vector2)
        {
            if (vector1.Dimensions != vector2.Dimensions)
                throw new ArgumentException("Vectors must have the same dimensions");

            var result = new MathVector(new double[vector1.Dimensions]);
            for (int i = 0; i < vector1.Dimensions; ++i)
                result[i] = vector1[i] - vector2[i];
            return result;
        }

        public static MathVector operator -(MathVector vector, double number)
        {
            return (MathVector)vector.SumNumber(-number);
        }

        public static MathVector operator *(MathVector vector1, MathVector vector2)
        {
            if (vector1.Dimensions != vector2.Dimensions)
                throw new ArgumentException("Vectors must have the same dimensions");

            return (MathVector)vector1.Multiply(vector2);
        }

        public static MathVector operator *(MathVector vector, double number)
        {
            return (MathVector)vector.MultiplyNumber(number);
        }

        public static MathVector operator /(MathVector vector1, MathVector vector2)
        {
            if (vector1.Dimensions != vector2.Dimensions)
                throw new ArgumentException("Vectors must have the same dimensions");

            var result = new MathVector(new double[vector1.Dimensions]);
            for (int i = 0; i < vector1.Dimensions; ++i)
            {
                if (vector2[i] == 0)
                    throw new DivideByZeroException();
                result[i] = vector1[i] / vector2[i];
            }
            return result;
        }

        public static MathVector operator /(MathVector vector, double number)
        {
            if (number == 0)
                throw new DivideByZeroException();
            return (MathVector)vector.MultiplyNumber(1.0 / number);
        }

        public override string ToString()
        {
            return $"({string.Join(", ", arr)})";
        }
    }
}