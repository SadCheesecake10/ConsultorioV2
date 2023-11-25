using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioV2
{
    internal class DIPOMEX_API
    {
        public async Task<string> GetCall(string url)
        {
            try 
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string APIurl = "https://api.tau.com.mx/dipomex/v1/" + url;

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(APIurl);
                    client.Timeout = TimeSpan.FromSeconds(30);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("APIKEY", "ca6fee26f6d263fa9b41b583a7e7d68c41fdc943");

                    var response = await client.GetAsync(APIurl);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
