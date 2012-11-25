namespace Kodefu.Tests
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
    }
}
