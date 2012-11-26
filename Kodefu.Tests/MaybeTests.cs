namespace Kodefu
{
    using System;
    using System.Linq;
    using Xunit;
    using FluentAssertions;

    public class MaybeTests
    {
        [Fact]
        public void When_Coalescing_Empty_Maybe()
        {
            var result = Maybe.Create<int>().Coalesce();

            result.Should().Be(default(int));
        }

        [Fact]
        public void When_Coalescing_Empty_Maybe_With_Factory()
        {
            var value = 1;
            var result = Maybe.Create<int>().Coalesce(() => value);

            result.Should().Be(value);
        }

        [Fact]
        public void When_Coalescing_Empty_Maybe_With_Value()
        {
            var value = 1;
            var result = Maybe.Create<int>().Coalesce(value);

            result.Should().Be(value);
        }

        [Fact]
        public void When_Coalescing_Just_Maybe()
        {
            var value = 1;
            var result = Maybe.Create(value).Coalesce();

            result.Should().Be(value);
        }

        [Fact]
        public void When_Coalescing_Just_Maybe_From_Thunk()
        {
            var value = 1;
            var result = Maybe.Create(() => value).Coalesce();

            result.Should().Be(value);
        }

        [Fact]
        public void When_Select_To_Another_Type_With_Just_Maybe()
        {
            var value = 1;
            var expectedValue = "1";
            var resultMaybe = Maybe.Create(value).Select(i => i.ToString());

            resultMaybe.Should().BeOfType<Maybe<string>>();            
            resultMaybe.HasValue.Should().BeTrue();
            
            var resultValue = resultMaybe.Coalesce();
            resultValue.Should().NotBeNull().And.NotBeEmpty().And.Be(expectedValue);
        }

        [Fact]
        public void When_Just_Maybe_Or_Just_Maybe()
        {
            var left = Maybe.Create(1);
            var right = Maybe.Create(2);
            var expectedValue = 3;

            var resultMaybe = left.Or(right, (a, b) => a + b);
            
            resultMaybe.Should().BeOfType<Maybe<int>>();
            resultMaybe.HasValue.Should().BeTrue();

            var resultValue = resultMaybe.Coalesce();
            resultValue.Should().Be(expectedValue);
        }

        [Fact]
        public void When_Just_Maybe_Or_Empty_Maybe()
        {
            var left = Maybe.Create(1);
            var right = Maybe.Create<int>();
            var expectedValue = 1;

            var resultMaybe = left.Or(right, (a, b) => a + b);

            resultMaybe.Should().BeOfType<Maybe<int>>();
            resultMaybe.HasValue.Should().BeTrue();

            var resultValue = resultMaybe.Coalesce();
            resultValue.Should().Be(expectedValue);
        }

        [Fact]
        public void When_Empty_Maybe_Or_Just_Maybe()
        {
            var left = Maybe.Create<int>();
            var right = Maybe.Create(1);
            var expectedValue = 1;

            var resultMaybe = left.Or(right, (a, b) => a + b);

            resultMaybe.Should().BeOfType<Maybe<int>>();
            resultMaybe.HasValue.Should().BeTrue();

            var resultValue = resultMaybe.Coalesce();
            resultValue.Should().Be(expectedValue);
        }

        [Fact]
        public void When_Empty_Maybe_Or_Empty_Maybe()
        {
            var left = Maybe.Create<int>();
            var right = Maybe.Create<int>();
            var expectedValue = default(int);

            var resultMaybe = left.Or(right, (a, b) => 5);

            resultMaybe.Should().BeOfType<Maybe<int>>();
            resultMaybe.HasValue.Should().BeFalse();

            var resultValue = resultMaybe.Coalesce();
            resultValue.Should().Be(expectedValue);
        }

        [Fact]
        public void When_Just_Maybe_And_Just_Maybe()
        {
            var left = Maybe.Create(1);
            var right = Maybe.Create(2);
            var expectedValue = 3;

            var resultMaybe = left.And(right, (a, b) => a + b);

            resultMaybe.Should().BeOfType<Maybe<int>>();
            resultMaybe.HasValue.Should().BeTrue();

            var resultValue = resultMaybe.Coalesce();
            resultValue.Should().Be(expectedValue);
        }

        [Fact]
        public void When_Just_Maybe_And_Empty_Maybe()
        {
            var left = Maybe.Create(1);
            var right = Maybe.Create<int>();
            var expectedValue = default(int);

            var resultMaybe = left.And(right, (a, b) => a + b);

            resultMaybe.Should().BeOfType<Maybe<int>>();
            resultMaybe.HasValue.Should().BeFalse();

            var resultValue = resultMaybe.Coalesce();
            resultValue.Should().Be(expectedValue);
        }

        [Fact]
        public void When_Empty_Maybe_And_Just_Maybe()
        {
            var left = Maybe.Create<int>();
            var right = Maybe.Create(1);
            var expectedValue = default(int);

            var resultMaybe = left.And(right, (a, b) => a + b);

            resultMaybe.Should().BeOfType<Maybe<int>>();
            resultMaybe.HasValue.Should().BeFalse();

            var resultValue = resultMaybe.Coalesce();
            resultValue.Should().Be(expectedValue);
        }

        [Fact]
        public void When_Empty_Maybe_And_Empty_Maybe()
        {
            var left = Maybe.Create<int>();
            var right = Maybe.Create<int>();
            var expectedValue = default(int);

            var resultMaybe = left.And(right, (a, b) => 5);

            resultMaybe.Should().BeOfType<Maybe<int>>();
            resultMaybe.HasValue.Should().BeFalse();

            var resultValue = resultMaybe.Coalesce();
            resultValue.Should().Be(expectedValue);
        }

        public void When_Do_Called_On_Just_Maybe_Side_Effects_Occurs_After_Coalesce()
        {
            var i = 1;
            var expected = 0;
            var result = 0;

            var maybe = Maybe.Create(i)
                             .Do(a => result = a);

            result.Should().Be(expected);

            maybe.Coalesce();

            result.Should().Be(i);
        }

        public void When_Run_Called_On_Just_Maybe_Side_Effects_Occur_Immediately()
        {
            var i = 1;
            var expected = 1;
            var result = 0;

            Maybe.Create(i)
                 .Run(a => result = a);

            result.Should().Be(expected);
        }

        public void When_Do_Called_On_Empty_Maybe_Side_Effects_Dont_Occur()
        {
            var expected = 0;
            var result = 0;

            var maybe = Maybe.Create<int>()
                             .Do(a => result = a);

            result.Should().Be(expected);

            maybe.Coalesce();

            result.Should().Be(expected);
        }

        public void When_Run_Called_On_Empty_Maybe_Side_Effects_Dont_Occur()
        {
            var notExpected = -1;
            var expected = 0;
            var result = 0;

            Maybe.Create<int>()
                 .Run(a => result = notExpected);

            result.Should().Be(expected);
        }
    }
}
