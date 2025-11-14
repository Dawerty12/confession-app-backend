using ConfessionApp.Application.Interfaces;
using ConfessionApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ConfessionApp.WebApi.Controllers
{
    [ApiController]
    [Route("api")] 
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireRepository _repository;

        public QuestionnaireController(IQuestionnaireRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("steps/order")]
        public async Task<IActionResult> GetStepsOrder()
        {
            var stepsOrder = await _repository.GetStepsOrderAsync();
            return Ok(stepsOrder); 
        }

        [HttpGet("step/{id:int}")]
        public async Task<IActionResult> GetStepById(int id)
        {
            var stepData = await _repository.GetStepByIdAsync(id);

            if (stepData == null)
            {
                return NotFound($"Step com ID {id} não encontrado.");
            }

            return Ok(stepData);
        }
    }
}