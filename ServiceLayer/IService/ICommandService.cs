using Domain.Model.Entities;
using ServiceLayer.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.IService
{
    public interface ICommandService
    {
        public List<Command> GetCommands(InputCommandsDto inputCommandsDto);
    }
}
