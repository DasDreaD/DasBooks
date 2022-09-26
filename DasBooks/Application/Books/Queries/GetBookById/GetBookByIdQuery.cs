using Application.Contracts.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<GetBookResponse>
    {
        public int Id { get; }

        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}
