using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApiBasicAuthentication.Models;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebAPIBasicAuthentication.Controllers
{
    public  class PartNumberPassThruController : ApiController
    {
        /*
        // Option #1 - Deseralize the JSON result into an object, then return as IHttpActionResult
        public async Task<IHttpActionResult> GetPartNumbers()
        {
            HttpResponseMessage response = null;
            string apiKey = "7f5645122a634577a53dca81359138b6";
            string apiSecret = "3186b763ddb4405bbf0b0d0eac5892cf";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Request.RequestUri.GetLeftPart(UriPartial.Authority));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                        "Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", apiKey, apiSecret)))
                        );

                response = await client.GetAsync("api/PartNumbers");

                if (response.IsSuccessStatusCode)
                {
                    PartNumber[] data = JsonConvert.DeserializeObject<PartNumber[]>(response.Content.ReadAsStringAsync().Result);

                    return Ok(data);
                }
            }

            return NotFound();

        }

        */

        // Option #2 - Deseralize the JSON result into an object, then return as IQueryable<PartNumber>
        /*
        public async Task<IQueryable<PartNumber>> GetPartNumbers()
        {
            HttpResponseMessage response = null;
            string apiKey = "7f5645122a634577a53dca81359138b6";
            string apiSecret = "3186b763ddb4405bbf0b0d0eac5892cf";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Request.RequestUri.GetLeftPart(UriPartial.Authority));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                        "Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", apiKey, apiSecret)))
                        );

                response = await client.GetAsync("api/PartNumbers");

                if (response.IsSuccessStatusCode)
                {
                    PartNumber[] data = JsonConvert.DeserializeObject<PartNumber[]>(response.Content.ReadAsStringAsync().Result);

                    IQueryable<PartNumber> partNumbers = data.AsQueryable();

                    return partNumbers;
                }
            }

            return null;

        }
        */

        ///*
        //Option #3 - Pass the Response object directly thru to the client
        public async Task<HttpResponseMessage> GetPartNumbers()
        {
  
            HttpResponseMessage response = null;
            string json = "";
            string apiKey = "7f5645122a634577a53dca81359138b6";
            string apiSecret = "3186b763ddb4405bbf0b0d0eac5892cf";

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Request.RequestUri.GetLeftPart(UriPartial.Authority));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                        "Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", apiKey, apiSecret)))
                        );

                response = await client.GetAsync("api/PartNumbers");

        
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
            }


            return Request.CreateResponse(HttpStatusCode.NotFound);

        }
        //*/


    }
}
