using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.Dto
{
    public class InputPositionDto
    {
        public int X { get; set; }

        public int Y { get; set; }

        public string Direction { get; set; }

        public override bool Equals(object obj)
        {
            return obj is InputPositionDto dto &&
                   X == dto.X &&
                   Y == dto.Y &&
                   Direction == dto.Direction;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Direction);
        }
    }
}
