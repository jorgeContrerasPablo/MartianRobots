using Domain.Model.Entities;
using Microsoft.Extensions.Configuration;
using ServiceLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureEF.Repositories
{
    public class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        public PositionRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Position GetOrCreate(Position position)
        {
            MartianContext martianContext = NewContext();
            Position positionDb = martianContext.Set<Position>().Where(p => 
            p.X == position.X &&
            p.Y == position.Y &&
            p.DirectionId == position.DirectionId).FirstOrDefault();
            if(positionDb == null)
            {
                positionDb = AddAsync(position);
            }
            Complete(martianContext);
            return positionDb;
        }
    }
}
