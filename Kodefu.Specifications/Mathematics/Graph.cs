namespace Kodefu.Mathematics
{
    using System;
    using System.Linq;
    using Machine.Specifications;
    
    public class With_Graph_Created_From_Factory
    {
        protected static Graph<int> graph;
        Establish that = () => graph = Graph.Create(new[] { 1, 2, 3, }, new[,]{ { 1, 2 }, { 1, 3 }, { 2, 3 } });

        It should_have_three_nodes = () => graph.Nodes.Count().ShouldEqual(3);
    }

    public class When_Graph_Is_Selected_With_Increment_By_One : With_Graph_Created_From_Factory
    {
        protected static Graph<int> result;
        Because of = () => result = graph.Select(n => n + 1);

        It should_contain_values = () => result.Vertices.ShouldContain(2, 3, 4);
        It should_have_three_vertices = () => result.Vertices.Count().ShouldEqual(3);
    }

    public class When_Graph_Is_Combined_With_Other_Using_SelectMany_And_Adding_Vertices: With_Graph_Created_From_Factory
    {
        protected static Graph<int> result;
        Because of = () => result = graph.SelectMany(Graph.Create(new[] {1, 2}, new[,]{{1,2}}), (left, right) => left + right);

        It should_contain_values = () => result.Vertices.ShouldContain(2, 3, 4, 5);
        It should_have_four_vertices = () => result.Vertices.Count().ShouldEqual(4);
        It should_have_six_edges = () => result.Edges.Count().ShouldEqual(6);
    }
}
