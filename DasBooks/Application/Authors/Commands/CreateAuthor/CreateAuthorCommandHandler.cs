using Application.Contracts.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Authors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IAuthorsRepository authorsRepository, IMapper mapper)
        {
            _authorsRepository = authorsRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _mapper.Map<AuthorForCreation>(request.CreateAuthorRequest);
            return await _authorsRepository.CreateAuthor(author);
        }
    }
}
