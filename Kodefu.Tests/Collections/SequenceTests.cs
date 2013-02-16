namespace Kodefu.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using FluentAssertions;
    
    public class SequenceTests
    {
        [Fact]
        public void When_IEnumerable_Is_Materialized()
        {
            var seq = new[] { 1, 2, 3 };
            var result = seq.Materialize();

            result.Should().NotBeNull().And.NotBeEmpty().And.BeAssignableTo<IEnumerable<int>>();
        }

        [Fact]
        public void Conversions()
        {
            Sequence<int> seq = new[] { 1, 2, 3 };
        }

        [Fact]
        public void Operators()
        {
            var expected = new[] { 1, 2, 3, 4, 5 };

            Sequence<int> seq = new[] { 1, 2, 3 };
            var result  = seq + new[] { 4, 5 };
            result.Should().ContainInOrder(expected);

            expected = new[] { -1, 0, 1, 2, 3 };
            result =  new[] { -1, 0 } + seq;
            result.Should().ContainInOrder(expected);

            expected = new[] { 1, 2, 3, 4 };
            result = seq + 4;
            result.Should().ContainInOrder(expected);

            expected = new[] { 0, 1, 2, 3 };
            result = 0 + seq;
            result.Should().ContainInOrder(expected);

            var expectedTuples = new[] { Tuple.Create(1, 1), Tuple.Create(1, 2), Tuple.Create(2, 1), Tuple.Create(2, 2), Tuple.Create(3, 1), Tuple.Create(3, 2) };
            var resultTuples = seq * new[] { 1, 2 };
            resultTuples.Should().ContainInOrder(expectedTuples);
            
            expected = new[] { 1, 2, 3, 1, 2 };
            resultTuples.Cast<int>().Should().ContainInOrder(expected);

            seq = new[] { 1, 2 };
            int[] arr = new[] { 8, 9 };
            int num = 5;

            var seqSeq = seq + seq;
            var seqNum = seq + num;
            var numSeq = num + seq;
            var seqArr = seq + arr;
            var arrSeq = arr + seq;

            seqSeq.Should().BeOfType<Sequence<int>>();
            seqNum.Should().BeOfType<Sequence<int>>();
            numSeq.Should().BeOfType<Sequence<int>>();
            seqArr.Should().BeOfType<Sequence<int>>();
            arrSeq.Should().BeOfType<Sequence<int>>();

            seqSeq.Should().ContainInOrder(1, 2, 1, 2);
            seqNum.Should().ContainInOrder(1, 2, 5);
            numSeq.Should().ContainInOrder(5, 1, 2);
            seqArr.Should().ContainInOrder(1, 2, 8, 9);
            arrSeq.Should().ContainInOrder(8, 9, 1, 2);
        }
    }
}
