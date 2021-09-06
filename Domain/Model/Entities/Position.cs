using System;
using System.Collections.Generic;
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

        public int PositionId { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int DirectionId { get; set; }

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
                   EqualityComparer<ICollection<Route>>.Default.Equals(Routes, position.Routes) &&
                   EqualityComparer<ICollection<Robot>>.Default.Equals(Robots, position.Robots);
        }
    }
}
