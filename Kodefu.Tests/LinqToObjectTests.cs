namespace Kodefu.Tests
{
    using System;
    using System.Linq;
    using Xunit;
    using FluentAssertions;
    
    public class LinqToObjectTests
    {
        [Fact]
        public void When_One_From()
        {
            var x = 0;

            var result = from a in x
                         select a + 1;
            
            var expected = x + 1;
            result.Should().Be(expected);
        }

        [Fact]
        public void When_Two_From()
        {
            var x = 0;
            var y = 1;

            var result = from a in x
                         from b in y
                         select a + b;

            var expected = x + y;
            result.Should().Be(expected);
        }

        [Fact]
        public void When_Where_Is_False()
        {
            var x = 0;

            var result = from a in x
                         where a != 0
                         select a;

            result.HasValue.Should().BeFalse();
        }

        [Fact]
        public void When_Where_Is_True()
        {
            var x = 1;

            var result = from a in x
                         where a != 0
                         select a;

            result.Should().BeOfType<Maybe<int>>();
            result.HasValue.Should().BeTrue();
        }

        [Fact]
        public void When_From_Two_Values_And_Where_Is_False()
        {
            var x = 1;
            var y = 0;

            var result = from a in x
                         from b in y
                         where b != 0
                         select a / b;

            result.Should().BeOfType<Maybe<int>>();
            result.HasValue.Should().BeFalse();
        }

        [Fact]
        public void When_Two_Where_And_First_Is_False()
        {
            var x = 1;

            var result = from a in x
                         where a != 1
                         where a != 2
                         select a;

            result.Should().BeOfType<Maybe<int>>();
            result.HasValue.Should().BeFalse();
        }

        [Fact]
        public void When_Two_Where_And_Second_Is_False()
        {
            var x = 2;

            var result = from a in x
                         where a != 1
                         where a != 2
                         select a;

            result.Should().BeOfType<Maybe<int>>();
            result.HasValue.Should().BeFalse();
        }

        [Fact]
        public void When_Two_Where_And_Both_Are_True()
        {
            var x = 0;

            var result = from a in x
                         where a != 1
                         where a != 2
                         select a;

            result.Should().BeOfType<Maybe<int>>();
            result.HasValue.Should().BeTrue();
        }
    }
}
