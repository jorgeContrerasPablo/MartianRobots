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
        public WorldService(IRobotRepository robotRepository, IPositionRepository positionRepository, IRouteRepository routeRepository)
        {

        }

        public FinalPositionDto MoveRobot(List<Command> commands, World world)
        {
            bool isLost = false;
            foreach (Command command in commands)
            {
                switch (command.CommandId)
                {
                    case (int)Command.Type.L:
                        world.ActualRobot.MoveLeft();
                        break;
                    case (int)Command.Type.R:
                        world.ActualRobot.MoveRight();
                        break;
                    case (int)Command.Type.F:
                        world.ActualRobot.MoveForward();
                        break;
                    default:
                        break;
                }
                //Is Scent?
                //Save route
            }
            return new FinalPositionDto(world.ActualRobot.Position, isLost);
        }

        public void StartRobot(Position position, World world)
        {
            Robot robot = new Robot(position);
            world.ActualRobot = robot;
            //Save robot
            //Save route
        }

        public void StartWorld(Position finalPosition, World world)
        {
            world.FinalPosition = finalPosition;
            world.Scent = new List<Position>();
            world.ActualRobot = null;
        }
    }
}
