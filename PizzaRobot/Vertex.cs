using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRobot
{
    // Класс вершины
    public class Vertex<T> where T: AbstractPoint
    {
        // Список смежных вершин
        public List<Vertex<T>> Neighbors { get; set; }

        public T Value { get; set; }

        public Vertex(T value)
        {
            Value = value;
            Neighbors = new List<Vertex<T>>();
        }

        public Vertex(T value, List<Vertex<T>> neighbors)
        {
            Value = value;
            Neighbors = neighbors;
        }

        public void AddEdge(Vertex<T> vertex)
        {
            Neighbors.Add(vertex);
        }

        public void AddEdges(List<Vertex<T>> newNeighbors)
        {
            Neighbors.AddRange(newNeighbors);
        }

        public void RemoveEdge(Vertex<T> vertex)
        {
            Neighbors.Remove(vertex);
        }

        // Строковая репрезентация вершины
        public override string ToString()
        {

            StringBuilder allNeighbors = new StringBuilder("");
            allNeighbors.Append(Value.ToString() + ": ");

            foreach (Vertex<T> neighbor in Neighbors)
            {
                allNeighbors.Append(neighbor.Value.ToString() + "  ");
            }

            return allNeighbors.ToString();

        }
    }
}
