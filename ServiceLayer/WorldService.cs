using Domain.Model;
using Domain.Model.Entities;
using Microsoft.Extensions.Caching.Memory;
using ServiceLayer.Dto;
using ServiceLayer.IRepositories;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;

namespace ServiceLayer
{
    public class WorldService : IWorldService
    {

        private IMemoryCache _cache;
        private const int _worldKeyCache = 1;
        private const int _scentKeyCache = 3;
        private readonly IRobotRepository _robotRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IRouteRepository _routeRepository;

        public WorldService(IRobotRepository robotRepository, IPositionRepository positionRepository, IRouteRepository routeRepository, IMemoryCache memoryCache)
        {
            _robotRepository = robotRepository;
            _positionRepository = positionRepository;
            _routeRepository = routeRepository;
            _cache = memoryCache;

        }

        public FinalPositionDto MoveRobot(List<Command> commands)
        {
            bool isLost = false;
            World world = GetWorld();
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
                // Is Scent?
                _robotRepository.Update(world.ActualRobot);
                //AddRoute(command);
            }
            UpadteWorld(world);
            return new FinalPositionDto(world.ActualRobot.Position, isLost);
        }

        public void StartRobot(InputPositionDto positionDto)
        {
            int directionId = (int)Direction.GetTypeByName(positionDto.Direction);
            Position position = GetPosition(positionDto.X, positionDto.Y, directionId);

            //AddRobot(position);
            //AddRoute(null);
        }

        public void StartWorld(InputPositionDto finalPositionDto)
        {
            World world = new World();
            Position finalPosition = GetPosition(finalPositionDto.X, finalPositionDto.Y, null);
            world.FinalPosition =  finalPosition;
            world.Scent = new List<Position>();
            world.ActualRobot = null;
            UpadteWorld(world);
        }

        private Position GetPosition(int x, int y, int? idDirection)
        {
            Position position = new Position(x, y, idDirection);
            position = _positionRepository.GetOrCreate(position);
            return position;
        }

        private void AddRobot(Position position)
        {
            Robot robot = new Robot(position);
            robot = _robotRepository.Add(robot);
            World world = GetWorld();
            world.ActualRobot = robot;
            UpadteWorld(world);

        }
        private void AddRoute(Command command)
        {
            Route route = new Route(GetWorld().ActualRobot, command);
            //_routeRepository.AddAsync(route);
        }

        public World GetWorld()
        {
            return (World)_cache.Get(_worldKeyCache);
        }

        public void AddWorldToCache(World world)
        {
            _cache.Set(_worldKeyCache, world, TimeSpan.FromDays(1));
        }

        public void DeleteWorld()
        {
            _cache.Remove(_worldKeyCache);
        }

        public void UpadteWorld(World world)
        {
            DeleteWorld();
            AddWorldToCache(world);
        }

    }
}
