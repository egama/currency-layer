using System;
using System.Collections.Generic;
using System.Text;

namespace Neon.Elivelton.Domain.ViewModel
{
    public class DefaultResponseCurrency
    {
        public bool success { get; set; }
        public string terms { get; set; }
        public string privacy { get; set; }
        public DefaultErrorResponseCurrency error { get; set; }
    }

    public class DefaultErrorResponseCurrency
    {
        public int code { get; set; }
        public string info { get; set; }
    }
}
