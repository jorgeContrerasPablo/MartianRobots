using Domain.Model.Entities;
using ServiceLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEF.Repositories
{
    public class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        public PositionRepository(MartianContext context) : base(context)
        {
        }
    }
}
