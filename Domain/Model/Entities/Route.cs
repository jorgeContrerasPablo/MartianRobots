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

        public override bool Equals(object obj)
        {
            return obj is Route route &&
                   RobotId == route.RobotId &&
                   PositionId == route.PositionId &&
                   CommandId == route.CommandId &&
                   EqualityComparer<Robot>.Default.Equals(Robot, route.Robot) &&
                   EqualityComparer<Position>.Default.Equals(Position, route.Position) &&
                   EqualityComparer<Command>.Default.Equals(Command, route.Command);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RobotId, PositionId, CommandId, Robot, Position, Command);
        }
    }
}
