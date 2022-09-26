﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts.Response
{
    public sealed class GetAuthorResponse
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string About { get; set; }
    }
}
