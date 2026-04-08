using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeBE.Domain
{
    public class AuthData
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
