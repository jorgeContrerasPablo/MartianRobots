using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class World
    {
        public World()
        {
        }

        public Position FinalPosition { get; set; }

        public Robot ActualRobot { get; set; }

        public List<Position> Scent { get; set; }

        public void StartWorld(Position finalPosition)
        {
            FinalPosition = finalPosition;
            Scent = new List<Position>();
            ActualRobot = null;
        }
    }
}
