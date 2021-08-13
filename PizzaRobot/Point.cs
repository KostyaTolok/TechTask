using System;

namespace PizzaRobot
{
    // Класс точки
    public class Point : AbstractPoint
    {
        public override int X { get; protected set; }

        public override int Y { get; protected set; }

        public Point(int x, int y) : base(x, y)
        {
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            Point other = (Point)obj;
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(X, Y).GetHashCode();
        }
    }
}
