using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaRobot
{
    // Класс графа
    public class Graph<T, F>
        where T : AbstractPoint
        where F : IPointFactory, new()
    {
        // Список вершин графа
        public List<Vertex<T>> Vertices { get; }

        public int Size { get; }

        public F Factory { get; }

        public Graph(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Number of vertices cannot be negative");
            }

            Size = size;

            Vertices = new List<Vertex<T>>(size);

            Factory = new F();
        }

        public Graph(List<Vertex<T>> vertices)
        {
            Vertices = vertices;

            Size = vertices.Count;

            Factory = new F();
        }

        public void AddVertex(Vertex<T> vertex)
        {
            Vertices.Add(vertex);
        }

        public void RemoveVertex(Vertex<T> vertex)
        {
            Vertices.Remove(vertex);
        }

        public bool HasVertex(Vertex<T> vertex)
        {
            return Vertices.Contains(vertex);
        }

        // Метод нахождения пути, использующий поиск в ширину
        public List<Vertex<T>> FindPath(T startPoint, T endPoint)
        {
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();

            // Словарь сохраняющий предыдущую вершину
            Dictionary<Vertex<T>, Vertex<T>> cameFrom = new Dictionary<Vertex<T>, Vertex<T>>();

            Vertex<T> start = Vertices.Find(v => v.Value.Equals(startPoint));

            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                // Извлекаем из очереди вершину
                Vertex<T> current = queue.Dequeue();

                // Если искомая - формируем путь
                if (current.Value.Equals(endPoint))
                {
                    List<Vertex<T>> path = new List<Vertex<T>>() { current };

                    while (!current.Value.Equals(start.Value))
                    {
                        current = cameFrom[current];
                        path.Add(current);
                    }
                    path.Reverse();

                    return path;
                }

                // Посещаем все смежные вершины
                foreach (Vertex<T> neighbor in current.Neighbors)
                {
                    // Если смежная вершина непосещена, помещаем в очередь и в словарь предыдущих вершин
                    if (!cameFrom.ContainsKey(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        cameFrom[neighbor] = current;
                    }
                }
            }

            throw new ArgumentException($"Path to {endPoint} not found");
        }

        // Метод заполнения графа вершинами и добавления смежных вершин
        public void FillGraph(int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Создаем точку используя фабрику
                    T point = (T)Factory.Create(x, y);

                    Vertex<T> vertex = new Vertex<T>(point);

                    if (x + 1 < width)
                    {
                        CreateOrAppendVertex(vertex, x + 1, y);
                    }
                    if (y + 1 < height)
                    {
                        CreateOrAppendVertex(vertex, x, y + 1);

                    }
                    if (x - 1 >= 0)
                    {
                        CreateOrAppendVertex(vertex, x - 1, y);
                    }
                    if (y - 1 >= 0)
                    {
                        CreateOrAppendVertex(vertex, x, y - 1);
                    }

                    AddVertex(vertex);
                }
            }
        }

        // Метод создания вершины или добавления ребер к уже существующей
        private void CreateOrAppendVertex(Vertex<T> vertex, int x, int y)
        {
            T point = (T)Factory.Create(x, y);

            Vertex<T> newVertex;

            if (Vertices.Any(v => v.Value.Equals(point)))
            {
                newVertex = Vertices.Find(v => v.Value.Equals(point));
            }
            else
            {
                newVertex = new Vertex<T>(point);
            }

            vertex.AddEdge(newVertex);
            newVertex.AddEdge(vertex);
        }

    }
}
