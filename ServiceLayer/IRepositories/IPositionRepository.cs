using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IRepositories
{
    public interface IPositionRepository
    {
        public Position GetOrCreate(Position position);
    }
}
