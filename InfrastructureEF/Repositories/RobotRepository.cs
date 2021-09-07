using Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfrastructureEF.Repositories
{
    public class RobotRepository : GenericRepository<Robot>, IRobotRepository
    {
        public RobotRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public Robot Add(Robot robot)
        {
            MartianContext martianContext = NewContext();
            Robot returnRobot = martianContext.Add(robot).Entity;
            Complete(martianContext);
            returnRobot = martianContext.Robots
                .Where(r => r.RobotId == returnRobot.RobotId)
                .Include(r => r.Position)
                .FirstOrDefault();
            Complete(martianContext);
            returnRobot = martianContext.Robots
                .Where(r => r.RobotId == returnRobot.RobotId)
                .Include(r => r.Position)
                .ThenInclude(p => p.Direction)
                .FirstOrDefault();
            Complete(martianContext);
            return returnRobot;
        }
    }
}
