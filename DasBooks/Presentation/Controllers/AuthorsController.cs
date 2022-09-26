using Application.Authors.Commands.CreateAuthor;
using Application.Authors.Queries.GetAuthorById;
using Application.Authors.Queries.GetAuthors;
using Application.Contracts.Request;
using Application.Contracts.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public AuthorsController(IMediator mediator, ILogger<AuthorsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<GetAuthorsResponse>> GetAuthors(CancellationToken cancellationToken)
        {
            var query = new GetAuthorsQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpGet("{id}", Name="GetAuthor")]
        public async Task<ActionResult<GetAuthorResponse>> GetAuthorById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{User} is fetching author by Id - {id}");
            var query = new GetAuthorByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateAuthor([FromBody]CreateAuthorRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateAuthorCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtRoute("GetAuthor", new { id = result }, result);
        }
    }
}
