using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Entities
{
    public class Route
    {
        public int RouteId { get; set; }

        public int RobotId { get; set; }

        public int PositionId { get; set; }

        public int CommandId { get; set; }

        public virtual Robot Robot { get; set; }

        public virtual Position Position { get; set; }

        public virtual Command Command { get; set; }

    }
}
