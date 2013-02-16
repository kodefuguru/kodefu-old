namespace Kodefu.Math
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using FluentAssertions;

    public class MovingAverageTests
    {
        private IEnumerable<float> values = new[] { 11f, 12, 13, 14, 15, 16, 17 };
        private IEnumerable<float> expectedSimpleResult = new[] { 11, 11.5f, 12, 13, 14, 15, 16 };
        private IEnumerable<float> expectedRollingResult = new[] { 13, 14, 15, 15.5f, 16, 16.5f, 17 };

        [Fact]
        public void SimpleAverageShouldMatchExpected()
        {
            var result = values.MovingAverage().Simple(5);
            result.Should().ContainInOrder(expectedSimpleResult);
        }

        [Fact]
        public void RollingAverageShouldMatchExpected()
        {
            var result = values.MovingAverage().Rolling(5);
            result.Should().ContainInOrder(expectedRollingResult);
        }
    }
}
