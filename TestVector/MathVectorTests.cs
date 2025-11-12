using LinearAlgebra;

namespace TestVector
{
    public class MathVectorTests
    {
        [Fact]
        public void ConstructorTests()
        {
            double[] array = { 1, 2, 3 };

            var vectorWithArray = new MathVector(array);

            Assert.Equal(3, vectorWithArray.Dimensions);
            Assert.Equal(1, vectorWithArray[0]);
            Assert.Equal(2, vectorWithArray[1]);
            Assert.Equal(3, vectorWithArray[2]);

            var list = new List<double> { 4, 5, 6 };

            var vectorWithList = new MathVector(list);

            Assert.Equal(3, vectorWithList.Dimensions);
            Assert.Equal(4, vectorWithList[0]);
            Assert.Equal(5, vectorWithList[1]);
            Assert.Equal(6, vectorWithList[2]);

            var vectorCopy = new MathVector(vectorWithList);

            Assert.Equal(vectorCopy.Dimensions, vectorWithList.Dimensions);
            Assert.Equal(vectorCopy[0], vectorWithList[0]);
            Assert.Equal(vectorCopy[1], vectorWithList[1]);
            Assert.Equal(vectorCopy[2], vectorWithList[2]);

            Assert.Throws<ArgumentNullException>(() => new MathVector((IEnumerable<double>)null));

            var emptyVector = new MathVector(new List<double>());

            Assert.Equal(0, emptyVector.Dimensions);
        }

        [Fact]
        public void PropertyTests()
        {
            var vector = new MathVector(new List<double> { 3, 4 });

            Assert.Equal(2, vector.Dimensions);

            Assert.Equal(5.0, vector.Length); 

            Assert.Equal(3, vector[0]);
            Assert.Equal(4, vector[1]);
        }

        [Fact]
        public void IndexerOutOfRangeTests()
        {
            var vector = new MathVector(new List<double> { 1, 2, 3 });

            Assert.Throws<ArgumentOutOfRangeException>(() => vector[-1]);
            Assert.Throws<ArgumentOutOfRangeException>(() => vector[3]);
        }

        [Fact]
        public void SumNumberTests()
        {
            var vector = new MathVector(new List<double> { 1, 2, 3 });
            var result = vector.SumNumber(2);

            Assert.Equal(3, result[0]);
            Assert.Equal(4, result[1]);
            Assert.Equal(5, result[2]);

            Assert.Equal(1, vector[0]);
            Assert.Equal(2, vector[1]);
            Assert.Equal(3, vector[2]);
        }

        [Fact]
        public void MultiplyNumberTests()
        {
            var vector = new MathVector(new List<double> { 1, 2, 3 });
            var result = vector.MultiplyNumber(3);

            Assert.Equal(3, result[0]);
            Assert.Equal(6, result[1]);
            Assert.Equal(9, result[2]);
        }

        [Fact]
        public void SumVectorsTests()
        {
            var vector1 = new MathVector(new List<double> { 1, 2, 3 });
            var vector2 = new MathVector(new List<double> { 4, 5, 6 });
            var result = vector1.Sum(vector2);

            Assert.Equal(5, result[0]);
            Assert.Equal(7, result[1]);
            Assert.Equal(9, result[2]);
        }

        [Fact]
        public void MultiplyVectorsTests()
        {
            var vector1 = new MathVector(new List<double> { 1, 2, 3 });
            var vector2 = new MathVector(new List<double> { 4, 5, 6 });
            var result = vector1.Multiply(vector2);

            Assert.Equal(4, result[0]);
            Assert.Equal(10, result[1]);
            Assert.Equal(18, result[2]);
        }

        [Fact]
        public void ScalarMultiplyTests()
        {
            var vector1 = new MathVector(new List<double> { 1, 2, 3 });
            var vector2 = new MathVector(new List<double> { 4, 5, 6 });
            var result = vector1.ScalarMultiply(vector2);

            Assert.Equal(32, result);  // 1*4 + 2*5 + 3*6 = 4 + 10 + 18 = 32
        }

        [Fact]
        public void CalcDistanceTests()
        {
            var vector1 = new MathVector(new List<double> { 1, 2, 3 });
            var vector2 = new MathVector(new List<double> { 4, 5, 6 });
            var distance = vector1.CalcDistance(vector2);

            var result = Math.Sqrt(27);// sqrt((4-1)**2 + (6-2)**2 + (8-3)**2) = sqrt(9 + 9 + 9) = sqrt(27)

            Assert.Equal(result, distance); 
        }

