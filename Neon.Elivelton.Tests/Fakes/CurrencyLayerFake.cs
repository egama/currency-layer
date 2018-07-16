using Neon.Elivelton.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neon.Elivelton.Tests.Fakes
{
    public class CurrencyLayerFake : ICurrencyLayer
    {
        private string _jsonResult { get; set; }
        public CurrencyLayerFake(string JsonResult)
        {
            this._jsonResult = JsonResult;
        }

        public Task<string> listCurrency()
        {
            return returnJson();
        }

        public Task<string> liveCurrency()
        {
            return returnJson();
        }

        private Task<string> returnJson()
        {
            return Task<string>.Factory.StartNew(() =>
            {
                return this._jsonResult;
            });
        }
    }
}
