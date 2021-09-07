using Domain.Model;
using Domain.Model.Entities;
using ServiceLayer.Dto;
using ServiceLayer.IRepositories;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;

namespace ServiceLayer
{
    public class WorldService : IWorldService
    {
        private World _world;

        public WorldService(IRobotRepository robotRepository, IPositionRepository positionRepository, IRouteRepository routeRepository)
        {

        }

        public FinalPositionDto MoveRobot(List<Command> commands)
        {
            bool isLost = false;
            foreach (Command command in commands)
            {
                switch (command.CommandId)
                {
                    case (int)Command.Type.L:
                        _world.ActualRobot.MoveLeft();
                        break;
                    case (int)Command.Type.R:
                        _world.ActualRobot.MoveRight();
                        break;
                    case (int)Command.Type.F:
                        _world.ActualRobot.MoveForward();
                        break;
                    default:
                        break;
                }
                //Is Scent?
                //Save route
            }
            return new FinalPositionDto(_world.ActualRobot.Position, isLost);
        }

        public void StartRobot(InputPositionDto positionDto)
        {
            // Get Position or create
            int directionId = (int)new Direction().GetTypeByName(positionDto.Direction);
            Position position = new Position()
            {
                X = positionDto.X,
                Y = positionDto.Y,
                Direction = new Direction()
                {
                    DirectionId = directionId,
                }
            };
            Robot robot = new Robot(position);
            _world.ActualRobot = robot;
            //Save robot
            //Save route
        }

        public void StartWorld(InputPositionDto finalPositionDto)
        {

            _world = new World();
            // Get Position or create
            Position finalPosition = new Position()
            {
                X = finalPositionDto.X,
                Y = finalPositionDto.Y,
            };
            _world.FinalPosition =  finalPosition;
            _world.Scent = new List<Position>();
            _world.ActualRobot = null;
        }
    }
}
