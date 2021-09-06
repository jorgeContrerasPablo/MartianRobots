using System;
using System.Collections.Generic;
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
    }
}
