using Domain.Model;
using Domain.Model.Entities;
using ServiceLayer.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.IService
{
    public interface IWorldService
    {
        public void StartWorld(Position finalPosition, World world);

        public void StartRobot(Position position, World world);

        public FinalPositionDto MoveRobot(List<Command> commands, World world);
    }
}
