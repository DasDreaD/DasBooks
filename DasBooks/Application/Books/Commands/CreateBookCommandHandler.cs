using Application.Contracts.Response;
using Domain.Abstractions;
using Domain.Books;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Books.Commands
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int?>
    {
        private readonly IBooksRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookCommandHandler(IBooksRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int?> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = BookForCreation.Create(request.Request.BookTitle, request.Request.BookPrice, request.Request.AuthorId, request.Request.CategoryId);
            await _bookRepository.CreateBook(book);
            //return await _unitOfWork.SaveChangesAsync(cancellationToken);
            return 0;
        }
    }
}
