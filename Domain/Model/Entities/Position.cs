using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Entities
{
    public class Position
    {

        public Position()
        {
            Routes = new HashSet<Route>();
            Robots = new HashSet<Robot>();
        }

        public int PositionId { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int DirectionId { get; set; }

        public virtual Direction Direction { get; set; }

        public virtual ICollection<Route> Routes { get; set; }

        public virtual ICollection<Robot> Robots { get; set; }
    }
}
