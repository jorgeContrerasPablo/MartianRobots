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

        public World(Position finalPosition)
        {
            FinalPosition = finalPosition;
            Scent = new List<Position>();
        }

        public Position FinalPosition { get; set; }

        public Robot ActualRobot { get; set; }

        public List<Position> Scent { get; set; }
    }
}
