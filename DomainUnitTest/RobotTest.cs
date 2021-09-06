using Domain.Model.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace DomainUnitTest
{
    public class RobotTest
    {

        [Theory]
        [InlineData(Direction.Type.N, Direction.Type.W, 0, 0, 0, 0)]
        [InlineData(Direction.Type.S, Direction.Type.E, 0, 0, 0, 0)]
        [InlineData(Direction.Type.E, Direction.Type.N, 0, 0, 0, 0)]
        [InlineData(Direction.Type.W, Direction.Type.S, 0, 0, 0, 0)]

        public void MoveLeft(Direction.Type inDirection, Direction.Type outDirection, int inX, int inY, int outX, int outY)
        {
            Robot robot = CreateRobot(inDirection, inX, inY);

            robot.MoveLeft();

            CheckRobot(robot, outDirection, outX, outY).Should().BeTrue();
        }


        [Theory]
        [InlineData(Direction.Type.N, Direction.Type.E, 0, 0, 0, 0)]
        [InlineData(Direction.Type.S, Direction.Type.W, 0, 0, 0, 0)]
        [InlineData(Direction.Type.E, Direction.Type.S, 0, 0, 0, 0)]
        [InlineData(Direction.Type.W, Direction.Type.N, 0, 0, 0, 0)]

        public void MoveRight(Direction.Type inDirection, Direction.Type outDirection, int inX, int inY, int outX, int outY)
        {
            Robot robot = CreateRobot(inDirection, inX, inY);

            robot.MoveRight();

            CheckRobot(robot, outDirection, outX, outY).Should().BeTrue();
        }


        [Theory]
        [InlineData(Direction.Type.N, Direction.Type.N, 1, 1, 1, 2)]
        [InlineData(Direction.Type.S, Direction.Type.S, 1, 1, 1, 0)]
        [InlineData(Direction.Type.E, Direction.Type.E, 1, 1, 2, 1)]
        [InlineData(Direction.Type.W, Direction.Type.W, 1, 1, 0, 1)]

        public void MoveForward(Direction.Type inDirection, Direction.Type outDirection, int inX, int inY, int outX, int outY)
        {
            Robot robot = CreateRobot(inDirection, inX, inY);

            robot.MoveForward();

            CheckRobot(robot, outDirection, outX, outY).Should().BeTrue();
        }

        private Robot CreateRobot(Direction.Type inDirection, int inX, int inY)
        {
            Robot robot = new Robot()
            {
                Position = new Position()
                {
                    X = inX,
                    Y = inY,
                    DirectionId = (int)inDirection,
                    Direction = new Direction()
                    {
                        DirectionId = (int)inDirection,
                    }
                },
            };

            return robot;
        }

        private bool CheckRobot(Robot robot, Direction.Type outDirection, int outX, int outY)
        {
            bool sameDirection = robot.Position.Direction.DirectionId == (int)outDirection;
            bool sameX = robot.Position.X == outX;
            bool sameY = robot.Position.Y == outY;

            return sameDirection && sameX && sameY;
        }
    }
}
