using Domain.Model.Entities;
using Microsoft.Extensions.Configuration;
using ServiceLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEF.Repositories
{
    public class RouteRepository : GenericRepository<Route>, IRouteRepository
    {
        public RouteRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
