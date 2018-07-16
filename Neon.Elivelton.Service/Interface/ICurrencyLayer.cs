using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neon.Elivelton.Service.Interface
{
    public interface ICurrencyLayer
    {
        Task<string> liveCurrency();
        Task<string> listCurrency();
    }
}
