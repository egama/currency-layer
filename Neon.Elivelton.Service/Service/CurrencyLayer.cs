using Microsoft.Extensions.Configuration;
using Neon.Elivelton.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neon.Elivelton.Service
{
    public class CurrencyLayer : ICurrencyLayer
    {
        #region Global Variables
        
        private string _key { get; set; }
        private string _urlApiLayer { get; set; }
        
        #endregion

        private IConfiguration _configuration;
        public CurrencyLayer(IConfiguration configuration)
        {
            this._configuration = configuration;


            this._key = this._configuration.GetSection("AppSettings").GetSection("key").Value.ToString();
            this._urlApiLayer = this._configuration.GetSection("AppSettings").GetSection("urlApiLayer").Value.ToString();
        }

        public async Task<string> liveCurrency()
        {
            Helper helper = new Helper();
            return await helper.MethodGet(string.Format("{0}live?access_key={1}", this._urlApiLayer, this._key));
        }

        public async Task<string> listCurrency()
        {
            Helper helper = new Helper();
            return await helper.MethodGet(string.Format("{0}list?access_key={1}", this._urlApiLayer, this._key));
        }
    }
}
