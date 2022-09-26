using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts.Response
{
    public sealed class GetBookResponse
    {
        public string BookTitle { get; set; }
        public double BookPrice { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
    }
}
