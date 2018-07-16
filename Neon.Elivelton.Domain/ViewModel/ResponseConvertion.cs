using System;
using System.Collections.Generic;
using System.Text;

namespace Neon.Elivelton.Domain.ViewModel
{
    public class ResponseConvertion
    {
        public ResponseConvertion(decimal _value)
        {
            value = _value;
        }

        public decimal value { get; set; }
        public string valueFormatted2 { get { return value.ToString("N2"); } }
        public string valueFormatted3 { get { return value.ToString("N3"); } }
    }
}
