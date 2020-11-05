using System.Collections.Generic;

namespace ICanHazDadJokeMVC.Models
{
    public class ICanHazDadJokeSettings
    {
        public Dictionary<string, string> ClientSettings;

        public ICanHazDadJokeSettings()
        {
            ClientSettings = new Dictionary<string, string>();
            ClientSettings.Add("Accept", "application/json");

            // ICanHazDadJoke API requested to include a custom User-Agent for usage tracking
            ClientSettings.Add("User-Agent", @"My Library (https://github.com/rockytauhid/icanhazdadjokemvc)");
        }

        /// <summary>
        /// ICanHazDadJoke API URL
        /// </summary>
        public string BaseURL { get; } = @"https://icanhazdadjoke.com";

        ///// <summary>
        ///// Short joke which is less 10 words (requirement)
        ///// </summary>
        //public int ShortJokeLimit { get; } = 10;

        ///// <summary>
        ///// Medium joke which is less 20 words (requirement)
        ///// </summary>
        //public int MediumJokeLimit { get; } = 20;

        /// <summary>
        /// Maximum number of jokes retrieved set to 30 (requirement)
        /// </summary>
        public string JokesRetrievedLimit { get; } = @"30";

        //public string SearchTerm { get; set; }
    }
}
