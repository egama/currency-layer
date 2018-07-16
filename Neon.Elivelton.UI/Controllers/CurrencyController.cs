
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using Neon.Elivelton.Application.Interface;

namespace Neon.Elivelton.UI.Controllers
{
    [Route("api/[controller]")]
    public class CurrencyController : Controller
    {
        private readonly ICurrency _currency;

        public CurrencyController(ICurrency currency)
        {
            this._currency = currency;
        }


        /// <summary>
        /// Lista todas moedas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var conv = await this._currency.GetAllCurrencies();
            if (conv.success)
                return Ok(conv);
            else
                return NotFound(conv);
        }
    
        /// <summary>
        /// Converte as moedas 
        /// </summary>
        /// <param name="from">De</param>
        /// <param name="to">Para</param>
        /// <returns></returns>
        [Route("{from}/{to}")]
        [HttpGet]
        public async Task<IActionResult> Get(string from, string to)
        {
            var conv = await this._currency.GetConvertion(from, to);
            if (conv.success)
                return Ok(conv);
            else
                return NotFound(conv);
        }
        
    }
}
