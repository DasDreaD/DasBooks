using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts.Request
{
    public sealed class CreateBookRequest
    {
        public string BookTitle { get; set; }
        public double BookPrice { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
