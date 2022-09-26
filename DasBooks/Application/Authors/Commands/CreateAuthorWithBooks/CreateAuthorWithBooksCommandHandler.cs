using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Authors;
using MediatR;

namespace Application.Authors.Commands.CreateAuthorWithBooks
{
    public class CreateAuthorWithBooksCommandHandler : IRequestHandler<CreateAuthorWithBooksCommand, CreateAuthorResponse>
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAuthorWithBooksCommandHandler(IAuthorsRepository authorsRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _authorsRepository = authorsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateAuthorResponse> Handle(CreateAuthorWithBooksCommand request, CancellationToken cancellationToken)
        {
            var author = _mapper.Map<AuthorForCreation>(request.CreateAuthorRequest);
            await _authorsRepository.CreateAuthor(author);
            //var a = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new CreateAuthorResponse();
        }
    }
}