        [Fact]
        public void DifferentDimensionsTests()
        {
            var vector1 = new MathVector(new List<double> { 1, 2, 3 });
            var vector2 = new MathVector(new List<double> { 4, 5 });

            Assert.Throws<ArgumentException>(() => vector1.Sum(vector2));
            Assert.Throws<ArgumentException>(() => vector1.Multiply(vector2));
            Assert.Throws<ArgumentException>(() => vector1.ScalarMultiply(vector2));
            Assert.Throws<ArgumentException>(() => vector1.CalcDistance(vector2));
        }

        [Fact]
        public void OperatorPlusVectorTests()
        {
            var vector1 = new MathVector(new List<double> { 1, 2, 3 });
            var vector2 = new MathVector(new List<double> { 4, 5, 6 });
            var result = vector1 + vector2;

            Assert.Equal(5, result[0]);
            Assert.Equal(7, result[1]);
            Assert.Equal(9, result[2]);
        }

        [Fact]
        public void OperatorPlusScalarTests()
        {
            var vector = new MathVector(new List<double> { 1, 2, 3 });
            var result = vector + 2;

            Assert.Equal(3, result[0]);
            Assert.Equal(4, result[1]);
            Assert.Equal(5, result[2]);
        }

        [Fact]
        public void OperatorMinusVectorTests()
        {
            var vector1 = new MathVector(new List<double> { 1, 2, 3 });
            var vector2 = new MathVector(new List<double> { 4, 5, 6 });
            var result = vector1 - vector2;

            Assert.Equal(-3, result[0]);
            Assert.Equal(-3, result[1]);
            Assert.Equal(-3, result[2]);
        }

        [Fact]
        public void OperatorMinusScalarTests()
        {
            var vector = new MathVector(new List<double> { 1, 2, 3 });
            var result = vector - 2;

            Assert.Equal(-1, result[0]);
            Assert.Equal(0, result[1]);
            Assert.Equal(1, result[2]);
        }

        [Fact]
        public void OperatorMultiplyVectorTests()
        {
            var vector1 = new MathVector(new List<double> { 1, 2, 3 });
            var vector2 = new MathVector(new List<double> { 4, 5, 6 });
            var result = vector1 * vector2;

            Assert.Equal(4, result[0]);
            Assert.Equal(10, result[1]);
            Assert.Equal(18, result[2]);
        }

        [Fact]
        public void OperatorMultiplyScalarTests()
        {
            var vector = new MathVector(new List<double> { 1, 2, 3 });
            var result = vector * 3;

            Assert.Equal(3, result[0]);
            Assert.Equal(6, result[1]);
            Assert.Equal(9, result[2]);
        }

        [Fact]
        public void OperatorDivideVectorTests()
        {
            var vector1 = new MathVector(new List<double> { 4, 6, 10 });
            var vector2 = new MathVector(new List<double> { 1, 2, 5 });
            var result = vector1 / vector2;

            Assert.Equal(4, result[0]);
            Assert.Equal(3, result[1]);
            Assert.Equal(2, result[2]);
        }

        [Fact]
        public void OperatorDivideScalarTests()
        {
            var vector = new MathVector(new List<double> { 6, 8, 10 });
            var result = vector / 2;

            Assert.Equal(3, result[0]);
            Assert.Equal(4, result[1]);
            Assert.Equal(5, result[2]);
        }

        [Fact]
        public void OperatorDivideByZeroTests()
        {
            var vector1 = new MathVector(new List<double> { 1, 2 });
            var vector2 = new MathVector(new List<double> { 0, 4 });

            Assert.Throws<DivideByZeroException>(() => vector1 / vector2);
            Assert.Throws<DivideByZeroException>(() => vector1 / 0);
        }

        [Fact]
        public void OperatorDifferentDimensionsTests()
        {
            var vector1 = new MathVector(new List<double> { 1, 2, 3 });
            var vector2 = new MathVector(new List<double> { 4, 5 });

            Assert.Throws<ArgumentException>(() => vector1 + vector2);
            Assert.Throws<ArgumentException>(() => vector1 - vector2);
            Assert.Throws<ArgumentException>(() => vector1 * vector2);
            Assert.Throws<ArgumentException>(() => vector1 / vector2);
        }

        [Fact]
        public void ToStringTest()
        {
            var vector = new MathVector(new List<double> { 1, 2, 3 });

            Assert.Equal("(1, 2, 3)", vector.ToString());
        }

        [Fact]
        public void EnumeratorTest()
        {
            var vector = new MathVector(new List<double> { 1, 2, 3 });
            var list = new List<double>();

            foreach (var item in vector)
            {
                list.Add(item);
            }

            Assert.Equal(3, list.Count);
            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);
            Assert.Equal(3, list[2]);
        }
    }
}