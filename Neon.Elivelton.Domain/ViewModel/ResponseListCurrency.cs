using System;
using System.Collections.Generic;
using System.Text;

namespace Neon.Elivelton.Domain.ViewModel
{
    public class ResponseListCurrency : DefaultResponseCurrency
    {
        public IDictionary<string, string> currencies { get; set; }
    }
}
