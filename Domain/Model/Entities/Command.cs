using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Model.Entities
{
    public class Command
    {
        /// <summary>
        /// Left(L): the robot turns left 90 degrees and remains on the current grid point.
        /// Right(R): the robot turns right 90 degrees and remains on the current grid point.
        /// Forward(F): the robot moves forward one grid point in the direction of the current 
        /// orientation and maintains the same orientation.
        /// </summary>
        public enum Type
        {
            L = 1,
            R = 2,
            F = 3,
        }

        public Command()
        {
            Routes = new HashSet<Route>();
        }

        public Command(Type type) : this()
        {
            CommandId = (int) type;
        }

        public int CommandId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Route> Routes { get; set; }

        public static Type GetTypeByName(string typeName)
        {
            return Enum.Parse<Type>(typeName);
        }

        public override bool Equals(object obj)
        {
            return obj is Command command &&
                   Name == command.Name &&
                   Description == command.Description &&
                   Routes.SequenceEqual(command.Routes);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Description, Routes);
        }
    }
}
