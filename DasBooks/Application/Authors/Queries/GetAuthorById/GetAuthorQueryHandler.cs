using Application.Contracts.Response;
using AutoMapper;
using Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorResponse>
    {
        private readonly IAuthorsRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorQueryHandler(IAuthorsRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<GetAuthorResponse> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAuthorById(request.Id);
            return _mapper.Map<GetAuthorResponse>(author);
        }
    }
}
