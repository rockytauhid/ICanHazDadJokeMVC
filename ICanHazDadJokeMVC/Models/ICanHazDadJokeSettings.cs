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
    }
}
