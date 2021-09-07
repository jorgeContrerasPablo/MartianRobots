using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Model;
using Domain.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLayer.Dto;
using ServiceLayer.IService;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorldController : ControllerBase
    {
        private readonly ILogger<WorldController> _logger;
        private readonly IWorldService _worldService;
        private readonly ICommandService _commandService;

        public WorldController(IWorldService worldService, ICommandService commandService, ILogger<WorldController> logger)
        {
            _logger = logger;
            _worldService = worldService;
            _commandService = commandService;
        }

        [HttpPut("startworld")]
        public void StartWorld([FromBody] InputPositionDto inputPositionDto)
        {
            _worldService.StartWorld(inputPositionDto);            
        }

        [HttpPut("startrobot")]
        public void StartRobot([FromBody] InputPositionDto initPositionDto)
        {
            _worldService.StartRobot(initPositionDto);
        }

        [HttpPost("moverobot")]
        public string MoveRobot([FromBody] InputCommandsDto inputCommandsDto)
        {
            List<Command> commands = _commandService.GetCommands(inputCommandsDto);
            FinalPositionDto finalPositionDto = _worldService.MoveRobot(commands);
            return finalPositionDto.Position.X.ToString() + finalPositionDto.Position.Y.ToString() + finalPositionDto.Position.Direction.DirectionId + finalPositionDto.IsLost.ToString();
        }
    }
}
