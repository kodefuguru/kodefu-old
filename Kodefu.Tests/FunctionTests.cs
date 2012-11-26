namespace Kodefu
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class FunctionTests
    {
        private readonly Func<int, int> inc;
        private readonly Func<int, int, int> add2;
        private readonly Func<int, int, int, int> add3;
        private readonly Func<int, int, int, int, int> add4;

        public FunctionTests()
        {
            this.inc = a => a + 1;
            this.add2 = (a, b) => a + b;
            this.add3 = (a, b, c) => a + b + c;
            this.add4 = (a, b, c, d) => a + b + c + d;            
        }

        [Fact]
        public void When_One_Arity_Function_Is_Applied()
        {
            var result = this.inc.Apply(0);

            result.Should()
                  .BeOfType<Func<int>>()
                  .And
                  .Should()
                  .NotBeNull();
        }

        [Fact]
        public void When_Two_Arity_Function_Is_Applied_One()
        {
            var result = this.add2.Apply(0);

            result.Should()
                  .BeOfType<Func<int, int>>()
                  .And
                  .Should()
                  .NotBeNull();
        }

        [Fact]
        public void When_Two_Arity_Function_Is_Applied_Two()
        {
            var result = this.add2.Apply(0, 0);

            result.Should()
                  .BeOfType<Func<int>>()
                  .And
                  .Should()
                  .NotBeNull();
        }

        [Fact]
        public void When_Three_Arity_Function_Is_Applied_One()
        {
            var result = this.add3.Apply(0);

            result.Should()
                  .BeOfType<Func<int, int, int>>()
                  .And
                  .Should()
                  .NotBeNull();
        }

        [Fact]
        public void When_Three_Arity_Function_Is_Applied_Two()
        {
            var result = this.add3.Apply(0, 0);

            result.Should()
                  .BeOfType<Func<int, int>>()
                  .And
                  .Should()
                  .NotBeNull();
        }

        [Fact]
        public void When_Three_Arity_Function_Is_Applied_Three()
        {
            var result = this.add3.Apply(0, 0, 0);

            result.Should()
                  .BeOfType<Func<int>>()
                  .And
                  .Should()
                  .NotBeNull();
        }

        [Fact]
        public void When_Four_Arity_Function_Is_Applied_One()
        {
            var result = this.add4.Apply(0);

            result.Should()
                  .BeOfType<Func<int, int, int, int>>()
                  .And
                  .Should()
                  .NotBeNull();
        }

        [Fact]
        public void When_Four_Arity_Function_Is_Applied_Two()
        {
            var result = this.add4.Apply(0, 0);

            result.Should()
                  .BeOfType<Func<int, int, int>>()
                  .And
                  .Should()
                  .NotBeNull();
        }

        [Fact]
        public void When_Four_Arity_Function_Is_Applied_Three()
        {
            var result = this.add4.Apply(0, 0, 0);

            result.Should()
                  .BeOfType<Func<int, int>>()
                  .And
                  .Should()
                  .NotBeNull();
        }

        [Fact]
        public void When_Four_Arity_Function_Is_Applied_Four()
        {
            var result = this.add4.Apply(0, 0, 0, 0);

            result.Should()
                  .BeOfType<Func<int>>()
                  .And
                  .Should()
                  .NotBeNull();
        }

        [Fact]
        public void When_Two_Arity_Function_Is_Curried()
        {
            var result = this.add2.Curry();

            result.Should()
                  .BeOfType<Func<int, Func<int, int>>>()
                  .And
                  .Should()
                  .NotBeNull();
        }

        [Fact]
        public void When_Three_Arity_Function_Is_Curried()
        {
            var result = this.add3.Curry();

            result.Should()
                  .BeOfType<Func<int, Func<int, Func<int, int>>>>()
                  .And
                  .Should()
                  .NotBeNull();
        }

        [Fact]
        public void When_Four_Arity_Function_Is_Curried()
        {
            var result = this.add4.Curry();

            result.Should()
                  .BeOfType<Func<int, Func<int, Func<int, Func<int, int>>>>>()
                  .And
                  .Should()
                  .NotBeNull();
        }

        [Fact]
        public void When_Two_Arity_Function_Is_Uncurried()
        {
            var result = this.add2.Curry().Uncurry();

            result.Should()
                  .BeOfType<Func<int, int, int>>()
                  .And
                  .Should()
                  .NotBeNull();
        }

        [Fact]
        public void When_Three_Arity_Function_Is_Uncurried()
        {
            var result = this.add3.Curry().Uncurry();

            result.Should()
                  .BeOfType<Func<int, int, int, int>>()
                  .And
                  .Should()
                  .NotBeNull();
        }

        [Fact]
        public void When_Four_Arity_Function_Is_Uncurried()
        {
            var result = this.add4.Curry().Uncurry();

            result.Should()
                  .BeOfType<Func<int, int, int, int, int>>()
                  .And
                  .Should()
                  .NotBeNull();
        }
    }
}