using Application.Contracts.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<GetAuthorResponse>
    {
        public int Id { get; }

        public GetAuthorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
