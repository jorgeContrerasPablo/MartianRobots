using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.IRepositories
{
    public interface IRobotRepository
    {
        public Robot Add(Robot robot);

        public Robot Update(Robot robot);
    }
}
