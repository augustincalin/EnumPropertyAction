using EPA.API.Model;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace EPA.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        private readonly IValidator<People> validator;

        public PeopleController(ILogger<PeopleController> logger, IValidator<People> _validator)
        {
            _logger = logger;
            validator = _validator;
        }

        [HttpGet(Name = "GetPeople")]
        public IActionResult Get(int id)
        {
            var people = new People { Id = id, Gender=GenderType.Male, Name="John" };
            return Ok(people);
        }

        [HttpPost(Name = "DoPeople")]
        public IActionResult AddPeople(People people)
        {
            ValidationResult validationResult = validator.Validate(people);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(err=>err.ErrorMessage));
            }
            return Ok(people);
        }
    }
}