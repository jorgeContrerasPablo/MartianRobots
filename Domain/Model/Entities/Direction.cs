using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Model.Entities
{
    public class Direction
    {
        /// <summary>
        /// The direction North corresponds to the direction from grid point (x, y) to grid point (x,  y+1).
        /// </summary>
        public enum Type
        {
            N = 1,
            S = 2,
            E = 3,
            W = 4,
        }

        public Direction()
        {
            Positions = new HashSet<Position>();
        }

        public int DirectionId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Position> Positions{ get; set; }

        public void ChangeLeft()
        {
            DirectionId = DirectionId switch
            {
                (int)Type.N => (int)Type.W,
                (int)Type.S => (int)Type.E,
                (int)Type.E => (int)Type.N,
                (int)Type.W => (int)Type.S,
                _ => throw new NotImplementedException(),
            };
        }

        public void ChangRight()
        {
            DirectionId = DirectionId switch
            {
                (int)Type.N => (int)Type.E,
                (int)Type.S => (int)Type.W,
                (int)Type.E => (int)Type.S,
                (int)Type.W => (int)Type.N,
                _ => throw new NotImplementedException(),
            };
        }

        public Type GetTypeByName(string typeName)
        {
            return Enum.Parse<Type>(typeName);
        }

        public override bool Equals(object obj)
        {
            return obj is Direction direction &&
                   Name == direction.Name &&
                   Description == direction.Description &&
                   Positions.SequenceEqual(direction.Positions);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Description, Positions);
        }
    }
}
