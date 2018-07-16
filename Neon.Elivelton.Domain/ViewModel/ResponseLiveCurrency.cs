using System;
using System.Collections.Generic;
using System.Text;

namespace Neon.Elivelton.Domain.ViewModel
{
    public class ResponseLiveCurrency : DefaultResponseCurrency
    {
        public string source { get; set; }
        public IDictionary<string, decimal> quotes { get; set; }
    }
}
