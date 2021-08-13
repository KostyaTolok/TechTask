using System;
using Xunit;
using PizzaRobot;

namespace Tests
{
    public class RobotTests
    {
        [Fact]
        public void TestFirstString()
        {
            Robot<Point, PointFactory> robot = new Robot<Point, PointFactory>("5x5 (1, 3) (4, 4)");

            string path = robot.FindPath();
            Assert.True(path == "ENNNDEEEND" ||
                        path == "ENNNDNEEED" ||
                        path == "NNNEDEEEND" ||
                        path == "NNNEDNEEED");
        }

        [Fact]
        public void TestSecondString()
        {
            Robot<Point, PointFactory> robot = new Robot<Point, PointFactory>("5x5 (0, 0) (1, 3) (4, 4) (4, 2) (4, 2) (0, 1) (3, 2) (2, 3) (4, 1)");

            Assert.Equal("DENNNDEEENDSSDDWWWWSDEEENDWNDSSEED", robot.FindPath());
        }

        [Fact]
        public void TestThirdString()
        {
            Robot<Point, PointFactory> robot = new Robot<Point, PointFactory>("4x3 (0, 0) (3, 1) (0, 0) (1, 0) (0, 0) (0, 1)");

            string path = robot.FindPath();
            Assert.True(path == "DEEENDWWWSDEDWDND" ||
                        path == "DNEEEDWWWSDEDWDND" ||
                        path == "DEEENDSWWWDEDWDND" ||
                        path == "DNEEEDSWWWDEDWDND");
        }

        [Fact]
        public void TestEnvalidInputException()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Robot<Point, PointFactory>("5x5 (0,0) (1 3) (4, 4)"));

            Assert.Equal("Invalid input", exception.Message);
        }

        [Fact]
        public void TestOutOfBoundsException()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Robot<Point, PointFactory>("3x3 (0, 0) (1, 4)"));

            Assert.Equal("Cell (1, 4) is out of bounds", exception.Message);
        }
    }
}
