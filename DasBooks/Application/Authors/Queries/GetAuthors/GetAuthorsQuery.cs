using Application.Contracts.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authors.Queries.GetAuthors
{
    public class GetAuthorsQuery : IRequest<GetAuthorsResponse>
    {
    }
}
