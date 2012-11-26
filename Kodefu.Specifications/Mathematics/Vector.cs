namespace Kodefu.Mathematics
{
    using System;
    using Machine.Specifications;

    public class With_Vector_Created_From_Factory
    {
        protected static Vector2 vector;
        protected static float x = 1;
        protected static float y = 2;

        Establish that = () => vector = Vector.CreateF(x, y);

        It should_have_X_property_equal_x_variable = () => vector.X.Equals(x);
        It should_have_Y_property_equal_y_variable = () => vector.Y.Equals(y);
    }

    public class When_Vector_Is_Assigned_From_Tuple : With_Vector_Created_From_Factory
    {
        protected static Tuple<float, float> tuple = new Tuple<float,float>(5, 6);

        Because of = () =>
            {
                vector = tuple;
            };

        It should_be_type_Vector2 = () => vector.ShouldBeOfType<Vector2>();
        It should_have_X_property_equal_tuple_item1 = () => vector.X.ShouldEqual(tuple.Item1);
        It should_have_Y_property_equal_tuple_item2 = () => vector.Y.ShouldEqual(tuple.Item2);
    }

    public class When_Vector_Is_Multiplied_By_Scale : With_Vector_Created_From_Factory
    {
        protected static float scale = 0.5f;
        protected static Vector2 result;
        Because of = () =>
        {
            result = scale * vector;
        };

        It should_have_X_property_equal_vector_X_times_scale = () => result.X.ShouldEqual(vector.X * scale);
        It should_have_Y_property_equal_vector_Y_time_scale = () => result.Y.ShouldEqual(vector.Y * scale);
    }

    public class With_Generic_Vector_Created_From_Factory
    {
        protected static Vector<float, float> vector;
        protected static float x = 1;
        protected static float y = 2;

        Establish that = () => vector = Vector.Create(x, y);

        It should_have_X_property_equal_x_variable = () => vector.X.Equals(x);
        It should_have_Y_property_equal_y_variable = () => vector.Y.Equals(y);
    }

    public class When_Generic_Vector_Is_Added_To_Vector2 : With_Generic_Vector_Created_From_Factory
    {
        protected static float vector2x;
        protected static float vector2y;
        protected static Vector2 vector2;
        protected static Vector2 result;

        Because of = () =>
        {
            vector2 = new Vector2(vector2x = 3, vector2y = 4);
            result = vector + vector2;
        };

        It should_have_X_property_equal_vector_X_plus_vector2_X = () => result.X.Equals(vector.X + vector2.X);
        It should_have_Y_property_equal_vector_Y_plus_vector2_Y = () => result.Y.Equals(vector.Y + vector2.Y);
    }

    public class When_Generic_Vector_Is_Compared_To_Equal_Vector2 : With_Generic_Vector_Created_From_Factory
    {
        protected static Vector2 vector2;
        protected static bool resultEquals;
        protected static bool resultNotEquals;


        Because of = () =>
        {
            vector2 = vector;
            resultEquals = vector == vector2;
            resultNotEquals = vector != vector2;
        };

        It should_set_resultEquals_to_true = () => resultEquals.ShouldBeTrue();
        It should_set_resultNotEquals_to_false = () => resultNotEquals.ShouldBeFalse();
    }
}
