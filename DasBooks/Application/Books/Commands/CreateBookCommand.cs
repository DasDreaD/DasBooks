using Application.Contracts.Request;
using Application.Contracts.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Books.Commands
{
    public class CreateBookCommand : IRequest<int?>
    {
        public CreateBookRequest Request { get; }

        public CreateBookCommand(CreateBookRequest request)
        {
            Request = request;
        }
    }
}
