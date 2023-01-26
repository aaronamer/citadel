using Citadel.Data;
using Citadel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Citadel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamesController : ControllerBase
    {
        private readonly INamesRepository _repository;
        private readonly ILogger _logger;

        public NamesController(INamesRepository repository, ILogger<NamesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post(NameModel model)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(model?.Name))
            {
                _logger.Log(LogLevel.Debug, "User submitted an empty name");
                return BadRequest(ModelState.Values);
            }

            try
            {
                await _repository.Add(model.Name);
                _logger.LogInformation($"Received request from {model.Name}");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"An exception occurred adding the name {model.Name} to the database");
                throw; 
            }

            return Ok();
        }
    }
}
