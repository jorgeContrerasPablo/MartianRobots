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
                foreach (char commandLetter in commandsSplited)
                {
                    Command command = GetCommand(commandLetter);
                    returnedCommands.Add(command);
                }
            }
            catch (ArgumentException argumentException)
            {

                throw new CommandNotImplementedException(argumentException.Message);
            }

            return returnedCommands;
        }

        private Command GetCommand(char commandLetter)
        {
            Command newCommand;
            if (char.IsLetter(commandLetter))
            {
                int commandId = (int)Command.GetTypeByName(commandLetter.ToString());
                newCommand = _commandRepository.GetById(commandId);
            }
            else
            {
                throw new CommandNotImplementedException(commandLetter.ToString());
            }
            return newCommand;
        }
    }
}
