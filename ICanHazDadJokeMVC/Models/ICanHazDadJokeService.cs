using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace ICanHazDadJokeMVC.Models
{
    public class ICanHazDadJokeService
    {
        public ICanHazDadJokeService()
        {
            ICanHazDadJokeSettings = new ICanHazDadJokeSettings();
        }

        public ICanHazDadJokeSettings ICanHazDadJokeSettings { get; }

        /// <summary>
        /// Get random joke
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> RandomJoke()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ICanHazDadJokeSettings.BaseURL);
                client.DefaultRequestHeaders.Clear();
                foreach (var obj in ICanHazDadJokeSettings.ClientSettings)
                {
                    client.DefaultRequestHeaders.Add(obj.Key, obj.Value);
                }
                return await client.GetAsync(string.Empty);
            }
        }

        /// <summary>
        /// Search for jokes
        /// </summary>
        /// <param name="vSearchTerm"></param>
        /// <returns>Http response message</returns>
        public async Task<HttpResponseMessage> SearchJoke(string vSearchTerm, int vJokesLimit)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var obj in ICanHazDadJokeSettings.ClientSettings)
                {
                    client.DefaultRequestHeaders.Add(obj.Key, obj.Value);
                }
                UriBuilder builder = new UriBuilder(ICanHazDadJokeSettings.BaseURL + "/search");
                var query = HttpUtility.ParseQueryString(builder.Query);
                query.Add("term", vSearchTerm);
                query.Add("limit", vJokesLimit.ToString());
                builder.Query = query.ToString();
                string url = builder.ToString();

                return await client.GetAsync(url);
            }
        }
    }
}
