using Domain.Model.Entities;
using ServiceLayer.Dto;
using ServiceLayer.Exceptions;
using ServiceLayer.IRepositories;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    public class CommandService : ICommandService
    {
        private readonly ICommandRepository _commandRepository;
        public CommandService(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public List<Command> GetCommands(InputCommandsDto inputCommandsDto)
        {
            List<Command> returnedCommands = new List<Command>();
            try
            {
                char[] commandsSplited = inputCommandsDto.Commands.ToCharArray();
                foreach (char command in commandsSplited)
                {
                    if (char.IsLetter(command))
                    {
                        // TODO Get from database
                        Command newCommand = new Command();
                        newCommand.CommandId = (int)newCommand.GetTypeByName(command.ToString());
                        returnedCommands.Add(newCommand);
                    }
                    else
                    {
                        throw new CommandNotImplementedException(command.ToString());
                    }
                }
            }
            catch (ArgumentException argumentException)
            {

                throw new CommandNotImplementedException(argumentException.Message);
            }

            return returnedCommands;
        }
    }
}
