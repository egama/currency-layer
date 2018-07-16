using Neon.Elivelton.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neon.Elivelton.Application.Interface
{
    public interface ICurrency
    {
        Task<DefaultResponseNeon> GetAllCurrencies();
        Task<DefaultResponseNeon> GetConvertion(string _from, string _to);
    }
}
