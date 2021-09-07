using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.IRepositories
{
    public interface ICommandRepository
    {
        public Command GetById(int commandId);
    }
}
