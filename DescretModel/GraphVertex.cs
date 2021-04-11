using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescretModel
{
    class GraphVertex
    {
        // Назва вершини
        public string Name { get; }

        // Список ребер
        public List<GraphEdge> Edges { get; }
        
        // Конструктор
        public GraphVertex(string vertexName)
        {
            Name = vertexName;
            Edges = new List<GraphEdge>();
        }

        // Додавання ребра
        public void AddEdge(GraphEdge newEdge)
        {
            Edges.Add(newEdge);
        }

        // Додавання ребра
        public void AddEdge(GraphVertex vertex, int edgeWeight)
        {
            AddEdge(new GraphEdge(vertex, edgeWeight));
        }

        // Перетворення в рядок
        public override string ToString() => Name;
        
    }
}
