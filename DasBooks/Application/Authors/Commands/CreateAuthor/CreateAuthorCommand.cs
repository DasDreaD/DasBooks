using Application.Contracts.Request;
using Application.Contracts.Response;
using MediatR;

namespace Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public CreateAuthorCommand(CreateAuthorRequest createAuthorRequest)
        {
            CreateAuthorRequest = createAuthorRequest;
        }

        public CreateAuthorRequest CreateAuthorRequest { get; }
    }
}
