using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UL.Models;
using UL.Interfaces;
using Serilog;

namespace UL.Controllers
{
    [Route("ULCalculationTask/[controller]")]
    [ApiController]
    public class ExpressionController : ControllerBase
    {

        private readonly IExpressionService _expressionService;
        private readonly IValidate _validate;
        private readonly ILogger<ExpressionController> _logger;

        public ExpressionController(IExpressionService expressionService, IValidate validate, ILogger<ExpressionController> logger)
        {
            _expressionService = expressionService;
            _validate = validate;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ExpressionResult>> Get(string expression)
        {
            ExpressionResult expressionResult = new();

            if (String.IsNullOrEmpty(expression) || expression.Length < 3)
            {
                _logger.LogWarning("Invalid expression length");
                return BadRequest(new { message = ("Invalid expression length") });
            }

            if (!_validate.ValidExpression(expression))
            {
                _logger.LogWarning($"Invalid expression {expression}");
                return BadRequest(new { message = ("Invalid expression") });
            }

            if (expression.Contains("."))
            {
                _logger.LogWarning($"Invalid expression no decimal places permitted {expression}");
                return BadRequest(new { message = ("Invalid expression not decimal places permitted") });
            }

            try
            {
                expressionResult.Result = await _expressionService.CalculateResult(expression);
                expressionResult.Expression = expression;
                return expressionResult;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} {expression}");
                return StatusCode(500, "Internal Server Error:" + ex.Message);
            }
        }
    }
}
