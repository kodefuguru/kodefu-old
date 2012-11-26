namespace Kodefu
{
    using System;
    using System.Linq;
    using Xunit;
    using FluentAssertions;

    public class LinqToFunctionsSamples
    {
        [Fact]
        public void Create_Hypotenuse_Function()
        {
            Func<int, int> square = x => x * x;

            var hypotenuse = from h in square
                             from w in square
                             select Math.Sqrt(h + w);

            hypotenuse.Should().BeOfType<Func<int, int, double>>()
                      .And.Should().NotBeNull();

            hypotenuse(3, 4).Should().BeInRange(5, 5);
        }
    }
}
