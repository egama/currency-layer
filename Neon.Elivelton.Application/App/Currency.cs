using Neon.Elivelton.Application.Interface;
using Neon.Elivelton.Domain.ViewModel;
using Neon.Elivelton.Service.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Neon.Elivelton.Application.App
{
    public class Currency : ICurrency
    {
        private ICurrencyLayer _currencyLayer;
        public Currency(ICurrencyLayer currencyLayer)
        {
            this._currencyLayer = currencyLayer;
        }

        public async Task<DefaultResponseNeon> GetAllCurrencies()
        {
            DefaultResponseNeon response = new DefaultResponseNeon();

            try
            {
                string responseList = await this._currencyLayer.listCurrency();
                var resp_list = JsonConvert.DeserializeObject<ResponseListCurrency>(responseList);
                if (resp_list.success)
                {
                    response.AddSuccess(resp_list.currencies);
                }
                else
                {
                    response.AddError(resp_list.error.info);
                }
            }
            catch (Exception e)
            {
                response.AddError(e.Message);
            }

            return response;
        }

        public async Task<DefaultResponseNeon> GetConvertion(string _from, string _to)
        {
            DefaultResponseNeon response = new DefaultResponseNeon();
            try
            {
                string responseLive = await this._currencyLayer.liveCurrency();
                ResponseLiveCurrency liveObj = JsonConvert.DeserializeObject<ResponseLiveCurrency>(responseLive);
                if (liveObj != null && liveObj.success)
                {
                    decimal valueCurrency1 = liveObj.quotes.Where(x => x.Key == ("USD" + _from)).Select(x => x.Value).FirstOrDefault();
                    decimal valueCurrency2 = liveObj.quotes.Where(x => x.Key == ("USD" + _to)).Select(x => x.Value).FirstOrDefault();

                    if (valueCurrency1 == 0 || valueCurrency2 == 0)
                        throw new Exception("Moeda origem e/ou destino não encontrada(s)");

                    decimal V_USD = 1 / valueCurrency1;
                    decimal V_CNV = V_USD * valueCurrency2;

                    ResponseConvertion value = new ResponseConvertion(V_CNV);
                    response.AddSuccess(value);
                }
                else
                    response.AddError(liveObj.error.info);
            }
            catch (Exception e) { response.AddError(e.Message); }

            return response;
        }
    }
}
