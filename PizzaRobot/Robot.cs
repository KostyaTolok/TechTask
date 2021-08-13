using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PizzaRobot
{
    // Класс Робота
    public class Robot<T, F>
        where T : AbstractPoint
        where F : IPointFactory, new()
    {
        public List<T> Points { get; }

        public Graph<T, F> Graph { get; }

        public F Factory { get; }

        public Robot(string input)
        {
            Points = new List<T>();

            Factory = new F();

            ParseInput(input, out int width, out int height);

            Graph = new Graph<T, F>(width * height);

            Graph.FillGraph(width, height);
        }

        private void ParseInput(string input, out int width, out int height)
        {
            Regex fieldSizeRegex = new Regex(@"^(?<fieldWidth>\d+)x(?<fieldHeight>\d+)(?<coords>\s\(\d+, \d+\))+$");

            // Проверка входной строки на соответсвие заданному шаблону
            if (fieldSizeRegex.IsMatch(input))
            {
                Match match = fieldSizeRegex.Match(input);

                // Извлечение длины и ширины поля
                width = int.Parse(match.Groups["fieldWidth"].Value);
                height = int.Parse(match.Groups["fieldHeight"].Value);

                foreach (Capture capture in match.Groups["coords"].Captures)
                {
                    Regex coordRegex = new Regex(@"\s\((?<x>\d+), (?<y>\d+)\)");

                    foreach (Match coordMatch in coordRegex.Matches(capture.Value))
                    {
                        // Извлечение координат точек и создание объектов точек с помощью фабрики
                        int x = int.Parse(coordMatch.Groups["x"].Value);
                        int y = int.Parse(coordMatch.Groups["y"].Value);

                        if (x >= width || y >= height)
                        {
                            throw new ArgumentException($"Cell ({x}, {y}) is out of bounds");
                        }

                        T point = (T)Factory.Create(x,y);

                        Points.Add(point);
                    }
                }
            }
            else
            {
                throw new ArgumentException("Invalid input");
            }
        }

        // Метод нахождения пути
        public string FindPath()
        {
            string result = "";

            // Создание начальной точки
            T previousPoint = (T)Factory.Create(0, 0);

            foreach (T point in Points)
            {
                //Находим путь с помощью поиска в ширину
                var path = Graph.FindPath(previousPoint, point);

                T previous = path[0].Value;

                // Заполнение результирующей строки
                for (int i = 1; i < path.Count; i++)
                {
                    if (previous.X < path[i].Value.X)
                    {
                        result += "E";
                    }
                    else if(previous.X > path[i].Value.X)
                    {
                        result += "W";
                    }
                    else if (previous.Y < path[i].Value.Y)
                    {
                        result += "N";
                    }
                    else if (previous.Y > path[i].Value.Y)
                    {
                        result += "S";
                    }
                    previous = path[i].Value;
                }

                result += "D";
                previousPoint = point;
            }

            return result;
        }
    }
}
