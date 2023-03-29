using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prueba.WebApi.Contracts;
using Prueba.Application.UseCases;

namespace Prueba.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<UserController> _logger;
        private readonly ISender sender;

        public UserController(ILogger<UserController> logger, ISender sender)
        {
            _logger = logger;
            this.sender = sender;
        }

        [HttpPost()]
        public async Task<IActionResult>  Post([FromBody] CreateUserContract createUserContract)
        {
            var com = new CreateUser.Command(createUserContract.FirstName,createUserContract.LastName,createUserContract.mail);
            await sender.Send(com);
            return Created("",null);
        }


        [HttpGet()]

        public async Task<IActionResult> Get()
        {
            var lista = await sender.Send(new ListUser.Query());
            return Ok(lista);

        }
        [HttpGet("{Id}")]

        public async Task<IActionResult> ById([FromRoute] int Id)
        {
            var lista = await sender.Send(new GetUser.Query(Id));
            return Ok(lista);

        }
        [HttpPut("{Id}")]

        public async Task<IActionResult> update([FromRoute] int Id, string FirstName, string LastName, string mail)
        {
            var lista = await sender.Send(new UpdateUser.Command(Id,FirstName,LastName,mail));
            return Ok(lista);

        }
        [HttpDelete("{Id}")]

        public async Task<IActionResult> delete([FromRoute] int Id)
        {
            var lista = await sender.Send(new DeleteUser.Command(Id));
            return Ok(lista);
           
        }
    }
}