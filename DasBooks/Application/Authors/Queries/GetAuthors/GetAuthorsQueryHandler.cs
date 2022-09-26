using Application.Contracts.Response;
using AutoMapper;
using Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Authors.Queries.GetAuthors
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, GetAuthorsResponse>
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IMapper _mapper;

        public GetAuthorsQueryHandler(IAuthorsRepository authorsRepository, IMapper mapper)
        {
            _authorsRepository = authorsRepository;
            _mapper = mapper;
        }

        public async Task<GetAuthorsResponse> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorsRepository.GetAuthors();
            return _mapper.Map<GetAuthorsResponse>(authors);
        }
    }
}
