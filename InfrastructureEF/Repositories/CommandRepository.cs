using Domain.Model.Entities;
using Microsoft.Extensions.Configuration;
using ServiceLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEF.Repositories
{
    public class CommandRepository : GenericRepository<Command>, ICommandRepository
    {
        public CommandRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
