using Domain.Model.Entities;
using ServiceLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEF.Repositories
{
    public class RobotRepository : GenericRepository<Robot>, IRobotRepository
    {
        public RobotRepository(MartianContext context) : base(context)
        {
        }
    }
}
