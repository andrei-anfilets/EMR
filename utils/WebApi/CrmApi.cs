using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace utils
{
   public class CrmApi
    {

        private async Task<CrmAuth> AuthorizeUser()
        {
            CrmAuth authInfo = await this.PostAction("auth", new StringContent("{  \"login\": \""+WebApiConfig.CRM_LOGIN+"\",  \"password\": \""+WebApiConfig.CRM_PASSWORD+"\"}", System.Text.Encoding.Default))
                .Content.ReadAsAsync<CrmAuth>();
            return authInfo;
        }

        /// <summary>
        /// Sending post request
        /// </summary>
        /// <param name="Uri">Action</param>
        /// <param name="content">form data</param>
        /// <returns></returns>
        private HttpResponseMessage PostAction(String Uri, StringContent content)
        {            
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("authorization", "Bearer "+WebApiConfig.BEARER_TOKEN+"");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                var response = httpClient.PostAsync(WebApiConfig.BASE_URL + Uri, content).Result;
                return response;                                
            }
        }

        /// <summary>
        /// Get action
        /// </summary>
        /// <param name="Uri">uri with parameters</param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> GetAction(String Uri)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "Bearer " + WebApiConfig.BEARER_TOKEN + ", User " + this.AuthorizeUser().Result.user_token);
                //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                using (var response = await httpClient.GetAsync(WebApiConfig.BASE_URL + Uri))
                {
                    return response;
                }
            }
        }

        public IEnumerable<EMR.DAL.Models.CrmPerson> GetPersons()
        {
            RootObject obj = new RootObject();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "Bearer " + WebApiConfig.BEARER_TOKEN + ", User " + this.AuthorizeUser().Result.user_token);
                //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                using (var response =  httpClient.GetAsync(WebApiConfig.BASE_URL + "clients/128637"))
                {
                    obj = response.Result.Content.ReadAsAsync<RootObject>().Result;
                }
            }
            
            return obj.data;
        }

    }
}
