using Domain.Model;
using Domain.Model.Entities;
using FluentAssertions;
using Moq;
using ServiceLayer;
using ServiceLayer.Dto;
using ServiceLayer.IRepositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace ServiceLayerUnitTest
{
    public class WorldServiceTest
    {
        private readonly WorldService _worldService;
        public WorldServiceTest()
        {
            Mock<IRobotRepository> mockRobotRepository = new Mock<IRobotRepository>();
            Mock<IRouteRepository> mockRoutRepository = new Mock<IRouteRepository>();
            Mock<IPositionRepository> mockPositionRepository = new Mock<IPositionRepository>();
            _worldService = new WorldService(mockRobotRepository.Object, mockPositionRepository.Object, mockRoutRepository.Object);
        }

        [Fact]
        public void MoveRobot()
        {
            int finalWorldX = 5;
            int finalWorldY = 3;
            int initRoboX = 1;
            int initRoboY = 1;
            World world = StartNewWorld(finalWorldX, finalWorldY);
            Position position = NewPosition(initRoboX, initRoboY, Direction.Type.E);
            _worldService.StartRobot(position, world);

            List<Command> commands = new List<Command>
            {
                new Command(Command.Type.R),
                new Command(Command.Type.F),
                new Command(Command.Type.R),
                new Command(Command.Type.F),
                new Command(Command.Type.R),
                new Command(Command.Type.F),
                new Command(Command.Type.R),
                new Command(Command.Type.F)
            };

            FinalPositionDto finalPositionDtoExpected = new FinalPositionDto()
            {
                Position = position,
                IsLost = false,
            };

            FinalPositionDto finalPositionDto = _worldService.MoveRobot(commands, world);

            finalPositionDto.Should().BeEquivalentTo(finalPositionDtoExpected);
        }

        [Fact]
        public void StartRobot_insideWorld()
        {
            int x = 1;
            int y = 2;
            World world = StartNewWorld(x, y);

            Position position= NewPosition(x, y, Direction.Type.E);

            _worldService.StartRobot(position, world);

            world.ActualRobot.Position.Should().BeEquivalentTo(position);
        }

        [Fact]
        public void StartWorld()
        {
            int x = 1;
            int y = 2;
            World world = StartNewWorld(x, y);

            world.FinalPosition.X.Should().Be(x);
            world.FinalPosition.Y.Should().Be(y);
            world.ActualRobot.Should().BeNull();
            world.Scent.Should().BeEmpty();
        }

        private World StartNewWorld(int x, int y)
        {
            World world = new World();

            Position finalPosition = new Position()
            {
                X = x,
                Y = y,
            };

            _worldService.StartWorld(finalPosition, world);

            return world;
        }

        private Position NewPosition(int x, int y, Direction.Type direction)
        {
            Position position = new Position()
            {
                X = x,
                Y = y,
                Direction = new Direction()
                {
                    DirectionId = (int)direction,
                }
            };

            return position;
        }
    }
}
