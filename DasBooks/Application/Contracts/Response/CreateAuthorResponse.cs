using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts.Response
{
    public class CreateAuthorResponse
    {
        public int AuthorId { get; set; }
        public ICollection<int> BookIds { get; set; }
    }
}
