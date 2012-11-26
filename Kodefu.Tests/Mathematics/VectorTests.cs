namespace Kodefu.Mathematics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using FluentAssertions;
    
    public class VectorTests
    {
        [Fact]
        public void When_Vector_Is_Created_With_Floats()
        {
            Vector.CreateF(1.0f, 2.0f)
                  .Should().BeOfType<Vector2>();
        }

        [Fact]
        public void When_Vector_Is_Created_With_Ints()
        {
            Vector.CreateF(1, 2)
                  .Should().BeOfType<Vector2>();
        }

        [Fact]
        public void When_Vector2F_Is_Added()
        {
            var vector = Vector.CreateF(1.0f, 2.0f);
            var result = vector + vector;
            result.X.Should().BeInRange(2.0f, 2.0f);
            result.Y.Should().BeInRange(4.0f, 4.0f);
        }

        [Fact]
        public void When_Tuple_Is_Assigned_To_Vector2F()
        {
            var tuple = Tuple.Create(1.0f, 2.0f);
            Vector2 result = tuple;
            result.X.Should().BeInRange(tuple.Item1, tuple.Item1);
            result.Y.Should().BeInRange(tuple.Item2, tuple.Item2);
        }
    }
}
