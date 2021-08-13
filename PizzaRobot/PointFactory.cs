
namespace PizzaRobot
{
    // Класс фабрики точек
    public class PointFactory : IPointFactory
    {
        public AbstractPoint Create(int x, int y) => new Point(x, y);
    }
}
