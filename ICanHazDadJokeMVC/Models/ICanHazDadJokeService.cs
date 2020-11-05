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

        public void InitializeClient(HttpClient client)
        {
            foreach (var obj in ICanHazDadJokeSettings.ClientSettings)
            {
                client.DefaultRequestHeaders.Add(obj.Key, obj.Value);
            }
        }

        public async Task<ICanHazDadJokeModel> RandomJoke()
        {
            ICanHazDadJokeModel model = new ICanHazDadJokeModel();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(ICanHazDadJokeSettings.BaseURL);

                client.DefaultRequestHeaders.Clear();
                //Define request data format
                foreach (var obj in ICanHazDadJokeSettings.ClientSettings)
                {
                    client.DefaultRequestHeaders.Add(obj.Key, obj.Value);
                }

                //Sending request to find web api REST service resource using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(string.Empty);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the model
                    model = JsonConvert.DeserializeObject<ICanHazDadJokeModel>(response);
                }
            }
            return model;
        }

        public async Task<ICanHazDadJokeListModel> SearchJoke(string vSearchTerm)
        {
            ICanHazDadJokeListModel models = new ICanHazDadJokeListModel();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                foreach (var obj in ICanHazDadJokeSettings.ClientSettings)
                {
                    client.DefaultRequestHeaders.Add(obj.Key, obj.Value);
                }

                //Passing service url
                var builder = new UriBuilder(ICanHazDadJokeSettings.BaseURL + "/search");
                var query = HttpUtility.ParseQueryString(builder.Query);
                query.Add("term", vSearchTerm);
                query.Add("limit", ICanHazDadJokeSettings.JokesRetrievedLimit);
                builder.Query = query.ToString();
                string url = builder.ToString();

                //Sending request to find web api REST service resource using HttpClient
                HttpResponseMessage Res = await client.GetAsync(url);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the model
                    models = JsonConvert.DeserializeObject<ICanHazDadJokeListModel>(response);
                }
            }
            return models;
        }

        //private void GroupByLength(ICanHazDadJokeListModel vModelList)
        //{
        //    IList<ICanHazDadJokeModel> shortJokes = new List<ICanHazDadJokeModel>();
        //    IList<ICanHazDadJokeModel> mediumJokes = new List<ICanHazDadJokeModel>();
        //    IList<ICanHazDadJokeModel> longJokes = new List<ICanHazDadJokeModel>();

        //    foreach (ICanHazDadJokeModel model in vModelList.Results)
        //    {
        //        int wordCount = WordCount(model.Joke);

        //        if (wordCount < ICanHazDadJokeSettings.ShortJokeLimit)
        //        {
        //            shortJokes.Add(model);
        //        }
        //        else if (wordCount > ICanHazDadJokeSettings.ShortJokeLimit && wordCount < ICanHazDadJokeSettings.MediumJokeLimit)
        //        {
        //            mediumJokes.Add(model);
        //        }
        //        else
        //        {
        //            longJokes.Add(model);
        //        }
        //    }
        //}

        //private int WordCount(string vJokes)
        //{
        //    int result = 1;
        //    foreach (char i in vJokes)
        //    {
        //        foreach (char j in vJokes)
        //        {
        //            if (char.IsWhiteSpace(i))
        //                result++;
        //        }
        //    }
        //    return result;
        //}
    }
}
