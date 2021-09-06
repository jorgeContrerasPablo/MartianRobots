using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLayer.IService;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorldController : ControllerBase
    {
        private readonly ILogger<WorldController> _logger;
        private readonly IWorldService _worldService;

        public WorldController(IWorldService worldService, ILogger<WorldController> logger)
        {
            _logger = logger;
            _worldService = worldService;
        }

        [HttpPut("startworld")]
        public string StartWorld([FromBody] Position worldFinishPosition)
        {
            //_worldService.StartWorld(inputPosition.X, inputPosition.Y);
            return (worldFinishPosition.X + worldFinishPosition.Y).ToString();
        }
    }
}
