using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Dto
{
    public class FinalPositionDto
    {
        public FinalPositionDto()
        {
        }
        public FinalPositionDto(Position position, bool isLost)
        {
            Position = position;
            IsLost = isLost;
        }

        public Position Position { get; set; }

        public bool IsLost { get; set; }

        public override bool Equals(object obj)
        {
            return obj is FinalPositionDto dto &&
                   EqualityComparer<Position>.Default.Equals(Position, dto.Position) &&
                   IsLost == dto.IsLost;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Position, IsLost);
        }
    }
}
