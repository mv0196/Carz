using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.Common.Configuration
{
    public class JwtConfiguration
    {
        public string SigningKey { get; set; }
        public int ExpiryTimeInMinutes { get; set; }
    }
}
