namespace Kodefu.Mathematics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Machine.Specifications;

    public class With_Degree
    {
        protected static Degree degree;

        Establish that = () => degree = 200;
    }

    public class When_ArcDegree_Is_Converted_To_Radian : With_Degree
    {
        protected static readonly Radian expected = 3.49f;
        protected static Radian result;

        Because of = () => result = degree;

        It should_be_expected_value = () => ((float)result).ShouldBeCloseTo(expected, 0.001f);
    }
}
