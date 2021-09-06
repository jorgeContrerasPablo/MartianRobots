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
    }
}
