using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DevWorkshops.Service.Model;

namespace DevWorkshops.Service
{
    public class BaseService
    {
        protected virtual string Host { get; }

        protected virtual string Scheme { get; }

        public async Task<GeneralResponse> GetAsync(Uri uri)
        {
            var result = new GeneralResponse();

            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpResponseMessage response = await http.GetAsync(uri);

                await FillResultData(response, result);
            }

            return result;
        }

        protected Uri BuildUri(string method) 
        {
            var ub = new UriBuilder();

            ub.Host = Host;
            ub.Scheme = Scheme;
            ub.Path = method;

            return ub.Uri;
        }

        private async Task FillResultData(
            HttpResponseMessage response,
            GeneralResponse result,
            HttpStatusCode expectedSuccessStatusCode = HttpStatusCode.OK)
        {
            result.StatusCode = response.StatusCode;
            result.IsSuccess = response.StatusCode == expectedSuccessStatusCode;

            string contentString = await response.Content.ReadAsStringAsync();
            result.ResponseContentString = contentString;
        }
    }
}
