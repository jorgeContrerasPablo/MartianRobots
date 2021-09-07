using Domain.Model.Entities;
using FluentAssertions;
using Moq;
using ServiceLayer;
using ServiceLayer.Dto;
using ServiceLayer.Exceptions;
using ServiceLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ServiceLayerUnitTest
{
    public class CommandServieTest
    {
        private readonly CommandService _commandService;

        public CommandServieTest()
        {
            Mock<ICommandRepository> mockCommandRepository = new Mock<ICommandRepository>();
            _commandService = new CommandService(mockCommandRepository.Object);
        }

        [Fact]
        public void GetCommands()
        {
            string initCommands = "FRRFLLFFRRFLL";

            List<Command> commandsExpected = new List<Command>
            {
                new Command(Command.Type.F),
                new Command(Command.Type.R),
                new Command(Command.Type.R),
                new Command(Command.Type.F),
                new Command(Command.Type.L),
                new Command(Command.Type.L),
                new Command(Command.Type.F),
                new Command(Command.Type.F),
                new Command(Command.Type.R),
                new Command(Command.Type.R),
                new Command(Command.Type.F),
                new Command(Command.Type.L),
                new Command(Command.Type.L),
            };

            InputCommandsDto inputCommandsDto = new InputCommandsDto()
            {
                Commands = initCommands,
            };

            List<Command> commands = _commandService.GetCommands(inputCommandsDto);

            commands.Should().BeEquivalentTo(commandsExpected);
        }

        [Fact]
        public void GetCommands_CommandNotImplemented()
        {
            string initCommands = "URRFLLFFRRFLL";

            InputCommandsDto inputCommandsDto = new InputCommandsDto()
            {
                Commands = initCommands,
            };

            Action action = () => _commandService.GetCommands(inputCommandsDto);
            action.Should().Throw<CommandNotImplementedException>();

            initCommands = "FRRF2LFFRRFLL";

            inputCommandsDto.Commands = initCommands;

            action = () => _commandService.GetCommands(inputCommandsDto);
            action.Should().Throw<CommandNotImplementedException>();
        }
    }
}
