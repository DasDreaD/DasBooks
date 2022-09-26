using Application.Contracts.Response;
using AutoMapper;
using Domain.Abstractions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Books.Queries.GetBookById
{
    public class GetBookQueryHandler : IRequestHandler<GetBookByIdQuery, GetBookResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBooksRepository _bookRepository;

        public GetBookQueryHandler(IMapper mapper, IBooksRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<GetBookResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookById(request.Id);
            return _mapper.Map<GetBookResponse>(book);
        }
    }
}
