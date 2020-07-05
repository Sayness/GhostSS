using GhostSS_Clean;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GhostSS.API
{
    class API
    {

        private static readonly HttpClient client = new HttpClient();
        private static string token = "";
        public static async Task<string> sendResult(Dictionary<string, string> values, string token)
        {
            var content = new FormUrlEncodedContent(values);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Add("token", token);
            var response = await client.PostAsync("http://d403cda933e2.ngrok.io/api/response", content);
            var responseString = await response.Content.ReadAsStringAsync();
            MessageBox.Show(responseString);
            return responseString;
           // TU MA PARLER ? 
        }

        //public static async Task<string> sendPin(Dictionary<string, string> values)
        //{
        //    var test = new Dictionary<string, string>
        //    {
        //        { "pin", Login.cassingText }
        //    };//fait le xd // XD il c'est fermé& instant vas y xd
        //    var content = new FormUrlEncodedContent(test);
        //    //client.DefaultRequestHeaders.Add("Authorization", token);
        //    // te suicide pas hein XDDDDD
        //    var response = await client.PostAsync("http://d403cda933e2.ngrok.io/api/pin", content);
        //    var responseString = "error API";
        //    if (response != null)
        //    {
        //        responseString = await response.Content.ReadAsStringAsync();

        //    }

        //    return responseString;
        //}
        public static async Task<string> sendPin(string values)
        {
            // fin comme ça
            //var content = new FormUrlEncodedContent(values);
            var httpContent = new StringContent(values, Encoding.UTF8, "application/xml");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            // te suicide pas hein XDDDDD
            var response = await client.PostAsync("http://d403cda933e2.ngrok.io/api/pin", httpContent);
            var responseString = "error API";
            if (response != null)
            {
                responseString = await response.Content.ReadAsStringAsync();

            }
            // ui tt 
            return responseString;
        }
    }
}
