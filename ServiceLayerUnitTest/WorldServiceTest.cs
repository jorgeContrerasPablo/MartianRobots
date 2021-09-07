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
            int initRobotX = 1;
            int initRobotY = 1;
            StartNewWorld(finalWorldX, finalWorldY);
            InputPositionDto position = NewPosition(initRobotX, initRobotY, Direction.Type.E);
            _worldService.StartRobot(position);

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
                Position = new Position() 
                {
                    X = initRobotX,
                    Y = initRobotY,
                    Direction = new Direction(){
                        DirectionId = (int)Direction.Type.E, 
                    }
                },
                IsLost = false,
            };

            FinalPositionDto finalPositionDto = _worldService.MoveRobot(commands);

            finalPositionDto.Should().BeEquivalentTo(finalPositionDtoExpected);
        }

        //[Fact]
        //public void StartRobot_insideWorld()
        //{
        //    int x = 1;
        //    int y = 2;
        //    StartNewWorld(x, y);

        //    InputPositionDto position = NewPosition(x, y, Direction.Type.E);

        //    _worldService.StartRobot(position);

        //    Position positionExpected = new Position()
        //    {
        //        X = x,
        //        Y = y,
        //        Direction = new Direction()
        //        {
        //            DirectionId = (int)Direction.Type.E,
        //        }                
        //    };

        //    world.ActualRobot.Position.Should().BeEquivalentTo(positionExpected);
        //}

        private void StartNewWorld(int x, int y)
        {
            InputPositionDto finalPosition = new InputPositionDto()
            {
                X = x,
                Y = y,
            };

            _worldService.StartWorld(finalPosition);
        }

        private InputPositionDto NewPosition(int x, int y, Direction.Type direction)
        {
            InputPositionDto position = new InputPositionDto()
            {
                X = x,
                Y = y,
                Direction = Enum.GetName(typeof(Direction.Type), direction),
            };

            return position;
        }
    }
}
