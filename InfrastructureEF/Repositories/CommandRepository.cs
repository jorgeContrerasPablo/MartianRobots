using Domain.Model.Entities;
using ServiceLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEF.Repositories
{
    public class CommandRepository : GenericRepository<Command>, ICommandRepository
    {
        public CommandRepository(MartianContext context) : base(context)
        {
        }
    }
}
