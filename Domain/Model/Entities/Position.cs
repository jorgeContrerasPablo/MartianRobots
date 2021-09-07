using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Model.Entities
{
    public class Position
    {
        const int oneCoordinate = 1;

        public Position()
        {
            Routes = new HashSet<Route>();
            Robots = new HashSet<Robot>();
        }

        public Position(int x, int y, int? directionId) : this()
        {
            X = x;
            Y = y;
            DirectionId = directionId;
        }

        public int PositionId { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int? DirectionId { get; set; }

        public virtual Direction Direction { get; set; }

        public virtual ICollection<Route> Routes { get; set; }

        public virtual ICollection<Robot> Robots { get; set; }

        internal void BackOneX()
        {
            X -= oneCoordinate;
        }

        internal void AdvanceOneX()
        {
            X += oneCoordinate;
        }

        internal void BackOneY()
        {
            Y -= oneCoordinate;
        }

        internal void AdvanceOneY()
        {
            Y += oneCoordinate;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   X == position.X &&
                   Y == position.Y &&
                   DirectionId == position.DirectionId &&
                   EqualityComparer<Direction>.Default.Equals(Direction, position.Direction) &&
                   Routes.SequenceEqual(position.Routes) &&
                   Robots.SequenceEqual(position.Robots);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, DirectionId, Direction, Routes, Robots);
        }
    }
}
