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
        public void StartWorld(InputPositionDto finalPosition);

        public void StartRobot(InputPositionDto position);

        public FinalPositionDto MoveRobot(List<Command> commands);
    }
}
