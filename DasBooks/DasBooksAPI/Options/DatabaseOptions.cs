using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DasBooksAPI.Options
{
    public class DatabaseOptions
    {
        public string ConnectionString { get; set; } = string.Empty;
        public int MaxRetryCount { get; set; }
        public int CommandTimeout { get; set; }
        public bool EnableSensitiveDataLogging { get; set; }
        public bool EnableDetailedError { get; set; }
    }
}
