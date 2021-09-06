using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Entities
{
    public class Robot
    {
        public Robot()
        {
            Routes = new HashSet<Route>();
        }       

        public int RobotId { get; set; }

        public int PositionId { get; set; }

        public DateTime CreatedTime { get; set; }

        public virtual Position Position { get; set; }

        public virtual ICollection<Route> Routes {get; set;}

        public void MoveLeft()
        {
            Position.Direction.ChangeLeft();
        }

        public void MoveRight()
        {
            Position.Direction.ChangRight();
        }

        public void MoveForward()
        {
            switch (Position.DirectionId)
            {
                case (int)Direction.Type.N:
                    Position.AdvanceOneY();
                    break;
                case (int)Direction.Type.S:
                    Position.BackOneY();
                    break;
                case (int)Direction.Type.E:
                    Position.AdvanceOneX();
                    break;
                case (int)Direction.Type.W:
                    Position.BackOneX();
                    break;
                default:
                    break;
            }
        }
    }
}
