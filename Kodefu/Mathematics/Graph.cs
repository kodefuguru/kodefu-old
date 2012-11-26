namespace Kodefu.Mathematics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class Graph
    {
        public static Graph<T> Create<T>(IEnumerable<T> nodes, IEnumerable<KeyValuePair<T, T>> edges)
        {
            return new Graph<T>(nodes, edges);
        }

        public static Graph<T> Create<T>(IEnumerable<T> nodes, T[,] edges)
        {
            return new Graph<T>(nodes, edges);
        }
    }

    public class Graph<T>
    {
        private readonly List<T> vertices = new List<T>();
        private readonly List<Edge> edges = new List<Edge>();
        private readonly Lazy<IEnumerable<Node>> nodes;

        public IEnumerable<Node> Nodes
        {
            get
            {
                return nodes.Value;
            }
        }
        public IEnumerable<T> Vertices
        {
            get
            {
                return this.vertices;
            }
        }

        public IEnumerable<Edge> Edges
        {
            get
            {
                return this.edges;
            }
        }

        private Graph()
        {
            nodes = new Lazy<IEnumerable<Node>>(() => this.vertices.Select(v => new Node(this, v))); 
        }

        internal Graph(IEnumerable<T> nodes, IEnumerable<KeyValuePair<T, T>> edges) : this()
        {
            CreateVertices(nodes);
            this.edges.AddRange(edges.Select(pair => new Edge(this, this.vertices.Single(n => n.Equals(pair.Key)), this.vertices.Single(n => n.Equals(pair.Value)))));
        }

        internal Graph(IEnumerable<T> nodes, IEnumerable<IEnumerable<T>> edges) : this()
        {
            CreateVertices(nodes);
            CreateEdges(edges);
        }

        internal Graph(IEnumerable<T> nodes, T[,] edges) : this()
        {
            CreateVertices(nodes);

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                this.edges.Add(new Edge(this, edges[i, 0], edges[i, 1]));
            }
        }
  
        private void CreateVertices(IEnumerable<T> vertices)
        {
            this.vertices.AddRange(vertices.Distinct());
        }

        private void CreateEdges(IEnumerable<IEnumerable<T>> edges)
        {
            this.edges.AddRange(edges.Distinct(new Edge.SequenceParser()).Select(seq => new Edge(this, seq)));
        }

        public Graph<TResult> Select<TResult>(Func<T, TResult> selector)
        {

            return new Graph<TResult>(this.vertices.Select(selector), edges.Select(e => e.Vertices.Select(selector)));
        }

        public Graph<TResult> SelectMany<T2, TResult>(Graph<T2> other, Func<T, T2, TResult> selector)
        {
            var combined = this.Select(n => other.Select(o => selector(n, o)));
            var expand = new Graph<TResult>(combined.Vertices.SelectMany(g => g.Vertices),
                                            combined.Vertices.SelectMany(g => g.Edges.Select(e => e.Vertices))
                                            .Concat(combined.Edges.SelectMany(e => e.Vertices.First().Vertices.SelectMany(v => e.Vertices.Last().Vertices.Select(v2 => new[] { v, v2 })))));
            // This isn't correct yet. Need to ensure all edges then fold.
            return expand;
        }

        public Graph<TResult> SelectMany<T2, TResult>(Func<T, Graph<T2>> other, Func<T, T2, TResult> selector)
        {
            return SelectMany(other(default(T)), selector);
        }        

        public class Edge
        {
            private readonly T vertex1;
            private readonly T vertex2;
            private readonly Graph<T> graph;

            public IEnumerable<T> Vertices { get { return new[] { vertex1, vertex2 }; } }

            internal Edge(Graph<T> graph, T vertex1, T vertex2)
            {
                this.graph = graph;
                this.vertex1 = vertex1;
                this.vertex2 = vertex2;
            }

            internal Edge(Graph<T> graph, IEnumerable<T> vertices)
            {
                this.graph = graph;
                this.vertex1 = vertices.First();
                this.vertex2 = vertices.Last();
            }

            public static Graph<TResult>.Edge Create<TResult>(Graph<TResult> graph, Edge original, Func<T, TResult> selector)
            {
                return new Graph<TResult>.Edge(graph, selector(original.vertex1), selector(original.vertex2)); 
            }

            public bool AttachedTo(T vertex)
            {
                return vertex.Equals(vertex1) || vertex.Equals(vertex2);
            }

            public override int GetHashCode()
            {
                return vertex1.GetHashCode() ^ vertex2.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as Edge);
            }

            public bool Equals(Edge other)
            {
                return other != null &&
                       ((this.vertex1.Equals(other.vertex1) && this.vertex2.Equals(other.vertex2)) ||
                       (this.vertex1.Equals(other.vertex2) && this.vertex2.Equals(other.vertex1)));
            }

            /// <summary>
            /// This will return a vertex even if the one passed is not valid for this edge.
            /// </summary>
            public T OtherVertex(T vertex)
            {
                return vertex.Equals(vertex1) ? vertex2 : vertex1;
            }

            /// <summary>
            /// This will return a vertex even if the one passed is not valid for this edge.
            /// </summary>
            public T OtherVertex(Node node)
            {
                return node.Value.Equals(vertex1) ? vertex2 : vertex1;
            }

            /// <summary>
            /// This will return a node even if the one passed is not valid for this edge.
            /// </summary>
            public Node OtherNode(T vertex)
            {
                return new Node(graph, vertex.Equals(vertex1) ? vertex2 : vertex1);
            }

            /// <summary>
            /// This will return a node even if the one passed is not valid for this edge.
            /// </summary>
            public Node OtherNode(Node node)
            {
                return new Node(graph, node.Value.Equals(vertex1) ? vertex2 : vertex1);
            }

            internal class EqualityComparer : IEqualityComparer<Edge>
            {
                public bool Equals(Edge x, Edge y)
                {
                    return x.Equals(y);
                }

                public int GetHashCode(Edge edge)
                {
                    return edge.GetHashCode();
                }
            }

            internal class SequenceParser : IEqualityComparer<IEnumerable<T>>
            {
                public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
                {
                    return !x.Difference(y).Any();
                }

                public int GetHashCode(IEnumerable<T> sequence)
                {
                    return sequence.GetHashCode();
                }
            }
        }

        public class Node
        {
            private readonly Graph<T> graph;

            public T Value { get; private set; }

            public IEnumerable<T> Edges
            {
                get
                {
                    return from edge in graph.edges
                           where edge.AttachedTo(Value)
                           from vertex in edge.Vertices
                           where !vertex.Equals(Value)
                           select vertex;
                }
            }

            internal Node(Graph<T> graph, T value)
            {
                this.graph = graph;
                this.Value = value;
            }
        }
    }
}
