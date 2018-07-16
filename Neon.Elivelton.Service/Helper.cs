using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Neon.Elivelton.Service
{
    public class Helper
    {
        public async Task<string> MethodGet(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
