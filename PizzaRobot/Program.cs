using System;

namespace PizzaRobot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string input = Console.ReadLine();

                Robot<Point, PointFactory> robot = new Robot<Point, PointFactory>(input);

                Console.WriteLine(robot.FindPath());
            }
            catch(ArgumentException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            Console.WriteLine("Press any button to continue");
            Console.ReadKey();
        }
    }
}
