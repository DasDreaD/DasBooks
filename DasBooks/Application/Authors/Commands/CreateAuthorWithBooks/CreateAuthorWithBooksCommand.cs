using Application.Contracts.Request;
using Application.Contracts.Response;
using MediatR;

namespace Application.Authors.Commands.CreateAuthorWithBooks
{
    public class CreateAuthorWithBooksCommand : IRequest<CreateAuthorResponse>
    {
        public CreateAuthorWithBooksCommand(CreateAuthorRequest createAuthorRequest)
        {
            CreateAuthorRequest = createAuthorRequest;
        }

        public CreateAuthorRequest CreateAuthorRequest { get; }
    }
}
