using Application.Books.Commands;
using Application.Books.Queries.GetBookById;
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
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public BooksController(IMediator mediator, ILogger<BooksController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("{id}", Name="GetBook")]
        public async Task<ActionResult<GetBookResponse>> GetBook(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{User.Identity.Name} is fetching book by Id - {id}");
            var query = new GetBookByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int?>> CreateBookForAuthor([FromBody]CreateBookRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateBookCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            if(result == null)
            {
                
            }
            return CreatedAtRoute("GetBook", new { id = result });
        }
    }
}
